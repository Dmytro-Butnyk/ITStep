using lesson_5;
using lesson_5.Models;
using lesson_5.Models.Products;
using Microsoft.EntityFrameworkCore;
using static System.Console;

using (ShopContext context = new())
{
    WriteLine("CALLS:\n");
    context.Calls.Include("Consultant").Include("Client")
        .ToList()
        .ForEach(WriteLine);


    WriteLine("\n\nSUPPLIES:\n");
    context.Supplies.Include("Manager").Include("Provider").Include("Product")
        .ToList()
        .ForEach(WriteLine);

    WriteLine("\n\nPURCHASES:\n");
    context.Purchases.Include("Manager").Include("Buyer").Include("Product")
        .ToList()
        .ForEach(WriteLine);
}