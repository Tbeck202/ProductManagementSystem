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
        "Create a Product:   (Enter: p)\n" +
        "List all products:  (Enter: a\n" +
        "Exit App:          (Enter: x)");
    string decision = Console.ReadLine().ToLower();
    if (decision == "p")
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
    else if (decision == "a")
    {
        foreach(Product p in db.GetAllProducts())
        {
            Console.WriteLine($"{p.Name} is a {p.Type} product.\nIt costs ${p.Price}.\nDescription: {p.Description}\n***************************\n");
        }
    }
    else if (decision == "s")
    {
        Console.WriteLine("Which products would you like to sum?");
        foreach(Product p in db.GetAllProducts())
        {
            Console.WriteLine($"{p.Name}");
        }
        string selectedProduct1 = Console.ReadLine();
        string selectedProduct2 = Console.ReadLine();
        Product[] productToSum = new Product[2];
        foreach (Product p in db.GetAllProducts())
        {
            
            if(selectedProduct1 == p.Name)
            {
                productToSum[0] = db.GetProduct(selectedProduct1);
            }
            if (selectedProduct2 == p.Name)
            {
                productToSum[1] = db.GetProduct(selectedProduct2);
            }
        }
        decimal sum = db.SumProducts(productToSum[0], productToSum[0]);
        Console.WriteLine($"The total price of {productToSum[0].Name} and {productToSum[1].Name} is {sum}");
    }
    else
    {
        Console.WriteLine("Sorry, we don't recognize that command. Try again.");
    }
}

