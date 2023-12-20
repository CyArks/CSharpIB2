using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

/**\mainpage
 * Ein Projekt von Florian Manhartseder\n
 * Dieses Projekt implementiert eine Simulation verschiedener Tiere im Zoo-Kontext,
 * einschließlich ihrer Verhaltensweisen und Eigenschaften.
 */

/**\namespace
 * Namespace Zoo, in welchem sich alle implementierten Klassen befinden.
 * Beinhaltet Klassen und Interfaces zur Darstellung von Zoo-Tieren und deren Verhalten.
 */
namespace Zoo
{
    /**\interface ITauchzeit
     * Interface für Wassertiere
     */
    interface ITauchzeit
    {
        void setTauchzeit(int tauchzeit);
        int getTauchzeit();
    }

    /**\interface IGeschwindigkeit
     * Interface für Landtiere
     */
    interface IGeschwindigkeit
    {
        void setGeschwindigkeit(int geschwindigkeit); ///< Setzt die Geschwindigkeit des Tieres.
        int getGeschwindigkeit(); ///< Gibt die Geschwindigkeit des Tieres zurück.
    }


    /**\class Program
     * Hauptklasse des Programms, beinhaltet die Main-Methode und die Definition von Tierarten.
     */
    internal class Program
    {
        private static List<Tier> tiere = new List<Tier>();

        /**\class Tier
         * Basis-Klasse für alle Tiere im Zoo.
         */
        public class Tier
        {

            private string name; ///< Name des Tieres.
            private int gewicht; ///< Gewicht des Tieres.
            private int alter; ///< Alter des Tieres.

            /**\brief
             * Standardkonstruktor für die Klasse Tier.
             */
            public Tier() { }

            /**\brief
             * Konstruktor für die Klasse Tier.
             * @param name Name des Tieres.
             * @param gewicht Gewicht des Tieres.
             * @param alter Alter des Tieres.
             */
            public Tier(string name, int gewicht, int alter)
            {
                this.name = name;
                this.gewicht = gewicht;
                this.alter = alter;
            }

            /**\fn
             * Diese Funktion erlaubt es den Namen eines Tieres zu ändern
             * @return void
             */
            public void nameAendern(string name)
            {
                this.name = name;
            }

            /**\fn
             * Diese Funktion dient zum Updaten des alters
             * @return void
             */
            public void updateAlter(int alter)
            {
                this.alter = alter;
            }

            /**\fn
             * Diese Funktion erlaub dem Tier sich zu bewegen
             * @return void
             */
            public virtual void bewegen()
            {
                Console.WriteLine("Das Tier bewegt sich...");
            }

            /**\fn
             * Diese Funktion implementiert das Verhalten wenn das Tier schläft
             * @return void
             */
            public virtual void schlafen()
            {
                Console.WriteLine("Das Tier schläft...");
            }

            /**\fn
             * Diese Funktion implementiert das Verhalten wenn das Tier isst
             * @return void
             */
            public virtual void essen()
            {
                Console.WriteLine("Das Tier isst!");
            }

            /**\fn
            * Implementiert die Ausgabe eines Steckbriefes
            * @return void
            */
            public virtual void SteckbriefAusgeben()
            {
                Console.WriteLine("Name: " + name);
                Console.WriteLine("Gewicht: " + gewicht);
                Console.WriteLine("Alter: " + alter);
            }
        }


        /**\class Wassertier
         * Klasse für alle Wassertiere im Zoo.
         */
        public class Wassertier : Tier, ITauchzeit 
        {
            private int tauchzeit; ///< Tauchzeit des Wassertiers.

            /**\brief
             * Konstruktor für die Klasse Wassertier.
             * @param name Name des Tieres.
             * @param gewicht Gewicht des Tieres.
             * @param alter Alter des Tieres.
             */
            public Wassertier(string name, int gewicht, int alter) : base(name, gewicht, alter)
            {

            }

            /**\fn
             * Diese Funktion setzt die Tauchzeit des Wassertiers
             * @return void
             */
            public void setTauchzeit(int tauchzeit)
            {
                this.tauchzeit = tauchzeit;
            }

            /**\fn
             * Diese Funktion gib die Tauchzeit des Wassertiers zurück
             * @return int tauchzeit
             */
            public int getTauchzeit() { return this.tauchzeit; }

            /**\fn
             * Diese Funktion implementiert das Verhalten wenn das Wassertier schwimmt
             * @return void
             */
            public override void bewegen()
            {
                Console.WriteLine("Das Wassertier schwimmt...");
            }

            /**\fn
             * Diese Funktion implementiert das Verhalten wenn das Wassertier schläft
             * @return void
             */
            public override void schlafen()
            {
                Console.WriteLine("Das Wassertier schläft...");
            }

            /**\fn
             * Diese Funktion implementiert das Verhalten wenn das Wassertier isst
             * @return void
             */
            public override void essen()
            {
                Console.WriteLine("Das Wassertier isst...");
            }

            /**\fn
            * Implementiert die Ausgabe eines Steckbriefes
            * @return void
            */
            public override void SteckbriefAusgeben()
            {
                Console.WriteLine("Klasse: " + typeof(Wassertier));
                Console.WriteLine("Tauchzeit: " + tauchzeit);
                base.SteckbriefAusgeben();
            }
        }


        /**\class Landtier
         * Klasse für alle Landtiere im Zoo.
         */
        public class Landtier : Tier, IGeschwindigkeit 
        {
            private int geschwindigkeit; ///< Geschwindigkeit des Tieres

            /**\brief
             * Konstruktor für die Klasse Wassertier.
             * @param name Name des Tieres.
             * @param gewicht Gewicht des Tieres.
             * @param alter Alter des Tieres.
             * @param geschwindigkeit Geschwindigkeit des Tieres
             */
            public Landtier(string name, int gewicht, int alter, int geschwindigkeit) : base(name, gewicht, alter)
            { 
                this.geschwindigkeit = geschwindigkeit;
            }

            /**\fn
             * Diese Funktion setzt die Geschwidigkeit des Landtieres
             * @return void
             */
            public void setGeschwindigkeit(int geschwindigkeit)
            {
                this.geschwindigkeit = geschwindigkeit;
            }

            /**\fn
             * Diese Funktion gibt die Geschwindigkeit des Landtieres zurück
             * @return int geschwindigkeit
             */
            public int getGeschwindigkeit()
            {
                return this.geschwindigkeit;
            }

            /**\fn
             * Diese Funktion implementiert das Verhalten wenn sich das Landtier bewegt
             * @return void
             */
            public override void bewegen()
            {
                Console.WriteLine("Das Landtier bewegt sich...");
            }

            /**\fn
             * Diese Funktion implementiert das Verhalten wenn das Landtier isst
             * @return void
             */
            public override void essen()
            {
                Console.WriteLine("Das Landtier isst...");
            }

            /**\fn
             * Diese Funktion implementiert das Verhalten wenn das Landtier schläft
             * @return void
             */
            public override void schlafen()
            {
                Console.WriteLine("Das Landtier schläft...");
            }

            /**\fn
            * Implementiert die Ausgabe eines Steckbriefes
            * @return void
            */
            public override void SteckbriefAusgeben()
            {
                Console.WriteLine("Klasse: " + typeof(Landtier));
                Console.WriteLine("Geschwindigkeit: " + geschwindigkeit);
                base.SteckbriefAusgeben();
            }
        }


        /**\class Wal
         * Subklasse der Klasse Wassertier, implementiert das Verhalten und die Attribute eines Wals.
         */
        public class Wal : Wassertier 
        {
            private string gattung; ///< Gattung des Wals

            /**\brief
            * Konstruktor für die Wal-Klasse.
            * Initialisiert einen Wal mit Namen, Gewicht, Alter und Gattung.
            * @param name Name des Wals.
            * @param gewicht Gewicht des Wals.
            * @param alter Alter des Wals.
            * @param gattung Gattung des Wals.
            */
            public Wal(string name, int gewicht, int alter, string gattung, int tauchzeit) : base(name, gewicht, alter)
            {
                this.gattung = gattung;
                base.setTauchzeit(tauchzeit);
            }

            /**\fn
             * Implementiert das Schwimmverhalten des Wals.
             * Überschreibt die bewegen-Methode der Basisklasse Wassertier.
             * @return void
             */
            public override void bewegen()
            {
                Console.WriteLine("Der Wal schwimmt...");
            }

            /**\fn
             * Implementiert das Essverhalten des Wals.
             * Überschreibt die essen-Methode der Basisklasse Wassertier.
             * @return void
             */
            public override void essen()
            {
                Console.WriteLine("Der Wal isst...");
            }

            /**\fn
             * Implementiert das Schlafverhalten des Wals.
             * Überschreibt die schlafen-Methode der Basisklasse Wassertier.
             * @return void
             */
            public override void schlafen()
            {
                Console.WriteLine("Der Wal schläft...");
            }

            /**\fn
            * Implementiert die Ausgabe eines Steckbriefes
            * @return void
            */
            public override void SteckbriefAusgeben()
            {
                Console.WriteLine("Klasse: " + typeof(Wal));
                Console.WriteLine("Gattung: " + gattung);
                base.SteckbriefAusgeben();
            }
        }


        /**\class Delfin
         * Subklasse der Klasse Wassertier, implementiert das Verhalten und die Attribute eines Delfins.
         * Erbt von Wassertier und fügt spezifische Eigenschaften und Verhaltensweisen eines Delfins hinzu.
         */
        public class Delfin : Wassertier 
        {
            private string art; ///< Art des Delfins.

            /**\brief
            * Konstruktor für die Delfin-Klasse.
            * Initialisiert einen Delfin mit Namen, Gewicht, Alter und Art.
            * @param name Name des Delfins.
            * @param gewicht Gewicht des Delfins.
            * @param alter Alter des Delfins.
            * @param art Art des Delfins.
            */
            public Delfin(string name, int gewicht, int alter, string art) : base(name, gewicht, alter)
            {
                this.art = art;
            }

            /**\fn
             * Implementiert das Schwimmverhalten des Delfins.
             * Überschreibt die bewegen-Methode der Basisklasse Wassertier.
             * @return void
             */
            public override void bewegen()
            {
                Console.WriteLine("Der Delfin schwimmt...");
            }

            /**\fn
             * Implementiert das Essverhalten des Delfins.
             * Überschreibt die essen-Methode der Basisklasse Wassertier.
             * @return void
             */
            public override void essen()
            {
                Console.WriteLine("Der Delfin isst...");
            }

            /**\fn
             * Implementiert das Schlafverhalten des Delfins.
             * Überschreibt die schlafen-Methode der Basisklasse Wassertier.
             * @return void
             */
            public override void schlafen()
            {
                Console.WriteLine("Der Delfin schläft...");
            }

            /**\fn
            * Implementiert die Ausgabe eines Steckbriefes
            * @return void
            */
            public override void SteckbriefAusgeben()
            {
                Console.WriteLine("Klasse: " + typeof(Delfin));
                Console.WriteLine("Art: " + art);
                base.SteckbriefAusgeben();
            }
        }


        /**\class Elefant
        * Subklasse der Klasse Landtier, implementiert das Verhalten und die Attribute eines Elefanten.
        * Erbt von Landtier und fügt spezifische Eigenschaften und Verhaltensweisen eines Elefanten hinzu.
        */
        public class Elefant : Landtier
        {
            private string lieblingsFutter; ///< Lieblingsfutter des Elefanten.

            /**\brief
             * Konstruktor für die Elefant-Klasse.
             * Initialisiert einen Elefanten mit Namen, Gewicht, Alter, Geschwindigkeit und Lieblingsfutter.
             * @param name Name des Elefanten.
             * @param gewicht Gewicht des Elefanten.
             * @param alter Alter des Elefanten.
             * @param geschwindigkeit Geschwindigkeit des Elefanten.
             * @param lieblingsFutter Lieblingsfutter des Elefanten.
             */
            public Elefant(string name, int gewicht, int alter, int geschwindigkeit, string lieblingsFutter) : base(name, gewicht, alter, geschwindigkeit)
            {
                this.lieblingsFutter = lieblingsFutter;
            }

            /**\fn
             * Implementiert das Bewegungsverhalten des Elefanten.
             * Überschreibt die bewegen-Methode der Basisklasse Tier.
             * @return void
             */
            public override void bewegen()
            {
                Console.WriteLine("Der Elefant geht...");
            }

            /**\fn
             * Implementiert das Essverhalten des Elefanten.
             * Überschreibt die essen-Methode der Basisklasse Tier.
             * @return void
             */
            public override void essen()
            {
                Console.WriteLine("Der Elefant isst...");
            }

            /**\fn
             * Implementiert das Schlafverhalten des Elefanten.
             * Überschreibt die schlafen-Methode der Basisklasse Tier.
             * @return void
             */
            public override void schlafen()
            {
                Console.WriteLine("Der Elefant schläft...");
            }

            /**\fn
            * Implementiert die Ausgabe eines Steckbriefes
            * @return void
            */
            public override void SteckbriefAusgeben()
            {
                Console.WriteLine("Klasse: " + typeof(Elefant));
                Console.WriteLine("Lieblingsfutter: " + lieblingsFutter);
                base.SteckbriefAusgeben();
            }
        }


        /**\class Nashorn
        * Subklasse der Klasse Landtier, implementiert das Verhalten und die Attribute eines Nashorns.
        * Erbt von Landtier und fügt spezifische Eigenschaften und Verhaltensweisen eines Nashorns hinzu.
        */
        public class  Nashorn : Landtier 
        {
            private int hornLaenge; ///< Gibt die Hornlänge des Nashorns an

            /**\brief
            * Konstruktor für die Nashorn-Klasse.
            * Initialisiert ein Nashorn mit Namen, Gewicht, Alter, Geschwindigkeit und Hornlänge.
            * @param name Name des Nashorns.
            * @param gewicht Gewicht des Nashorns.
            * @param alter Alter des Nashorns.
            * @param geschwindigkeit Geschwindigkeit des Nashorns.
            * @param hornLaenge Länge des Horns des Nashorns.
            */
            public Nashorn(string name, int gewicht, int alter, int geschwindigkeit, int hornLaenge) : base(name, gewicht, alter, geschwindigkeit)
            {
                this.hornLaenge = hornLaenge;
            }

            /**\fn
            * Implementiert das Bewegungsverhalten des Nashorns.
            * Überschreibt die bewegen-Methode der Basisklasse Tier.
            * @return void
            */
            public override void bewegen()
            {
                Console.WriteLine("Das Nashorn geht...");
            }

            /**\fn
            * Implementiert das Essverhalten des Nashorns.
            * Überschreibt die essen-Methode der Basisklasse Tier.
            * @return void
            */
            public override void essen()
            {
                Console.WriteLine("Das Nashorn isst...");
            }

            /**\fn
            * Implementiert das Schlafverhalten des Nashorns.
            * Überschreibt die schlafen-Methode der Basisklasse Tier.
            * @return void
            */
            public override void schlafen()
            {
                Console.WriteLine("Das Nashorn schläft...");
            }

            /**\fn
            * Implementiert die Ausgabe eines Steckbriefes
            * @return void
            */
            public override void SteckbriefAusgeben()
            {
                Console.WriteLine("Klasse: " + typeof(Nashorn));
                Console.WriteLine("Hornlänge: " + hornLaenge);
                base.SteckbriefAusgeben();
            }
        }


        /**\brief
         * Hauptmethode des Programms.
         * Erstellt Instanzen von Tieren und demonstriert deren Verhalten.
         */
        static void Main(string[] args)
        {
            /**\brief
             * Dieses Programm erstellt Instanzen der implementierten Klassen
             * @author Florian Manhartseder
             * @date 19.12.2023
             * @file Program.cs
             * @code cs
             **/

            /**\fn
            * Implementiert die Ausgabe eines erweiterten Menüs
            * @return int
            */
            int ErweitertesMenuAnzeigen()
            {
                Console.WriteLine("\n\n-------------- Spezifisches Menü --------------");
                Console.WriteLine(" 1. Instanz von Wal erstellen");
                Console.WriteLine(" 2. Instanz von Delfin erstellen");
                Console.WriteLine(" 3. Instanz von Elefant erstellen");
                Console.WriteLine(" 4. Instanz von Nashorn erstellen");
                Console.WriteLine(" 5. Eingabe beenden und Steckbriefe ausgeben");
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("\n");

                Console.WriteLine("Wählen Sie eine Option aus: ");
                return Convert.ToInt32(Console.ReadLine());
            }

            /**\fn
            * Implementiert die Ausgabe eines allgemeinen Menüs
            * @return int
            */
            int MenuAnzeigen()
            {
                Console.WriteLine("\n\n--------------- Allgemeines Menü ---------------");
                Console.WriteLine(" 1. Instanz von Landtier erstellen");
                Console.WriteLine(" 2. Instanz von Wassertier erstellen");
                Console.WriteLine(" 3. Erweitertes Menü anzeigen");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("\n");

                Console.WriteLine("Wählen Sie eine Option aus: ");
                return Convert.ToInt32(Console.ReadLine());
            }

            Wal ErstelleWal()
            {
                Console.Write("Name des Wals: ");
                string name = Console.ReadLine();
                Console.Write("Gewicht des Wals: ");
                int gewicht = Convert.ToInt32(Console.ReadLine());
                Console.Write("Alter des Wals: ");
                int alter = Convert.ToInt32(Console.ReadLine());
                Console.Write("Gattung des Wals: ");
                string gattung = Console.ReadLine();
                Console.Write("Tauchzeit des Wals: ");
                int tauchzeit = Convert.ToInt32(Console.ReadLine());

                Wal wal = new Wal(name, gewicht, alter, gattung, tauchzeit);
                wal.schlafen();
                wal.bewegen();
                wal.essen();
                Console.WriteLine("Wal erstellt: " + name);
                return wal;
            }

            Elefant ErstelleElefant()
            {
                Console.Write("Name des Elefanten: ");
                string name = Console.ReadLine();
                Console.Write("Gewicht des Elefanten: ");
                int gewicht = Convert.ToInt32(Console.ReadLine());
                Console.Write("Alter des Elefanten: ");
                int alter = Convert.ToInt32(Console.ReadLine());
                Console.Write("Geschwindigkeit des Elefanten: ");
                int geschwindigkeit = Convert.ToInt32(Console.ReadLine());
                Console.Write("Lieblingsfutter des Elefanten: ");
                string lieblingsFutter = Console.ReadLine();

                Elefant elefant = new Elefant(name, gewicht, alter, geschwindigkeit, lieblingsFutter);
                elefant.schlafen();
                elefant.bewegen();
                elefant.essen();
                Console.WriteLine("Elefant erstellt: " + name);
                return elefant;
            }

            Nashorn ErstelleNashorn()
            {
                Console.Write("Name des Nashorns: ");
                string name = Console.ReadLine();
                Console.Write("Gewicht des Nashorns: ");
                int gewicht = Convert.ToInt32(Console.ReadLine());
                Console.Write("Alter des Nashorns: ");
                int alter = Convert.ToInt32(Console.ReadLine());
                Console.Write("Geschwindigkeit des Nashorns: ");
                int geschwindigkeit = Convert.ToInt32(Console.ReadLine());
                Console.Write("Hornlänge des Nashorns: ");
                int hornLaenge = Convert.ToInt32(Console.ReadLine());

                Nashorn nashorn = new Nashorn(name, gewicht, alter, geschwindigkeit, hornLaenge);
                nashorn.schlafen();
                nashorn.bewegen();
                nashorn.essen();
                Console.WriteLine("Nashorn erstellt: " + name);
                return nashorn;
            }

            Delfin ErstelleDelfin()
            {
                Console.Write("Name des Delfins: ");
                string name = Console.ReadLine();
                Console.Write("Gewicht des Delfins: ");
                int gewicht = Convert.ToInt32(Console.ReadLine());
                Console.Write("Alter des Delfins: ");
                int alter = Convert.ToInt32(Console.ReadLine());
                Console.Write("Art des Delfins: ");
                string art = Console.ReadLine();

                Delfin delfin = new Delfin(name, gewicht, alter, art);
                delfin.schlafen();
                delfin.bewegen();
                delfin.essen();
                Console.WriteLine("Delfin erstellt: " + name);
                return delfin;
            }

            Landtier ErstelleLandtier()
            {
                Console.Write("Name des Landtiers: ");
                string name = Console.ReadLine();
                Console.Write("Gewicht des Landtiers: ");
                int gewicht = Convert.ToInt32(Console.ReadLine());
                Console.Write("Alter des Landtiers: ");
                int alter = Convert.ToInt32(Console.ReadLine());
                Console.Write("Geschwindigkeit des Landtiers: ");
                int geschwindigkeit = Convert.ToInt32(Console.ReadLine());

                Landtier landtier = new Landtier(name, gewicht, alter, geschwindigkeit);
                landtier.schlafen();
                landtier.bewegen();
                landtier.essen();
                Console.WriteLine("Landtier erstellt: " + name);
                return landtier;
            }

            Wassertier ErstelleWassertier()
            {
                Console.Write("Name des Wassertiers: ");
                string name = Console.ReadLine();
                Console.Write("Gewicht des Wassertiers: ");
                int gewicht = Convert.ToInt32(Console.ReadLine());
                Console.Write("Alter des Wassertiers: ");
                int alter = Convert.ToInt32(Console.ReadLine());
                Console.Write("Tauchzeit des Wassertiers: ");
                int tauchzeit = Convert.ToInt32(Console.ReadLine());

                Wassertier wassertier = new Wassertier(name, gewicht, alter);
                wassertier.setTauchzeit(tauchzeit);
                wassertier.schlafen();
                wassertier.bewegen();
                wassertier.essen();
                Console.WriteLine("Wassertier erstellt: " + name);
                return wassertier;
            }

            while (true)
            {
                int feedback = MenuAnzeigen();

                if (feedback == 3)
                {
                    int option = ErweitertesMenuAnzeigen();
                    switch (option)
                    {
                        case 1:
                            tiere.Add(ErstelleWal());
                            break;
                        case 2:
                            tiere.Add(ErstelleDelfin());
                            break;
                        case 3:
                            tiere.Add(ErstelleElefant());
                            break;
                        case 4:
                            tiere.Add(ErstelleNashorn());
                            break;
                        case 5:
                            foreach (var tier in tiere)
                            {
                                tier.SteckbriefAusgeben();
                            }

                            Console.ReadLine();

                            return;
                        default:
                            Console.WriteLine("Ungültige Option.");
                            break;
                    }
                }
                else if (feedback == 1 || feedback == 2)
                {
                    if (feedback == 1) 
                    {
                        tiere.Add(ErstelleLandtier());
                    }
                    else
                    {
                        tiere.Add(ErstelleWassertier());
                    }
                }
                else
                {
                    Console.WriteLine("Ungültige Option.");
                }
            }


        /*
        Wassertier Wal = new Wassertier("Wally", 1000000, -3);
            Wal.schlafen();
            // "Der Wal schläft"
            Wal.bewegen();
            // "Der Wal schwimmt"
            Wal.essen();
            // "Der Wal isst"
            Wal.setTauchzeit(25);
            Wal.updateAlter(13);

            Landtier Katze = new Landtier("Leo", 5, 15, 32);
            Katze.schlafen();
            // "Das Landtier schläft"

            Tier irgendEinTier = new Tier();
            irgendEinTier.schlafen();
            // "Das Tier schläft"

            irgendEinTier = (Tier) Wal;
            irgendEinTier.schlafen();
            // "Das Wassertier schläft"

            Console.ReadLine();
        */

        }
    }
}
