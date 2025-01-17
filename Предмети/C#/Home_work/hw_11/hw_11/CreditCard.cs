using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_11
{
    public class CreditCard
    {
        public string CardNumber { get; private set; }
        public string OwnerName { get; private set; }
        public DateTime ExpiryDate { get; private set; }
        public int Pin { get; private set; }
        public decimal CreditLimit { get; private set; }
        public decimal Balance { get; private set; }

        public event Action<decimal> AccountReplenished;
        public event Action<decimal> FundsSpent;
        public event Action CreditStarted;
        public event Action LimitReached;
        public event Action PinChanged;

        public CreditCard(string cardNumber, string ownerName, DateTime expiryDate, int pin, decimal creditLimit)
        {
            CardNumber = cardNumber;
            OwnerName = ownerName;
            ExpiryDate = expiryDate;
            Pin = pin;
            CreditLimit = creditLimit;
            Balance = 0;
        }

        public void ReplenishAccount(decimal amount)
        {
            Balance += amount;
            AccountReplenished?.Invoke(amount);
        }

        public void SpendFunds(decimal amount)
        {
            if (Balance - amount < 0)
            {
                CreditStarted?.Invoke();
                if (Balance + CreditLimit - amount < 0)
                {
                    LimitReached?.Invoke();
                    return;
                }
            }

            Balance -= amount;
            FundsSpent?.Invoke(amount);
        }

        public void ChangePin(int newPin)
        {
            Pin = newPin;
            PinChanged?.Invoke();
        }
    }
}
