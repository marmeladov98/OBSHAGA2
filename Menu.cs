using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBSHAGA
{
    class Menu
    {
        private int SelectedIndex; //Номер пункта
        private List<string> Options; //Строка с выбором нужного пункта
        private string Prompt; //Строка Меню
        private int Health; // Кол-во HP
        private int Sigi;

        public Menu(string prompt, List<string> options, int health, int sigi)
        {
            Prompt = prompt;
            Health = health;
            Sigi = sigi;
            Options = options;
            SelectedIndex = 0;

        }

        private void DisplayOptions() // Визуализация движения курсора
        {
            if (Health == 101) Console.Write(Prompt + "\n\n");
            else
            {
                Console.Write("\nЗдоровье: ");
                if (Health >= 50) Console.ForegroundColor = ConsoleColor.Green;
                else if (Health < 50 && Health >= 30) Console.ForegroundColor = ConsoleColor.Yellow;
                else if (Health < 30) Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(Health);
                Console.ResetColor();
                Console.Write(" | Сигарет: " + Sigi + "\n\n");
                Console.Write(Prompt + "\n\n");
            }

            for (int i = 0; i < Options.Count; i++)
            {
                string currentOption = Options[i];
                string prefix;
                if (i == SelectedIndex)
                {
                    prefix = "*";
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    prefix = " ";
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine($"{prefix} << {currentOption} >>");
            }
            Console.ResetColor();
        }

        public int Run()
        {
            ConsoleKey keyPressed;
            do
            {
                Console.Clear();
                DisplayOptions();
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                //Обновление курсора
                if (keyPressed == ConsoleKey.UpArrow)
                {
                    SelectedIndex--;
                    if (SelectedIndex == -1)
                    {
                        SelectedIndex = Options.Count - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    SelectedIndex++;
                    if (SelectedIndex == Options.Count)
                    {
                        SelectedIndex = 0;
                    }
                }
            }
            while (keyPressed != ConsoleKey.Enter);

            return SelectedIndex;

        }
    }
}
