using System;
using BudgetManager;

namespace BudgetManagerProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Budget budget = new Budget();

            while (true)
            {
                Console.WriteLine("Wprowadź transakcje (wartość(zł), opis(za co?), Czy to wydatek?(true,false) ):");
                string input = Console.ReadLine();

                if (input == "exit")
                {
                    break;
                }

                string[] parts = input.Split(' ');
                decimal amount = decimal.Parse(parts[0]);
                string description = parts[1];
                bool isExpense = bool.Parse(parts[2]);
                Transaction t = new Transaction(amount, DateTime.Now, description, isExpense);
                budget.AddTransaction(t);
                Console.Clear();
            }

            budget.PrintSummary();
        }
    }
}
