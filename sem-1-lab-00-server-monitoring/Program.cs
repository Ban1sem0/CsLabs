using System;
namespace lab01
{
    class Program
    {
        /// <summary>
        /// TEST
        /// </summary>



        public static void Main()
        {
            Random random = new Random();
            int people = random.Next(5000,8001);
            int pingServer = random.Next(20,81);
            int pingPeople = random.Next(15, 71);
            Console.WriteLine("Добро пожаловать на сервер ЧелГУ, введите пароль (фамилия лучшего программиста в мире): ");
            string password = Console.ReadLine();
            if (password == "Кирсанов" )
            {
                Console.WriteLine("Успешно! Проверить сервер ЧелГУ? (y/n)");
                string yn = Console.ReadLine();
                if (yn == "y")
                {
                    Console.Write("Запускается проверка сервера"); Console.Write("."); Console.Write("."); Console.WriteLine(".");
                    Console.WriteLine("Информация о сервере:");
                    Console.WriteLine("--------------------------------------------------------------");
                    if (people > 6001)
                    {
                        Console.WriteLine($"Большое кол-во учащихся {people}, возможна высокая нагрузка на сервер");
                    }
                    else
                    {
                        Console.WriteLine($"Количество учащихся - {people}");
                    }
                    if (pingServer > 59)
                    {
                        Console.WriteLine($"Пинг сервера высокий {pingServer}! Возможны неполадки!");
                    }
                    else
                    {
                        Console.WriteLine($"пинг сервера в норме: {pingServer}");
                    }
                    if (pingPeople > 49)
                    {
                        Console.WriteLine($"Пинг учащихся высокий - {pingPeople}, проверьте сервер");
                    }
                    else
                    {
                        Console.WriteLine($"Пинг учащихся в норме - {pingPeople}");
                    }
                    Console.WriteLine("--------------------------------------------------------------");
                    if (pingServer >= 51 && pingPeople >= 61 && people >= 7001)
                    {
                        Console.WriteLine("Сервер сильно нагружен, запуск невозможен!");
                        return;
                    }
                    else if (pingPeople >= 40 && pingPeople <= 60 && pingServer >= 50 && pingServer <= 60 && people >= 6001 && people <= 7000)
                        {
                            Console.WriteLine("Сервер немного нагружен, для запуска напишите 'подтверждаю'");
                            string confirm = Console.ReadLine();
                            if (confirm == "подтверждаю")
                            {
                                Console.WriteLine("Сервер запущен!");
                            }
                            else
                            {
                                Console.WriteLine("Сервер не запущен!");
                                return;
                            }
                        }
                     else
                    {
                        Console.WriteLine("Сервер готов к запуску");
                    }
                }
                else
                {
                    Console.WriteLine("Проверка сервера отменена, выход из системы");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Пароль неверный, пока!");
                return;
            }
        }
    }
}