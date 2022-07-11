using System;
using System.Globalization;
using Course.Entities;
using Course.Entities.Exceptions;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter account data");

            Console.Write("Number: ");
            var number = int.Parse(Console.ReadLine());

            Console.Write("Holder: ");
            string name = Console.ReadLine();

            Console.Write("Initial balance: ");
            var initialBalance = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Withdraw limit: ");
            var withdrawLimit = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Account account = new Account(number, name, initialBalance, withdrawLimit);

            Console.WriteLine();
            Console.Write("Enter amount for withdraw: ");
            var amount = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);   

            try
            {
                account.Withdraw(amount);
                Console.WriteLine("New balance: {0}", account.Balance.ToString("F2", CultureInfo.InvariantCulture));
            }
            catch(FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(DomainException e)
            {
                Console.WriteLine($"Withdraw error: {e.Message}");
            }
            catch(Exception e)
            {
                Console.WriteLine($"Unexpected error! {e.Message}");
            }

            Console.ReadKey();
        }
    }
}
