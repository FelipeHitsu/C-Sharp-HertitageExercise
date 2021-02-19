using System;
using System.Collections.Generic;
using System.Globalization;
using HeritageExercise.Entities;

namespace HeritageExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> Products = new List<Product>();

            Console.Write("Enter the number of products: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Product {i} data:");
                Console.Write("Common, used or imported (c/u/i)? ");
                char c = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);

                if(c == 'i')
                {
                    Console.Write("Customs fee: ");
                    double fee = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
                    Products.Add(new ImportedProduct(name, price, fee));
                }
                else if(c == 'u')
                {
                    Console.Write("Manufacture Date (DD/MM/YYYY): ");
                    DateTime date = DateTime.Parse(Console.ReadLine());
                    Products.Add(new UsedProduct(name, price, date));
                }
                else
                {
                    Products.Add(new Product(name, price));
                }
            }

            foreach(Product p in Products)
            {
                Console.WriteLine(p.PriceTag());
            }


        }
    }
}
