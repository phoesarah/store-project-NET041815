﻿using StoreProject.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreProject.UI.ConsoleApplication
{
    /// <summary>
    /// Main program class
    /// </summary>
    class Program
    {
        /// <summary>
        /// Entry point of the application
        /// </summary>
        static void Main(string[] args)
        {
            var store = new Store();
            Cart cart = null;

            while (true)
            {
                switch (ShowMainMenu())
                {
                    case "l":
                        ListProducts(store);
                        break;
                    case "a":
                        cart = cart ?? new Cart();
                        new AddProductUI(store, cart).Run();
                        break;
                    case "q":
                        return;
                }
            }
        }

        /// <summary>
        /// List a collection of products
        /// </summary>
        private static void ListProducts(Store store)
        {
            foreach (var product in store.AllProducts())
            {
                Console.WriteLine(product);
            }
        }

        /// <summary>
        /// Show the main store menu
        /// </summary>
        private static string ShowMainMenu()
        {
            Console.WriteLine("Store Main Menu");
            Console.WriteLine("===============");
            Console.WriteLine("l) List products");
            Console.WriteLine("a) Add products to cart");
            Console.WriteLine("q) Quit");

            return Console.ReadLine().Trim().ToLower();
        }
    }
}
