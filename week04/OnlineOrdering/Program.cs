using System;

class Program
{
    static void Main(string[] args)
    {
        // Order 1 - USA Customer
        Address address1 = new Address("123 Main St", "Springfield", "IL", "USA");
        Customer customer1 = new Customer("John Doe", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Notebook", "N123", 2.50, 4));
        order1.AddProduct(new Product("Pen Pack", "P456", 3.75, 2));

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalPrice():0.00}\n");

        // Order 2 - International Customer
        Address address2 = new Address("45 Rue de Lyon", "Paris", "Île-de-France", "France");
        Customer customer2 = new Customer("Marie Curie", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Lab Flask", "L789", 12.00, 1));
        order2.AddProduct(new Product("Beaker Set", "B012", 25.00, 1));
        order2.AddProduct(new Product("Goggles", "G034", 5.00, 2));

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalPrice():0.00}");
    }
}
