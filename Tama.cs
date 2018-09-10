﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tamagotchi
{
    class Tama
    {
        public string Name { get; set; }
        public int Dicipline { get; set; }
        public int Hungry { get; set; }
        public int Happy { get; set; }
        public int Poop { get; set; }
        public bool Good { get; set; }

        public string food;

        public string Stage { get; set; }
        ConsoleColor Color { get; set; }

        public Tama(string name)
        {
            Name = name;
            Stage = "Яйцо";
            Color = ConsoleColor.DarkMagenta;
        }

        public void WriteTama()
        {
            if (Hungry > 5)
            {
                Poop += 1;
                Hungry = 2;
            }

            Console.Clear();
            WriteName();
            DrawTama();
            DrawChart();

            if (Poop > 0) DrawPoop();
        }

        public void ChangeStage(string stage)
        {
            Stage = stage;

            if (Stage == "Хороший Подросток" || Stage == "Хороший Взрослый" || Stage == "Ангел")
                Good = true;
            else
                Good = false;
        }

        public void WriteName()
        {
            Console.SetCursorPosition(7, 1);
            Console.WriteLine("  ♥  ♥  ♥  {0}  ♥  ♥  ♥", Name);
            Console.WriteLine();
        }

        public void DrawChart()
        {
            Console.SetCursorPosition(5, 17);

            Console.Write("Дисциплина: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            for (var i = 0; i < Dicipline; i++)
            {
                Console.Write("♥");
            }
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("  Голод: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (var i = 0; i < Hungry; i++)
            {
                Console.Write("♥");
            }
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("  Счастье: ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            for (var i = 0; i < Happy; i++)
            {
                Console.Write("♥");
            }
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }

        public void DrawPoop()
        {
            Console.SetCursorPosition(5, 19);
            Console.Write("Измотанность: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            for (var i = 0; i < Poop; i++)
            {
                Console.Write("▲");
            }
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }

        public void DrawTama()
        {
            switch (Stage)
            {
                case "Ребенок":
                    Color = ConsoleColor.Magenta;
                    Baby();
                    break;
                case "Хороший Подросток":
                    Color = ConsoleColor.Cyan;
                    GoodTeen();
                    break;
                case "Плохой Подросток":
                    Color = ConsoleColor.Green;
                    BadTeen();
                    break;
                case "Хороший Взрослый":
                    Color = ConsoleColor.Blue;
                    GoodAdult();
                    break;
                case "Плохой Взрослый":
                    Color = ConsoleColor.DarkGreen;
                    BadAdult();
                    break;
                case "Ангел":
                    Color = ConsoleColor.DarkCyan;
                    Angel();
                    break;
                case "Умер":
                    Color = ConsoleColor.DarkGray;
                    Dead();
                    break;
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        public void TamaTalks(string String)
        {
            Console.ForegroundColor = Color;
            Console.WriteLine();
            Console.Write("{0}> ", Name);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(String);
            Console.WriteLine();
            System.Threading.Thread.Sleep(1000);
        }

        public void Hatching()
        {
            for (int i = 0; i < 15; i++)
            {
                Console.Clear();

                WriteName();

                if (i % 2 == 0)
                    Egg();
                else if (i % 3 == 0)
                    Egg2();
                else
                    Egg3();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(Name + " родился!!");
                System.Threading.Thread.Sleep(200);
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.Clear();
            WriteName();
            Egg();
            Console.ForegroundColor = ConsoleColor.White;
            System.Threading.Thread.Sleep(500);

            Console.Clear();
            WriteName();
            Egg4();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            TamaTalks("МАМА!");
            System.Threading.Thread.Sleep(400);
            TamaTalks("*крик*");
            System.Threading.Thread.Sleep(800);
            Console.ForegroundColor = ConsoleColor.White;
        }

        void Egg()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine("                     ■■       ");
            Console.WriteLine("                  ■     ■     ");
            Console.WriteLine("                ■         ■   ");
            Console.WriteLine("               ■           ■  ");
            Console.WriteLine("              ■             ■ ");
            Console.WriteLine("             ■               ■");
            Console.WriteLine("             ■               ■");
            Console.WriteLine("             ■               ■");
            Console.WriteLine("               ■           ■  ");
            Console.WriteLine("                 ■  ■■■■ ■    ");
        }

        void Egg2()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine("                   ■■         ");
            Console.WriteLine("                 ■     ■      ");
            Console.WriteLine("               ■         ■    ");
            Console.WriteLine("             ■             ■  ");
            Console.WriteLine("            ■               ■ ");
            Console.WriteLine("            ■               ■ ");
            Console.WriteLine("             ■              ■ ");
            Console.WriteLine("               ■          ■   ");
            Console.WriteLine("                 ■ ■■■■ ■     ");
        }

        void Egg3()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine("                     ■■       ");
            Console.WriteLine("                   ■    ■     ");
            Console.WriteLine("                 ■       ■    ");
            Console.WriteLine("               ■          ■   ");
            Console.WriteLine("              ■             ■ ");
            Console.WriteLine("             ■               ■");
            Console.WriteLine("             ■               ■");
            Console.WriteLine("             ■              ■ ");
            Console.WriteLine("               ■          ■   ");
            Console.WriteLine("                 ■ ■■■■ ■     ");
        }

        void Egg4()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine("                    ■■       ");
            Console.WriteLine("                  ■    ■     ");
            Console.WriteLine("                ■        ■   ");
            Console.WriteLine("              ■            ■ ");
            Console.WriteLine("             ■  ■ ■ ■■ ■ ■  ■");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("              ■  ■      ■  ■ ");
            Console.WriteLine("              ■    ■■■■    ■ ");
            Console.ForegroundColor = Color;
            Console.WriteLine("             ■  ■ ■ ■■ ■ ■  ■");
            Console.WriteLine("             ■              ■");
            Console.WriteLine("             ■              ■");
            Console.WriteLine("               ■          ■  ");
            Console.WriteLine("                 ■ ■■■■ ■    ");
        }


        void Baby()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                  ■ ■■■■ ■   ");
            Console.WriteLine("                ■          ■ ");
            Console.WriteLine("               ■  ■      ■  ■");
            Console.WriteLine("               ■    ■■■■    ■");
            Console.WriteLine("               ■            ■");
            Console.WriteLine("                ■          ■ ");
            Console.WriteLine("                  ■ ■■■■ ■   ");
        }

        void GoodTeen()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine();
            Console.WriteLine("                  ■■      ■■     ");
            Console.WriteLine("                ■    ■■■■   ■    ");
            Console.WriteLine("               ■  ■       ■  ■   ");
            Console.WriteLine("              ■              ■   ");
            Console.WriteLine("              ■      ■■■■     ■  ");
            Console.WriteLine("            ■■                 ■■");
            Console.WriteLine("               ■             ■   ");
            Console.WriteLine("                ■          ■     ");
            Console.WriteLine("                 ■   ■ ■   ■     ");
            Console.WriteLine("                  ■■    ■■       ");
        }

        void BadTeen()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine();
            Console.WriteLine("                  ■■      ■■     ");
            Console.WriteLine("                ■    ■■■■   ■    ");
            Console.WriteLine("               ■  ■       ■  ■   ");
            Console.WriteLine("          ■■■■■              ■■■■■   ");
            Console.WriteLine("          ■■■■■     ■■■■     ■■■■■  ");
            Console.WriteLine("            ■■                 ■■");
            Console.WriteLine("               ■             ■   ");
            Console.WriteLine("                ■          ■     ");
            Console.WriteLine("                 ■   ■ ■   ■     ");
            Console.WriteLine("                  ■■    ■■       ");
        }

        void GoodAdult()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine("                   ■       ■     ");
            Console.WriteLine("                  ■■■■   ■■■■    ");
            Console.WriteLine("                 ■■■■■■■■■■■■■   ");
            Console.WriteLine("                 ■           ■   ");
            Console.WriteLine("                ■  ■       ■  ■  ");
            Console.WriteLine("                ■   ■■■_■■■    ■  ");
            Console.WriteLine("              ■■■             ■■■");
            Console.WriteLine("                 ■           ■   ");
            Console.WriteLine("                  ■         ■    ");
            Console.WriteLine("                   ■  ■ ■  ■     ");
            Console.WriteLine("                    ■     ■      ");
        }

        void BadAdult()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine("                   ■       ■     ");
            Console.WriteLine("                  ■■■■   ■■■■    ");
            Console.WriteLine("                 ■■■■■■■■■■■■■   ");
            Console.WriteLine("                 ■           ■   ");
            Console.WriteLine("             ■■■■  ■       ■  ■■■■  ");
            Console.WriteLine("             ■■■■   ■■■_■■■   ■■■■  ");
            Console.WriteLine("              ■■■             ■■■");
            Console.WriteLine("                 ■           ■   ");
            Console.WriteLine("                  ■         ■    ");
            Console.WriteLine("                   ■  ■ ■  ■     ");
            Console.WriteLine("                    ■     ■      ");
        }

        void Angel()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine("                              ■■■■■                        ");
            Console.WriteLine("                          ■           ■                    ");
            Console.WriteLine("                              ■ ■ ■                        ");
            Console.WriteLine("                          ■           ■                    ");
            Console.WriteLine("      ■            ■     ■  ■       ■  ■     ■             ");
            Console.WriteLine("    ■ ■ ■      ■      ■  ■     ■■■      ■  ■      ■        ");
            Console.WriteLine("      ■     ■     ■      ■              ■      ■     ■     ");
            Console.WriteLine("      ■                   ■           ■                    ");
            Console.WriteLine("                             ■      ■                      ");
            Console.WriteLine("                                ■ ■                        ");
            Console.WriteLine("                                 ■                         ");
        }

        void Dead()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine("                   ■ ■ ■ ■      ");
            Console.WriteLine("                   ■     ■      ");
            Console.WriteLine("             ■ ■ ■ ■     ■ ■ ■ ■");
            Console.WriteLine("             ■      R.I.P.     ■");
            Console.WriteLine("             ■ ■ ■ ■     ■ ■ ■ ■");
            Console.WriteLine("                   ■     ■      ");
            Console.WriteLine("                   ■     ■      ");
            Console.WriteLine("                   ■     ■      ");
            Console.WriteLine("                   ■     ■      ");
            Console.WriteLine("                   ■     ■      ");
            Console.WriteLine("                   ■ ■ ■ ■      ");
        }
    }
}
