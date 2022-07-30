using System;

namespace ProductManagementSystem
{
    public class MockProductsDB 
    {
        //List<Product> products = new List<Product>();
        public List<Product> Products = new List<Product>();

        public MockProductsDB()
        {
            Products.Add(new Product("The Big Lebowski: mp4", "Digital", 3.99m, "A downloadable copy of the movie"));
            //Products.Add(new Product("The Big Lebowski: Blue Ray", "Physical", 9.99m, "A Blu-Ray copy of the movie"));
            Products.Add(new Product("Miller Lite Can", "Physical", 1.99m, "A can of delicious Lite beer"));
            Products.Add(new Product("Meet and greet with Thor", "Consultation", 99999.99m, "Hang out with the God of Thunder!"));
            Products.Add(new Product("Air Pods", "Physical", 279.99m, "The best wireless headphones for the iPhone"));
            //Products.Add(new Product("La Croix", "Physical", 3.99m, "12 pack of Sparkling water"));
        }

        public List<Product> GetAllProducts()
        {
            return Products;
        }

        public Product GetProduct(string name)
        {
            foreach(Product p in Products)
            {
                if(name == p.Name)
                {
                    return p;
                }
            }
            return new Product("Not Found", "Physical", 0.00m, "Not Found");
        }

        public decimal SumProducts(string product1, string product2)
        {
            if(Products.Exists(Product => Product.Name == product1) && Products.Exists(Product => Product.Name == product2))
            {
                Product? productSearch1 = Products.Find(Product => Product.Name == product1);
                Product? productSearch2 = Products.Find(Product => Product.Name == product2);

                //Console.WriteLine($"The total price of {productSearch1.Name} and {productSearch2.Name} is {productSearch1.Price + productSearch2.Price}");
                return productSearch1.Price + productSearch2.Price;
            }
            //Console.WriteLine("Sorry, we couldn't find your items");
            
            return 0.00m;
        }
    }
}

