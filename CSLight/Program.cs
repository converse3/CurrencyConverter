using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace CSLight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float rubToUSD = 0.011f;
            float usdToRUB = 90.41f;

            float countToExchange;

            float rubWallet = 0, usdWallet = 0;

            int selectionWallet;
            int exchangeOperation;
            float finalCountToExchange;

            Console.WriteLine("\n---------------");
            Console.WriteLine("1. RUBLES WALLET");
            Console.WriteLine("2. DOLLARS WALLET");
            Console.WriteLine("3. BOTH WALLETS");
            Console.WriteLine("---------------\n");

            Console.Write("Укажите кошелек для пополнения: ");
            selectionWallet = Convert.ToInt32(Console.ReadLine());

            switch(selectionWallet)
            {
                case 1:
                    Console.WriteLine("\n---------------");
                    Console.WriteLine("БУДЕТ ПОПОЛНЕН КОШЕЛЕК В РУБЛЯХ");
                    Console.WriteLine("---------------\n");
                    Console.Write("Укажите сумму рублей для пополнения: ");
                    rubWallet += Convert.ToSingle(Console.ReadLine());
                    Console.WriteLine("\n---------------");
                    Console.WriteLine($"К ПОПОЛНЕНИЮ {rubWallet}РУБ.");
                    Console.WriteLine("---------------\n");
                    break;
                case 2:
                    Console.WriteLine("\n---------------");
                    Console.WriteLine("БУДЕТ ПОПОЛНЕН КОШЕЛЕК В ДОЛЛАРАХ");
                    Console.WriteLine("---------------\n");
                    Console.Write("Укажите сумму долларов для пополнения: ");
                    usdWallet += Convert.ToSingle(Console.ReadLine());
                    Console.WriteLine("\n---------------");
                    Console.WriteLine($"К ПОПОЛНЕНИЮ ${usdWallet}");
                    Console.WriteLine("---------------\n");
                    break;
                case 3:
                    Console.WriteLine("\n---------------");
                    Console.WriteLine("БУДУТ ПОПОЛНЕНЫ ОБА КОШЕЛЬКА");
                    Console.WriteLine("---------------\n");
                    Console.Write("Укажите сумму рублей для пополнения: ");
                    rubWallet += Convert.ToSingle(Console.ReadLine());

                    Console.Write("Укажите сумму долларов для пополнения: ");
                    usdWallet += Convert.ToSingle(Console.ReadLine());

                    Console.WriteLine("\n---------------");
                    Console.WriteLine($"К ПОПОЛНЕНИЮ ${usdWallet} И {rubWallet}РУБ.");
                    Console.WriteLine("---------------\n");
                    break;
                default:
                    Console.WriteLine("Неверное значение, счет будет некорректным!");
                    break;
            }
            Console.WriteLine("\n---------------");
            Console.WriteLine($"1. RUB TO USD (текущий курс ${rubToUSD} за рубль)");
            Console.WriteLine($"2. USD TO RUB (текущий курс {usdToRUB}руб. за доллар)");
            Console.WriteLine("---------------\n");

            Console.Write("Укажите способ конвертации: ");
            exchangeOperation = Convert.ToInt32(Console.ReadLine());
            if((exchangeOperation == 1 && rubWallet <= 0) || (exchangeOperation == 2 && usdWallet <= 0)) { 
                Console.WriteLine("У вас нет денег на кошельке, продолжение невозможно.");
            } else
            {
                switch (exchangeOperation)
                {
                    case 1:
                        Console.Write($"Укажите, сколько рублей хотите перевести в доллары (доступно {rubWallet}руб.): ");
                        countToExchange = Convert.ToSingle(Console.ReadLine());
                        if(countToExchange <= rubWallet)
                        {
                            Console.WriteLine($"{countToExchange} рублей в долларах: {finalCountToExchange = countToExchange * rubToUSD} доллара.");
                            Console.WriteLine("\n---------------");
                            Console.WriteLine($"RUS WALLET -{countToExchange}RUB. (BALANCE: {rubWallet -= countToExchange}RUB.)");
                            Console.WriteLine($"USD WALLET +${finalCountToExchange} (BALANCE: ${usdWallet += finalCountToExchange})");
                            Console.WriteLine("---------------\n");
                        } else
                        {
                            Console.WriteLine("Недостаточно денег на балансе.");
                        }
                        break;
                    case 2:
                        Console.Write($"Укажите, сколько долларов хотите перевести в рубли (доступно ${usdWallet}): ");
                        countToExchange = Convert.ToSingle(Console.ReadLine());
                        if (countToExchange <= usdWallet)
                        {
                            Console.WriteLine($"{countToExchange} долларов в рублях: {finalCountToExchange = countToExchange * usdToRUB} рублей.");
                            Console.WriteLine("\n---------------");
                            Console.WriteLine($"USD WALLET -${countToExchange} (BALANCE: ${usdWallet -= countToExchange})");
                            Console.WriteLine($"RUS WALLET +{finalCountToExchange}RUB. (BALANCE: {rubWallet += finalCountToExchange}RUB.)");
                            Console.WriteLine("---------------\n");
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно денег на балансе.");
                        }
                        break;
                    default:
                        Console.WriteLine("Вам необходимо выбрать доступные варианты (1 или 2)");
                        break;
                }
            }
            }
        }
}
