
/*
 
  -  07.12.2023 - Florian Manhartseder
  -  Bubblesort
  -  Statistics
  -  Chess v1.0
  -  Chess Aufgabe

 */


using System;
using System.Collections.Generic;
using System.Text;

namespace Arrays
{
    internal class Program
    {
        class Bubblesort
        {
            private int[] myArr;

            public Bubblesort(int[] unsortedArr) 
            {
                if (unsortedArr == null) throw new Exception("Can't be null when initialised!");
                myArr = unsortedArr;
                Array.Copy(unsortedArr, myArr, unsortedArr.Length);
            }

            public int[] sort()
            {
                int[] sortedArr = new int[myArr.Length];
                int zwischenSpeicher = 0;
                

                for (int i = 0; i < myArr.Length; i++)
                {
                    for (int j = 0; j < myArr.Length; j++)
                    {
                        if (myArr[j] > myArr[i])
                        {
                            zwischenSpeicher = myArr[i];
                            myArr[i] = myArr[j];
                            myArr[j] = zwischenSpeicher;
                        }
                    }
                }

                Array.Copy(myArr, sortedArr, myArr.Length);
                return sortedArr;
            }

            public void print()
            {
                int zaehler = 0;

                foreach (int val in myArr)
                {
                    Console.WriteLine("Index: [" + zaehler + "]: " + Convert.ToString(val));
                    zaehler++;
                }
            }
        }

        class Statistics
        {
            private int[] myValues;
            private int[] sortedValues;

            private double median;
            private double spannweite;

            public Statistics(int[] myValueArr) 
            {
                this.myValues = myValueArr;
                Array.Copy(myValueArr, sortedValues, myValueArr.Length);
                Array.Sort(this.sortedValues);
            }

            public double mittelwert()
            {
                int gesamt = 0;

                foreach (int i in myValues)
                {
                    gesamt += i;
                }

                int myMittelwert = gesamt / myValues.Length;
                return myMittelwert;
            }

            public double Spannweite()
            {
                spannweite = sortedValues[sortedValues.Length] - sortedValues[0];
                return spannweite;
            }

            public double calcMedian()
            {
                if (sortedValues.Length % 2 != 1)
                {
                    median = (sortedValues[(sortedValues.Length - 1) / 2] + sortedValues[(sortedValues.Length + 1 / 2)]) / 2;
                }
                else
                {
                    median = sortedValues[sortedValues.Length / 2];
                }
                return median;
            }

            public int relativeHaeufigkeit(int targetValue)
            {
                int i = 0;

                foreach (int val in myValues)
                {
                    if (targetValue == val)
                    {
                        i++;
                    }
                }
                return i;
            }
        }

        class Position
        {
            private int x;
            private int y;

            public Position(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public int getX() { return x; }
            public int getY() { return y; }

            public void setX(int x) {  this.x = x; }
            public void setY(int y) { this.y = y; }

            public void updatePosition(Position updatedPos) { this.x = updatedPos.x; this.y = updatedPos.y; }
            public Position getPosition() { return this; }
        }

        class Move
        {
            private Position prevPosition;
            private Position futurePosition;

            public Move(Position from, Position to)
            {
                prevPosition = from;
                futurePosition = to;
            }

            public int diffXAbs()
            {
                return Math.Abs(prevPosition.getX() - futurePosition.getX());
            }

            public int diffYAbs()
            {
                return Math.Abs(prevPosition.getY() - futurePosition.getY());
            }

            public Position getPrevPosition() { return prevPosition; }
            public Position getFuturePosition() {  return futurePosition; }

        }


        class Player
        {
            private string name;
            private int nMovesPlayed; // Number of moves played
            private bool beginner; // Depends is the user beginns the game or not / Black white

            public Player(string name, bool beginner)
            {
                this.name = name;
                this.beginner = beginner;
            }
        }

        class Figure
        {
            private Position position;
            private Player owner;
            private bool isAlive;
            private List<Move> possibleMoves;

            public Figure(Position position, bool isAlive = true) 
            {
                this.position = position;
                this.isAlive = isAlive;
            }

            public void getPossibleMoves()
            {
                List<Move> possibleMoves = new List<Move>();
                List<Position> possiblePositions = new List<Position>();

                //if (typeof(Figure) == King)
                //{

                //}

                // Calc all possible positions then throw out all positions where a figure is on that can't be beaten 


                // Calc all possible moves depending on what derived type the Figure is
            }

            public void moveFigure(Move move)
            {
                // ToDo: Test if move is in list of legal moves
                position.updatePosition(move.getFuturePosition());
            }

            public bool isLegalMove(Move move) 
            {
                // ToDo: Implement test for legal moves
                return false;
            }


            class King : Figure
            {
                /* The king may move to any adjoining square. No move may be made such that the king is placed or left in check.
                 * The king may participate in castling, which is a move consisting of the king moving two squares toward a same-colored rook on the same rank and the rook moving to the square crossed by the king.
                 * Castling may only be performed if the king and rook involved are unmoved, if the king is not in check, if the king would not travel through or into check, 
                 * and if there are no pieces between the rook and the king. */
                public King(Position position, bool isAlive = true) : base(position, isAlive)
                {
                }
            }

            class Queen : Figure
            {
                /* The queen may move any number of squares vertically, horizontally, or diagonally without jumping. */
                public Queen(Position position, bool isAlive = true) : base(position, isAlive)
                {
                    
                }
            }

            class Rook : Figure
            {
                /* The rook may move any number of squares vertically or horizontally without jumping. It also takes part, along with the king, in castling. */
                public Rook(Position position, bool isAlive = true) : base(position, isAlive)
                {
                }
            }

            class Bishop : Figure
            {
                /* The bishop may move any number of squares diagonally without jumping. Consequently, a bishop stays on squares of the same color throughout the game. */
                public Bishop(Position position, bool isAlive = true) : base(position, isAlive)
                {
                }

            }

            class Knight : Figure
            {
                /* The knight moves from one corner of any two-by-three rectangle to the opposite corner. Consequently, the knight alternates its square color each time it moves. It is not obstructed by other pieces. */
                public Knight(Position position, bool isAlive = true) : base(position, isAlive)
                {   
                }
            }

            class Pawn : Figure
            {
                /* The pawn may move forward one square, and one or two squares when on its starting square, toward the opponent's side of the board. When there is an enemy piece one square diagonally ahead of a pawn,
                 * then the pawn may capture that piece. A pawn can perform a special type of capture of an enemy pawn called en passant ("in passing"),
                 * wherein it captures a horizontally adjacent enemy pawn that has just advanced two squares as if that pawn had only advanced one square.
                 * If the pawn reaches a square on the back rank of the opponent, it promotes to the player's choice of a queen, rook, bishop, or knight of the same color.[6] */
                public Pawn(Position position, bool isAlive = true) : base(position, isAlive)
                {
                }
            }
        }

        class Schach
        {
            private int[] myBorders = new int[2] { 8, 8 };
            private string[,] myBoard = new string[8, 8];
            private int[] posHorse = new int[2] { 1, 1 };

            private string blackSquare = "\u25A0";
            private string whiteSquare = "\u25A1";

            public Schach() 
            {
                initSchachbrett();
            }

            public void initSchachbrett()
            {
                // Schachbrett initialisieren
                for (int i = 0; i < myBorders[0]; i++)
                {
                    for (int j = 0; j < myBorders[1]; j++)
                    {
                        if (i % 2 == 0)
                        {
                            if (j % 2 == 0)
                            {
                                myBoard[i, j] = blackSquare;
                            }
                            else myBoard[i, j] = whiteSquare;
                        }
                        else
                        {
                            if (j % 2 == 1)
                            {
                                myBoard[i, j] = blackSquare;
                            }
                            else myBoard[i, j] = whiteSquare;
                        }
                    }
                }
            }

            public void printSchachbrett()
            {
                // Set Springer on the board
                myBoard[posHorse[0], posHorse[1]] = "S";

                for (int i = 0;i < myBorders[0];i++)
                {
                    for (int j = 0; j < myBorders[1]; j++)
                    {
                        if (j == 0) Console.Write("\t\t");
                        Console.Write("." + myBoard[i, j]);
                    }
                    Console.Write(" -> " + Convert.ToString(i));
                    Console.WriteLine("");
                }
                Console.WriteLine("\t\t 0,1,2,3,4,5,6,7\n\n");
            }

            public bool IsOnBoard(int[] pos)
            {
                if (pos[0] <= myBorders[0] - 1)
                {
                    if (pos[1] <= myBorders[1] - 1)
                    {
                        if (pos[0] >= 0)
                        {
                            if (pos[1] >= 0)
                            {
                                return true;
                            }
                        }
                    }
                }
                return false;
            }

            public void getEingabe()
            {
                do
                {
                    Console.WriteLine("Geben Sie die nächste Sprungnummer an, mögliche Sprünge: ");

                    int[] poss1 = new int[2] { posHorse[1] + 1, posHorse[0] + 2 };
                    int[] poss2 = new int[2] { posHorse[1] + 2, posHorse[0] + 1 };
                    int[] poss3 = new int[2] { posHorse[0] - 1, posHorse[1] - 2 };
                    int[] poss4 = new int[2] { posHorse[0] - 2, posHorse[1] - 1 };

                    List<int[]> possibleJumps = new List<int[]>();
                    List<int[]> jumpList = new List<int[]> { poss1, poss2, poss3, poss4 };

                    // Mögliche Sprünge ausgeben
                    foreach (int[] pos in jumpList)
                    {
                        if (IsOnBoard(pos))
                        {
                            Console.WriteLine("\tSprung {" + jumpList.IndexOf(pos) + "} nach: xPos->" + pos[0] + ", yPos->" + pos[1]);
                            possibleJumps.Add(pos);
                        }
                    }

                    // Eingabe verarbeiten
                    try
                    {
                        int nextJump = Convert.ToInt32(Console.ReadLine());
                        int updatedX = 0, updatedY = 0;

                        // Eingabegültigkeit checken
                        if (nextJump >= possibleJumps.Count) throw new IndexOutOfRangeException();

                        updatedX = possibleJumps[nextJump][0];
                        updatedY = possibleJumps[nextJump][1];

                        Console.WriteLine("\n\nMoving Springer to X=" + Convert.ToString(updatedX) + " , Y=" + Convert.ToString(updatedY));

                        if (updatedX <= myBorders[0]) if (updatedY <= myBorders[1]) if (updatedX >= 0) if (updatedY >= 0)
                                    {
                                        // Gültiger Sprung ausgewählt -> position updaten
                                        posHorse = possibleJumps[nextJump];

                                        initSchachbrett();
                                        printSchachbrett();
                                    }
                                    else throw new IndexOutOfRangeException();
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("Index not in range!");
                        continue;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("An error occurred! " + e.Message);
                        continue;
                    }
                    finally
                    {
                        Console.WriteLine("Moved Figure!");
                        Console.WriteLine("");
                    }
                }
                while (true);
            }
        }
        

        static void Main(string[] args)
        {
            // Change encoding to utf-8
            Console.OutputEncoding = Encoding.UTF8;

            // Ein und mehr dimensionale arrays erstellen
            int[] myIntArr = new int[10];
            int[] firstArr = new int[10];
            int[] secondArr = new int[10]; 
            int[,] myArr = new int[2, 2] {  { 2, 3 },
                                            { 7, 9 }  };

            // Get dimension length
            int borderDimension = myArr.GetLength(0);

            // Array kopieren
            Array.Copy(firstArr, secondArr, firstArr.Length);

            // Object array
            object[] objArr = new object[2] { 2, "Obj" };

            // Iter over object array
            foreach (Object o in objArr)
            {
                if (o.GetType() == typeof(string))
                {
                    Console.WriteLine("String: " + o.ToString());
                }
                if (o.GetType() == typeof(int))
                {
                    Console.WriteLine("Int: " + o.ToString());
                }
            }

            // Arrays sortieren
            int[] myUnsortedArr = new int[10] { 2, 4, 1, 4, 9, 6, 0, 2, 3, 6 };

            Console.WriteLine("\nBubblesort!");

            Bubblesort mySorter = new Bubblesort(myUnsortedArr);
            mySorter.sort();
            
            Console.WriteLine("Bubblesort ende!\n");

            // Mit Methode sortieren
            Array.Sort(myUnsortedArr);

            // Ausgeben des sortierten Arrays
            Console.WriteLine("Sortiertes Array:");
            foreach (int t in myUnsortedArr)
            {
                Console.WriteLine("Object value: " + t);
            }
            Console.WriteLine("\n");

            // Schach
            Schach mySchach = new Schach();
            mySchach.printSchachbrett();
            mySchach.getEingabe();

            Console.ReadLine();

        }
    }
}
