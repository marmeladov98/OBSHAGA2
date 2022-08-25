using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OBSHAGA
{

    class qGame
    {
        public qGame()
        {
            code = Codename();                                  // Кодовое слово для входа к Алексею
            girlName = GirlNames();                             // Имя девушки
            codeCut = code.Substring(3);
        }
        bool phone = true;
        bool phoneNumber = false;                               // Оставить девушке номер телефона
        bool sosed = true;
        bool Key = false;                                       // Ключ для открытия двери
        bool Sam = false;                                       // Сэм выбежал из шкафа?
        bool shkaf = false;                                     // Чтобы нельзя было бесконечно брать сиги из шкафа
        bool Vodka = false;                                     // Нужен для получения инф от Ивана
        bool Ivan = true;                                       // Иван жив или же набухан в сраку
        bool KitchenSigi = false;                               // Проверка поиска на полках кухни
        bool keycard = false;                                   // Пропуск для выхода из общаги
        bool drunk = false;                                     // Проверяет твое алкогольное опьянение
        bool tualet = false;                                    // Информирование об Иване в прихоже 806. Если тру - разговор с уже Иваном был
        bool Door806 = false;                                   // Проверка открыта ли дверь в начальной комнате.
        bool angryComenda = false;                              // Состояние коменды. Если тру - оставаться на этаже опасно
        bool angryGuard = false;                                // Состояни охраны на КПП. Если тру - выходить опасно.
        bool GoshaNeverSleep = false;                           // Гоша проснулся?
        bool thiefSigi = false;                                 // Сиги украдены?
        bool girl = false;
        bool botan = false;
        bool xpysteam = true;
        bool girlQ = true;                                      // Вопрос о девушке у Гоши
        string code = null;                                     // Кодовое слово для входа к Алексею
        string codeCut = null;
        string girlName = null;                                 // Имя девушки
        int health = 80;                                        // Текущее здоровье
        int attempt = 2;                                        // Кол-во попыток, чтобы угадать код Алексея
        int sigiGoshi = 2;                                      // Кол-во сигарет в пачке у Гоши
        int sigi = 0;                                           // Кол-во сигарет в инвентаре (для балкона)
        int RoomNumber = 1;                                     /* Определение номера комнаты: 
                                                                    1 - Начальная комната (будильник и девушка), 
                                                                    2 - Прихожя 806 (Иван), 
                                                                    3 - Коридор 8 этажа, 
                                                                    4 - Кухня на 8 этаже, 
                                                                    5 - Коридор 1 этажа, 
                                                                    6 - Балкон 9 этажа,
                                                                    7 - Гоша 915 блок на 9 этаже, 
                                                                    8 - Алексей 913 блок на 9 этаже, 
                                                                    9 - Коридор 9 этажа.*/

        public void Intro()                                     // Текст вступления - Интро
        {
            RoomNumber = 1;
            Console.Clear();
            Console.WriteLine("Добро пожаловать в Общагу!\n");
            Console.WriteLine("Данная игра представляет собой текстовый квест, где выбор игрока влияет на развитие сюжета.");
            Console.WriteLine("Игровой персонаж - студент, который пришел на вечеринку в общежитие к друзьям.");
            Console.WriteLine("Основная задача - покинуть общежитие в добром здравии.");
            Console.WriteLine("Для продолжения нажмите Enter.");
            Console.WriteLine("Удачи!");
            Console.WriteLine("___");
            Console.ReadLine();
            WakeUp();
        }
        void WakeUp() {
            Console.Clear();
            PrintText("Ты просыпаешься в общежитии товарища от звонка будильника, который забыл выключить накануне.");
            PrintText("Твоя голова раскалывается из-за большого количества выпитого алкоголя.\n");
            PrintText("В комнате висит едкий запах перегара и остатков еды на столе.");
            PrintText("Ты сразу вспоминаешь, что ты находишься здесь не совсем официально.\n");
            PrintText("Именно поэтому, нужно покинуть общежитие как можно быстрее и не попасться администрации.");
            PrintText("Твои размышления прерывает какой-то потрепанный парень своими яростными криками с соседней кровати.");
            PrintText("Оторвавшись от размышлений ты слышишь, что он в грубой форме требует выключить будильник!");

            Console.ReadLine();
            AlarmClock();
        }

        void AlarmClock()                                   // Выключение будильника
        {
            RoomNumber = 1;
            string prompt = "Доступные действия:\n";
            List<string> options = new List<string>() { "Выключить будильник", "Послать соседа нахуй", "Затупить" };
            Menu mainMenu = new Menu(prompt, options, health, sigi);
            int selectedIndex = mainMenu.Run();
            Console.Clear();
            switch (selectedIndex)
            {
                case 0:
                    PrintText("\nТы отключаешь будильник, буйный сосед моментально успокаивается и засыпает.");
                    PrintText("Теперь можно выдохнуть и все хорошенько обдумать.");
                    Console.ReadLine();
                    PrintText("Неожиданно ты замечаешь спящую рядом симпатичную незнакомку примерно твоего же возраста.");
                    PrintText("Кажется, итог вчерашней вечеринки был приятнее, чем тебе казалось :)");
                    Console.ReadLine();
                    PrintText("На тебя накатывает желание обнять ее и последовать примеру соседа - продолжить сон.");
                    PrintText("К тому же это твой шанс завести новые романтические отношения.");
                    Console.ReadLine();
                    PrintText("С другой стороны, оставаться в общежитии опасно. Нужно принять решение!");
                    Console.ReadLine();
                    Bed();
                    break;

                case 1:
                    PrintText("\nНе выдержав шума будильника, сосед вскакивает с кровати, выхватывает телефон из твоих рук и бросает его в сторону окна.");
                    PrintText("С невероятной точностью, телефон отправляется прямо в открую форточку... Его уже не спасти");
                    Console.ReadLine();
                    PrintText("Нахлынувшая ярость позволяет тебе вырубить соседа с одного не менее точного удара по голове.");
                    PrintText("После удара ты чувствуешь боль в кулаке.");
                    health = СalculationHealth(health, 20, true);
                    if (health == 0) break;
                    phone = false;
                    sigi++;
                    Key = true;
                    PrintText("Немного успокоившись, ты замечаешь ключ от комнаты и одну сигарету рядом с кроватью, выпавшие из штанов соседа.");
                    PrintText("Количество сигарет в кармане: " + sigi);
                    Console.ReadLine();
                    PrintText("Оглядевшись, ты замечаешь в своей кровати спящую красотку примерно твоего возраста.");
                    PrintText("Кажется, итог вчерашней вечеринки был приятнее, чем тебе казалось :)");
                    Console.ReadLine();
                    PrintText("На тебя накатывает желание обнять ее и продолжить сон.");
                    PrintText("К тому же это твой шанс завести новые романтические отношения.");
                    Console.ReadLine();
                    PrintText("С другой стороны, оставаться в общежитии опасно.");
                    PrintText("Тем более сосед может очнуться. Нужно принять решение!");
                    Console.ReadLine();
                    sosed = false;
                    Bed();
                    break;

                case 2:
                    PrintText("\nТы озадаченно смотришь то на него, то на будильник, то на комнату.");
                    PrintText("Не выдержав шума будильника, сосед вскакивает с кровати и выхватывает телефон из твоих рук.");
                    Console.ReadLine();
                    PrintText("Отключив будильник, он дерзко бросает телефон обратно со словами:");
                    PrintText("- Ало, ты что, сидя заснул? Жестко ты вчера тусил... Держи сигу - взбодрись!");
                    Console.ReadLine();
                    PrintText("Сосед достает сигарету из пачки и бросает рядом телефоном.");
                    sigi++;
                    PrintText("Количество сигарет: " + sigi);
                    Console.ReadLine();
                    PrintText("Не дождавшись ответа, он возвращается обратно в постель.");
                    Console.ReadLine();
                    PrintText("Еще немного посмотрев в одну точку, ты начинаешь приходить в себя.");
                    PrintText("Оглядевшись, ты замечаешь рядом спящую красотку примерно твоего возраста.");
                    PrintText("Кажется, итог вчерашней вечеринки был приятнее, чем тебе казалось!");
                    Console.ReadLine();
                    PrintText("Накатывает сильное желание обнять ее и продолжить сон.");
                    PrintText("К тому же это твой шанс завести долгожданные отношения.");
                    Console.ReadLine();
                    PrintText("С другой стороны, оставаться в общежитии опасно.");
                    PrintText("Нужно принять решение!");
                    Console.ReadLine();
                    Bed();
                    break;
            }
        }

        void Bed()                                          //Активность в кровати 
        {
            string prompt = "Доступные действия:\n";
            List<string> options = new List<string>() { "Обнять девушку и продолжить спать", 
                                                        "Одеться и найти способ выбраться",
                                                        "Начать приставать к девушке" };
            if (phone) options.Add("Залипнуть в инсте");
            Menu mainMenu = new Menu(prompt, options, health, sigi);
            int selectedIndex = mainMenu.Run();
            Console.Clear();
            switch (options[selectedIndex])
            {
                case "Обнять девушку и продолжить спать":
                    Console.Clear();
                    PrintText("\nТы засыпаешь рядом с прекрасной дамой.");
                    Console.ReadLine();
                    PrintText("Некоторое время спустя ты подскакиваешь от громких стуков в дверь и криков.");
                    PrintText("Открыв глаза, ты обнаруживаешь вламывающуюся коменду с двумя крупкими охранниками.");
                    Console.ReadLine();
                    PrintText("Нужно было уходить! Теперь у тебя будут неприятности...");
                    Console.ReadLine();
                    Lose();
                    break;

                case "Одеться и найти способ выбраться":
                    Console.Clear();
                    PrintText("\nТы неохотно встаешь с кровати и медленно натягиваешь разбросанную по комнате одежду.");
                    PrintText("Очень тяжело покидать теплую кровать, но тебе нужно выбраться из общежития и не попасться в лапы коменданта.");
                    Console.ReadLine();
                    Room806();
                    break;

                case "Залипнуть в инсте":
                    PrintText("\nТы начинаешь смотреть смешные видосики из ленты.");
                    PrintText("Ого, оказывается ребята вчера записывали сторис!");
                    health = СalculationHealth(health, 5, false);
                    PrintText("Проснувшись от громких звуков, девушка что-то бубнит себе под нос.");
                    PrintText("После чего отворачивается и накрывает голову подушкой.");
                    Console.ReadLine();
                    PrintText("Ты неохотно встаешь с кровати и медленно натягиваешь разбросанную по комнате одежду.");
                    PrintText("Очень тяжело покидать теплую кровать, но тебе нужно выбраться из общежития и не попасться в лапы коменданта.");
                    Console.ReadLine();
                    options.Remove("Залипнуть в инсте");
                    Room806();
                    break;
                    
                case "Начать приставать к девушке":
                    PrintText("\nТвоя рука под одеялом совершает сближение с грудью девушки.");
                    PrintText("Соприкосновение... Вроде бы она ничего не заметила!");
                    Console.ReadLine();
                    PrintText("После такого ты чувствуешь себя лучше!");
                    health = СalculationHealth(health, 5, false);
                    Boobs();
                    break;
            }
        }

        void Boobs()
        { 
            while (RoomNumber == 1)
            { 
                string prompt = "Доступные действия:\n";
                List<string> options = new List<string>() { "Продолжить", 
                                                            "Закончить" };
                Menu mainMenu = new Menu(prompt, options, health, sigi);
                int selectedIndex = mainMenu.Run();
                Console.Clear();
                switch (selectedIndex)
                {
                    case 0:
                        Random rnd = new Random();
                        int value = rnd.Next(3);
                        PrintText("\nТы продолжаешь мять грудь девушки.");
                        if (value == 0 || value == 1 && health != 100)
                        {
                            PrintText("Она все еще не реагирует.");
                            health = СalculationHealth(health, 5, false);
                        }
                        else
                        {
                            PrintText("Увлекшись, ты слишком сильно сжимаешь ее упругую прелесть!");
                            Console.ReadLine();
                            PrintText("Проснувшаяся девушка, поняв что происходит, начинает ругаться сонным голосом:");
                            PrintText("- Ты совсем ахуел? Руку убери! Мы не одни в комнате!");
                            Console.ReadLine();
                            PrintText("Дав заслуженную пощечину, она отворачивается и накрывает голову подушкой.");
                            health = СalculationHealth(health, 5, true);
                            if (health == 0) break;
                            PrintText("Больно. Но оно того стоило! Да и сон как рукой сняло!");
                            Console.ReadLine();
                            PrintText("Ты неохотно встаешь с кровати и медленно натягиваешь разбросанную по комнате одежду.");
                            PrintText("Очень тяжело покидать теплую кровать, но тебе нужно выбраться из общежития и не попасться в лапы коменданта.");
                            Console.ReadLine();
                            break;
                        }
                        continue;
                        

                    case 1:
                        PrintText("\nТы аккуратно убираешь руку.");
                        PrintText("Настроение просто прекрасное! Сон как рукой сняло.");
                        Console.ReadLine();
                        PrintText("Встав с кровати, ты резво натягиваешь разбросанную по комнате одежду.");
                        PrintText("Настало время приключений!");
                        Console.ReadLine();
                        break;
                }
                break;
            }                     
            Room806();
        }

        void Room806()                                      //Действия в 806 комнате
        {
            Console.Clear();
            RoomNumber = 1;
            string prompt = "Доступные действия:\n";
            List<string> options = new List<string>() { "Обыскать комнату", "Вернуться в кровать" };
            if (!phoneNumber && phone) options.Add("Оставить девушке номер телефона");
            if (!Door806 && !Key)
            {
                if (sosed)
                {
                    PrintText("Сосед и незнакомка крепко спят.");
                    PrintText("Ты подходишь к двери и дергаешь за ручку. Заперто на ключ.");
                }
                else
                {
                    PrintText("Девушка продолжает крепко спать. Сосед без сознания.");
                    PrintText("Ты подходишь к двери и дергаешь за ручку.");
                    PrintText("Заперто на ключ.");
                }
                options.Add("Попробовать силой открыть дверь");
            }
            else if (Key && !Door806)
            {
                PrintText("Ты подходишь к двери в прихожую и дергаешь за ручку.");
                PrintText("Заперто на ключ.");
                options.Add("Использовать ключ");
            }
            else if (Door806)
            {
                PrintText("Обстановке в комнате без изменений - все в полном отрубе.");
                PrintText("Дверь в прихожую открыта.");
                options.Add("Выйти в прихожую");
                options.Remove("Попробовать силой открыть дверь");
            }

            Console.ReadLine();

            Menu mainMenu = new Menu(prompt, options, health, sigi);
            int selectedIndex = mainMenu.Run();

            Console.Clear();

            switch (options[selectedIndex])
            {
                case "Обыскать комнату":
                    SearchR806();
                    break;

                case "Попробовать силой открыть дверь":
                    PrintText("Ты несколько раз бьешь ногой по двери рядом с замком, как это делали в фильмах.");
                    PrintText("Неудачно рассчитав удар, ты повреждаешь ногу.");
                    health = СalculationHealth(health, 10, true);
                    if (health == 0) break;
                    PrintText("На удивление, дверь с грохотом распахивается!");
                    PrintText("Ты попадаешь в прихожую блока.");
                    Console.ReadLine();
                    PrintText("Из комнаты раздаются недовольные возгласы:");
                    PrintText("- Голова раскалывается, потише!");
                    Console.ReadLine();
                    PrintText("Видимо, твоя выходка их сейчас не сильно беспокоит.");
                    PrintText("Да уж, знатная вчера была вечеринка!");
                    Console.ReadLine();
                    PrintText("Несколько мгновений спустя, ты слышишь громкий стук в дверь.");
                    PrintText("Открывайте! Что у вас там происходит?");
                    PrintText("Обернувшись, ты видишь комендантшу с двумя крепкими охранниками.");
                    Console.ReadLine();
                    Lose();
                    break;

                case "Вернуться в кровать":
                    PrintText("Не справившись с навалившейся усталостью, ты снимаешь вещи.");
                    PrintText("Украткой взглянув на девушку, с улыбкой возвращаешься под одеяло.");
                    PrintText("Приобняв красавицу, ты засыпаешь в прекрасной компании.");
                    Console.ReadLine();
                    PrintText("Некоторое время спустя ты подскакиваешь от громких стуков в дверь и криков.");
                    PrintText("Открыв глаза, ты обнаруживаешь входящую коменду с двумя крупкими охранниками.");
                    Console.ReadLine();
                    PrintText("От ее гнева тебя уже ничего не спасет!");
                    Console.ReadLine();
                    health = СalculationHealth(health, 100, true);
                    if (health == 0) break; 
                    break;

                case "Оставить девушке номер телефона":
                    PrintText("Заметив на тумбочке рядом с кроватью салфетку и лежащую рядом ручку, тебе в голову приходит мысль.");
                    PrintText("Ты пишешь на салфетке свой номер телефона, имя и в конце рисуешь сердечко <3.");
                    PrintText("Оставляешь записку на тумбе.");
                    Console.ReadLine();
                    phoneNumber = true;
                    options.Remove("Оставить девушке номер телефона");
                    Room806();
                    break;

                case "Использовать ключ":
                    PrintText("\nТы аккуратно приблизился к двери, медленно вставил ключ и попробовал его провернуть.");
                    PrintText("Успех! Ключ подошел. Дверь открыта.");
                    options.Remove("Использовать ключ");
                    Door806 = true;
                    RoomNumber = 2;
                    Console.ReadLine();
                    Room806();
                    break;

                case "Выйти в прихожую":
                    RoomNumber = 2;
                    IToilet();
                    break;
            }
            return;
        }

        void SearchR806()                                   //Обыск коммнаты начальной комнаты
        {
            RoomNumber = 1;
            bool att = true;
            PrintText("Ты решаешь осмотреть комнату в поисках вещей, которые смогут помочь выбраться.");
            Console.ReadLine();

            while (RoomNumber == 1)
            {
                string prompt = "Доступные действия:\n";
                List<string> options = new List<string>()
                {
                    "Поискать под кроватью",
                    "Поискать на столе",
                    "Поискать в шкафу",
                    "Поискать в тумбочке" 
                };
                if (sosed) options.Add("Поискать в карманах соседа");
                else options.Remove("Поискать в карманах соседа");
                if (Key && !Door806) options.Add("Использовать ключ");
                options.Add("Закончить поиски");
                if (Door806) options.Add("Выйти в прихожую");
                Menu mainMenu = new Menu(prompt, options, health, sigi);
                int selectedIndex = mainMenu.Run();
                Console.Clear();        
                switch (options[selectedIndex])
                {
                    case "Поискать под кроватью":
                        if (!Vodka && Ivan)
                        {
                            Vodka = true;
                            PrintText("\nТы заглядываешь под кровать и обнаруживаешь там бутылку водки.");
                            PrintText("Недолго думая, ты достаешь ее, сделав несколько целебных глотков. ");
                            PrintText("Оставшуюся часть берешь себе. Лечебное зелье всегда должно быть под рукой!");
                            Console.ReadLine();
                            health = СalculationHealth(health, 20, false);
                            PrintText("Головная боль потихньку начала отпускать.");
                            Console.ReadLine();
                            continue;
                        }
                        else
                        {
                            PrintText("\nТы решаешь повторно заглянуть под кровать.");
                            PrintText("Однако ничего нового, кроме использованного презерватива ты не обнаруживаешь.");
                            Console.ReadLine();
                            continue;
                        }

                    case "Поискать на столе":
                        if (!xpysteam)
                        {
                            PrintText("\nНа столе все еще лежит пустая пачка сигарет, грязная посуда и опусташенная тобой пачка 'ХРУСteam'.");
                            PrintText("Ничего полезного.");
                            Console.ReadLine();
                        }
                        else
                        {
                            PrintText("\nНа столе ты находишь пустую пачку сигарет, грязную посуду и открытую пачку сухариков 'ХРУСteam'.");
                            PrintText("\nНемедленно опустошив пачку, ты чувствуешь некоторое облегчение.\n");
                            xpysteam = false;
                            health = СalculationHealth(health, 5, false);
                            PrintText("На столе больше ничего полезного. Необходимо вернуться к поискам!");
                            Console.ReadLine();
                        }
                        continue;

                    case "Поискать в шкафу":
                        if (!Door806)
                        {
                            PrintText("\nТы осторожно отодвигаешь щеколду шкафа и начинаешь открывать шкаф.");
                            PrintText("Однако дверца стремительно распахивается и мощным ударом опрокидывает тебя на пол.");
                            PrintText("Темная фигура выбегает из шкафа и начинает громко ругаться матом на английском...");
                            health = СalculationHealth(health, 75, true);
                            if (health == 0) break;
                            PrintText("Придя в себя, ты обнаруживаешь, что дверь в комнату открыта.");
                            PrintText("Кажется, этот чувак всю ночь сидел в шкафу...");
                            Sam = true;
                            Door806 = true;
                            Console.ReadLine();
                            PrintText("Тусовка прошла успешно, раз ты не помнишь, как вы заперли кого-то в шкафе.");
                            PrintText("Потерев лоб, ты решаешь продолжить поиски.");
                            continue;
                        }

                        else if (Door806 && !Sam)
                        {
                            Sam = true;
                            PrintText("\nТы отодвигаешь щеколду шкафа и медленно открываешь скрипучую дверцу...");
                            Console.ReadLine();
                            PrintText("Дверца стремительно распахивается и больно бьет тебя по голове.");
                            health = СalculationHealth(health, 20, true);
                            if (health == 0) break;
                            PrintText("Из шкафа выскакивает темнокожий парень, он покидает комнату, параллельно матерясь на английском.");
                            Console.ReadLine();
                            PrintText("Рядом со шкафом лежит визитка. Часть текста стерта: '..." + codeCut.Substring(0, codeCut.Length - 2) + "...'");
                            PrintText("Интересно, что бы это могло значить? Ты, потирая ушиб, кладешь визитку обратно.");
                            Console.ReadLine();

                        }

                        else if (Door806 && Sam && !shkaf)
                        {
                            sigi++;
                            shkaf = true;
                            PrintText("\nТы решаешь повторно проверить содержимое шкафа.");
                            PrintText("Дверца осталась приоткрытой с прошлого инцидента.");
                            Console.ReadLine();
                            PrintText("Внимательно осмотрев содержимое, ты замечаешь сиграету среди прочего хлама.");
                            PrintText("Забираешь ее себе.\nКоличество сиграет в кармане: " + sigi);
                            Console.ReadLine();
                            PrintText("Рядом лежит такая же карточка с надписью '..." +  codeCut.Substring(0, codeCut.Length - 2)  + "...'");
                            PrintText("Что бы это могло значить?");
                            Console.ReadLine();
                        }
                        else if (Door806 && Sam && shkaf)
                        {
                            PrintText("\nВ очередной раз ты решаешь проверить шкаф.");
                            PrintText("Дверца все еще приоткрыта.");
                            Console.ReadLine();
                            PrintText("Проход в Нарнию так и не появился.");
                            PrintText("Зато, по-прежнему, лежит визитка с надписью '..." + codeCut.Substring(0, codeCut.Length - 2) + "...'");
                            Console.ReadLine();
                        }
                        continue;


                    case "Поискать в карманах соседа":
                        if (!Key)
                        {
                            if (!Door806)
                            {
                                PrintText("\nТы видишь, как нужный ключ чуть ли не вываливается из кармана соседа.");
                                PrintText("Один миг и ключ уже у тебя руке! Это было слишком просто!");
                                Console.ReadLine();
                                PrintText("Теперь ты можешь открвыть дверь. Хотя кто знает какие еще секреты может хранить комната общежития...");
                                Key = true;
                                Console.ReadLine();
                            }
                            else
                            {
                                PrintText("\nТы видишь, как нужный ключ чуть ли не вываливается из кармана соседа.");
                                PrintText("Но зачем он тебе? Дверь уже открыта.");
                                Console.ReadLine();
                                PrintText("Стоит ли тогда лазить по чужим карманам?");
                                Console.ReadLine();
                                NeighborRaid();
                            }
                        }
                        else
                        {
                            PrintText("\nТы решаешь, что повторно обыскать соседа - вовсе неплохая идея.");
                            PrintText("'Нехуй было орать из-за будильника, долбаеб!' - примечаешь ты и лезешь исследовать карманы.");
                            Console.ReadLine();
                            PrintText("Нащупав в его штанах пачку сигарет, ты пытаешься аккуратно ее вытащить.");
                            PrintText("Еще немного и сигареты станут твоими!");
                            Console.ReadLine();
                            PrintText("Как в фильме ужасов, сосед резко открывает глаза, хватает тебя за горло и бьет по щеке.");
                            health = СalculationHealth(health, 40, true);
                            if (health == 0) break;
                            PrintText("Не растерявшись, ты перехватываешь инициативу и несколько раз бьешь соседа в ответ.");
                            PrintText("Оппонент лежит на кровати без сознания. Ты забираешь сигареты себе и отходишь.");
                            sigi++;
                            Console.ReadLine();
                            PrintText("Количество сиграет в кармане: " + sigi);
                            sosed = false;
                            options.Remove("Поискать в карманах соседа");
                        }
                        continue;

                    case "Поискать в тумбочке":         
                        if (att)
                        {
                            PrintText("Открыв дверцу, ты видишь только бесполезный мусор и хлам.");
                            PrintText("Ничего полезного.");
                            Console.ReadLine();
                            att = false;
                        }
                        else
                        {
                            PrintText("Открыв дверцу еще раз, ты видишь среди хлама оторванную часть визитки с надписью:\n'..." + code.Remove(0,7) +"'");
                            PrintText("- Это что еще за хрень? - думаешь ты, возвращаясь к поискам.");
                            Console.ReadLine();
                        }
                        continue;

                    case "Использовать ключ":
                        if (!Door806 && Key)
                        {
                            PrintText("\nТы аккуратно приблизился к двери, медленно вставил ключ и попробовал его провернуть.");
                            PrintText("Успех! Ключ подошел. Дверь открыта.");
                            Console.ReadLine();

                            options.Remove("Использовать ключ");
                            Door806 = true;
                            Room806();
                        }
                        else
                        {
                            PrintText("\nТы подошел к двери, потянул за ручку и вышел из комнаты.");
                            Console.ReadLine();
                            IToilet();
                        }
                        options.Remove("Закончить поиски");
                        break;

                    case "Выйти в прихожую":
                        RoomNumber = 2;
                        options.Remove("Выйти в прихожую");
                        IToilet();
                        break;

                    case "Закончить поиски":
                        PrintText("\nТы решаешь закончить поиски.");
                        Console.ReadLine();
                        options.Remove("Закончить поиски");
                        Room806();
                        break;
                }
                return;
            }
        }
        void NeighborRaid()
        {
            string prompt = "Доступные действия:\n";
            List<string> options = new List<string>() { "Обыскать карманы", "Не беспокоить" };
            Menu mainMenu = new Menu(prompt, options, health, sigi);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Console.Clear();
                    Key = true;
                    PrintText("\nТы все же решаешься обыскать соседа в поисках наживы.");
                    PrintText("Приблизившись, ты мдленно просовываешь руку в карман.");
                    Console.ReadLine();
                    PrintText("Нащупав пачку сигарет, ты пытаешься аккуратно ее вытащить.");
                    PrintText("Еще мгновенье и сигареты станут твоими!");
                    Console.ReadLine();
                    PrintText("Как в фильме ужасов, сосед резко открывает глаза, хватает тебя за горло и бьет по щеке.");
                    health = СalculationHealth(health, 40, true);
                    if (health == 0) break;
                    PrintText("Не растерявшись, ты перехватываешь инициативу и несколько раз бьешь соседа в ответ.");
                    PrintText("Оппонент лежит на кровати без сознания. Ты забираешь сигареты себе и отходишь.");
                    sigi++;
                    sosed = false;
                    Console.ReadLine();
                    PrintText("Количество сиграет в кармане: " + sigi);
                    Console.ReadLine();
                    SearchR806();
                    break;

                case 1:
                    Console.Clear();
                    PrintText("\n-Ну я же не вор ебаный!");
                    PrintText("\nДумаешь ты, и отходишь от кровати соседа.");
                    Console.ReadLine();
                    SearchR806();
                    break;
            }
            return;
        }

        void IToilet()                                      //Прихожая 806 блока + Иван. 
        {
            RoomNumber = 2;
            Console.Clear();
            PrintText("Ты в прихожей 806 блока. Двери в коридор и комнату открыты.");
            if (!tualet)
            {
                PrintText("Чтобы проскользнуть мимо охраны и выбраться из общежития, тебе понадобится пропуск.");
                PrintText("Но где его взять? Всех, с кем ты вчера пил, разбросало по общежитию.");
                Console.ReadLine();
                PrintText("Внезапно в туалете раздались звуки отторжения, вызванные алкогольной интоксикацией.");
                PrintText("Судя по звукам, это Иван. И кажется, он немного перебрал вчера.");
                Console.ReadLine();
                PrintText("Он может дать тебе свой пропуск. Но стоит ли его беспокоить в таком состоянии?");
                tualet = true;
            }
            Console.ReadLine();
            while (RoomNumber == 2)
            {
                string prompt = "Доступные действия:\n";
                List<string> options = new List<string>() { "Выйти в коридор", "Вернуться в комнату" };
                if (Ivan) options.Add("Спросить про пропуск");
                if (Vodka) options.Add("Предложить водку");

                Menu mainMenu = new Menu(prompt, options, health, sigi);

                Console.Clear();

                int selectedIndex = mainMenu.Run();

                switch (options[selectedIndex])
                {
                    case "Выйти в коридор":
                        if (Ivan)
                        {
                            PrintText("Ты решаешь не беспокоить Ивана и с опаской выходишь в коридор общежития.");
                            Console.ReadLine();
                            RoomNumber = 3;
                            Corridor8();
                        } else
                        {
                            PrintText("Ты с опаской выходишь в коридор общежития.");
                            Console.ReadLine();
                            RoomNumber = 3;
                            Corridor8();
                        }
                        break;

                    case "Вернуться в комнату":
                        Room806();
                        break;

                    case "Спросить про пропуск":
                        PrintText("Ты осторожно подходишь к двери, стучишься и шепотом произносишь:");
                        PrintText("- О, преподобный dungeon master, помоги мне выбраться из общаги.");
                        Console.ReadLine();
                        PrintText("Иван, угарнув, отвечает измучанным голосом, что он не в состоянии идти.");
                        PrintText("Сильная головная боль не позволяет ему четко выговаривать слова, из-за чего понять его очень сложно.");
                        Console.ReadLine();
                        PrintText("Все, что тебе удалось разобрать – в 913 блоке можно взять пропуск.");
                        PrintText("Ивану явно не мешало бы опохмелиться…");
                        Ivan = false;
                        options.Remove("Спросить про пропуск");
                        continue;

                    case "Предложить водку":
                        options.Remove("Предложить водку");
                        Vodka = false;
                        Ivan = false;
                        tualet = true;

                        PrintText("Ты достаешь из-за пазухи бутыль и предлагаешь Ивану вдарить по беленькой.");
                        PrintText("Дверь в туалет резко открывается, оттуда вылезает рука с широко распахнутыми пальцами.");
                        Console.ReadLine();
                        PrintText("Ты с опаской вкладываешь полупустую бутылку водки в руку товарища.");
                        PrintText("Пальцы молниеносно сжимают бутылку, рука затягивается обратно в туалет и дверь стремительно закрывается.");
                        Console.ReadLine();
                        PrintText("Несколько глотков спустя Иван решительно заявляет:");
                        PrintText("- В 913 блоке сейчас откисает Алексей, ты можешь взять мой пропуск у него.");
                        PrintText("Но он пускает в свою комнату только по кодовому слову – '" + code.Remove(6, code.Length - 6) + "...'.");
                        Console.ReadLine();
                        PrintText("Речь Ивана резко прерывает рвотный позыв.");
                        PrintText("Кажется, Иван будет недоступен ближайшее время.");
                        Console.ReadLine();
                        continue;
                }
            }
        }

        void Corridor8()                                    //Коридор 8 этажа. 
        {
            RoomNumber = 3;

            PrintText("Рядом находится дверь с табличкой 'Комендант', лестница и лифт.");
            PrintText("В конце коридора виднеется кухня.");
            Console.ReadLine();

            Console.Clear();

            string prompt = "Доступные действия:\n";
            List<string> options = new List<string>() { "Заглянуть на кухню",
                                                        "Воспользоваться лифтом",
                                                        "Пойти по лестнице",
                                                        "Постучать в дверь коменде и убежать",
                                                        "Вернуться в 806 блок" };
            Menu mainMenu = new Menu(prompt, options, health, sigi);
            int selectedIndex = mainMenu.Run();
            switch (selectedIndex)
            {
                case 0:
                    Console.Clear();
                    PrintText("Ты на цыпочках пробираешься в общажную кухню.");
                    PrintText("Здесь пахнет одновременно гречкой с курицей, дошираком и чебупелями.");
                    Console.ReadLine();
                    PrintText("Ты видишь незнакомых студентов, которые занимаются своими делами.");
                    PrintText("Никто даже не заметил твое присутствие.");
                    Console.ReadLine();
                    Kitchen();
                    break;

                case 1:
                    Console.Clear();
                    PrintText("Ты подходишь к лифту и останавливаешся, чтобы подумать.");
                    PrintText("Не слишком ли рискованно ехать на лифте? Наверняка, его придется долго жадть...");
                    Console.ReadLine();
                    ElevatorCall();
                    break;

                case 2:
                    Ladder();
                    break;

                case 3:
                    PrintText("Ты решаешь порофлить над комендой классическим способом.");
                    PrintText("Приблизившись к двери, ты громко стучишь 3 раза.");
                    Console.ReadLine();
                    angryComenda = true;
                    ActionPobeg();
                    break;

                case 4:
                    PrintText("Ты подходишь к блоку с номером 806.");
                    PrintText("Осторожно приоткрыв дверь, возвращаешься в прихожую.");
                    Console.ReadLine();
                    IToilet();
                    break;
            }
        }

        void Kitchen()                                      //Кухня 
        {
            RoomNumber = 4;
            while (RoomNumber == 4)
            {
                string prompt = "Доступные действия:\n";
                List<string> options = new List<string>() { "Пообщаться со студентами",
                                                            "Обыскать кухню",
                                                            "Отобрать чужую еду",
                                                            "Купить еду",
                                                            "Выйти в коридор" };
                Menu mainMenu = new Menu(prompt, options, health, sigi);
                int selectedIndex = mainMenu.Run();
                switch (options[selectedIndex])
                {
                    case "Пообщаться со студентами":
                        PrintText("\nВозле плиты стоит хрупкая девушка, у входа стоит какой-то лысый скинхед, в углу комнаты ест ботан.");
                        Console.ReadLine();
                        KitchenDialogs();
                        break;

                    case "Обыскать кухню":
                        PrintText("\nТы решаешь обыскать кухню.");
                        PrintText("Но где лучше начать поиски?");
                        Console.ReadLine();
                        KitchenSearch();
                        break;

                    case "Отобрать чужую еду":
                        PrintText("\nПриятный запах пробуждает в тебе зверский голод.");
                        PrintText("Ты вспоминаешь, что не ел со вчерашнего дня. Нужно срочно исправлять ситуацию!");
                        Console.ReadLine();
                        PrintText("Оглядев обедующих студентов, ты заметил одинокого тощего ботана в очках.");
                        PrintText("Рядом с ним стоит тарелка с криным бульоном и ароматная лазанья 'Золотой петушок'.");
                        Console.ReadLine();
                        PrintText("Ты взял вилку из шкафа и сел напротив очкарика.");
                        PrintText("С невозмутимым видом ты придвигаешь лазанью поближе к себе и начинаешь есть.");
                        Console.ReadLine();
                        PrintText("Опешив от такой наглости, ботаник вполне ожидаемо начинает возмущаться:");
                        PrintText("- Ты охренел? Это моя лазанья!");
                        Console.ReadLine();
                        PrintText("Продолжая есть, ты удивленно отвечаешь:");
                        PrintText("- Как это твоя? Я же ее ем, получается моя!");
                        Console.ReadLine();
                        PrintText("Не в силах терпеть подобную дерзость, ботан начинает подзывать к себе какого-то Макса.");
                        PrintText("Спустя мгновнье, справа от тебя появляется сомнительная фигура, напоминающая скинхеда.");
                        Console.ReadLine();
                        PrintText("Оценив ситуацию и без лишних слов, Макс хватает тебя за голову и несколько раз прикладывает головой об стол.");
                        health = СalculationHealth(health, 60, true);
                        if (health == 0) break;
                        PrintText("Приведя себя в порядок, ты встаешь и, как ни в чем не бывало, продолжаешь свои дела.");
                        Console.ReadLine();
                        continue;

                    case "Купить еду":
                        PrintText("Ты подходишь к парню в солнечных очках и предлгаешь купить у него бутерброды.");
                        PrintText("Он отвечает: - Продам за полтос!");
                        Console.ReadLine();
                        PrintText("Не найдя денег в карманах, ты грустно отвечаешь: - Блин, не взял с собой кошель.");
                        PrintText("Парень, поняв твою боль, предлагает обменять бутерброды на сигареты.");
                        Console.ReadLine();
                        if (sigi > 0)
                        {
                            sigi--;
                            PrintText("Ты меняешь сигареты на бутерброды с колбасой, кетчупом и сыром.");
                            PrintText("Сигарет в кармане: " + sigi);
                            Console.ReadLine();
                            health = СalculationHealth(health, 20, false);
                            PrintText("Уталив голод, ты чувствуешь себя лучше!");
                            Console.ReadLine();

                        }
                        else
                        {
                            PrintText("У тебя нет сигарет!");
                            PrintText("Нужно поискать их где-нибудь в общежитии.");
                            Console.ReadLine();
                            PrintText("Ты извиняешься за беспокойство и отходишь.");
                        }
                        continue;
                    case "Выйти в коридор":
                        PrintText("\nТы выходишь с кухни и медленно пробираешься к 806 блоку.");
                        Console.ReadLine();
                        Corridor8();
                        break;
                }
            }
        }

        void KitchenDialogs()
        {
            while (RoomNumber == 4)
            {
                string prompt = "С кем пообщаться:\n";
                List<string> options = new List<string>() { "С девушкой у плиты",
                                                            "Со скинхедом у входа",
                                                            "С ботаном за столом",
                                                            "Не общаться ни с кем" };
                Menu mainMenu = new Menu(prompt, options, health, sigi);
                int selectedIndex = mainMenu.Run();
                Console.Clear();
                switch (options[selectedIndex])
                {
                    case "С девушкой у плиты":
                        if (!girl)
                        {
                            PrintText("\nТы подходишь к девушке, жарящей пельмени на старой грязной газовой плите.");
                            PrintText("Ты: - Привет! Как вкусно пахнет! Обожаю жаренные пельмени.");
                            Console.ReadLine();
                            PrintText("Девушка: - Привет! Кажется мы не знакомы... Ты хочешь съесть мои пельмени?");
                            Console.ReadLine();
                            PrintText("Ты ухмыляешься и отвешаешь, что вы действительно не знакомы, но перекусить ты бы не отказался.");
                            PrintText("Девушка поясняет, что кроме пельменей у нее ничего не осталось и угостить тебя она не сможет.");
                            Console.ReadLine();
                            PrintText("Однако она предлагает тебе спуститься на первый этаж и посетить месную столовую.");
                            PrintText("Ты отвечаешь, что у тебя все равно нет денег, поэтому идти в столовую бессмысленно.");
                            PrintText("Девушка:\n- Ну и хорошо! Ходят байки, что в столовй водится повар-маньяк, который похищает студентов и готовит из них еду.");
                            Console.ReadLine();
                            PrintText("Ты смеешься и говоришь, что это какая-то уж очень кринжовая история.");
                            PrintText("Девушка:\n - Согласна. Но, если что, я тебя предупредила! Извини, мне пора. Пельмени готовы.");
                            Console.ReadLine();
                            girl = true;
                            continue;
                        }
                        else
                        {
                            PrintText("\nДевушка занята поеданием пельменей и листанием ленты инстаграм.");
                            PrintText("Лучшее ее не беспокоить.");
                            Console.ReadLine();
                            continue;
                        }

                    case "Со скинхедом у входа":
                        PrintText("\nТы подходишь к парню в сомнительном прикиде и делаешь комплимент:");
                        PrintText("- Привет! Крутые берцы! Где брал?");
                        Console.ReadLine();
                        PrintText("Лысый детина с пренебрежение смотрит на тебя и говорит:");
                        PrintText("- Тебе че надо, еблан?");
                        Console.ReadLine();
                        PrintText("Ты отвечаешь, что просто хотел пообщаться.");
                        PrintText("- Просто пообщаться? Я похож на того, с кем можно просто пообщаться?");
                        Console.ReadLine();
                        PrintText("Размахнувшись с оттяжкой скинхед бьет тебя прямо под дых.");
                        PrintText("Скорчившись от боли, ты падаешь на пол.");
                        health = СalculationHealth(health, 20, true);
                        if (health == 0) break;
                        PrintText("Поняв свою ошибку, ты извиняешься и отходишь.");
                        Console.ReadLine();
                        continue;

                    case "С ботаном за столом":
                        if (!botan)
                        {
                            PrintText("\nТы подходишь к ботанику в очках и дружелюбно здороваешься.");
                            PrintText("Оторвавшись от прием пищи, он тоже здоровается и спрашивает что ты хотел.");
                            Console.ReadLine();
                            PrintText("Ты:\n- Мне нужно найти пропуск, чтобый выйти из общаги.");
                            PrintText("А всех моих друзей раскидало по общаге. Ты не знаешь у кого можно взять пропуск?");
                            Console.ReadLine();
                            PrintText("Ботаник:\n- На 9 этаже в 913 блоке ты можешь взять пропуск. Но тебе нужен код для входа!");
                            PrintText("Визитки с кодами валяются по всей общаге. Если найдешь странную надпись - это и будет код!");
                            PrintText("А теперь извини, я все-таки ем!");
                            Console.ReadLine();
                            botan = true;
                        }
                        else
                        {
                            PrintText("\nОчкарик занят поеданием пищи и просмотром турнира по DOTA 2.");
                            PrintText("Лучшее его не отвлекать.");
                            Console.ReadLine();
                        }
                        continue;

                    case "Не общаться ни с кем":
                        Kitchen();
                        break;
                }
            }
        }                                                   //Диалоги на кухне

        void KitchenSearch()                                //Обыск кухни
        {
            while (RoomNumber == 4)
            {
                string prompt = "Варианты поиска:\n";
                List<string> options = new List<string>() { "В холодильнике",
                                                            "На полках",
                                                            "На столах",
                                                            "Возле окна",
                                                            "Закончить поиски" };
                Menu mainMenu = new Menu(prompt, options, health, sigi);
                int selectedIndex = mainMenu.Run();

                switch (options[selectedIndex])
                {
                    case "В холодильнике":
                        PrintText("\nДождавшись, когда доступ к холодильнику освободится, ты встал рядом.");
                        PrintText("Открыв дверцу, ты обнаружил священные запасы провизии местных жителей.");
                        Console.ReadLine();
                        PrintText("На уровне твоих глаз красуются очень аппетитные голубцы со сметаной.");
                        PrintText("Живот начинает урчать. Соблазн съесть их велик.");
                        Console.ReadLine();
                        StealFood();
                        break;

                    case "На полках":
                        if (!KitchenSigi)
                        {
                            PrintText("\nТы решаешь обыскать полки кухни.");
                            PrintText("Открыв дверцы, ты видишь тарелки, приборы и прочую куханную утварь.");
                            Console.ReadLine();
                            PrintText("Присмотревшись, ты замечаешь аккуратно запрятанную сигарету в углу одной из полок.");
                            PrintText("Не долго думая, достаешь сигарету и кладешь ее за ухо.");
                            Console.ReadLine();
                            sigi = sigi + 1;
                            KitchenSigi = true;
                        }
                        else
                        {
                            PrintText("\nТы решаешь повторно обыскать полки кухни.");
                            PrintText("Открыв дверцы, ты видишь тарелки, приборы и прочую куханную утварь.");
                            PrintText("Больше ничего интересного.");
                            Console.ReadLine();
                        }
                        continue;

                    case "На столах":
                        PrintText("\nТы решаешь проверить столы на кухне.");
                        PrintText("Нагло вторгаясь в личное пространство обедующих, ты пошел по рядам в поисках полезных вещей.");
                        Console.ReadLine();
                        PrintText("Ты видишь пропуск, лежаший рядом с рукой его владельца - худощавого ботана в очках.");
                        PrintText("Оценив свои возможности, решение отобрать пропуск силой было принято почти мгновенно.");
                        Console.ReadLine();
                        PrintText("Резко сблизившись с очкариком, ты вытащил из под его руки пропуск.");
                        PrintText("Опешив от такой дерзости, парень хотел было возразить.");
                        Console.ReadLine();
                        PrintText("Но ты опередил его, сказав легендарную фразу из фильма детства:");
                        PrintText("- Раздевайся! Мне нужна твоя одежда. И ... пропуск, чтобы выйти!");
                        Console.ReadLine();
                        PrintText("Ты развернулся и направился в сторону выхода из кухни, но путь преградил какой-то скинхед.");
                        PrintText("- Ты в курсе, что этот парень моя золотая курица, которая делает за меня все работы?");
                        PrintText("Спросил лысый сторонник национализма.");
                        Console.ReadLine();
                        PrintText("Взвесив свои шансы, ты решаешь ответить бегством.");
                        PrintText("Немного побегав по кухне, скинхед все же ловит тебя и пару раз прикладывает головой об стол.");
                        health = СalculationHealth(health, 50, true);
                        if (health == 0) break;
                        break;

                    case "Возле окна":
                        PrintText("\nПодойдя к окну на кухне, ты решаешь пошарить рядом.");
                        PrintText("Под батареей ты находишь потертую бумажку, напоминающую визитку.");
                        Console.ReadLine();
                        PrintText("Часть текста стерлась: '..." + code.Remove(2,5) + "...'");
                        PrintText("Стоит запомнить, это может быть полезно.");
                        Console.ReadLine();
                        continue;

                    case "Закончить поиски":
                        PrintText("\nТы решаешь завершить поиски.");
                        PrintText("Видимо, здесь нет ничего полезного...");
                        Kitchen();
                        break;
                }
            }
        }

        /*        void KitchenBlackjack()
                {


                }*/

        void StealFood()
        {
            string prompt = "Доступные действия:\n";
            List<string> options = new List<string>() { "Забрать голубцы",
                                                        "Не трогать" };
            Menu mainMenu = new Menu(prompt, options, health, sigi);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    PrintText("\nБудучи уверенным, что никто не заметит пропажи, ты осторожно берешь контейнер с голубцами.");
                    PrintText("На пол пути до микроволновки тебя останавливает крепкий бритоголовый парень со словами:\n- Дружок, ты ничего не перепутал?");
                    Console.ReadLine();
                    PrintText("Резко вырвав из твоих рук контейнер, хозяин голубцов бьет тебя под дых.");
                    health = СalculationHealth(health, 20, true);
                    if (health == 0) break;
                    PrintText("Поняв свою ошибку, ты извиняешься и отходишь.");
                    Console.ReadLine();
                    PrintText("Содержимое твоего желудка неконтролируемо вырывается наружу.");
                    PrintText("Студентов и прочих обитателей кухни охватывает бурная реакция.");
                    Console.ReadLine();
                    KitchenSearch();
                    break;

                case 1:
                    PrintText("Скрипя зубами, ты закрываешь дверцу холодильника и возвращаешься к поискам.");
                    Console.ReadLine();
                    KitchenSearch();
                    break;
            }

        }                                 //Украсть еду из холодоса

        void ElevatorCall()                                 //Вызов лифта на 8 этаже
        {
            if (angryComenda)
            {
                PrintText("Ты решаешь отвлечь внимание коменды, чтобы свободно перемещаться по 8 этажу.");
                PrintText("Собрав в кучу немного бумажного мусора с лестничной клетки, ты зашел на этаж, чтобы устроить мини поджег.");
                Console.ReadLine();
                PrintText("Ты достал зажигалку из кармана и начал подпаливать первую бумажку.");
                PrintText("Пламя начало разрастаться...");
                Console.ReadLine();
                PrintText("Вдруг ты чувствуешь, что сзади тебя кто-то нагоняет тень.");
                PrintText("Развернувшись, ты видишь коменду с двумя крепкими охранниками.");
                Console.ReadLine();
                Lose();
            }
            string prompt = "Доступные действия:\n";
            List<string> options = new List<string>() { "Пойти по лестнице" };
            if (!angryComenda)
            {
                options.Add("Вернуться в коридор");
                options.Add("Вызвать лифт");
            }
            else
            {
                PrintText("Действовать нужно крайне осторожно.");
                PrintText("Коменда с охраной где-то на этаже и они жаждут тебя поймать.");
                Console.ReadLine();
                options.Add("Прокрасться в коридор");
                options.Add("Сделать отвлекающий маневр");
            }

            Menu mainMenu = new Menu(prompt, options, health, sigi);
            int selectedIndex = mainMenu.Run();

            switch (options[selectedIndex])
            {
                case "Пойти по лестнице":
                    Ladder();
                    break;

                case "Вернуться в коридор":
                    Corridor8();
                    break;

                case "Прокрасться в коридор":
                    Corridor8();
                    break;

                case "Вызвать лифт":
                    Elevator();
                    break;
            }
        }

        void Elevator()                                     //Лифт по всему общежитию 
        {
            var rnd = new Random();
            int[,] diapazone = { { 1, 2, 3, 4, 5, 6, 7, 10, 11, 12, 13, 14 } };
            int itaj = diapazone[rnd.Next(diapazone.GetLength(0)), rnd.Next(diapazone.GetLength(1))];
            if (angryComenda)
            {
                PrintText("Ты нажимаешь на кнопку, и видишь как лифт начал движение с " + itaj + " этажа");
                PrintText("Ты слышишь быстрые и громкие шаги, приближающиеся к тебе из коридора.");
                Console.ReadLine();
                PrintText("Спустя миг из-за угла появляется коменда с двумя крепики охранниками.");
                PrintText("Она в ярости. Наказние неизбежно.");
                Console.ReadLine();
                //Дописать, что лифтом лучше не пользоваться, нужны иные меры.
                Lose();
            }
            else if (itaj >= 4 && itaj <= 12)
            {
                PrintText("Ты нажимаешь на кнопку, и видишь как лифт начал движение с " + itaj + " этажа");
                PrintText("Он едет достаточно быстро и не останавливается на других этажах.");
                Console.ReadLine();
                PrintText("Спустя примерно 15 секунд двери лифта открываются.");
                PrintText("Ты заходишь внутрь. Но на какой этаж лучше отправиться?");
                Console.ReadLine();
                ElevatorSelection();
            }
            else if (itaj > 12)
            {
                PrintText("Ты нажимаешь на кнопку, и видишь как лифт начинает движение с " + itaj + " этажа");
                PrintText("Он спускается слишком медленно! И останавливается почти на всех этажах.");
                Console.ReadLine();
                PrintText("Неожиданно ты слышишь, как дверь в комнату коменданта начинает открываться.");
                Console.ReadLine();
                ActionPobeg();
            }
            else
            {
                PrintText("Ты нажимаешь на кнопку, и видишь как лифт начинает движение с " + itaj + " этажа");
                PrintText("Он останавливается почти на всех этажах и поднимается слишком медленно!");
                Console.ReadLine();
                PrintText("Неожиданно ты слышишь, как дверь в комнату коменданта начинает открываться.");
                Console.ReadLine();
                ActionPobeg();
            }
        }

        void Ladder()                                       //Лестница

        {
            PrintText("Ты попадаешь на лестничную клетку 8 этажа.");
            PrintText("Здесь пахнет куревом и повсюду разбросан мусор.");
            Console.ReadLine();
            PrintText("На этажах ниже кто-то кашляет, постоянно громко шагает и хлопает дверьми.");
            PrintText("Нельзя здесь долго задерживаться. Но куда лучше пойти?");
            Console.ReadLine();

            string prompt = "Доступные действия:\n";
            List<string> options = new List<string>() { "Вернуться в коридор 8 этажа" };
            if (RoomNumber == 3)
            {
                options.Add("Подняться на 9 этаж");
                options.Add("Спуститься на 1 этаж");
            }
            else if (RoomNumber == 9)
            {
                options.Add("Вернуться на 9 этаж");
                options.Add("Спуститься на 8 этаж");
                options.Add("Спуститься на 1 этаж");
            }
            else if (RoomNumber == 5)
            {
                options.Add("Вернуться на 1 этаж");
                options.Add("Подняться на 8 этаж");
                options.Add("Подняться на 9 этаж");
            }
            Menu mainMenu = new Menu(prompt, options, health, sigi);
            int selectedIndex = mainMenu.Run();

            switch (options[selectedIndex])
            {
                case "Вернуться в коридор 8 этажа":
                    PrintText("Ты возвращаешься на 8 этаж.");
                    Console.ReadLine();
                    Corridor8();
                    break;

                case "Подняться на 9 этаж":
                    PrintText("Ты поднимаешься на 9 этаж.");
                    PrintText("По внешнему виду и отделке он ничем не отличается от 8.");
                    Console.ReadLine();
                    Corridor9();
                    break;

                case "Вернуться на 9 этаж":

                    PrintText("Ты возвращаешься на 9 этаж.");
                    Console.ReadLine();
                    Corridor9();
                    break;

                case "Спуститься на 1 этаж":
                    Ladder1mg();
                    break;

                case "Спуститься на 8 этаж":
                    PrintText("Ты возвращаешься на 8 этаж.");
                    Console.ReadLine();
                    Corridor8();
                    break;
            }
        }

        void ActionPobeg()                                  //Сценарии побега от коменды на 8 этаже
        {
            string prompt = "Доступные действия:\n";
            List<string> options = new List<string>() { "Спрятаться за стеной",
                                                        "Побежать на лестницу",
                                                        "Забежать в 806 блок" };
            Menu mainMenu = new Menu(prompt, options, health, sigi);
            int selectedIndex = mainMenu.Run();
            Console.Clear();
            switch (selectedIndex)
            {
                case 0:
                    PrintText("Ты спрятался за стенкой, чтобы понаблюдать за реакцией.");
                    PrintText("Комендша вышла из своего блока и направилась в твою сторону.");
                    Console.ReadLine();
                    PrintText("Она остановилась рядом и начала подозрительно озираться.");
                    PrintText("Ты замер и побледнел от страха. Она так близко!");
                    Console.ReadLine();
                    PrintText("Комендант разворачивается и направляется в противоположное крыло общежития.");
                    PrintText("Еще немного и ты сможешь сбежать!");
                    Console.ReadLine();
                    PrintText("Но, как назло, приезжает лифт, который привлекает внимание 'стражника’ общежития.");
                    PrintText("Комендша оборачивается и замечает твое дрожащее и бледное от алкоголя тело.");
                    ActionLieComenda();
                    break;

                case 1:
                    PrintText("Ты, аки Усейн Болт, спринтуешь в сторону лестницы.");
                    PrintText("Залетев в дверь, ты подскальзываешься на скользкой плитке и пдаешь на пол.");
                    health = СalculationHealth(health, 10, true);
                    if (health == 0) break;
                    PrintText("Спрятавшись и немного отдышавсь, ты заглядываешь в дверную щель...");
                    Console.ReadLine();
                    PrintText("Коменда тебя не заметила! Что это, если не чудо?");
                    PrintText("Но теперь есть шанс, что она будет искать тебя. Нужно быть начеку!");
                    Console.ReadLine();
                    Ladder();
                    break;

                case 2:
                    if (!angryComenda)
                    {
                        PrintText("Вопреки здравому смыслу, ты бежишь навстречу коменде, в надежде успеть занырнуть в 806 блок");
                        PrintText("Запнувшись о неровный пол, ты с грохотом падаешь на землю.");
                        Console.ReadLine();
                        PrintText("Открыв глаз, ты видишь перед собой устрашающую фигуру коменды.");
                        PrintText("Ты кто такой, почему я тебя не знаю? - Грозно спрашивает она.");
                        Console.ReadLine();
                        ActionLieComenda();
                    }
                    else
                    {
                        PrintText("Ты решаешь укрыться в 806 блоке.");
                        PrintText("Но запнувшись о неровный пол, ты с грохотом падаешь на землю.");
                        Console.ReadLine();
                        PrintText("Открыв глаз, ты видишь перед собой грозную фигуру коменды с двумя охранниками;");
                        PrintText("Один из них хватает тебя за шиворот и метко бьет кулаком прямо в челюсть");
                        Lose();
                    }
                    break;
            }
        }

        void Corridor9()                                    //Коридор 9 этажа
        {
            RoomNumber = 9;
            Console.Clear();
            PrintText("Ты стоишь между 913 и 915 блоками 9 этажа.");
            PrintText("Дальше по коридору виднеется приоткрытая дверь на общий балкон.");
            Console.ReadLine();
            string prompt = "Доступные действия:\n";
            List<string> options = new List<string>() { "Войти в 913 блок",
                                                        "Войти в 915 блок",
                                                        "Выйти на балкон",
                                                        "Пойти на лестницу",
                                                        "Вызвать лифт" };
            Menu mainMenu = new Menu(prompt, options, health, sigi);
            int selectedIndex = mainMenu.Run();
            Console.Clear();
            switch (selectedIndex)
            {
                case 0:
                    PrintText("\nТы подходишь к двери с надписью 913 и дергаешь за ручку. Заперто.");
                    PrintText("Несколько раз постучав, ты слышишь громкие шаги за дверью, после которых раздается голос:");
                    Console.ReadLine();
                    ActionCodeAlex();
                    break;

                case 1:
                    PrintText("\nПриблизившись к блоку 915,ты видишь, что входная дверь не заперта.");
                    PrintText("Ты заходишь в прихожую. Дверь в правую комнату тоже открыта.");
                    Console.ReadLine();
                    Room915();
                    break;

                case 2:
                    PrintText("\nТы попадаешь на открытый балкон общежития.");
                    PrintText("Весь пол засыпан окурками, стеклотарой и прочим мусором.");
                    Console.ReadLine();
                    ActionBalkon();
                    break;

                case 3:
                    PrintText("Ты вышел на лестничную клетку и спустился на этаж ниже.");
                    Ladder();
                    break;

                case 4:
                    PrintText("Ты подходишь к лифту и нажимаешь на кнопку вызова.");
                    PrintText("Спустя некоторое время, двери лифта открываются и ты заходишь внутрь.");
                    ElevatorSelection();
                    break;
            }
        }

        void Room915()                                      //915 блок. Гоша спит.
        {
            RoomNumber = 7;

            PrintText("Ты в комнате 915 блока.");
            if (!GoshaNeverSleep) PrintText("К твоему счастью, в спящем на кровате теле ты узнаешь своего друга - Гошу.");
            else PrintText("Гошу приветливо кивает тебе головой.");
            Console.ReadLine();
            while (!GoshaNeverSleep && RoomNumber == 7)
            {
                string prompt = "Доступные действия:\n";
                List<string> options = new List<string>() { "Разбудить Гошу",
                                                            "Выйти в коридор"};
                if (sigiGoshi == 2) options.Add("Забрать сигареты Гоши");
                if (!drunk) options.Add("Выпить чачу");

                Menu mainMenu = new Menu(prompt, options, health, sigi);
                int selectedIndex = mainMenu.Run();
                Console.Clear();
                switch (options[selectedIndex])
                {
                    case "Разбудить Гошу":
                        PrintText("Ты без особых проблем будишь Гошу и рассказываешь все, что с тобой приключилось.");
                        Console.ReadLine();
                        PrintText("Он не особо внимательно тебя слушает, сконцентрировавшись на скопившехся уведомлениях от обожательниц в телефоне.");
                        PrintText("После чего резюмирует, что подобные похождения в общаге - не редкость.");
                        Console.ReadLine();
                        GoshaNeverSleep = true;
                        break;

                    case "Выйти в коридор":
                        PrintText("Ты решил не беспокоить Гошу и вышел в коридор 9 этажа.");
                        Console.ReadLine();
                        Corridor9();
                        break;

                    case "Забрать сигареты Гоши":
                        thiefSigi = true;
                        PrintText("Ты решаешь обезопасить друга от табачных изделий.");
                        PrintText("Поэтому содержимое Гошиной пачки Winstone оказывается в твоем кармане.");
                        sigi = sigi + sigiGoshi;
                        sigiGoshi = -2;
                        PrintText("Количество сигарет в кармане: " + sigi);
                        Console.ReadLine();
                        continue;

                    case "Выпить чачу":
                        PrintText("Ты решаешь в одиночку оценить домашнюю чачу прямиком из солнечной Абхазии.");
                        PrintText("Подняв с пола грязную стопку, ты садишься за стол и наливаешь себе топлива.");
                        Console.ReadLine();
                        PrintText("Плохо пить в одиночку, - подумал ты. Нужно сказать тост:");
                        PrintText("Высоко-высоко в горах...");
                        Console.ReadLine();
                        PrintText("...хм как там дальше??");
                        PrintText("Плюнув на продолжение, ты залпом махнул стопку чачи не закусывая.");
                        Console.ReadLine();
                        PrintText("Через 10 минут бутылка была опустошена.");
                        drunk = true;
                        continue;
                }
                ActionGosha915();
            }
        }

        void ActionGosha915()                               //915 блок. Гоша проснулся.
        {
            int angryGosha = 1;
            int att = 2;
            while (RoomNumber == 7)
            {
                string prompt = "Доступные действия:\n";
                List<string> options = new List<string>() { "Спросить про пропуск",
                                                            "Предложить выпить",
                                                            "Предложить покурить" };
                if (girlQ || att > 0) options.Add("Узнать о девушке из 806");
                options.Add("Выйти в коридор");
                Menu mainMenu = new Menu(prompt, options, health, sigi);
                int selectedIndex = mainMenu.Run();
                Console.Clear();
                switch (options[selectedIndex])
                {
                    case "Спросить про пропуск":
                        PrintText("Ты спрашиваешь есть ли у Гоши пропуск, чтобы выбраться из общаги.");
                        PrintText("Почесав голову, он задумчиво отвечает:");
                        PrintText("- Бля, мой пропуск в другом блоке завален грудой хлама. Я не смогу его быстро найти.");
                        Console.ReadLine();
                        PrintText("Взяв небольшую паузу на размышления, он вдруг торжественно заявляет:");
                        PrintText("- О! У Алексея же есть пропуск! Он в соседнем 913 блоке. Но не все так просто...");
                        Console.ReadLine();
                        PrintText("После того, как Алексей начал продавать хакерское ПО для взлома, он перестал впускать к себе незнакомцев.");
                        PrintText("Мы давно не общались, но я знаю, что для входа нужно назвать какой-то код.");
                        PrintText("Иван в 806 блоке должен быть в курсе или поспрашивай у кого-нибудь в общаге.");
                        Console.ReadLine();
                        continue;

                    case "Предложить выпить":
                        if (!drunk)
                        {
                            PrintText("Заприметив на столе фирменную Гошину чачу, ты предлагаешь ему выпить.");
                            PrintText("Долго уговаривать Гошу не приходится.");
                            Console.ReadLine();
                            PrintText("Он поднимает с пола грязные стопки, протирает их и разливает кажому чудо Абхазской спиртовой промышленности!");
                            PrintText("Подняв рюмку над головой он торжественно заявляет, - тост!");
                            Random rnd = new Random();
                            string[] codeVariants = { "Высоко-высоко, в горах, там, где воздух чист и прозрачен настолько, что опьяняет; там, где до солнца чуть ближе, а луна и звезды сияют ярче, уважают гордость и справедливость. Так выпьем же этот напиток, подаренный нам природой и человеческой мудростью, за то, чтобы наша гордость никогда не мешала справедливым решениям и поступкам.",
                                                      "Высоко-высоко в горах, среди великолепных снежных вершин, обитал самый свежий и свободный ветер. Он был быстр как удар молнии, силен как девятый вал и смел как влюбленный юноша! Но вот однажды, решил он взглянуть на мир за пределами горных вершин и спустился в долину. И увидел диковинную вещь, сотворенную людскими руками — это была ветряная мельница. Решил вольный ветер поближе разглядеть непонятную вещь, да так и запутался в лопастях, что уже никогда не смог выкрутиться. И с тех самых пор так и крутит он мельничные крылья и не знает больше другой жизни. Так давайте же выпьем за то, что бы никогда любопытство не лишало нас свободы!",
                                                      "Высоко в горах, среди прекрасных горных пейзажей, где облака зацепляются своими прядями за вершины белоснежных равнин, на роскошной лужайке полной изумрудной травы, жил-был себе горный козел. И вел этот козел себя как самый настоящий козел, все время орал не своим голосом и норовил кого-то поддеть на рога или зацепить своим косматым боком. Был он настолько злобен, что наступил тот день, когда вокруг совсем никого не осталось. И тогда козел захирел от грусти и сдох. И еще долго его одинокие косточки белели среди прекрасной долины. Так давайте же выпьем за то, что бы какая бы нас ни окружала природа, мы никогда бы не были козлами! Потому что козлы умирают в одиночестве!" };
                            int rndFunction = rnd.Next(codeVariants.Length);
                            string resultatate = codeVariants[rndFunction];
                            PrintText(resultatate);
                            drunk = true;
                            health = СalculationHealth(health, 30, false);
                            PrintText("Опустошив остатки водки, вы сели на диван и почувствовали приятное тепло, пробегающее по телу.");
                            PrintText("Прекрасное чувство... Но задерживаться нельзя. Пора выбираться из общежития!");
                            Console.ReadLine();
                            continue;
                        }
                        else
                        {
                            PrintText("Хотел было ты выпить Гошину чачу из Абхазии.");
                            PrintText("Но взглянув на стол, видишь лишь пустую бутылку.");
                            Console.ReadLine();
                            continue;
                        }

                    case "Предложить покурить":
                        if (thiefSigi)
                        {
                            PrintText("Гоша хотел было согласиться, но обнаружил пропажу сиг в пачке.");
                            PrintText("Еще немного поискав содержимое, он с досадой сказал:");
                            PrintText("- Ну пиздец, специально на утро 2 штуки оставил! Что за падла спиздила?");
                            Console.ReadLine();
                            PrintText("Ты начал испытывать сильное чувство стыда. Может лучше во всем сознаться?");
                            Console.ReadLine();
                            ActionLieGosha915();
                        }
                        else if (angryGosha > 0 && sigiGoshi >= 2)
                        {
                            PrintText("Взгянув на пачку сигарет, ты предложил покурить на балконе.");
                            PrintText("Но Гоша ответил, что ему впадлу вставать и протянул 2 сиги из своей пачки.");
                            Console.ReadLine();
                            sigi = sigi + sigiGoshi;
                            PrintText("Великодушие Гоши тебя поразило, но сигареты ты все же забрал себе.");
                            PrintText("Количество сигарет в кармане: " + sigi);
                            sigiGoshi = -2;
                        }
                        else if (angryGosha > 0)
                        {
                            PrintText("Тебе не хотелось курить одному, поэтому ты вновь предложил Гоше покурить на балконе.");
                            PrintText("На что Гоша, на секунду оторвавшись от телефона, ответил:");
                            PrintText("Я же сказал, что не пойду. Покури один! Я даже отдал тебе свои сигареты. Все, не мешай!");
                            Console.ReadLine();
                            PrintText("Ты проверил карманы своих фирменных джинс Levi'S.");
                            PrintText("Количество сигарет: " + sigi);
                            angryGosha--;
                        }
                        else if (angryGosha == 0)
                        {
                            PrintText("Ты снова предложил Гоше покурить на балконе.");
                            PrintText("Он моментально оторвал глаза от телефона и посмотрел на тебя");
                            Console.ReadLine();
                            PrintText("Его щеки побагровели и глаза налились кровью.");
                            PrintText("Тебе стало страшно...");
                            Console.ReadLine();
                            PrintText("Гоша резко подскачил с кровати, подбежал к тебе и втащил мощный подзатыльник.");
                            health = СalculationHealth(health, 20, true);
                            if (health == 0) break;
                            PrintText("Выкрикнув, что ты его заебал, он вернулся на место.");
                            PrintText("— Справедливо. — подумал ты и не стал отвечать.");
                            angryGosha--;
                        }
                        else
                        {
                            PrintText("Ты с неумолимым упорством снова предложил Гоше покурить.");
                            PrintText("Он моментально схватил стеклянную бутылу и бросил в тебя.");
                            health = СalculationHealth(health, 95, true);
                            if (health == 0) break;
                            PrintText("Это было очень больно, но ты понимаешь, что получил за дело.");
                        }
                        Console.ReadLine();
                        continue;

                    case "Узнать о девушке из 806":
                        if (girlQ)
                        {
                            PrintText("Удивившись, Гоша спрашивает:");
                            PrintText("- Ты об этой... Как ее зовут?.. О точно - " + girlName);
                            Console.ReadLine();
                            PrintText("Я думал ты мне про нее расскажешь. Вы же вчера целый вечер вдвоем обжимались...");
                            PrintText("Ты че, реально ничего не помнишь?");
                            Console.ReadLine();
                            PrintText("Это вроде чья-то знакомая, но я ее впервые вижу.");
                            PrintText("Я с ней особо не общался. Но мне она показалась какой-то странной.");
                            PrintText("Все ходила, какие-то вопросы странные задавала... Короче я хз.");
                            girlQ = false;
                            att--;
                            Console.ReadLine();
                        } else
                        {
                            PrintText("Да что ты все не уймешься никак с ней? Зацепила что ли?");
                            PrintText("Номерок ей хоть оставил?");
                            Console.ReadLine();
                            PrintText("Я же сказал, что не знаю ничего про нее.");
                            PrintText("Пообщайся с ней сам потом, если она тебе так понравилсь.");
                            att--;
                            options.Remove("Узнать о девушке из 806");
                            Console.ReadLine();
                        }
                        break;

                    case "Выйти в коридор":
                        PrintText("Ты извиняешься и говоришь, что тебе пора идти.");
                        PrintText("Открыв дверь, ты попадаешь в коридор.");
                        options.Remove("Выйти в коридор");
                        Console.ReadLine();
                        Corridor9();
                        break;
                }
            }
        }

        void ActionLieGosha915()                        //915 блок. Обман Гоши
        {
            string prompt = "Варианты поиска:\n";
            List<string> options = new List<string>()
            {
                "Вернуть сигареты",
                "Оставить себе"
            };
            Menu mainMenu = new Menu(prompt, options, health, sigi);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    PrintText("\nТы решаешь сознаться в содеянном и вернуть сигареты Гоше.");
                    PrintText("Его очень раздосадовал твой поступок. Поэтому он не стал церемониться и сразу зарядил тебе мощный чапалах.");
                    health = СalculationHealth(health, 20, true);
                    if (health == 0) break;
                    Console.ReadLine();
                    PrintText("Было больно, но ты почувсвовал облегчение на душе.");
                    PrintText("— Справедливо. — подумал ты и не стал отвечать");
                    break;

                case 1:
                    thiefSigi = false;
                    PrintText("\nТы покачал головой и сказал, что не в курсе пропажи.");
                    PrintText("Гоша сделал настолько грустное лицо, что еще чуть-чуть и ты бы раскололся.");
                    Console.ReadLine();
                    PrintText("Тебе стало настолько стыдно и неловко, что ты почувствовал себя плохо.");
                    health = СalculationHealth(health, 10, true);
                    if (health == 0) break;
                    PrintText("Но из-за нескольких сигарет не хотелось портить многолетнюю дружбу...");
                    Console.ReadLine();
                    break;
            }
            ActionGosha915();
        }

        void Room913()                                 //913 блок. Алексей. Получение пропуска
        {
            Console.Clear();
            PrintText("Ты слышишь звуки открывающихся замков, спустя время дверь распахивается!");
            PrintText("Перед тобой предстает крепкий парень лет 26-28 с короткой стрижкой.");
            Console.ReadLine();
            PrintText("На нем старая майка красного цвета. Он чем-то напоминает Русского Мясника.");
            PrintText("- Опасный тип - думаешь ты...");
            Console.ReadLine();
            PrintText("Позади него виднеется комната до отвала забитая техникой и работающими мониторами.");
            PrintText("Складывалось впечатление, что Алексей взламывает Пентагон.");
            Console.ReadLine();
            PrintText("Заметив твой интерес, он молча прикрывает дверь в комнату.");
            PrintText("После чего чешет голову и грозно спрашивает:");
            PrintText("- Че тебе?");
            Console.ReadLine();
            PrintText("Ты рассказываешь про свои приключения в общаге.");
            PrintText("Внимательно выслушав, он протягивает тебе пропуск и поясняет:");
            PrintText("- Можешь оставить в любом месте города, в него встроен датчик, мои люди заберут. Удачи.");
            keycard = true;
            Console.ReadLine();
            PrintText("Не успев ничего отвеить, дверь закрывается прямо перед твоим носом.");
            PrintText("Ты только и успеваешь промямлить 'спасибо'.");
            Console.ReadLine();
            PrintText("Все это кажется тебе очень странным...");
            PrintText("Зато теперь у тебя есть пропуск для выхода!");
            Console.ReadLine();
            Corridor9();
        }

        void ActionBalkon()                                  //Балкон 
        {
            RoomNumber = 6;
            while (RoomNumber == 6)
            {
                string prompt = "Доступные действия:\n";
                List<string> options = new List<string>() { "Полюбоваться видами",
                                                            "Выйти в коридор" };
                if (sigi > 0) options.Add("Закурить");
                if (drunk) options.Add("Сесть на край балкона");
                Menu mainMenu = new Menu(prompt, options, health, sigi);
                int selectedIndex = mainMenu.Run();
                Console.Clear();
                switch (options[selectedIndex])
                {
                    case "Полюбоваться видами":
                        PrintText("Ты смотришь вдаль. Весь город как на ладони.");
                        PrintText("Жизнь большого города кипит во всю: машины нетерпеливо сигналят друг другу, пешеходы куда-то спешат.");
                        PrintText("Эх...Хотелось бы тут задержаться, но дела не ждут.");
                        Console.ReadLine();
                        continue;

                    case "Сесть на край балкона":
                        ActionBalkonDrunk();
                        break;

                    case "Закурить":
                        ActionBalkonSigi();
                        break;

                    case "Выйти в коридор":
                        PrintText("Открыв дверь, ты возвращаешься на балкон.");
                        Console.ReadLine();
                        Corridor9();
                        break;
                }
                break;
            }
        }

        void ActionBalkonSigi()                              //Балкон >> Сценарий с сигой и поваром
        {
            PrintText("Ты достаешь сигарету из пачки, медленно подкуриваешь ее фирменной зажигалкой Cricket.");
            sigi--;
            PrintText("Прикоснувшись губами к сухому фильтру, ты делаешь сильную затяжку.");
            Console.ReadLine();
            PrintText("Ты слышишь приятное похрустование тлеющей бумаги с каждой новой тяжкой.");
            PrintText("Выдыхаемые клубы дыма подхватываются легкими порывами ветра и уносятся прочь.");
            health = СalculationHealth(health, 10, false);
            if (sigi > 0)
            {
                PrintText("Твое блаженство нарушает открывшаяся дверь балкона.");
                PrintText("Спустя миг, перед тобой предстаёт странный незнакомец на вид лет 30 в заляпанной куханной одежде.");
                Console.ReadLine();
                PrintText("Он просит угостить его сигареткой.");
                PrintText("Ты проверяшь пачку. Осталось сигарет: " + sigi);
                Console.ReadLine();
                PrintText("Стоит ли тратить столь ценный ресурс?");
                string prompt = "Доступные действия:\n";
                List<string> options = new List<string>() { "Угостить",
                                                            "Отказать"};
                Menu mainMenu = new Menu(prompt, options, health, sigi);
                int selectedIndex = mainMenu.Run();
                Console.Clear();
                switch (selectedIndex)
                {
                    case 0:
                        PrintText("Ты без проблем угощаешь незнакомца сигаретой, ведь сигареты все равно не твои.");
                        sigi--;
                        PrintText("Пытаясь подкурить, повар мельком поглядывает на тебя.");
                        Console.ReadLine();
                        PrintText("После небольшого неловкого молчания он решает разбавить перекур рассказом о работе.");
                        PrintText("Как оказалось, он работает поваром в столовой на 1 этаже общежития.");
                        Console.ReadLine();
                        PrintText("Недослушав историю о твоих похождения, он неожиданно прерывает тебя и говорит:");
                        PrintText("- Слушай, я могу провести тебя мимо турникетов. В столовой есть запасной выход на улицу.");
                        Console.ReadLine();
                        ActionBalkonPovar();
                        break;

                    case 1:
                        if (sigi == 1)
                        {
                            PrintText("Ты показал последнюю сигарету в пачке и пояснил:");
                            PrintText("- Последнюю даже мусора не забирают!\n");
                            PrintText("Повар кивнул головой в знак согласия и вышел в коридор.");
                            Console.ReadLine();
                        }
                        else
                        {
                            PrintText("Ты покачал головой и сказал");
                            PrintText("Извиняй, последняя.\n");
                            PrintText("Повар кивнул головой и скрылся где-то в коридоре.");
                            Console.ReadLine();
                        }
                        break;
                }
            }

            PrintText("Докурив, ты выкидываешь бычок за пределы балкона.");
            PrintText("Полетев с 9 этажа он задевает ветки деревьев, разлетаясь на сотни ярких искр.");
            Console.ReadLine();
            ActionBalkon();
            return;
        }

        void ActionBalkonDrunk()                             //Балкон >> Сценарий с падением
        {
            PrintText("Под влиянием алкогольного опьянения, ты решаешь залезть на край балкона, чтобы полюбоваться городскими пейзажами свесив ноги.");
            PrintText("Не расчитав силы, ты камнем падаешь вниз с высоты 9 этажного здания.");
            PrintText("Сильный удар!... ");
            health = СalculationHealth(health, 95, true);
            if (health == 0) return;
            PrintText("Как ни странно, ты остаешься в сознании и даже не чувствуешь сильной боли.");
            PrintText("Невероятно! Ты преземлился на стог сена и листьев, собранных накануне местными дворниками.");
            Console.ReadLine();
            PrintText("Долгожданная свобода!");
            PrintText("- Все, больше не бухаю! - отвественно сказал ты, встав и отряхнувшись.");
            Console.ReadLine();
            PrintText("Дохромав до остановки, ты сел в автобус №Т19 и отправился в закат...");
            Console.ReadLine();
            Win();
            return;
        }

        void ActionBalkonPovar()                             //Балкон >> Сценарий с поваром
        {
            string prompt = "Доступные действия:\n";
            List<string> options = new List<string>() { "Пойти с поваром",
                                                        "Отказаться"};
            Menu mainMenu = new Menu(prompt, options, health, sigi);
            int selectedIndex = mainMenu.Run();
            Console.Clear();
            switch (selectedIndex)
            {
                case 0:
                    PrintText("Ты согласился с предложением повара - покинуть общагу через черный ход на кухне.");
                    PrintText("Вместе вы подошли к лифту и, спустя некоторое время, спустились на 1 этаж.");
                    Console.ReadLine();
                    PrintText("Повар подозвал тебя к лестничной клетке. Под листницей виднелась большая металлическая дверь.");
                    PrintText("Достав из фартука ключ, он медленно и осторожно открыл дверь, чтобы не издавать громких звуков.");
                    Console.ReadLine();
                    PrintText("Свет не горел, поэтому в открытой двери ты смог разглядеть лишь мрак.");
                    PrintText("Повар прошептал: - Заходи первым.");
                    PrintText("Тебе стало не по себе, но ты не подал виду и пошел во тьму.");
                    Console.ReadLine();
                    PrintText("Дверь захлопнулась и стало совсем темно.");
                    PrintText("Сделав несколько шагов, неожиданно ты почувствовал резкую боль в области затылка и потерял сознание...");
                    Console.ReadLine();
                    RoomNumber = 0;
                    Loading("Ты без сознания");
                    PodvalPovara();
                    break;

                case 1:
                    PrintText("Тебе показалось предложение повара очень подозрительным.");
                    PrintText("Да и сам он был каким-то странным. Лучше с такими не связываться!");
                    Console.ReadLine();
                    ActionBalkon();
                    break;
            }
        }

        void PodvalPovara()
        {
            RoomNumber = 10;
            if (phoneNumber)
            {
                Console.Clear();
                PrintText("Ты очнулся на полу от вибрации в кармане. Голова раскалывается от боли.");
                PrintText("Почему-то здесь очень холодно. Почти ничего не видно, свет выключен.");
                Console.ReadLine();
                PrintText("Ты вытащил телефон из кармана и увидел кучу сообщений с незнакомого номера.");
                PrintText("Осветив темную комнату, ты понимаешь, что оказался в промышленном холодильнике.");
                Console.ReadLine();
                PrintText("Связь почти не ловит - одна палочка и то пропадает.");
                PrintText("Нужно срочно что-то предпринять!");
                Console.ReadLine();
            }
            else
            {
                PrintText("Ты очнулся подвешенным вниз головой в промышленном холодильнике.");
                PrintText("Рядом висят туши животных. Напротив тебя стоит тот самый повар с тисаком в руках.");
                Console.ReadLine();
                PrintText("Ухмылка на лице повара - последнее, что ты видишь...");
                Lose();
            }
            string prompt = "Доступные действия:\n";
            List<string> options = new List<string>() { "Обыскать комнату",
                                                        "Проверить телефон",
                                                        "Позвать на помощь"};
            Menu mainMenu = new Menu(prompt, options, health, sigi);
            int selectedIndex = mainMenu.Run();
            Console.Clear();
            switch (selectedIndex)
            {
                case 0:
                    PrintText("Неуверенно встав на ноги, ты пошел вдоль стены.");
                    PrintText("Чуть дальше за стеной ты видишь подвешанные туши животных.");
                    Console.ReadLine();
                    PrintText("Это место очень напоминает промышленный холодильник.");
                    PrintText("За одной из дверей со стеклянным окном ты замечаешь пожарную кнопку.");
                    Console.ReadLine();
                    PrintText("Дернув за ручку, то понимаешь, что дверь заперта с другой стороны.");
                    ActionPodvalSearch();
                    break;

                case 1:
                    ActionPodvalPhone();
                    break;

                case 2:
                    PrintText("Ты решаешь позвать на помощь.");
                    PrintText("От страха ты издаешь неистовый крик, который еще больше тебя пугает.");
                    Console.ReadLine();
                    PrintText("Через полминуты дверь распахивается и с огромным тесаком на тебя надвигается повар-мясник.");
                    PrintText("Повар-маясник: - Закрой рот! Тебя все равно никто не услышит... АХАХАХА!!!");
                    Console.ReadLine();
                    PrintText("Мощнейшим ударом в область головы мясник навсегда лишает тебя возможности кричать.");
                    Lose();
                    break;
            }
        }

        void ActionPodvalSearch()
        {
            string prompt = "Доступные действия:\n";
            List<string> options = new List<string>() { "Разбить стекло",
                                                        "Открыть дверь силой",
                                                        "Продолжить поиски"};
            Menu mainMenu = new Menu(prompt, options, health, sigi);
            int selectedIndex = mainMenu.Run();
            Console.Clear();
            switch (selectedIndex)
            {
                case 0:
                    PrintText("Ты наматываешь рубашку на кулак и совершаешь сильный удар в центр окна.");
                    PrintText("Раздается грохот и осколки падают на пол, издавая сильный шум.");
                    health = СalculationHealth(health, 10, true);
                    if (health == 0) break;
                    PrintText("Ты суешь руку в разбитое окно и пытаешься нащупать щеколду.");
                    PrintText("Вдруг ты слышишь, как с противополжной стороны с ударом распахивается дверь.");
                    Console.ReadLine();
                    PrintText("В панике ты начинаешь еще яростнее пытаться открыть дверь.");
                    PrintText("Приближающиеся шаги все ближе...");
                    Console.ReadLine();
                    PrintText("Наконец, ты находишь злополучную щеколду и отводишь ее назад.");
                    PrintText("Резко вытащив руку, ты задеваешь оставшийся осколок.");
                    health = СalculationHealth(health, 20, true);
                    if (health == 0) break;
                    PrintText("Скорчившись от боли, ты пытаешь открыть дверь, но она стоит неподвижно.");
                    PrintText("- Что, сосунок, хотел сбежать от папочки, да?");
                    PrintText("Яростно кричит психопат в поворской одежде с тесаком в руках.");
                    Console.ReadLine();
                    PrintText("То ли от полученных увечий, то ли от испуга ты теряешь сознаение.");
                    PrintText("К сожалению, ты больше не приходишь в себя...");
                    Lose();
                    break;

                case 1:
                    PrintText("Ты решаешь выбить дверь с ноги.");
                    PrintText("Взяв небольшой разгон, ты летишь на дверь, целясь в область замка.");
                    Console.ReadLine();
                    PrintText("Громкий удар! Дверь стоит на месте.");
                    PrintText("Разбежавшись еще сильнее, ты замахнулся ногой еще больше.");
                    Console.ReadLine();
                    PrintText("Подскользнувшись на скольском полу, ты летишь на кафель головой в низ.");
                    health = СalculationHealth(health, 30, true);
                    if (health == 0) break;
                    PrintText("От сильного удара ты теряешь сознание.");
                    PrintText("К сожалению, ты больше не приходишь в себя...");
                    health = СalculationHealth(health, 100, true);
                    break;

                case 2:
                    PrintText("Ты решаешь вернуться к поискам.");
                    PrintText("Побродив еще несколько минут по темным холодным помещениям, ты не находишь ничего полезного.");
                    Console.ReadLine();
                    PrintText("Все выходы заперты. Бежать некуда. Нужно проверить телефон!");
                    Console.ReadLine();
                    ActionPodvalPhone();
                    break;
            }
        }

        void ActionPodvalPhone()
        {
            int SMSAttempts = 2;
            Console.Clear();
            PrintText("Ты решаешь срочно позвонить в полицию и попросить о помощи!");
            PrintText("Введя номер 911, ты замечаешь 8 SMS с новыми сообщениями.");
            Console.ReadLine();
            PrintText("Открыв сообщения, ты видишь много SMS с одного незнакомого номера:");
            PrintText("'Привет, это " + girlName + ". Ты оставил свой номер утром'");
            PrintText("'Перезвони мне, пожалуйста')");
            Console.ReadLine();
            PrintText("«Где ты? Мне срочно нужно с тобой поговорить!»");
            PrintText("«Я тебе не все о себе рассказала…»");
            Console.ReadLine();
            PrintText("«Я знаю, что ты еще в общежитии, но не могу понять где именно.»");
            PrintText("«Слушай, тут небезопасно. Ответь, пожалуйста…»");
            Console.ReadLine();
            PrintText("«Все, я проверяю камеры! Если ты это читаешь, дай знак»");
            PrintText("«В последний раз ты был на лестнице. Куда же ты пропал?..»");
            Console.ReadLine();
            PrintText("Ты вообще перестаешь понимать что происходит, головная боль усиливается.");
            PrintText("Очевидно, что нужно вызвать подмогу. Но откуда она знает, что ты все еще в общежитии?");
            Console.ReadLine();
            PrintText("Нужно написать ей свое местоположение. Ты надеешься, что SMS отправится.");
            PrintText("Ты вводишь сообщение:");
            PrintText("«Под лестницей 1 этажа есть проход. Меня заманил сюда какой-то стремный повар. Помоги!»");
            Random rnd = new Random();
            while (SMSAttempts != 0)
            {
                int value = rnd.Next(3);
                PrintText("Ты поднимаешь телефон к потолку, чтобы поймать связь.");
                Console.WriteLine("Нажми ввод, чтобы отправить сообщение:");
                Console.ReadLine();
                Console.Clear();
                Console.CursorVisible = false;
                Console.SetCursorPosition(1, 1);
                for (int i = 0; i < 10; i++)
                {
                    for (int y = 0; y < i; y++)
                    {
                        string pb = "\u2551";
                        Console.Write(pb);
                    }
                    Console.Write(i + " / 10");
                    Console.SetCursorPosition(1, 1);
                    System.Threading.Thread.Sleep(100);
                }
                Console.CursorVisible = true;
                Console.Clear();
                if (value == 0 || value == 1)
                {
                    PrintText("Ошибка отправки!");
                    PrintText("Нужно попробовать еще раз!");
                    Console.ReadLine();
                    SMSAttempts--;
                    continue;
                }
                else if (value == 2 || value == 3)
                {
                    PrintText("Появилась одна палочка сигнала!");
                    PrintText("Сообщение отправлено!");
                    Console.ReadLine();
                    PodvalWin();
                    return;
                }
                PrintText("Сообщения так и не отправились!");
                PrintText("От злости ты швырнул телефон в стену!");
                Console.ReadLine();
                PrintText("Телефон разлетелся в дребезги. А вместе с ним твои надежды на спасение...");
                Lose();
            }
        }

        void PodvalWin()
        {
            PrintText("Отлично, сообщение было доставлено!");
            PrintText("Теперь остается только ждать помощи...");
            PrintText("Спустя 4 минуты ты слышишь три громких стука в дверь с характерными выкриками по типу: ");
            PrintText("FBI open up!");
            PrintText("После этого дверь словно вынесло взрывчаткой и в холодильник ворвались спецназовцы.");
            PrintText("Оглушенный взрывом, ты приходишь в сознание только в машине скорой помощи.");
            PrintText("Рядом с тобой ты видишь " + girlName + ", держащую тебя за руку.");
            PrintText(girlName + ": - Я так за тебя переживала. Мне многое стоит тебе рассказать...");
            Win();
            return;
        }

        void Ladder1mg()                               //Мини-игра спуск по лестнице с 8 по 1 этаж
        {
            int storey = 0;
            if (RoomNumber == 3) storey = 8;
            if (RoomNumber == 9) storey = 9;
            PrintText("Ты огляделся. Номера этажей не указаны. Это странно.");
            PrintText("Чтобы не запутаться, нужно считать каждый пройденный ярус.");
            string lvl;
            int lvl2;
            Console.ReadLine();
            while (storey >= 1)
            {

                PrintText("Номер текущего этажа:");
                try
                {
                    lvl = Console.ReadLine();
                    lvl2 = Convert.ToInt32(lvl);
                    Console.Clear();
                }
                catch
                {
                    PrintText("Данное действие недоступно.");
                    PrintText("Необходимо указать номер этажа!\n");
                    continue;
                }
                if (lvl2 == storey)
                {
                    storey--;
                    PrintText("Ты спустился ниже!\n");
                    if (storey <= 0)
                    {
                        PrintText("Отлично! Ты добрался до 1 этажа.");
                        Console.ReadLine();
                        Corridor1();
                    }
                    continue;
                }
                else
                {
                    PrintText("Ты сбился! Повтори попытку.\n " + storey);
                    continue;
                }
            }
            PrintText("Отлично! Ты добрался до 1 этажа.");
            Console.ReadLine();
            Corridor1();
        }

        void ElevatorSelection()                               //Выбор этажа в лифте
        {
            string prompt = "Выбери этаж:\n";
            List<string> options = new List<string>()
            {
                "Девятый этаж",
                "Первый этаж"
            };
            if (RoomNumber == 3)
            {
                options = new List<string>()
                {
                    "Девятый этаж",
                    "Первый этаж"
                };
            }
            else if (RoomNumber == 9)
            {
                options = new List<string>()
                {
                    "Восьмой этаж",
                    "Первый этаж"
                };
            }
            else
            {
                options = new List<string>()
                {
                    "Девятый этаж",
                    "Восьмой этаж"
                };
            }
            Menu mainMenu = new Menu(prompt, options, health, sigi);
            int selectedIndex = mainMenu.Run();

            switch (options[selectedIndex])
            {
                case "Первый этаж":
                    PrintText("Ты выбираешь первый этаж. Двери лифта закрываются.");
                    PrintText("Спустя пол минуты ты оказываешься на 1 этаже.");
                    Console.ReadLine();
                    Corridor1();
                    break;

                case "Восьмой этаж":
                    PrintText("Ты выбираешь восьмой этаж. Двери лифта закрываются.");
                    PrintText("Спустя пол минуты ты оказываешься на 8 этаже.");
                    Console.ReadLine();
                    Corridor8();
                    break;

                case "Девятый этаж":
                    PrintText("Ты выбираешь девятый этаж. Двери лифта закрываются.");
                    PrintText("Спустя несколько секунд двери открывются на этаже выше.");
                    Console.ReadLine();
                    Corridor9();
                    break;
            }
        }

        void Corridor1()                                //Первый этаж
        {
            RoomNumber = 5;

            PrintText("Ты стоишь на 1 этаже рядом с лифтами, за тобой лестничаня клетка.");
            PrintText("За углом пост охраны, контролирующий проход через турникеты.");
            Console.ReadLine();
            string prompt = "Доступные действия:\n";
            List<string> options = new List<string>() { "Подняться по лестнице",
                                                        "Подняться на лифте",
                                                        "Обмануть охрану",
                                                        "Перепрыгнуть турникеты"};
            if (keycard) options.Add("Использовать пропуск");
            Menu mainMenu = new Menu(prompt, options, health, sigi);
            int selectedIndex = mainMenu.Run();
            Console.Clear();
            switch (options[selectedIndex])
            {
                case "Подняться по лестнице":
                    PrintText("Ты проходишь на лестничную площадку и решаешь подняться до 8 этажа.");
                    PrintText("Собрав волю в кулак, ты начинаешь восхождение вверх.");
                    Console.ReadLine();
                    PrintText("Умиря от отдышки, ты поднимаешься на 8 этаж.");
                    health = СalculationHealth(health, 5, true);
                    if (health == 0) break;
                    Ladder();
                    break;

                case "Подняться на лифте":
                    if (angryComenda)
                    {
                        PrintText("Ты нажимаешь на кнопку вызова лифта.");
                        PrintText("На панели ты видишь, что лифт начал свое движение вниз с 8 этажа.");
                        Console.ReadLine();
                        PrintText("Спустя пол миниты, лифт доезжает до 1 этажа и двери распахиваются.");
                        PrintText("Ты видишь перед собой красную от злости комендантшу с двумя крепкими охранниками.");
                        Console.ReadLine();
                        PrintText("Коменда показывает на тебя пальцем и один из охранников моментально начинает сближаться.");
                        PrintText("Лысый качаок сильным и точным ударом в челюсть отправляет тебя спать.");
                        Lose();
                    }
                    else
                    {
                        PrintText("Ты нажимаешь на кнопку вызова лифта.");
                        PrintText("Несколько студентов подходят к тебе, вероятно, тоже ждут лифт.");
                        Console.ReadLine();
                        PrintText("Спустя некоторое время, лифт спускается на 1 этаж и гостепреимно открывает двери.");
                        PrintText("Ты заходишь внутрь вслед за студентами.");
                        ElevatorSelection();
                    }
                    break;

                case "Обмануть охрану":
                    PrintText("Ты спокойно и уверенно подхоишь к турникетам. Делаешь вид, что не можешь найти пропуск.");
                    PrintText("Охранник, немного подождав спрашивает:");
                    PrintText("- Молодой человек, я вас не знаю. Где ваш пропуск?");
                    Console.ReadLine();
                    ActionLieGuard();
                    break;

                case "Перепрыгнуть турникеты":
                    if (drunk)
                    {
                        PrintText("Ты решаешь прорваться через турникеты, надеясь на нерасторопность охранников.");
                        PrintText("Выгянув из-за ула, ты видишь стеклянную будку. Чуть левее от нее стоят 3 турникета с высокими ограничителями.");
                        Console.ReadLine();
                        PrintText("Подгадав момент, ты выпрыгиваешь из-за угла и сломя голову бежишь в сторону выхода.");
                        PrintText("Охранник почти сраху же замечает подозрительную активность, вскаивает со стула и бежит к двери.");
                        Console.ReadLine();
                        PrintText("За секунду добежав до турникетов, ты отталкиваешься от земли изо всех сил, чтобы перепрыгнуть финальную преграду.");
                        PrintText("Отсутствие похмелья благодаря распитой с Гошей водки дарует тебе +50 к ловкости и ты без особых усилий преодолеваешь турникеты");
                        Console.ReadLine();
                        PrintText("Пока охранник пытался открыть заевшую в будке дверь, ты уже оказался на улице.");
                        PrintText("Довольный собой, пьяный и веселый, показав пару факов грустному охраннику за дверью, ты убегаешь в сторону автобусной отсановки.");
                        Console.ReadLine();
                        Win();
                        return;
                    }
                    else
                    {
                        PrintText("Ты решаешь прорваться через турникеты, надеясь на нерасторопность охранников.");
                        PrintText("Выгянув из-за ула, ты видишь стеклянную будку. Чуть левее от нее стоят 3 турникета с высокими ограничителями.");
                        Console.ReadLine();
                        PrintText("Подгадав момент, ты выпрыгиваешь из-за угла и сломя голову бежишь в сторону выхода.");
                        PrintText("Охранник моментально замечает подозрительную активность, вскаивает со стула и бежит к двери.");
                        Console.ReadLine();
                        PrintText("За секунду добежав до турникетов, ты отталкиваешься от земли изо всех сил, чтобы перепрыгнуть финальную преграду.");
                        PrintText("Но последствия вчерашней вечеринки в лице головной боли и слабости дают о себе знать.");
                        Console.ReadLine();
                        PrintText("Зацепившись ногой за преграду, ты, как падший, но гордый, орел, летишь лицом вниз.");
                        health = СalculationHealth(health, 60, true);
                        if (health == 0) break;
                        PrintText("Сильно ударившись носом, ты начинаешь терять сознание. Последнее что ты видишь - побегающий охранник.");
                        ActionLieGuard();
                    }
                    break;

                case "Использовать пропуск":
                    PrintText("Ты спокойно и очень уверенно подхоишь к турникетам и прикладываешь пропуск к считывателю.");
                    PrintText("Загорается зеленая стрелочка - проход открыт!");
                    Console.ReadLine();
                    PrintText("Напоследок ты оборачиваешься назад, что проводить взглядом уже полюбившиеся обшарпанные стены.");
                    PrintText("После чего с улыбкой покидаешь общежитие и направляешься в сторону автобусной остановки.");
                    Console.ReadLine();
                    Win();
                    break;
            }
        }

        void ActionLieComenda()                              //Обман коменды (тебя заметили)
        {
            string prompt = "Доступные действия:\n";
            List<string> options = new List<string>() { "Ответить бегством",
                                                        "Импровизировать",
                                                        "Нагрубить"};
            if (keycard) options.Add("Использовать пропуск");
            Menu mainMenu = new Menu(prompt, options, health, sigi);
            int selectedIndex = mainMenu.Run();
            Console.Clear();
            switch (selectedIndex)
            {
                case 0:
                    PrintText("Ты, аки Усейн Болт, подскакиваешь и спринтуешь в сторону лестницы.");
                    PrintText("Адреналин переполняет твой организм.");
                    Console.ReadLine();
                    PrintText("Ты оборачиваешься и видишь в метре от себя бешеную коменду, которая бежит за тобой.");
                    PrintText("Не заметив пивную бутылку под ногами, ты спотыкаешься и летишь вниз головой по лестнице.");
                    Lose();
                    break;

                case 1:
                    PrintText("Ты решаешь взять ситуацию под контроль и обмануть злобного защитника общаги.");
                    PrintText("- Молодой человек, я жду ответа! - продолжает коменда.");
                    Console.ReadLine();
                    ActionLieComendaImprovisation();
                    break;

                case 2:
                    PrintText("Не долго думая, ты отвечаешь ей:");
                    PrintText("- Да пошла ты нахуй!");
                    Console.ReadLine();
                    PrintText("Коменда, ошарашенная таким ответом, несколько секунд стоит в недоумении.");
                    PrintText("Это твой шанс сбежать! Ты совершаешь рывок до лестничной клетки со скоростью молнии.");
                    angryComenda = true;
                    Console.ReadLine();
                    PrintText("Кажется, комендша отстала. Вряд ли тебя кто-то будет искать наверху, пока можно расслабиться.");
                    PrintText("Но теперь нужно быть крайне осторожным! Особенно на 8 этаже...");
                    Console.ReadLine();
                    PrintText("Отдышавшись ты видишь надпись '9 этаж'.");
                    PrintText("В остальном отличий от 8 этажа не наблюдается.");
                    Console.ReadLine();
                    Corridor9();
                    break;
            }
        }

        void ActionLieComendaImprovisation()                 //Обман коменды >> Сценарий с импровизацией
        {
            string prompt = "Доступные ответы:\n";
            List<string> options = new List<string>() { "Я... я приходил к другу отдать конспекты",
                                                        "Я с 9 этажа, заходил на кухню, наша закрыта",
                                                        "Я студент первого курса, недавно заехал в 806 блок"};
            if (keycard) options.Add("Использовать пропуск");
            Menu mainMenu = new Menu(prompt, options, health, sigi);
            int selectedIndex = mainMenu.Run();
            Console.Clear();
            switch (selectedIndex)
            {
                case 0:
                    PrintText("Неужели? И как тебя зовут? - спрашивает она.");
                    PrintText("Ты представляешься и сообщаешь, что тебе пора, направившись в сторону как раз подоспевшего лифта.");
                    Console.ReadLine();
                    PrintText("Коменду не устраивает твой ответ. Она идет вслед за тобой и продолжает:");
                    PrintText("И к какому другу ты ходил? Пойдем покажешь!");
                    Console.ReadLine();
                    PrintText("Коменда продолжает медленно приближаеться к тебе с  явно дурными намерениями.");
                    PrintText("Тебе ничего не остается, кроме как ответить бегством.");
                    Console.ReadLine();
                    PrintText("Ты, аки Усейн Болт, подскакиваешь и спринтуешь в сторону лестницы.");
                    PrintText("Адреналин переполняет твой организм.");
                    Console.ReadLine();
                    PrintText("Ты оборачиваешься и видишь в метре от себя бешеную коменду, которая бежит за тобой.");
                    PrintText("Не заметив пивную бутылку под ногами, ты спотыкаешься и летишь вниз головой по лестнице.");
                    Lose();
                    break;

                case 1:
                    PrintText("С чего вдруг она закрыта? Сейчас я разберусь! - возмущается она.");
                    PrintText("Ты сообщаешь, что опаздываешь и направляешься в сторону только что подоспевшего лифта.");
                    angryComenda = true;
                    Console.ReadLine();
                    PrintText("Коменда недоверчиво смотрит вслед.");
                    PrintText("Кажется, она что-то заподозрила, нужно быть аккуратне, твой обман может быть раскрыт!");
                    Console.ReadLine();
                    ElevatorSelection();
                    break;

                case 2:
                    PrintText("Я знаю каждого жителя 8 этажа лично! Даже не пытайся меня обмануть!");
                    PrintText("Коменда хватает тебя за шиворот, достает телефон и вызывает охрану.");
                    Console.ReadLine();
                    Lose();
                    break;
            }
        }

        void ActionLieGuard()                                //Обман охранника на 1 этаже
        {
            PrintText("Ты находишься в будке охраны.");

            Console.Clear();
            if (!angryGuard)
            {
                string prompt = "Доступные ответы:\n";
                List<string> options = new List<string>() { "Потерял пропуск",
                                                            "Приходил забрать конспекты",
                                                            "Нагрубить"};
                if (keycard) options.Add("Использовать пропуск");
                Menu mainMenu = new Menu(prompt, options, health, sigi);
                int selectedIndex = mainMenu.Run();
                Console.Clear();
                switch (selectedIndex)
                {
                    case 0:
                        PrintText("Ты заявляешь, что первокурсник и потерял свой пропуск.");
                        PrintText("Охранник кивает головой и приглашает пройти в свою будку.");
                        Console.ReadLine();
                        PrintText("Очевидно, у тебя нет выбора. Ты покорно следуешь указаниям.");
                        PrintText("Он подводит тебя к компьютеру, делает фото и загружает в какую-то базу данных.");
                        Console.ReadLine();
                        PrintText("Несколько минут спустя он вызывает кого-то по рации и просит спутиться вниз.");
                        PrintText("Ты понимаешь, что твоего лица нет в системе. Бежать некуда. Это конец.");
                        Lose();
                        break;

                    case 1:
                        PrintText("Ты гордо заявляешь, что приходил к другу, чтобы забрать конспекты.");
                        PrintText("Охранник кивает головой и приглашает пройти в свою будку.");
                        Console.ReadLine();
                        PrintText("Очевидно, у тебя нет выбора. Ты покорно следуешь указаниям.");
                        PrintText("Он подводит тебя к компьютеру и спрашивает твое ФИО.");
                        Console.ReadLine();
                        PrintText("Ты уверенно представляешься.");
                        PrintText("Охранник открывает журнал посещений и начинает искать твое имя.");
                        Console.ReadLine();
                        PrintText("Минуту спустя он вызывает кого-то по рации и просит спутиться вниз.");
                        PrintText("Ты понимаешь, что твоего нет в журнале. Бежать некуда. Это конец.");
                        Lose();
                        break;

                    case 2:
                        PrintText("Ты отвечаешь резко и решительно:");
                        PrintText("- Это твои проблемы, что ты меня не знаешь! И тебя волновать не должно где мой пропуск! Открой, я выйду.");
                        Console.ReadLine();
                        PrintText("Охранник, опешив от такой наглости на пару секунд, достал рацию и вызвал кого-то на первый этаж.");
                        PrintText("Поняв, что дела твои плохи, ты решаешь ответить бегством.");
                        angryComenda = true;
                        angryGuard = true;
                        Console.ReadLine();
                        PrintText("Кажется, охранник остался в будке и даже не пытался тебя догнать. Но теперь за тобой может начаться охота!");
                        PrintText("Нужно быть еще аккуратнее...");
                        Corridor1();
                        break;
                }
            }
            else
            {
                PrintText("Второй раз меня не проведешь, засранец!");
                Console.ReadLine();
                Lose();
            }
        }

        void ActionCodeAlex()                                //Нужно угадать код Алексея. Комната 913
        {
            if (health <= 0) return;
            if (attempt > 0 && keycard)
            {
                PrintText("Я дал тебе все, что требуется. Не трать мое время!");
                attempt = 0;
                Console.ReadLine();
                Corridor9();
            }
            else if (attempt <= 0 && keycard)
            {
                PrintText("Ну все, ты меня достал!");
                PrintText("Резко открывшаяся дверь опрокидывает тебя на пол.");
                Console.ReadLine();
                PrintText("Ты видишь, как Алексей выходит из блока и быстро приближается к тебе.");
                PrintText("Его огромный кулак отправляет тебя в нокаут.");
                health = СalculationHealth(health, 80, true);
                if (health == 0) return;
                PrintText("Спустя несколько минут ты приходишь в себя.");
                PrintText("Лучше не злить этого парня!");
                Corridor9();
            }
            else if (attempt <= 0 && !keycard)
            {
                PrintText("Дверь резко открывается и перед тобой появляется здоровый бык качок.");
                PrintText("Он кричит что-то непонятное про ФCБ и, что они его не дотсанут!");
                Console.ReadLine();
                PrintText("Спустя мгновенье, ты видишь стремительно приближающийся к твоей челюсти огромный кулак.");
                PrintText("В глазах темнеет. Ты падаешь на пол без сознания.");
                health = СalculationHealth(health, 90, true);
                if (health == 0) return;
                PrintText("Спустя несколько минут ты приходишь в себя.");
                PrintText("Лучше не злить этого парня!");
                Console.ReadLine();
                Corridor9();
            }

            string answer = "";

            while (answer.ToLower() != code.ToLower() && !keycard)
            {
                if (health <= 0) return;
                if (attempt <= 0 && health > 0) ActionCodeAlex();
                Console.Clear();
                PrintText("Чтобы войти, назови код!");
                PrintText("Осталось попыток: " + attempt);
                PrintText("Введи код или введи слово - 'отойти':");

                answer = Console.ReadLine();

                if (answer.ToLower() == "отойти")
                {
                    PrintText("Ты решаешь не рисковать, извиняешься и отходишь от двери.");
                    Console.ReadLine();
                    answer = "";
                    Corridor9();
                    return;
                }
                else if (answer.ToLower() != "отойти" && answer.ToLower() != code.ToLower() && answer.ToLower() != "")
                {
                    PrintText("Неправильно!");
                    attempt--;
                    if (attempt <= 0) ActionCodeAlex();
                    if (health <= 0) return
                            ;
                    PrintText("Отсалось попыток: " + attempt);
                    Console.ReadLine();
                    continue;
                }
                else if (answer.ToLower() == code.ToLower())
                {
                    PrintText("Правильно!");
                    Console.ReadLine();
                    RoomNumber = 8;
                    Room913();
                    break;
                }
                Console.Clear();
                continue;
            }
        }

        public void Win()                                           //Победа!
        {
            PrintText(@"

██╗    ██╗██╗███╗   ██╗██╗
██║    ██║██║████╗  ██║██║
██║ █╗ ██║██║██╔██╗ ██║██║
██║███╗██║██║██║╚██╗██║╚═╝
╚███╔███╔╝██║██║ ╚████║██╗
 ╚══╝╚══╝ ╚═╝╚═╝  ╚═══╝╚═╝
                          ");
            PrintText("Поздравляем! Ты успешно покинул общагу!");
            PrintText("Игра окончена! Победа!");
            Console.ReadLine();
            RoomNumber = 0;
            return;
        }

        void Lose()                                          //Поражение!
        {

            health = 50;
            PrintText(@"
 ▄████  ▄▄▄       ███▄ ▄███▓▓█████     ▒█████   ██▒   █▓▓█████  ██▀███  
 ██▒ ▀█▒▒████▄    ▓██▒▀█▀ ██▒▓█   ▀    ▒██▒  ██▒▓██░   █▒▓█   ▀ ▓██ ▒ ██▒
▒██░▄▄▄░▒██  ▀█▄  ▓██    ▓██░▒███      ▒██░  ██▒ ▓██  █▒░▒███   ▓██ ░▄█ ▒
░▓█  ██▓░██▄▄▄▄██ ▒██    ▒██ ▒▓█  ▄    ▒██   ██░  ▒██ █░░▒▓█  ▄ ▒██▀▀█▄  
░▒▓███▀▒ ▓█   ▓██▒▒██▒   ░██▒░▒████▒   ░ ████▓▒░   ▒▀█░  ░▒████▒░██▓ ▒██▒
 ░▒   ▒  ▒▒   ▓▒█░░ ▒░   ░  ░░░ ▒░ ░   ░ ▒░▒░▒░    ░ ▐░  ░░ ▒░ ░░ ▒▓ ░▒▓░
  ░   ░   ▒   ▒▒ ░░  ░      ░ ░ ░  ░     ░ ▒ ▒░    ░ ░░   ░ ░  ░  ░▒ ░ ▒░
░ ░   ░   ░   ▒   ░      ░      ░      ░ ░ ░ ▒       ░░     ░     ░░   ░ 
      ░       ░  ░       ░      ░  ░       ░ ░        ░     ░  ░   ░     
                                                     ░                   ");

            PrintText("Игра окончена! Поражение!");
            Console.ReadLine();

        }

        static string GirlNames()                                   //Имя девушки
        {
            Random rnd = new Random();
            string[] codeVariants = { "Света", 
                                      "Ангелина", 
                                      "Настя", 
                                      "Ира", 
                                      "Кристина", 
                                      "Маша", 
                                      "Катя", 
                                      "Таня", 
                                      "Наташа", 
                                      "Мадина",
                                      "Вика",
                                      "Ксюша",
                                      "Лера",
                                      "Жанна",
                                      "Даша",
                                      "Оля",
                                      "Карина" };

            int rndFunction = rnd.Next(codeVariants.Length);
            string girlName = codeVariants[rndFunction];
            return girlName;
        }
        static string Codename()                                    //Псевдо рандомайзер кодового слова из списка в начале игры
        {
            Random rnd = new Random();
            string[] codeVariants = { "Убийца багов", "Ровный код", "Гладкий криминал",
                                    "Свежий кабанчик", "Здоровый мужик", "Веселый взломщик", "Кодомастер",
                                    "Прогрогигант", "Whos your daddy", "I see dead people", "Истребитель пива",
                                    "Дырявое седло", "Кузя Лакомкин", "Сап Двощ", "Пивной путь", "Страж ДОТЫ",
                                    "Быстро в палату", "Хочу пиццу", "Веб мастер", "Бегом в палату", "Это пароль",
                                    "Гуру таленда", "Интегратор 2000" };
            int rndFunction = rnd.Next(codeVariants.Length);
            string resultatate = codeVariants[rndFunction];
            return resultatate;
        }

        void Loading(string text)                                       //ProcessBar Загрузка без сознания
        {
            Console.Clear();
            PrintText(text);
            Console.CursorVisible = false;
            Console.SetCursorPosition(1, 1);
            for (int i = 0; i < 31; i++)
            {
                for (int y = 0; y < i; y++)
                {
                    string pb = "\u2551";
                    Console.Write(pb);
                }
                Console.Write(i + " / 30");
                Console.SetCursorPosition(1, 1);
                System.Threading.Thread.Sleep(100);
            }
            Console.Clear();
            Console.CursorVisible = true;
            Console.ReadLine();
        }

        public int СalculationHealth(int сurrentHealth, int damage, bool dmgHeal)
        {
            if (dmgHeal)
            {
                сurrentHealth = сurrentHealth - damage;
                if (сurrentHealth < 0) сurrentHealth = 0;
                Console.Write("\nТы получил урон! (");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("-" + damage);
            }
            else
            {
                сurrentHealth = сurrentHealth + damage;
                if (сurrentHealth > 100)
                {
                    сurrentHealth = 100;
                    Console.Write("\nТвое здоровье на максимуме! (");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("+" + damage);
                }
                else
                {
                    Console.Write("\nЗдоровье восстановлено! (");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("+" + damage);
                }
            }
            Console.ResetColor();

            Console.Write(")\nТекущее здоровье: ");

            if (сurrentHealth >= 50) Console.ForegroundColor = ConsoleColor.Green;
            else if (сurrentHealth < 50 && сurrentHealth >= 30) Console.ForegroundColor = ConsoleColor.Yellow;
            else if (сurrentHealth < 30) Console.ForegroundColor = ConsoleColor.Red;

            Console.Write(сurrentHealth);
            Console.WriteLine();
            Console.ReadLine();
            Console.ResetColor();

            if (сurrentHealth <= 0 || сurrentHealth == 0)
            {
                health = 50;
                Lose();
            }

            return сurrentHealth;
        }

        public void RunMainMenu()
        {
            string prompt = @"
░█████╗░██████╗░░██████╗██╗░░██╗░█████╗░██╗░░██╗░█████╗░░██████╗░░█████╗░
██╔══██╗██╔══██╗██╔════╝██║░░██║██╔══██╗██║░░██║██╔══██╗██╔════╝░██╔══██╗
██║░░██║██████╦╝╚█████╗░███████║██║░░╚═╝███████║███████║██║░░██╗░███████║
██║░░██║██╔══██╗░╚═══██╗██╔══██║██║░░██╗██╔══██║██╔══██║██║░░╚██╗██╔══██║
╚█████╔╝██████╦╝██████╔╝██║░░██║╚█████╔╝██║░░██║██║░░██║╚██████╔╝██║░░██║
░╚════╝░╚═════╝░╚═════╝░╚═╝░░╚═╝░╚════╝░╚═╝░░╚═╝╚═╝░░╚═╝░╚═════╝░╚═╝░░╚═╝

Текстовый квест 
Beta v3.0
";
            List<string> options = new List<string>() { "Новая игра", 
                                                        "Управление", 
                                                        "Создатели", 
                                                        "Выход" };
            Menu mainMenu = new Menu(prompt, options, 101, 101);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Intro();
                    break;
                case 1:
                    Console.Clear(); ;
                    PrintText("Управление реализовано стрелочками и вводом:");
                    PrintText(@"                                                                                                                                                                
                                                                                
                                                                             
               ________                                        ____________      
              |........|                                      |      ..... |     
              |.../\...|                 #                    |        ... |     
              |........|               #####                  |        ... |     
                ******                   #             _______|         .. |     
    ________    ______    ________                    | ..             ....|     
   |........| |........| |........|                   | ...    ENTER   ....|     
   |...<<...| |...\/...| |...>>...|                   | .....       .......|     
   |........| |........| |........|                   | ...................|     
    ********   ********   ********                      ******************       
                                                                                ");
                    PrintText("Начинай игру и не выебывайся\n");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    PrintText("* << Назад >>");
                    Console.ReadLine();
                    Console.ResetColor();
                    Console.Clear();
                    RunMainMenu();
                    break;
                case 2:
                    Console.Clear();
                    PrintText("Тут должен быть текст... Наверное...\n");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    PrintText("* << Назад >>");
                    Console.ReadLine();
                    Console.ResetColor();
                    Console.Clear();
                    RunMainMenu();
                    break;
                case 3:
                    PrintText("Выход...");
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }

        void PrintText(string message)
        {
            ConsoleKeyInfo cki = new ConsoleKeyInfo();
            int time = 0;
            for (int i = 0; i < message.Length; i++)
            {
                if (cki.Key == ConsoleKey.Enter) Console.Write("ENTER!!!");
                Console.Write(message[i]);
                System.Threading.Thread.Sleep(time);
            }
            Console.WriteLine();
            System.Threading.Thread.Sleep(time * 100);
            return;
        }

        public void NewGame()
        {
            phone = true;
            phoneNumber = false;                               // Оставить девушке номер телефона
            sosed = true;
            Key = false;                                       // Ключ для открытия двери
            Sam = false;                                       // Сэм выбежал из шкафа?
            shkaf = false;                                     // Чтобы нельзя было бесконечно брать сиги из шкафа
            Vodka = false;                                     // Нужен для получения инф от Ивана
            Ivan = true;                                       // Иван жив или же набухан в сраку
            KitchenSigi = false;                               // Проверка поиска на полках кухни
            keycard = false;                                   // Пропуск для выхода из общаги
            drunk = false;                                     // Проверяет твое алкогольное опьянение
            tualet = true;                                    // Информирование об Иване в прихоже 806. Если false - разговор с уже Иваном был
            Door806 = false;                                   // Проверка открыта ли дверь в начальной комнате.
            angryComenda = false;                              // Состояние коменды. Если тру - оставаться на этаже опасно
            angryGuard = false;                                // Состояни охраны на КПП. Если тру - выходить опасно.
            GoshaNeverSleep = false;                           // Гоша проснулся?
            thiefSigi = false;                                 // Сиги украдены?
            girl = false;
            botan = false;
            xpysteam = false;
            girlQ = true;
            health = 80;                                        // Текущее здоровье
            attempt = 2;                                        // Кол-во попыток, чтобы угадать код Алексея
            sigiGoshi = 2;                                      // Кол-во сигарет в пачке у Гоши
            sigi = 0;                                           // Кол-во сигарет в инвентаре (для балкона)
            RoomNumber = 1;
            health = 80;
            code = Codename();
            girlName = GirlNames();
            Intro();
        }

        public void Resume()
        {
            while (true) 
            {
                if (health <= 50) health = 50;
                attempt = 2;
                if (RoomNumber == 0) WakeUp();
                if (RoomNumber == 1) Room806();
                else if (RoomNumber == 2) IToilet();
                else if (RoomNumber == 3) Corridor8();
                else if (RoomNumber == 4) Kitchen();
                else if (RoomNumber == 5) Corridor1();
                else if (RoomNumber == 6) ActionBalkon();
                else if (RoomNumber == 7) Room915();
                else if (RoomNumber == 8) Room913();
                else if (RoomNumber == 9) Corridor9();
                else if (RoomNumber == 10) PodvalPovara();
                break;
            }
        }

/*        void Miganie()
        {
            string txt = "Hello, world!";
            while (true)
            {
                WriteBlinkingText(txt, 500, true);
                WriteBlinkingText(txt, 500, false);
            }
        }

        private static void WriteBlinkingText(string text, int delay, bool visible)
        {
            if (visible)
                Console.Write(text);
            else
                for (int i = 0; i < text.Length; i++)
                    Console.Write(" ");
                    Console.CursorLeft -= text.Length;
                    System.Threading.Thread.Sleep(delay);
         }*/
    }
}

/*Простая таблица 
 * 
string name = "Ivan";
string surname = "Ivanov";
int age = 26;
PrintText("Имя: {0, 10} | Фамилия: {1, 5} | Возраст: {2}", name, surname, age.ToString());
PrintText("Имя: {0, 10} | Фамилия: {1, 5} | Возраст: {2}", name, surname, age.ToString());*/
