using System;

namespace ProductManagementSystem
{
    public class MockProductsDB 
    {
        //List<Product> products = new List<Product>();
        public List<Product> Products = new List<Product>();

        public MockProductsDB()
        {
            Product product1 = new Product("The Big Lebowski: mp4", "Digital", 3.99m, "A downloadable copy of the movie");
            Product product2 = new Product("The Big Lebowski: Blue Ray", "Physical", 9.99m, "A Blu-Ray copy of the movie");
            Product product3 = new Product("Miller Lite Can", "Physical", 1.99m, "A can of delicious Lite beer");
            Product product4 = new Product("Meet and greet with Thor", "Consultation", 99999.99m, "Hang out with the God of Thunder!");
            Product product5 = new Product("Air Pods", "Physical", 279.99m, "The best wireless headphones for the iPhone");

            Products.Add(product1);
            Products.Add(product2);
            Products.Add(product3);
            Products.Add(product4);
            Products.Add(product5);
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

        public decimal SumProducts(Product product1, Product product2)
        {
            return product1.Price + product2.Price;
        }
    }
}

