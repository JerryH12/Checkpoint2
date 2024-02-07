// checkpoint 2 - produktlista
// Jerry Hall

using System;

string[] input = new string[3];
const int category = 0;
const int name = 1;
const int price = 2;

ProductList prodList = new ProductList();

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("To enter a new product - follow the steps | To quit - enter: \"Q\"");
Console.ResetColor();

string[] commands = new string[] { "Enter a Category: ", "Enter a Product Name: ", "Enter a Price: " };
bool exit = false;

    while (!exit)
    {
        for (int n = 0; n < 3; n++)
        {
            Console.Write(commands[n]);
            input[n] = Console.ReadLine();

            if (input[n].ToLower() == "q")
            {
                exit = true;
                break;
            }
        }

        if (exit)
        {
            prodList.DisplayProducts();
            Console.WriteLine("------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("To add a new product - enter: \"P\" | To quit - enter: \"Q\"");
            Console.ResetColor();

            while (true) 
            {
                string command = Console.ReadLine().ToLower();

                if (command == "p")
                {
                    exit = false;
                    break;
                }

                if (command == "q")
                {     
                    break;
                }
            }
        }    
        else if (int.TryParse(input[price], out int value))
        {
            prodList.AddProduct(new Product(input[category], input[name], value));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The product was successfully added!");      
            Console.ResetColor();
            Console.WriteLine("------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("To enter a new product - follow the steps | To quit - enter: \"Q\"");
            Console.ResetColor();
        }
    }
    

class ProductList
{
    List<Product> products = new List<Product>();

    public ProductList() {}

    public void AddProduct(Product p)
    {
        products.Add(p);
    }

    public void RemoveProduct(Product p)
    {
        products.Remove(p);
    }

    public void DisplayProducts()
    {
        Console.WriteLine("------------------------------------------------");

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Category".PadRight(20) + "Product".PadRight(20) + "Price");
        Console.ResetColor();

        int totalPrice = products.Sum(productItem => productItem.price);
        List<Product> productsSorted = products.OrderBy(productItem => productItem.price).ToList();

        foreach (var productItem in productsSorted)
        {
            Console.WriteLine(productItem.category.PadRight(20) + productItem.name.PadRight(20) + productItem.price);
        }
        Console.WriteLine("\n".PadRight(20) + "Total amount: ".PadRight(20) + totalPrice);
    }
}

class Product
{
    public string category { get; set; }
    public string name { get; set; }
    public int price { get; set; }

    public Product(){}

    public Product(string category, string name, int price)
    {
        this.category = category;
        this.name = name;
        this.price = price;
    }
}

