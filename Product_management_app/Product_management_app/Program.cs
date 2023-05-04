using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Product_management_app.Product;

namespace Product_management_app
{
    public class Product
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public DateTime Manufacture_Date { get; set; }
        public DateTime Expiry_Date { get; set; }
        public int Quantity { get; set; }

        public string Gender { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string Material { get; set; }


        //public Product(string name, int number, decimal price, string category, string gender,string size,string color,string material,DateTime expiry_date,DateTime manufacture_date)
        //{ 
        //    this.Name = name;
        //    this.Number = number;
        //    this.Category = category;
        //    this.Expiry_Date = expiry_date;
        //    this.Manufacture_Date = manufacture_date;
        //    this.Price = price;
        //    this.Gender = gender;
        //    this.Size = size;
        //    this.Color = color;
        //    this.Material = material;
        //}

        public override string ToString()
        {
            if (Category == "Food")
            {
                Console.WriteLine("All Food products are here...");
            }
            else if (Category == "Cloth")
            {
                Console.WriteLine("All Cloth products are here...");

            }
            else if (Category == "Other")
            {
                Console.WriteLine("All Other products are here...");

            }
            else
            {
                Console.WriteLine("You haven't choose any category...");
            }
            return base.ToString();
        }


        public class Admin
        {
            private string Username = "Admin";
            private string Password = "Admin_23";
            private bool Logged_in = false;
            private List<Product> products = new List<Product>();




            //While start the app
            public void Start()
            {
                Console.WriteLine("Welcome to WeNet Admin Portal");
                while (true)
                {
                    Console.WriteLine("Select Choice");
                    Console.WriteLine("1. Login");
                    Console.WriteLine("2. Close App");

                    int choice = GetChoice(2);
                    if (choice == 1)
                    {
                        Login();
                        if (Logged_in)
                        {
                            Dashboard();
                        }
                    }
                    else
                    {
                        break;
                    }

                }
            }

            //Choose the option for login and close the app
            private int GetChoice(int max_choice)
            {
                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > max_choice)
                {
                    Console.WriteLine("Invalid choice...");
                }
                return choice;
            }

            private void Login()
            {
                Console.WriteLine("\nUsername : ");
                string input_username = Console.ReadLine();

                Console.WriteLine("\nPassword : ");
                string input_password = Console.ReadLine();

                if (input_username == Username && input_password == Password)
                {
                    Console.WriteLine("Login successful.");
                    Logged_in = true;
                }
                else
                {
                    Console.WriteLine("Invalid username or password...!");
                    Logged_in = false;
                }
            }
            //Listout all the products
            private void ListProduct()
            {
                if (products.Count == 0)
                {
                    Console.WriteLine("No products found.");
                    return;
                }

                foreach (var product in products)
                {
                    Console.WriteLine(product.ToString());
                }
            }

            //provide the filter in the category
            private void ProvideFilter()
            {
                Console.WriteLine("\nSelect the categories from the above :\n1.Food\n2.Cloth\n3.Other");
                string category = Console.ReadLine();

                var filter_products = products.FindAll(x => x.Category == category);

                if (filter_products.Count > 0)
                {
                    Console.WriteLine("All products : ");
                    foreach(var product in filter_products)
                    {
                        Console.WriteLine($"{product}");
                    }
                }else
                {
                    Console.WriteLine("No Products");
                }
            }

            //method for add product
            private void AddProduct()
            {
                Console.WriteLine("\nAdd Product :");
                Console.WriteLine("\nProduct Number : ");
                int p_number = int.Parse(Console.ReadLine());

                Console.WriteLine("\nProduct Name : ");
                string p_name = Console.ReadLine();

                Console.WriteLine("Product Price : ");
                decimal p_price = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Category (Food , Cloth , Other ) : ");
                string p_category = Console.ReadLine();

                DateTime p_manufactureDate = DateTime.MinValue;
                DateTime p_expiryDate = DateTime.MinValue;
                int p_quantity = 0;
                string p_gender = "";
                string p_size = "";
                string p_color = "";
                string p_material = "";

                switch (p_category)
                {
                    case "Food":
                        Console.WriteLine("Manufacture Date : ");
                        p_manufactureDate = DateTime.Parse(Console.ReadLine());

                        Console.WriteLine("Expiry Date :");
                        p_expiryDate = DateTime.Parse(Console.ReadLine());

                        Console.WriteLine("Quantity :");
                        p_quantity = int.Parse(Console.ReadLine());
                        break;

                    case "Cloth":
                        Console.WriteLine("Gender  :");
                        p_gender = Console.ReadLine();

                        Console.WriteLine("Size  :");
                        p_size = Console.ReadLine();

                        Console.WriteLine("Color : ");
                        p_color = Console.ReadLine();

                        Console.WriteLine("Material : ");
                        p_material = Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Invalid input for category. Please enter Food, Cloth, or Other.");
                        return;


                }
                Product product = new Product
                {
                    Number = p_number,
                    Name = p_name,
                    Price = p_price,
                    Category = p_category,
                    Manufacture_Date = p_manufactureDate,
                    Material = p_material,
                    Expiry_Date = p_expiryDate,
                    Quantity = p_quantity,
                    Gender = p_gender,
                    Size = p_size,
                    Color = p_color
                };

                products.Add(product);

                Console.WriteLine("Product added successfully....!");

            }

            //Method for update product
            private void UpdateProduct()
            {


                Console.WriteLine("Update your product : ");
                Console.WriteLine($"\n Product Number : ");
                int p_number = int.Parse(Console.ReadLine());

                Product update_product = products.Find(p => p.Number == p_number);
                if (update_product != null)
                {
                    Console.WriteLine("This product is found ....! Now enter the new details...");
                    Console.WriteLine("\nProduct Name : ");
                    string p_name = Console.ReadLine();

                    Console.WriteLine("Product Price : ");
                    decimal p_price = decimal.Parse(Console.ReadLine());

                    Console.WriteLine("Category (Food , Cloth , Other ) : ");
                    string p_category = Console.ReadLine();
                    DateTime p_manufactureDate = DateTime.MinValue;
                    DateTime p_expiryDate = DateTime.MinValue;
                    int p_quantity = 0;
                    string p_gender = "";
                    string p_size = "";
                    string p_color = "";
                    string p_material = "";

                    switch (p_category)
                    {
                        case "Food":
                            Console.WriteLine("Manufacture Date : ");
                            p_manufactureDate = DateTime.Parse(Console.ReadLine());

                            Console.WriteLine("Expiry Date :");
                            p_expiryDate = DateTime.Parse(Console.ReadLine());

                            Console.WriteLine("Quantity :");
                            p_quantity = int.Parse(Console.ReadLine());
                            break;

                        case "Cloth":
                            Console.WriteLine("Gender  :");
                            p_gender = Console.ReadLine();

                            Console.WriteLine("Size  :");
                            p_size = Console.ReadLine();

                            Console.WriteLine("Color : ");
                            p_color = Console.ReadLine();

                            Console.WriteLine("Material : ");
                            p_material = Console.ReadLine();
                            break;
                        default:
                            Console.WriteLine("Invalid input for category. Please enter Food, Cloth, or Other.");
                            return;

                    }
                    update_product.Name = p_name;
                    update_product.Number = p_number;
                    update_product.Price = p_price;
                    update_product.Category = p_category;
                    update_product.Expiry_Date = p_expiryDate;
                    update_product.Quantity = p_quantity;
                    update_product.Gender = p_gender;
                    update_product.Size = p_size;
                    update_product.Manufacture_Date = p_manufactureDate;
                    update_product.Color = p_color;
                    update_product.Material = p_material;


                    Console.WriteLine("Product is updated...!");


                }

                else
                {
                    Console.WriteLine("Product is not availabel...!");
                }
            }

                //method for delete product
                private void DeleteProduct()
                {
                    Console.WriteLine("Delete your product  ");
                    Console.WriteLine($"\n Product Number : ");
                    int p_number = int.Parse(Console.ReadLine());

                    Product product = products.Find(p => p.Number == p_number);

                    if (product != null)
                    {
                        // Remove the product from the list
                        products.Remove(product);

                        Console.WriteLine("Product deleted successfully....!");
                    }
                    else
                    {
                        Console.WriteLine("Product not found....!");
                    }

                }

                //method for logout
                private void Logout()
                {
                    Console.WriteLine("\n Logout here");
                    Console.WriteLine("\nEnter you Password : ");
                    string input_password = Console.ReadLine();

                    if (input_password == Password)
                    {
                        Admin admin = null  ;
                        Console.WriteLine("logged out successfully....!");
                        Console.WriteLine("Bye..!");
                        
                    }
                }

                private void Dashboard()
                {
                    while (true)
                    {
                        Console.WriteLine("\n Select choice....");
                        Console.WriteLine("\n 1. Default list of all Products\r\n2. Provide Filter of Category , after apply filter can remove filter\r\n3. Add Product\r\n4. Update Product\r\n5. Delete Product\r\n6. Logout");
                        int choice = GetChoice(6);

                        switch (choice)
                        {
                            case 1:
                                ListProduct();
                                break;
                            case 2:
                                ProvideFilter();
                                break;
                            case 3:
                                AddProduct();
                                break;
                            case 4:
                                UpdateProduct();
                                break;
                            case 5:
                                DeleteProduct();
                                break;
                            case 6:
                                Logout();
                                break;

                        }
                    }
                }

            }
        }
        internal class Program
        {


            static void Main(string[] args)
            {
            
            Admin admin = new Admin();
            admin.Start();
            }
        }
    } 

