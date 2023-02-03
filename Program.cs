using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


 namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.ForegroundColor = ConsoleColor.Black; // for text/characters
            Console.BackgroundColor = ConsoleColor.Cyan; // entire screen or just highlighting luines (without console.clear())

            Console.Clear(); //Important, as You need to 
            // clear the console window AFTER setting the colors but BEFORE you write the text...


            //_________________________________________________________________________________________
            bool bPlayTime = true;
            bool bplayer1Winner = false;
            bool bplayer2Winner = false; // save when one of them wins.
            string sname1 = " ";
            string sname2 = " ";



            while (bPlayTime)
            {
                Console.WriteLine("\\Welcome to the Tic-Tac-Toe game. Please enter your names. \\");

                Console.WriteLine("Player 1(0): ");
                 sname1 = Console.ReadLine();
                Console.WriteLine("\r\n");
                Console.WriteLine("Player 2(X): ");
                 sname2 = Console.ReadLine(); // Save their names and stuff.

                // Starting position.
                int nPlayer1 = 0;
                int nPlayer2 = 0;
                int nMaxTimes = 4;

                char[] chPositions = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                string sSeparation = "--------------------------";
                Console.WriteLine("\n{0} and {1}, here is a representation of the Tic Tac Toe game: \r\n", sname1, sname2);
                //Form a table
                Console.WriteLine(chPositions[0] + " | " + chPositions[1] + " | " + chPositions[2]);
                Console.WriteLine(sSeparation);
                Console.WriteLine(chPositions[3] + " | " + chPositions[4] + " | " + chPositions[5]);
                Console.WriteLine(sSeparation);
                Console.WriteLine(chPositions[6] + " | " + chPositions[7] + " | " + chPositions[8]);
                Console.WriteLine(sSeparation);



                Console.WriteLine("Per rule, Player 1 shall start. The game begins now, good luck fellows!");
                Thread.Sleep(3000);
                Console.WriteLine("\r\n To begin, press a number between 1 to 9 according to the table.\r\n");



                //Limited 5 times Player 1 can go and 4 times Player 2 can go.

                // Create a public bool to ensure that mistakes are taken accordingly.
              /*   public bool bVoid()
                {
                     //This fuck causes so many issues
                } */

               /* while (bPlayTime)
                //{
                    if (nPlayer1 > 9 ||  )
                  { */

                  
                    for (int i = 1; i <= nMaxTimes; i++)
                    {
                        //COntrol Flow statement in case a player select a used numbers.
                        bool bRepeat = true;
                        bool bRepeat2 = true;
                        int n1Player1; // used for later NOT ENOUGH NOT ENOUGH NOT ENOUGH NOT ENOUGH
                        int n2Player2;

                        while (bRepeat)
                        {
                            Console.WriteLine("\r\n\r\nPlayer 1's turn: ");
                            n1Player1 = nPlayer1;

                            string sPlayer1 = Console.ReadLine();
                            Int32.TryParse(sPlayer1, out nPlayer1);

                            if (nPlayer1 == nPlayer2 || n1Player1 == nPlayer1)
                            {
                                Console.WriteLine("Number already taken. Please try another number.");

                                bRepeat = true;
                            }
                            else if (nPlayer1 < 0 || nPlayer1 > 9)
                            {
                                Console.WriteLine("Retry");
                                bRepeat2 = true;
                            }
                            else
                            {
                                chPositions[nPlayer1 - 1] = 'O';

                                bRepeat = false;
                            }

                        }


                        // }
                        // Redisplay the new thing
                        Console.WriteLine(chPositions[0] + " | " + chPositions[1] + " | " + chPositions[2]);
                        Console.WriteLine(sSeparation);
                        Console.WriteLine(chPositions[3] + " | " + chPositions[4] + " | " + chPositions[5]);
                        Console.WriteLine(sSeparation);
                        Console.WriteLine(chPositions[6] + " | " + chPositions[7] + " | " + chPositions[8]);
                        Console.WriteLine("");


                        if (ThreeStraight(chPositions, 'O'))
                        {
                            bplayer1Winner = true;

                            bPlayTime = false;
                            break; //TO GET OUT OF THE FOR LOOP
                        }

                        Console.WriteLine("\r\n\r\nPlayer 2's turn: \r\n");
                       
                        while (bRepeat2)
                       {
                           n2Player2 = nPlayer2;
                        string sPlayer2 = Console.ReadLine();
                        Int32.TryParse(sPlayer2, out nPlayer2);
                       // nPlayer2 = int.Parse(Console.ReadLine());

                        if (nPlayer2 == nPlayer1 || n2Player2 == nPlayer2)
                        {
                            Console.WriteLine("Number already taken. Please try another number.");
                            bRepeat2 = true;
                        }
                        else if (nPlayer2 < 0 || nPlayer2 > 9)
                        {
                            Console.WriteLine("Retry");
                            bRepeat2 = true;
                        }
                        else
                        {
                            chPositions[nPlayer2 - 1] = 'X';

                            bRepeat2 = false;
                        }
                       }

                        Console.WriteLine(chPositions[0] + " | " + chPositions[1] + " | " + chPositions[2]);
                        Console.WriteLine(sSeparation);
                        Console.WriteLine(chPositions[3] + " | " + chPositions[4] + " | " + chPositions[5]);
                        Console.WriteLine(sSeparation);
                        Console.WriteLine(chPositions[6] + " | " + chPositions[7] + " | " + chPositions[8]);
                        Console.WriteLine("");

                        if (ThreeStraight(chPositions, 'X'))
                        {
                            bplayer2Winner = true;
                            bPlayTime = false;
                            break; //TO GET OUT OF THE FOR LOOP
                        }

                        if (i == 4 && bplayer1Winner == false && bplayer2Winner == false)
                        {
                            bPlayTime = false;
                            break;
                        }


                    }
                        
                      
              }
                
//________________________________ Final Decision


               if (bplayer1Winner)
                {
                    Console.WriteLine("\n\n "+sname1 + " has won. CONGRATULATIONS WOOT WOOT!!!");
                }
                if (bplayer2Winner)
                {
                    Console.WriteLine("\n\n"+sname2 + " has won.cONGRATULATIONS WOOT WOOT!!!");
                }
                else if (bplayer1Winner == false && bplayer2Winner == false)
                {
                    Console.WriteLine("\n\nDRAW. YOU BOTH SUCK!!!");
                }

               
   //____________________________________________Restart or exit             
                Console.Write("\n\nTo restart the game, please press ENTER.\n\nIf not, press any key to exit program");
                ConsoleKeyInfo keyInfo = Console.ReadKey();
            

                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    bPlayTime = true;
                }
                else
                {
                    bPlayTime = false;
                } 




           // Console.ReadKey();

         }


        //Whoeevr won MUST STUDY THIS
        public static bool ThreeStraight(char[] chPositions, char X_or_O)
        {
            bool bSet = false;

            if (chPositions[0] == X_or_O && chPositions[1] == X_or_O && chPositions[2] == X_or_O)
            {
                bSet = true;
            }
            if (chPositions[3] == X_or_O && chPositions[4] == X_or_O && chPositions[5] == X_or_O)
            {
                bSet = true;
            }
            if (chPositions[6] == X_or_O && chPositions[7] == X_or_O && chPositions[8] == X_or_O)
            {
                bSet = true;
            }
            if (chPositions[0] == X_or_O && chPositions[3] == X_or_O && chPositions[6] == X_or_O)
            {
                bSet = true;
            }
            if (chPositions[1] == X_or_O && chPositions[4] == X_or_O && chPositions[7] == X_or_O)
            {
                bSet = true;
            }
            if (chPositions[2] == X_or_O && chPositions[5] == X_or_O && chPositions[8] == X_or_O)
            {
                bSet = true;
            }
            if (chPositions[0] == X_or_O && chPositions[4] == X_or_O && chPositions[8] == X_or_O)
            {
                bSet = true;
            }
            if (chPositions[2] == X_or_O && chPositions[4] == X_or_O && chPositions[6] == X_or_O)
            {
                bSet = true;
            }

            return bSet;
        }

    }
}


