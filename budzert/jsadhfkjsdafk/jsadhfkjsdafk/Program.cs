using System;
using System.Collections.Generic;

namespace BudgetManager
{
    public class Transaction
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public bool IsExpense { get; set; }

        public Transaction(decimal amount, DateTime date, string description, bool isExpense)
        {
            Amount = amount;
            Date = date;
            Description = description;
            IsExpense = isExpense;
        }
    }

    public class Budget
    {
        private List<Transaction> Transactions { get; set; }

        public Budget()
        {
            Transactions = new List<Transaction>();
        }

        public void AddTransaction(Transaction transaction)
        {
            Transactions.Add(transaction);
        }

        public void RemoveTransaction(Transaction transaction)
        {
            Transactions.Remove(transaction);
        }

        public decimal GetIncome()
        {
            decimal income = 0;
            foreach (var transaction in Transactions)
            {
                if (!transaction.IsExpense)
                {
                    income += transaction.Amount;
                }
            }
            return income;
        }

        public decimal GetExpenses()
        {
            decimal expenses = 0;
            foreach (var transaction in Transactions)
            {
                if (transaction.IsExpense)
                {
                    expenses += transaction.Amount;
                }
            }
            return expenses;
        }

        public decimal GetBalance()
        {
            return GetIncome() - GetExpenses();
        }

        public void PrintSummary()
        {
            Console.WriteLine("Przychody: zł" + GetIncome());
            Console.WriteLine("Wydatki: zł" + GetExpenses());
            Console.WriteLine("Balans: zł" + GetBalance());
            Console.WriteLine();
            Console.WriteLine("Podsumowanie transakcji:");
            Console.WriteLine("-------------------");
            foreach (var transaction in Transactions)
            {
                Console.WriteLine(transaction.Date.ToShortDateString() + ": zł" + transaction.Amount + " - " + transaction.Description + " (" + (transaction.IsExpense ? "Wydatki" : "Przychody") + ")");
            }
        }

    }
}
