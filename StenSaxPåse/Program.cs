using System;

namespace StenSaxPåse {
    class Program {
        static void Main(string[] args) {
            // 1 = sten
            //2 = sax
            //3 = påse
            int p1wins = 0;
            int p1losses = 0;
            int p1draws = 0;

            while(true) {
                bool finish = false;
                int p1choice = 0;
                Random rnd = new Random();

                if (Console.ReadLine() == "stats") {
                    Console.WriteLine("Wins: " + p1wins);
                    Console.WriteLine("Losses: " + p1losses);
                    Console.WriteLine("Draws: " + p1draws);
                }

                while (finish == false) {

                    Console.WriteLine("Player 1s turn");
                    string p1temp = Console.ReadLine();
                    p1choice = Convert(rnd, p1temp);
                    if (p1choice == 4) {
                        Console.WriteLine("pajas fel");
                        finish = false;
                    }
                    else {
                        finish = true;
                    }
                }

                Console.WriteLine("Player 2s turn");
                int p2choice = rnd.Next(1, 4);
                string p2choice2 = ReConvert(p2choice);
                Console.WriteLine(p2choice2);
                Tuple<int, int, int> stats = Winner(p2choice, p1choice, p1wins, p1losses, p1draws);
                p1wins = stats.Item1;
                p1losses = stats.Item2;
                p1draws = stats.Item3;
                Console.WriteLine("Wins: " + p1wins);
                Console.WriteLine("Losses: " + p1losses);
                Console.WriteLine("Draws: " + p1draws);
            }
        }

        static int Convert(Random rnd, string p1temp) {
            int p1choice;

            if (p1temp == "sten") {
                p1choice = 1;
            }

            else if (p1temp == "sax") {
                p1choice = 2;
            }

            else if (p1temp == "påse") {
                p1choice = 3;
            }

            else {
                p1choice = 4;
            }

            return p1choice;
        }

        static Tuple<int, int, int> Winner(int p2choice, int p1choice, int p1wins, int p1losses, int p1draws) {
            string result = "draw";

            // TILL NÄSTA GÅNG:
            // Kom på ett sätt att lösa följande funktion utan att "brute-forcea" varje kombination
            // Finns det något system?
            
            if (p1choice == 1 && p2choice == 1) {
                result = "draw";
            }

            else if (p1choice == 1 && p2choice == 2) {
                result = "p1";
            }

            else if (p1choice == 1 && p2choice == 3) {
                result = "p2";
            }

            else if (p1choice == 2 && p2choice == 1) {
                result  = "p2";
            }

            else if (p1choice == 2 && p2choice == 2) {
                result  = "draw";
            }

            else if (p1choice == 2 && p2choice == 3) {
                result  = "p1";
            }

            else if (p1choice == 3 && p2choice == 1) {
                result  = "p1";
            }

            else if (p1choice == 3 && p2choice == 2) {
                result  = "p2";
            }
            
            else if (p1choice == 3 && p2choice == 3) {
                result  = "draw";
            }

            if (result != "draw") {
                if (result ==  "p1") {
                    Console.WriteLine("p1 has won the game!");
                    p1wins++;
                }

                else {
                    Console.WriteLine("p2 has won the game_!!");
                    p1losses++;
                }
            }

            else {
                Console.WriteLine("Its a draw!");
                p1draws++;
            }

            return Tuple.Create(p1wins, p1losses, p1draws);
        }

        static string ReConvert(int p2choice) {
            string p2choice2 = "";


            if (p2choice == 1) {
                p2choice2 = "sten";
            }

            else if (p2choice == 2) {
                p2choice2 = "sax";
            }

            else if (p2choice == 3) {
                p2choice2 = "påse";
            }

            else {
                p2choice2 = "";
            }

            return p2choice2;
        }
    }
}
