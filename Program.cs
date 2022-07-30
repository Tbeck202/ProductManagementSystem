using ProductManagementSystem;
/*
 * Project Goals:
 * Create a mock product/inventory system.
 * 
 * User will be able to: 
 * - Create new Products and save them to a DB
 * - Query DB for specific Products (by name or ID)
 * - Query DB for all Products of a specifc type 
 * - Query DB for all current Products
 * - Calculate total price of combined Products
 * 
 * A Product will have:
 * - ID
 * - Name
 * - Type
 * - Price
 * - Description
 * 
 */

bool appRunning = true;
MockProductsDB db = new MockProductsDB();

while (appRunning)
{
    Console.WriteLine("Hello! What would you like to do?\n\n" +
        "Create a Product:        (c + enter)\n" +
        "List all products:       (a + enter)\n" +
        "Find a Product by name:  (f + enter)\n" +
        "Sum price of 2 products: (s + enter)\n" +
        "Exit App:                (x + enter)");
    string decision = Console.ReadLine().ToLower();
    if (decision.ToLower() == "c")
    {
        Product newProduct = new Product(
            ProductBuilder.SetProductName(),
            ProductBuilder.SetProductType(),
            ProductBuilder.SetProductPrice(),
            ProductBuilder.SetProductDescription()
            );
        db.Products.Add(newProduct);
        Console.WriteLine($"You created: {newProduct.Name}! It is a {newProduct.Type} product and it costs ${newProduct.Price}.\nDescription: {newProduct.Description}");
    }
    else if (decision == "x")
    {
        Console.WriteLine("K, bye!");
        appRunning = false;
    }
    else if (decision.ToLower() == "a")
    {
        foreach(Product p in db.GetAllProducts())
        {       
            Console.WriteLine($"{p.Name} is a {p.Type} product.\nIt costs ${p.Price}.\nDescription: {p.Description}\n\n" +
            $"************************************************************************************\n");
        }
    }
    else if (decision.ToLower() == "f")
    {
        Console.WriteLine("Enter a product name");
        string productName = Console.ReadLine();
        Product foundProduct = db.GetProduct(productName);
        Console.WriteLine(
            foundProduct.Name == "Not Found" ? $"Sorry, we couldn't find \"{productName}\" in our database" :
            $"{foundProduct.Name} is a {foundProduct.Type} product.\nIt costs ${foundProduct.Price}.\nDescription: {foundProduct.Description}\n\n");
    }
    else if (decision.ToLower() == "s")
    {
        Console.WriteLine("Which products would you like to sum?");
        foreach(Product p in db.GetAllProducts())
        {
            Console.WriteLine($"{p.Name}");
        }
        string selectedProduct1 = Console.ReadLine();
        string selectedProduct2 = Console.ReadLine();
        decimal sum = db.SumProducts(selectedProduct1, selectedProduct2);
        if (sum > 0.00m) { Console.WriteLine($"The total price of \"{selectedProduct1}\" and \"{selectedProduct2}\" is {sum}"); }
        else { Console.WriteLine("There was an error. Maybe check your spelling?"); }
    }
    else
    {
        Console.WriteLine("Sorry, we don't recognize that command. Try again.");
    }
}

