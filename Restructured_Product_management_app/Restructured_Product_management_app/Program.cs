using Restructured_Product_management_app;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Restructured_Product_management_app
{
    public enum Category
    {
        Food = 1,
        Cloth = 2,
        Other = 3
    }
    public class Admin
    {
        public string _username;
        private string _password;
        private readonly List<Product> _products;
        public Admin(string username, string password)
        {
            _username = username;
            _password = password;
            _products = new List<Product>();
        }
        public string GetUsername()
        {
            return _username;
        }
        public string GetPassword()
        {
            return _password;
        }
    }
    public class Product
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public decimal Price { get; set; }
        public ProductCategory Category { get; set; }
        public virtual bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(Name) &&
                Number > 0 &&
                Price > 0 &&
                Category != null &&
                Category.IsValid();
        }
    }
    public class ProductCategory
    {
        public string Category { get; set; }
        public virtual bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(Category);
        }
    }
    public class FoodCategory : ProductCategory
    {
        public DateTime ManufactureDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int Quantity { get; set; }
        public override bool IsValid()
        {
            return base.IsValid() &&
                ManufactureDate < ExpiryDate &&
                Quantity > 0;
        }
    }
    public class ClothCategory : ProductCategory
    {
        public string Gender { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string Material { get; set; }

        public override bool IsValid()
        {
            return base.IsValid() &&
                !string.IsNullOrWhiteSpace(Gender) &&
                !string.IsNullOrWhiteSpace(Size) &&
                !string.IsNullOrWhiteSpace(Color) &&
                !string.IsNullOrWhiteSpace(Material);
        }
    }
    public class OtherCategory : ProductCategory
    {
        public override bool IsValid()
        {
            return base.IsValid();
        }
    }
    public interface IProductManager
    {
        void AddProduct(Product product);
        void DeleteProduct(int productNumber);
        void Find_Product(int productNumber, Product product);
        List<Product> GetAllProducts();
        List<Product> GetProductsByCategory(ProductCategory category);
    }
    public class ProductManager : IProductManager
    {
        private List<Product> _products;

        public ProductManager()
        {
            _products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            while (true)
            {
                try
                {
                    if (!product.IsValid())
                    {
                        throw new Exception("Invalid product");
                    }

                    _products.Add(product);
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}\nPlease try again.");
                    break;
                }
            }
        }
        public void DeleteProduct(int productNumber)
        {
            var product = _products.FirstOrDefault(p => p.Number == productNumber);

            if (product == null)
            {
                throw new Exception("Product not found");
            }

            _products.Remove(product);
        }
        public static Product UpdateProduct(Product productToUpdate)
        {
            Console.WriteLine("Enter new product name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter new product price:");
            decimal price;
            while (!decimal.TryParse(Console.ReadLine(), out price) || price <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive decimal number for the price:");
            }

            // Ask user to choose the category for the updated product
            Console.WriteLine("Enter the category for the updated product:\n1. Food\n2. Cloth\n3. Other");
            int categoryChoice = int.Parse(Console.ReadLine());
            ProductCategory newCategory;
            switch (categoryChoice)
            {
                case 1:
                    newCategory = Categoryfactory.CreateFoodCategory();
                    break;
                case 2:
                    newCategory = Categoryfactory.CreateClothCategory();
                    break;
                case 3:
                    newCategory = new OtherCategory();
                    break;
                default:
                    throw new Exception("Invalid category choice");
            }

            // Create a new product object with the updated values
            Product updatedProduct = new Product
            {
                Name = name,
                Number = productToUpdate.Number,
                Price = price,
                Category = newCategory
            };

            return updatedProduct;
        }
        public static Product CreateProduct()
        {

            string name = "";
            int number = 0;
            decimal price = 0;

            Console.WriteLine("Enter the product category (1 for Food, 2 for Cloth, 3 for Other):");

            int categoryOption;

            while (!int.TryParse(Console.ReadLine(), out categoryOption))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }

            ProductCategory category;

            switch (categoryOption)
            {
                case 1:
                    Console.WriteLine("Enter the product name:");
                    name = Console.ReadLine();

                    Console.WriteLine("Enter the product number:");

                    while (!int.TryParse(Console.ReadLine(), out number))
                    {
                        Console.WriteLine("Invalid input. Please enter a number.");
                    }

                    Console.WriteLine("Enter the product price:");

                    while (!decimal.TryParse(Console.ReadLine(), out price))
                    {
                        Console.WriteLine("Invalid input. Please enter a decimal number.");
                    }

                    Console.WriteLine("Enter the product manufacture date (in yyyy-MM-dd format):");

                    DateTime manufactureDate;

                    while (!DateTime.TryParse(Console.ReadLine(), out manufactureDate))
                    {
                        Console.WriteLine("Invalid input. Please enter a date in yyyy-MM-dd format.");
                    }

                    Console.WriteLine("Enter the product expiry date (in yyyy-MM-dd format):");

                    DateTime expiryDate;

                    while (!DateTime.TryParse(Console.ReadLine(), out expiryDate))
                    {
                        Console.WriteLine("Invalid input. Please enter a date in yyyy-MM-dd format.");
                    }

                    Console.WriteLine("Enter the product quantity:");

                    int quantity;

                    while (!int.TryParse(Console.ReadLine(), out quantity))
                    {
                        Console.WriteLine("Invalid input. Please enter a number.");
                    }


                    category = new FoodCategory
                    {
                        Category = "Food",
                        ManufactureDate = manufactureDate,
                        ExpiryDate = expiryDate,
                        Quantity = quantity
                    };
                    break;

                case 2:
                    Console.WriteLine("Enter the product name:");
                    name = Console.ReadLine();

                    Console.WriteLine("Enter the product number:");

                    while (!int.TryParse(Console.ReadLine(), out number))
                    {
                        Console.WriteLine("Invalid input. Please enter a number.");
                    }

                    Console.WriteLine("Enter the product price:");

                    while (!decimal.TryParse(Console.ReadLine(), out price))
                    {
                        Console.WriteLine("Invalid input. Please enter a decimal number.");
                    }

                    Console.WriteLine("Enter the product gender :");
                    string gender = Console.ReadLine();

                    Console.WriteLine("Enter the product size:");
                    string size = Console.ReadLine();

                    Console.WriteLine("Enter the product color:");
                    string color = Console.ReadLine();

                    Console.WriteLine("Enter the product material:");
                    string material = Console.ReadLine();

                    category = new ClothCategory
                    {
                        Category = "Cloth",
                        Gender = gender,
                        Size = size,
                        Color = color,
                        Material = material
                    };
                    break;

                default:
                    category = new OtherCategory
                    {
                        Category = "Other"
                    };
                    break;
            }

            return new Product
            {
                Name = name,
                Number = number,
                Price = price,
                Category = category
            };
        }

        public void Find_Product(int productNumber, Product product)
        {
            try
            {
                if (!product.IsValid())
                {
                    throw new Exception("Invalid product");
                }

                var existingProduct = _products.FirstOrDefault(p => p.Number == productNumber);

                if (existingProduct == null)
                {
                    throw new Exception("Product not found");
                }

                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.Category = product.Category;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Eroor : {ex.Message}");
            }
        }

        public List<Product> GetAllProducts()
        {
            return _products;
        }

        public List<Product> GetProductsByCategory(ProductCategory category)
        {
            return _products.Where(p => p.Category.GetType() == category.GetType()).ToList();
        }

        public static void ListProducts(List<Product> products)
        {


            Console.WriteLine("\nList of Products:");
            Console.WriteLine("------------------");

            if (products.Count == 0)
            {
                Console.WriteLine("No products found.");
            }
            else
            {
                foreach (var product in products)
                {
                    Console.WriteLine($"Name: {product.Name}");
                    Console.WriteLine($"Number: {product.Number}");
                    Console.WriteLine($"Price: {product.Price}");
                    Console.WriteLine($"Category: {product.Category.Category}");

                    if (product.Category is FoodCategory foodCategory)
                    {
                        Console.WriteLine($"Manufacture Date: {foodCategory.ManufactureDate:d}");
                        Console.WriteLine($"Expiry Date: {foodCategory.ExpiryDate:d}");
                        Console.WriteLine($"Quantity: {foodCategory.Quantity}");
                    }
                    else if (product.Category is ClothCategory clothCategory)
                    {
                        Console.WriteLine($"Gender/Size: {clothCategory.Gender}");
                        Console.WriteLine($"Color: {clothCategory.Color}");
                        Console.WriteLine($"Material: {clothCategory.Material}");
                    }

                    Console.WriteLine("------------------");
                }
            }

            Console.WriteLine();
        }
    }
    public static class Categoryfactory
    {
        public static FoodCategory CreateFoodCategory()
        {
            try
            {
                DateTime manufactureDate;
                Console.WriteLine("Enter the product manufacture date (in yyyy-MM-dd format):");
                while (!DateTime.TryParse(Console.ReadLine(), out manufactureDate))
                {
                    Console.WriteLine("Invalid date format. Please enter the date in yyyy-MM-dd format:");
                }

                DateTime expiryDate;
                Console.WriteLine("Enter the product expiry date (in yyyy-MM-dd format):");
                while (!DateTime.TryParse(Console.ReadLine(), out expiryDate))
                {
                    Console.WriteLine("Invalid date format. Please enter the date in yyyy-MM-dd format:");
                }

                int quantity;
                Console.WriteLine("Enter the product quantity:");
                while (!int.TryParse(Console.ReadLine(), out quantity))
                {
                    Console.WriteLine("Invalid quantity. Please enter a valid integer:");
                }

                var category = new FoodCategory
                {
                    ManufactureDate = manufactureDate,
                    ExpiryDate = expiryDate,
                    Quantity = quantity
                };

                if (!category.IsValid())
                {
                    throw new Exception("Invalid category");
                }

                return category;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while creating the food category: " + ex.Message);
                return null;
            }
        }

        public static ClothCategory CreateClothCategory()
        {

            try
            {
                Console.WriteLine("Enter the gender:");
                string gender = Console.ReadLine();
                Console.WriteLine("Enter the size:");
                string size = Console.ReadLine();
                Console.WriteLine("Enter the color:");
                string color = Console.ReadLine();
                Console.WriteLine("Enter the material:");
                string material = Console.ReadLine();
                var category = new ClothCategory
                {
                    Gender = gender,
                    Size = size,
                    Color = color,
                    Material = material
                };
                return category.IsValid() ? category : throw new ArgumentException("Invalid category");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while creating the food category: " + ex.Message);
                return null;
            }
        }
    }
    internal class Program
    {
       
       

        static void Main(string[] args)
        {
            Admin admin = new Admin("Admin", "Admin_23");
            string username = admin.GetUsername();
            string password = admin.GetPassword();
            ProductManager productManager = new ProductManager();
            bool Logged_in = false;

            var apple = new Product
            {
                Name = "Apple",
                Number = 1,
                Price = 0.99m,
                Category = new FoodCategory
                {
                    Category = "Food",
                    ManufactureDate = new DateTime(2022, 1, 1),
                    ExpiryDate = new DateTime(2022, 1, 31),
                    Quantity = 100
                }
            };

            var tshirt = new Product
            {
                Name = "T-Shirt",
                Number = 2,
                Price = 9.99m,
                Category = new ClothCategory
                {
                    Category = "Cloth",
                    Gender = "M",
                    Size = "XL",
                    Color = "Blue",
                    Material = "Cotton"
                }
            };

            var pen = new Product
            {
                Name = "Pen",
                Number = 3,
                Price = 1.99m,
                Category = new OtherCategory
                {
                    Category = "Other"
                }
            };

            // Add the sample products to the manager
            productManager.AddProduct(apple);
            productManager.AddProduct(tshirt);
            productManager.AddProduct(pen);

            Console.WriteLine("All products:");
            foreach (var product in productManager.GetAllProducts())
            {
                Console.WriteLine($"{product.Name} ({product.Category.Category}): {product.Price:C}");
            }

            Console.WriteLine();

            // Start the application loop
            Console.WriteLine("Welcome to WeNet Admin Portal");
            int choice = 0;

            while (true)
            {
                try
                {
                    Console.WriteLine("Select Choice");
                    Console.WriteLine("1. Login");
                    Console.WriteLine("2. Close App");
                    choice = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Please enter a valid integer choice.");
                }

                if (choice == 1)
                {
                    Console.WriteLine("\nUsername : ");
                    string input_username = Console.ReadLine();

                    Console.WriteLine("\nPassword : ");
                    string input_password = Console.ReadLine();

                    if (input_username == username && input_password == password)
                    {
                        Console.WriteLine("Login successful.");
                        Logged_in = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid username or password...!");
                        Logged_in = false;
                    }

                    if (Logged_in)
                    {
                        while (Logged_in)
                        {
                            // Show the main menu and get the user's choice
                            Console.WriteLine("Welcome to the Product Management App!");
                            Console.WriteLine("1. List all products");
                            Console.WriteLine("2. Filter products by category");
                            Console.WriteLine("3. Add new product");
                            Console.WriteLine("4. Update existing product");
                            Console.WriteLine("5. Delete existing product");
                            Console.WriteLine("6. Logout");
                            Console.Write("Enter your choice (1-6): ");
                            choice = int.Parse(Console.ReadLine());

                            switch (choice)
                            {
                                case 1:
                                    // List all products
                                    ProductManager.ListProducts(productManager.GetAllProducts());
                                    break;

                                case 2:
                                    // Filter products by category
                                    Console.Write("Enter the category to filter. \n1. Food \n2. Cloth \n3. Other: ");
                                    string category = Console.ReadLine();
                                    ProductManager.ListProducts(productManager.GetProductsByCategory(new ProductCategory { Category = category }));
                                    break;

                                case 3:
                                    // Add new product
                                    Product newProduct = ProductManager.CreateProduct();
                                         productManager.AddProduct(newProduct);
                                        break;                                                               

                                case 4:
                                    // Update existing product
                                    Console.Write("Enter the product number to update: ");
                                    int productNumberToUpdate = int.Parse(Console.ReadLine());
                                    Product productToUpdate = productManager.GetAllProducts().FirstOrDefault(p => p.Number == productNumberToUpdate);

                                    if (productToUpdate == null)
                                    {
                                        Console.WriteLine("Product not found!");
                                    }
                                    else
                                    {
                                        Product updatedProduct = ProductManager.UpdateProduct(productToUpdate);
                                        productManager.Find_Product(productNumberToUpdate, updatedProduct);
                                    }
                                    break;

                                case 5:
                                    // Delete existing product
                                    Console.Write("Enter the product number to delete: ");
                                    int productNumberToDelete = int.Parse(Console.ReadLine());

                                    try
                                    {
                                        productManager.DeleteProduct(productNumberToDelete);
                                        Console.WriteLine("Product deleted successfully!");
                                    }
                                    catch (ArgumentException ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }

                                    break;

                                case 6:
                                    Console.WriteLine("Log out here successfully....");
                                    Logged_in = false;
                                    break;
                                default:
                                    Console.WriteLine("Invalid input for category. Please enter Food, Cloth, or Other.");
                                    return;
                            }
                        }
                    }
                }
                else if (choice == 2)
                {
                    Console.WriteLine("\nEnter you Password : ");
                    string input_password = Console.ReadLine();

                    if (input_password == password)
                    {
                        Console.WriteLine("logged out successfully....!");
                        Console.WriteLine("Bye..!");
                        Console.ReadKey();
                        Environment.Exit(0);

                    }
                }
                else
                {
                    Console.WriteLine("Please enter the choise 1 OR 2");
                }

            }
        }
    }
}
