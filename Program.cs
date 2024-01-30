using System;
using NLog;

namespace nloglab
{
    class Program
    {
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите число: ");
                int handleNumber = int.Parse(Console.ReadLine());

                InfiniteLoopClass test = new InfiniteLoopClass();
                test.InfiniteLoop(handleNumber);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка: {0}", ex.Message);
            }
        }

        public class InfiniteLoopClass
        {
            public void InfiniteLoop(int number)
            {
                try
                {
                    while (true)
                    {
                        checked
                        {
                            number *= number;
                        }
                    }
                }
                catch (OverflowException ex)
                {
                    logger.Error(ex, "Переполнение в бесконечном цикле умножения числа {0}", number);
                    throw;
                }
            }
        }
    }
}
