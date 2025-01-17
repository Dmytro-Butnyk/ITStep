using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_18
{
    [Serializable]
    public class PaymentAccount
    {
        public decimal DailyPayment { get; set; }
        public int Days { get; set; }
        public decimal DailyFine { get; set; }
        public int DelayDays { get; set; }

        [JsonIgnore]
        public decimal TotalWithoutFine => DailyPayment * Days;

        [JsonIgnore]
        public decimal Fine => DailyFine * DelayDays;

        [JsonIgnore]
        public decimal TotalToPay => TotalWithoutFine + Fine;

        [JsonIgnore]
        public static bool SerializeAll { get; set; } = true;

        public PaymentAccount(decimal dailyPayment, int days, decimal dailyFine, int delayDays)
        {
            DailyPayment = dailyPayment;
            Days = days;
            DailyFine = dailyFine;
            DelayDays = delayDays;
        }
        public PaymentAccount() { }

        public bool ShouldSerializeTotalWithoutFine() => SerializeAll;
        public bool ShouldSerializeFine() => SerializeAll;
        public bool ShouldSerializeTotalToPay() => SerializeAll;
        public void UpdateDays(int newDays)
        {
            Days = newDays;
        }
        public void UpdateDailyFine(decimal newDailyFine)
        {
            DailyFine = newDailyFine;
        }
        public void UpdateDelayDays(int newDelayDays)
        {
            DelayDays = newDelayDays;
        }
        public decimal CalculateTotalToPay()
        {
            return TotalToPay;
        }
        public override string ToString()
        {
            return $"Daily Payment: {DailyPayment}\n" +
            $"Number of Days: {Days}\n" +
            $"Fine per Day of Delay: {DailyFine}\n" +
            $"Number of Days Delayed: {DelayDays}\n" +
            $"Total Payment Without Fine: {TotalWithoutFine}\n" +
            $"Fine: {Fine}\n" +
            $"Total Payment Due: {TotalToPay}";
        }
    }
}
