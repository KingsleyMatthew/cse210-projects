using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the OnlineOrdering Project.");

        // ===== ORDER 1 =====
        Address address1 = new Address("12 Unity St", "Lagos", "LA", "Nigeria");
        Customer customer1 = new Customer("John Smith", address1);

        Order order1 = new Order(customer1);

        order1.AddProduct(new Product("Laptop", 101, 500, 1));
        order1.AddProduct(new Product("Mouse", 102, 20, 2));

        // ===== ORDER 2 =====
        Address address2 = new Address("45 Main St", "New York", "NY", "USA");
        Customer customer2 = new Customer("Mary Johnson", address2);

        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("Phone", 201, 300, 1));
        order2.AddProduct(new Product("Headphones", 202, 50, 3));

        // ===== DISPLAY ORDER 1 =====
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"TOTAL COST: ${order1.GetTotalCost()}\n");

        Console.WriteLine("-----------------------------");

        // ===== DISPLAY ORDER 2 =====
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"TOTAL COST: ${order2.GetTotalCost()}");
    }
}