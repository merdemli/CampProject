﻿using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EFProductDal());
            foreach (Product product in productManager.GetByUnitPrice(40,100))
            {
                Console.WriteLine(product.ProductName);
                
            }
            Console.ReadLine();




        }

    }
}
