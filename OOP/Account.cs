using System;

namespace OOP
{
	internal class Account
	{
		private string _KontoID { get; set; }
		private float _Saldo { get; set; }
		private double _Zinsen { get; set; }


		public Account(string kontoID, float saldo, double zinsen)
		{
			_KontoID = kontoID;
			_Saldo = saldo;
			_Zinsen = zinsen;
		}

		public void setSaldo (float saldo)
		{
			_Saldo = saldo;
		}

		public float getSaldo ()
		{
			return _Saldo;
		}

		public string getKontoID ()
		{
			return _KontoID;
		}

		public void setZinsen(double zinsen)
		{
			_Zinsen = zinsen;
		}

		public double getZinsen()
		{
			return _Zinsen;
		}

        public void SpellSaldo()
        {
            int mySaldo = Convert.ToInt32(_Saldo);

            if (mySaldo >= 0 && mySaldo <= 999)
            {
                string spelled = ""; // Init output string

                // Selection of classmethods to get the correct spelled number
                if (mySaldo >= 100)
                {
                    int hundreds = mySaldo / 100;
                    spelled += GetDigitWord(hundreds) + " Hundred ";
                    mySaldo %= 100;
                }

                if (mySaldo >= 20)
                {
                    int tens = (mySaldo / 10) * 10;
                    spelled += GetTensWord(tens) + " ";
                    mySaldo %= 10;
                }

                if (mySaldo > 0)
                {
                    spelled += GetDigitWord(mySaldo);
                }

                Console.WriteLine(spelled.Trim() + " Euro");
            }
            else
            {
                throw new Exception("Saldo not in a range where it's possible to spell it!");
            }
        }

        // Method to spell the one digits
        private string GetDigitWord(int digit)
        {
            switch (digit)
            {
                case 1:
                    return "One";
                case 2:
                    return "Two";
                case 3:
                    return "Three";
                case 4:
                    return "Four";
                case 5:
                    return "Five";
                case 6:
                    return "Six";
                case 7:
                    return "Seven";
                case 8:
                    return "Eight";
                case 9:
                    return "Nine";
                default:
                    return "";
            }
        }

        // Method to spell the ten digits
        private string GetTensWord(int tens)
        {
            switch (tens)
            {
                case 20:
                    return "Twenty";
                case 30:
                    return "Thirty";
                case 40:
                    return "Forty";
                case 50:
                    return "Fifty";
                case 60:
                    return "Sixty";
                case 70:
                    return "Seventy";
                case 80:
                    return "Eighty";
                case 90:
                    return "Ninety";
                default:
                    return "";
            }
        }
        
        public int makePayment(Account receiver, float amount)
        {
            if (_Saldo < amount)
            {
                throw new Exception("Not enough money!");
            }

            this.setSaldo(_Saldo - amount);
            receiver.setSaldo(receiver.getSaldo() + amount);
            Console.WriteLine("Payment successful!");
            return 0;
        }
    }
}
