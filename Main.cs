using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBSHAGA
{
    class Run
    {

        static void Main(string[] args)
        {
            qGame myGame = new qGame();
            myGame.RunMainMenu();

            string prompt = "Начать с начала?\n";
            List<string> options = new List<string>()
            {
                "В главное меню",
                "Новая игра",
                "Продолжить",
                "Выйти из игры"
            };

            Menu mainMenu = new Menu(prompt, options, 101);
            int selectedIndex = mainMenu.Run();

            do
            {
                switch (options[selectedIndex])
                {
                    case "В главное меню":
                        myGame.RunMainMenu();
                        selectedIndex = mainMenu.Run();
                        break;

                    case "Новая игра":
                        myGame.NewGame();
                        selectedIndex = mainMenu.Run();
                        break;

                    case "Продолжить":
                        myGame.Resume();
                        selectedIndex = mainMenu.Run();
                        break;
                }
            }
            while (options[selectedIndex] != "Выйти из игры");
        }
    }
}
