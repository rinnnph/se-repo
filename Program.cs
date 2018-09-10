﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace tamagotchi
{
    class Program
    {
        static void Main(string[] args)
        {
            string you = "";
            string name = "";

            while (you == "")
            {
                Write("Добро пожаловать, как тебя зовут?");
                Console.WriteLine();
                you = Console.ReadLine();
                Console.WriteLine();
            }

            while (name == "")
            {
                Write("Приятно познакомиться!А как назовёшь своего питомца?");
                YouTalk(you);
                name = Console.ReadLine();
            }


            // Яйцо
            var tama = new Tama(name);
            tama.Hatching();
            tama.ChangeStage("Ребёнок");


            // Ребёнок
            tama.WriteTama();
            tama.TamaTalks("Я так рад тебя видеть, " + you + "! *урчание в животе*");
            Write(tama.Name + " очень голоден, тебе нужно покормить его!");
            Feed(tama, you);

            tama.WriteTama();
            tama.TamaTalks(tama.food != "Ничего" ? "Ням, ням, ням, " + tama.food + "!" : "*постукивание*");
            tama.TamaTalks("Хочу играть!");
            bool play = YesNo(tama, you);

            tama.WriteTama();
            tama.TamaTalks(play ? "УРА!" : "Буууу!");
            tama.TamaTalks("Я всё ещё голоден! Покорми меня!");
            Feed(tama, you);

            tama.WriteTama();
            tama.TamaTalks(tama.food != "Ничего" ? "Ням, ням, ням, люблю " + tama.food + "!" : "Эээй, Я всего лишь ребёнок, мне нужна еда!");
            tama.TamaTalks("Уже поздно и я очень сонный. \r\nВыключишь свет для меня?");
            bool lights = YesNo(tama, you);
            if (lights)
            {
                tama.Happy += 1;
                tama.Dicipline += 1;
                Night();
            }
            else
            {
                tama.WriteTama();
                tama.TamaTalks("Ну пожалуйста, я правда хочу спать! *зевает*");
                lights = YesNo(tama, you);

                if (lights)
                {
                    tama.Happy += 1;
                    Night();
                }
                else
                {
                    tama.Dicipline = (tama.Dicipline != 0 ? tama.Dicipline -= 1 : 0);
                    tama.WriteTama();
                    tama.TamaTalks("*злится*");
                    Write("Извини, но теперь ты и " + tama.Name + " не будете спать всю ночь...");
                    System.Threading.Thread.Sleep(2000);
                    Night();
                }
            }

            tama.WriteTama();
            tama.TamaTalks(tama.Happy > 1 ? "Доброе утро " + you + "!" : "Ты не нравишься мне слишком сильно, " + you);
            Write("Время завтрака!");
            Feed(tama, you);

            tama.WriteTama();

            if (tama.Poop == 0)
            {
                tama.ChangeStage("Умер.");
                tama.WriteTama();
                Write("Бедный " + tama.Name + " умер от голода!");
                Write("Тебе не следует заводить питомцев, " + you + "...");
                Console.WriteLine();
                Write("Нажми ENTER, чтобы выйти.");
                Console.ReadLine();
                return;
                //конец
            }

            Write("По-моему " + tama.Name + " испачкался, помыть его?");
            bool poop = YesNo(tama, you);
            if (poop) tama.Poop = 0;

            if (tama.Dicipline > 2) tama.ChangeStage("Хороший подросток");
            else tama.ChangeStage("Плохой подросток");


            //подросток
            tama.WriteTama();
            if (tama.Good)
            {
                tama.TamaTalks(poop ? "Спасибо, " + you + "!" : "Наверное о нём можно позаботиться позже...");
                Write("Ой! " + tama.Name + " вырос!");
                Write("И он выглядит здоровым и отлично воспитанным.\r\nПродолжай в том же духе!");
            }
            else
            {
                tama.TamaTalks("Без разницы...");
                Write("Ой! " + tama.Name + "вырос испорченным подростком!");
                Write("Тебе действительно стоило бы начать быть хорошим родителем...");
            }

            System.Threading.Thread.Sleep(2000);
            Console.WriteLine();
            tama.TamaTalks(tama.Good ? "Хочешь поиграть?" : "Развлекай меня!");
            play = YesNo(tama, you);

            tama.WriteTama();
            if (tama.Good) tama.TamaTalks(play ? "Ты такой смешной! Все эти игры заставили меня проголодаться!" : "Ладно, в другой раз... Могу я что-нибудь поесть?");
            else tama.TamaTalks(play ? "Ты находишь это смешным? Сейчас же ПОКОРМИ МЕНЯ!" : "*вздох* ПОКОРМИ МЕНЯ!");
            Feed(tama, you);

            tama.WriteTama();
            Write("Становится поздно, тебе следует уложить " + tama.Name + " в постель и выключить свет!");
            lights = YesNo(tama, you);
            bool stayUp;

            if (tama.Good)
            {
                if (lights)
                {
                    tama.Dicipline += 1;
                    tama.TamaTalks("Спокойной ночи " + you + "!");
                    System.Threading.Thread.Sleep(1000);
                }
                else
                {
                    tama.Dicipline = (tama.Dicipline != 0 ? tama.Dicipline -= 1 : 0);
                    tama.TamaTalks("Могу я не спать всю ночь?");
                    stayUp = YesNo(tama, you);

                    if (stayUp)
                    {
                        tama.Dicipline = (tama.Dicipline != 0 ? tama.Dicipline -= 3 : 0);
                        tama.WriteTama();
                        Write("Не самое мудрое решение");
                        lights = false;
                        System.Threading.Thread.Sleep(2000);
                    }
                    else
                    {
                        tama.Happy += 1;
                    }
                }
            }
            else
            {
                var complaint = new List<string>();
                complaint.AddRange(new String[] {
                        "Я не пойду в постель!",
                        "Ты не заставишь меня!",
                        "Посмотри, Я НЕ СПЛЮ! Ты мне не хозяин!",
                        });

                for (int i = 0; i < 3; i++)
                {
                    if (lights) tama.Dicipline += 1;
                    else tama.Dicipline = (tama.Dicipline != 0 ? tama.Dicipline -= 1 : 0);

                    tama.TamaTalks(complaint[i]);
                    Write("Отправить " + tama.Name + " в кровать?");
                    lights = YesNo(tama, you);
                }

                if (!lights)
                {
                    tama.TamaTalks("Окей, я никогда не пойду в кровать.");
                    Write("Вам нужно уложить " + name + " в кровать!");
                    lights = YesNo(tama, you);
                    if (!lights)
                    {
                        tama.Dicipline = (tama.Dicipline != 0 ? tama.Dicipline -= 2 : 0);
                        tama.Happy = (tama.Happy != 0 ? tama.Happy -= 2 : 0);
                        tama.WriteTama();
                        tama.TamaTalks("*идущий берсерк*");
                        Write("Сохраняйте спокойствие...");
                        System.Threading.Thread.Sleep(2000);
                    }
                    else
                    {
                        tama.Happy = (tama.Happy != 0 ? tama.Happy -= 1 : 0);
                        tama.Dicipline += 1;
                    }
                }
            }
            Night();

            if (!lights)
            {
                Console.Clear();
                Write("Поскольку " + tama.Name + " не спал всю ночь, он не проснётся.");
                Write("Если ты не хочешь, чтобы у тебя было плохое домашнее животное \r\nтебе следует показать кто тут хозяин!");
                System.Threading.Thread.Sleep(2000);
                Console.WriteLine();
                Write("Поднимай " + tama.Name + " !");
                bool wake = YesNo(tama, you);

                while (!wake)
                {
                    var wakeIt = new List<string>();
                    wakeIt.AddRange(new String[] {
                        "Тебе следует встать, "+tama.Name+" ...",
                        "Поднимайся!",
                        "Вставай "+tama.Name+" или станешь ленивым!",
                        "Серьёзно, тебе следует быть ответственнее в воспитании питомца!",
                        you+", просыпайся!!",
                        "Ну давай, "+tama.Name+" вставай уже!",
                        "Вставай сейчас же!"
                        });
                    Random r = new Random();
                    int index = r.Next(wakeIt.Count);

                    tama.TamaTalks("Хрррррррр...");
                    Write(wakeIt[index]);
                    wake = YesNo(tama, you);
                }
                if (wake) tama.Dicipline += 1;
            }

            tama.WriteTama();
            tama.TamaTalks(tama.Good ? "Доброе утро,  " + you + "! \r\nМожно мне позавтракать, пожалуйста?" : "Почему ты разбудил меня!? \r\nЛучше бы тебе дать мне что-то вкусное на завтрак... \r\n Я просто хочу конфет!");
            Feed(tama, you);

            if (!tama.Good)
            {
                int i = 0;

                while (tama.food == "хлеб")
                {
                    var complaint = new List<string>();
                    complaint.AddRange(new String[] {
                        "Хлеб не вкусный... Я хочу конфеты!",
                        "Я же сказал! Я НЕ ХОЧУ хлеб, я хочу конфеты!!",
                        "ТОЛЬКО НЕ ХЛЕБ!!!"
                        });

                    tama.Dicipline += 1;
                    tama.WriteTama();
                    tama.TamaTalks(complaint[i]);
                    i += 1;
                    if (i == 3) break;
                    Feed(tama, you);
                }

                Write(tama.food == "конфеты" ? "Ты не должен вознаграждать плохое поведение конфетами..." : "Вау, ты начал делать небольшие успехи.");
                System.Threading.Thread.Sleep(2000);
            }

            tama.WriteTama();
            if (tama.food == "хлеб" && !tama.Good) tama.TamaTalks(tama.food + "Хлеб... *недоволен*");
            if (tama.food != "ничего" && tama.Good) tama.TamaTalks("НЯЯЯМ, " + tama.food + "!");
            if (tama.food == "ничего") tama.TamaTalks(tama.Good ? "Ладно, но я на самом деле голоден..." : "Не может быть! Ты не покормишь меня...?");

            if (tama.Poop > 0)
            {
                Write("Хм, тебе следует прибрать за " + tama.Name + ". \r\nСделаешь это?");
                poop = YesNo(tama, you);
                if (poop) tama.Poop = 0;
            }

            if (tama.Poop > 0 || tama.Happy < 3)
            {
                Write("О нет, " + tama.Name + " не чувствует себя хорошо... \r\nДай ему немного лекарств!");
                bool meds = YesNo(tama, you);
                if (!meds)
                {
                    tama.ChangeStage("Умер");
                    tama.WriteTama();
                    Write("Зачем, " + you + "!? \r\nТеперь " + tama.Name + " умер...");
                    Write("У тебя на самом деле не было домашних питомцев, " + you + "...");
                    Console.WriteLine();
                    Write("Нажми Enter, чтобы выйти.");
                    Console.ReadLine();
                    return;
                    //END
                }
                else
                {
                    tama.Happy += 2;
                }
            }
            else System.Threading.Thread.Sleep(2000);

            tama.ChangeStage(tama.Dicipline > 3 ? "Хороший Взрослый" : "Плохой Взрослый");
            tama.WriteTama();
            Write(tama.Good ? "Хорошая работа, " + you + ", \r\nты вырастил своего " + tama.Name + " хорошим и приличным питомцем!" : "Извини, " + you + ". Ты не очень хорош в воспитании " + tama.Name + "...");
            if (tama.Good)
            {
                tama.TamaTalks("Хочешь поиграть со мной?");
                play = YesNo(tama, you);

                int i = 0;
                while (!play)
                {
                    var wannaPlay = new List<string>();
                    wannaPlay.AddRange(new String[] {
                        "Но я думаю мы хоршо повеселимся вместе,\r\nне хочешь поиграть со мной?",
                        "Я больше тебе не нравлюсь? Я хочу играть с тобой!",
                        "Теперь мне правда грустно... Прошу тебя, поиграй со мной?",
                        "*плачет*"
                        });

                    tama.Happy = (tama.Happy != 0 ? tama.Happy -= 1 : 0);
                    tama.TamaTalks(wannaPlay[i]);
                    i += 1;
                    if (i == 4) break;
                    YesNo(tama, you);
                }
            }
            else
            {
                Write("Тебе следует поиграть немного с " + tama.Name + ".");
                play = YesNo(tama, you);

                int i = 0;
                while (play)
                {
                    var wannaPlay = new List<string>();
                    wannaPlay.AddRange(new String[] {
                        "Я не хочу играть с тобой...",
                        "Ты не слышишь меня? Я не хочу играть!",
                        "НЕЕЕЕТ!"
                        });

                    tama.Happy -= 1;
                    tama.Dicipline += 1;
                    tama.TamaTalks(wannaPlay[i]);
                    Write("Играть с " + tama.Name);
                    i += 1;
                    if (i == 3) break;
                    YesNo(tama, you);
                }
            }

            tama.WriteTama();
            if (tama.Good) tama.TamaTalks(play ? "Это было правда весело" + you + " !" : "Но теперь мне грустно...");
            else tama.TamaTalks(play ? "Это было так весело... НЕТ!" : "Забей...");

            Console.WriteLine();
            tama.TamaTalks("Я не очень хорошо чувствую себя...");
            tama.TamaTalks("Мне очень холодно, ты позаботишься обо мне?");
            var comfort = YesNo(tama, you);

            if (comfort)
            {
                tama.Happy += 2;
                tama.TamaTalks("Я чувствую, как будто исчезаю... \r\n");
                tama.TamaTalks(tama.Good ? "Ты так хорошо относился ко мне..." : "Спасибо за то, что заботился, даже когда я вёл себя плохо...");
            }
            else
                tama.Happy = 3;

            System.Threading.Thread.Sleep(2000);

            tama.ChangeStage(tama.Happy > 4 ? "ангел" : "умер");
            tama.WriteTama();
            if (tama.Good)
            {
                Write(tama.Name + " умер... Но ты отлично заботился о нём. Он прожил счастливую жизнь!");
                Write("Нажми ENTER, чтобы покинуть игру.");
                Console.ReadLine();
                return;
                //конец
            }
            else
            {
                Write(tama.Name + " умер... \r\nИзвини, но ты на самом ужасный хозяин питомца " + you);
                Write("Нажми ENTER, чтобы покинуть игру.");
                Console.ReadLine();
                return;
                //конец
            }


        }




        static void Write(string String)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine();
            Console.WriteLine(String);
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void YouTalk(string you)
        {
            Console.WriteLine();
            Console.Write(you + "> ");
        }

        static bool YesNo(Tama tama, string you)
        {
            bool answer = false;
            bool final = false;

            Write("[ да ]   [ нет ]");
            YouTalk(you);

            while (answer == false)
            {
                string readLine = Console.ReadLine().ToLower();

                if (readLine == "да" || readLine == "Да")
                {
                    tama.Happy += 1;
                    answer = true;
                    final = true;
                }
                else if (readLine == "нет" || readLine == "Нет")
                {
                    tama.Happy = (tama.Happy != 0 ? tama.Happy -= 1 : 0);
                    answer = true;
                    final = false;
                }
                else
                {
                    Write("[ да ]   [ нет ]");
                    YouTalk(you);
                    answer = false;
                }

            }
            return final;
        }

        static void Feed(Tama tama, string you)
        {
            bool fed = false;

            Write("Выберите: [ Хлеб ] [ Конфеты ] [ Ничего ]");
            YouTalk(you);

            while (fed == false)
            {
                tama.food = Console.ReadLine().ToLower();

                if (tama.food == "хлеб"||tama.food == "Хлеб")
                {
                    tama.Dicipline += 1;
                    tama.Hungry += 3;
                    fed = true;
                }
                else if (tama.food == "конфеты"||tama.food == "Конфеты")
                {
                    tama.Dicipline = (tama.Dicipline != 0 ? tama.Dicipline -= 1 : 0);
                    tama.Hungry += 2;
                    fed = true;
                }
                else if (tama.food == "ничего" || tama.food == "Ничего")
                {
                    tama.Hungry = (tama.Hungry != 0 ? tama.Hungry -= 1 : 0);
                    fed = true;
                }
                else
                {
                    Write("Выберите: [ Хлеб ] [ Конфеты ] [ Ничего ]");
                    YouTalk(you);
                }

            }

        }


        static void Night()
        {
            Console.Clear();
            var stars = new List<string>();
            stars.AddRange(new String[] {
                        "        *       ",
                        "              *       ",
                        "    *            ",
                        "          *          ",
                        "  *        ",
                        "           *    ",
                        "        *      "
                        });


            for (int i = 0; i < 200; i++)
            {

                Random s = new Random();
                int index = s.Next(stars.Count);

                if (i % 2 == 0)
                    Console.ForegroundColor = ConsoleColor.Gray;
                else if (i % 3 == 0)
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                else
                    Console.ForegroundColor = ConsoleColor.DarkCyan;

                Console.Write(stars[index]);
                System.Threading.Thread.Sleep(2);

            }

            System.Threading.Thread.Sleep(700);
            Console.ForegroundColor = ConsoleColor.White;

        }


    }




}

