/*
 <----------------------------------------------->
   |  Description    |   Vererbung Aufgabe      |
   |  Created by     |   @Florian Manhartseder  |
   |  Creation date  |   12.12.2023             |
 <----------------------------------------------->
 */


using System;

namespace Vererbung
{
    internal class Cell
    {
        private string chemistry;
        private double nominalVoltage;
        private double maxVoltage;
        private double watthours;
        private string size;
        private string supplier;
        private string model;
        private double cutoffVoltage;

        public Cell(string chemistry, string supplier, string model, double maxVoltage, double watthours, double nominalVoltage)
        {
            this.chemistry = chemistry;
            this.supplier = supplier;
            this.model = model;
            this.maxVoltage = maxVoltage;
            this.watthours = watthours;
            this.nominalVoltage = nominalVoltage;
        }

        public double getNominalVoltage() { return nominalVoltage; }
        public double getMaxVoltage() { return maxVoltage; }
        public double getWatthours() { return watthours; }
        public double getCutoffVoltage() { return cutoffVoltage; }
    }

    internal class Battery
    {
        private Cell cell;
        private double packNominalVoltage;
        private double packMaxVoltage;
        private string packSize;
        private string packSupplier;
        private double packMaxContOutPower;
        private double packPeakOutPower;
        private double packWatthours;
        private double packCutoffVoltage;
        private int nSerial;
        private int nParallel;

        public Battery(Cell usedCells, int nSerial, int nParallel, double maxContOutPower, double maxPeakPower, string supplier) : base()
        {
            this.cell = usedCells;
            this.nSerial = nSerial;
            this.nParallel = nParallel;
            this.packMaxContOutPower = maxContOutPower;
            this.packPeakOutPower = maxPeakPower;
            this.packSupplier = supplier;
        }

        public void calcAllValues()
        {
            try
            {
                calcNominalVoltage();
                calcPackMaxVoltage();
                calcWatthours();
                calcCutoffVoltage();
            }
            catch
            {
                Console.WriteLine("Error");
            }
        }

        public void calcNominalVoltage()
        {
            this.packNominalVoltage = this.nSerial * this.cell.getNominalVoltage();
        }

        public void calcPackMaxVoltage()
        {
            this.packMaxVoltage = this.nSerial * this.cell.getMaxVoltage();
        }

        public void calcWatthours()
        {
            this.packWatthours = this.cell.getWatthours() * nSerial * nParallel;
        }

        public void calcCutoffVoltage()
        {
            this.packCutoffVoltage = this.cell.getCutoffVoltage() * nSerial * nParallel;
        }
    }

    internal class Vehicle
    {
        private string marke;
        private int verbrauch100Km;
        private string antrieb;
        private int gefahreneKm;
        private int baujahr;
        private string color;
        private int maxGeschwindigkeit;
        private int leistung;

        public Vehicle(string marke, string antrieb, int baujahr, int maxGeschwindigkeit)
        {
            this.marke = marke;
            this.antrieb = antrieb;
            this.baujahr = baujahr;
            this.maxGeschwindigkeit = maxGeschwindigkeit;
        }

        public int getBaujahr() { return baujahr; }

        public void changeColor(string newColor)
        {
            this.color = newColor;
        }

        public void setLeistung(int leistungKW)
        {
            this.leistung = leistungKW;
        }

        public int getLeistung() { return leistung; }

    }

    internal class Motorrad : Vehicle
    {
        private string serviceFaellig;
        private bool scheibenBremsen;
        private bool gitterrohrrahmen;
        private bool vierTakt;

        public Motorrad(bool hatScheibenbremsen, bool hatGitterrohrrahmen, bool istViertakt, string marke, string antrieb, int baujahr, int maxV) : base(marke, antrieb, baujahr, maxV)
        {
            this.scheibenBremsen = hatScheibenbremsen;
            this.gitterrohrrahmen = hatGitterrohrrahmen;
            this.vierTakt = istViertakt;
        }

        public void setServiceFaelligDate(string serviceDate)
        {
            this.serviceFaellig = serviceDate;
        }
    }

    internal class ELongboard : Vehicle
    {
        private Battery boardBattery;
        private string deckMaterial;
        private string deckLayers;
        private string bereifung;
        private int motorLeistungKW;
        private int systemleistungSteuerung;
        private int nutzbareGesamtleistung;

        public ELongboard(string deckMaterial, string deckLayers, string bereifung, int motorLeistungKW, int nutzbareGesamtleistung, string marke, int baujahr, int maxV, string antrieb = "Elektro", Battery battery = null) : base(marke, antrieb, baujahr, maxV)
        {
            this.boardBattery = battery;
            this.deckMaterial = deckMaterial;
            this.deckLayers = deckLayers;
            this.bereifung = bereifung;
            this.motorLeistungKW = motorLeistungKW;
            this.nutzbareGesamtleistung = nutzbareGesamtleistung;
        }

        public void changeReifensatz(string newReifen)
        {
            Console.WriteLine("Reifensatz von " + this.bereifung + " auf " + newReifen + " gewechselt.");
            this.bereifung = newReifen;
        }

        public int getMotorLeistungKW() { return this.motorLeistungKW; }

        public void setBatteryPack(Battery battery)
        {
            this.boardBattery = battery;
        }

    }

    internal class Auto : Vehicle
    {
        private string oelwechselFaellig;
        private bool winterreifen;
        private int anzahlTueren;

        public Auto(int anzahlTueren, bool hatWinterreifen, string oelWechselFaellig, string marke, string antrieb, int baujahr, int maxV) : base(marke, antrieb, baujahr, maxV)
        {
            this.anzahlTueren = anzahlTueren;
            this.winterreifen = hatWinterreifen;
            this.oelwechselFaellig = oelWechselFaellig;
        }

        public void changeToWinterreifen()
        {
            this.winterreifen = true;
        }

        public void changeToSommerreifen()
        {
            this.winterreifen = false;
        }

        public void setOelwechselFaellig(string oelwechselDate)
        {
            this.oelwechselFaellig = oelwechselDate;
        }

        static void Main(string[] args)
        {
            Cell myCell = new Cell("Li-Ion", "LG", "T4", 4.2, 16.8, 3.7);
            Battery myBattery = new Battery(myCell, 10, 3, 3500, 4500, "Evolve");
            myBattery.calcAllValues();

            // Vehicle myVehicle = new Vehicle("Evolve", "Elektro", 2020, 65);
            // myVehicle.changeColor("Black");

            ELongboard myBoard = new ELongboard("Carbon fibre", "5 Layers", "Cloudwheels", 8, 4500, "Evolve", 2020, 65, "Electric", myBattery);

            myBoard.changeReifensatz("all terain");
            myBoard.setLeistung(4000);
            myBoard.setBatteryPack(myBattery);

            // Cast myVehicle to a ELongboard object
            // ELongboard myBoard = (ELongboard)myVehicle;

            Auto myCar = new Auto(5, true, "20.04.2024", "Toyota", "Benzin", 2017, 230);
            myCar.changeColor("Anthranzit");

            Console.ReadLine();

        }
    }
}
