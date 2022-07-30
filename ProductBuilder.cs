using System;
namespace ProductManagementSystem
{
    public static class ProductBuilder
    {

        public static string SetProductName()
        {
            string productName = "";
            while (productName == "")
            {
                Console.WriteLine("Please enter a product name");
                productName = Console.ReadLine();
            }
            return productName;
        }

        public static string SetProductType()
        {
            string productType = "";
            while (productType == "")
            {
                Console.WriteLine("Enter a product type");
                int typeSelector = 1;

                string selectedType = "0";
                foreach (ProductTypes p in Enum.GetValues(typeof(ProductTypes)))
                {
                    Console.WriteLine($"Enter {typeSelector} for {p}");
                    typeSelector++;
                }
                selectedType = Console.ReadLine();
                if (Convert.ToUInt32(selectedType) > typeSelector || Convert.ToUInt32(selectedType) < 0 || selectedType == "")
                {
                    Console.WriteLine("Please eneter a valid command");
                }
                else
                {
                    foreach (ProductTypes p in Enum.GetValues(typeof(ProductTypes)))
                    {
                        if (Convert.ToUInt32(selectedType) == (int)p)
                        {
                            productType = p.ToString();
                        }
                    }
                }
            }
            return productType;
        }

        public static decimal SetProductPrice()
        {
            decimal productPrice = 0.00m;
            while (productPrice == 0.00m)
            {
                Console.WriteLine("Enter a product price");
                decimal enteredPrice = Convert.ToDecimal(Console.ReadLine());
                if (enteredPrice <= 0.00m || enteredPrice == 0.00m)
                {
                    Console.WriteLine("The price cannot be negative or zero. Try again.");
                    enteredPrice = Convert.ToDecimal(Console.ReadLine());
                }
                string formatPrice = enteredPrice.ToString("0.00");
                productPrice = Convert.ToDecimal(formatPrice);
            }
            return productPrice;
        }

        public static string SetProductDescription()
        {
            string productDescription = "";
            while (productDescription == "")
            {
                Console.WriteLine("Enter a product description");
                productDescription = Console.ReadLine();
            }
            return productDescription;
        }
    }
}

