using BookShopDataBase.Models.BookTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopDataBase.Models.ClientDetails
{
    public class Order
    {
        public int Id { get; set; }
        public Client Client { get; set; }
        public Book Book { get; set; }
        public DateOnly Date { get; set; }

        public Order() { }
        public Order(DateOnly date)
        {
            Date = date;
        }

        public override string ToString() =>
            $"Order id: {Id}| Client: {Client.Login}| Date: {Date}";
    }
}
