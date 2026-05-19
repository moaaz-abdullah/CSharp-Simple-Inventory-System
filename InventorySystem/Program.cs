namespace InventorySystem
{
    internal class Program
    {
        public static string[,] products = new string[50, 3];

        public static int productCount = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to our Inventory Management System");

            while (true)
            {
                ShowMenu();

                int.TryParse(Console.ReadLine(), out int choice);

                switch (choice)
                {
                    case 1:
                        AddItem();
                        break;

                    case 2:
                        UpdateItem();
                        break;

                    case 3:
                        ViewItems();
                        break;

                    case 4:
                        Console.WriteLine("Good Bye!");
                        return;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }

        private static void ShowMenu()
        {
            Console.WriteLine("\n1- Add Item");
            Console.WriteLine("2- Update Item");
            Console.WriteLine("3- View Products");
            Console.WriteLine("4- Quit\n");
        }

        private static void AddItem()
        {
            Console.WriteLine("How many products do you want to add?");

            int.TryParse(Console.ReadLine(), out int itemsNum);

            for (int i = 0; i < itemsNum; i++)
            {
                Console.WriteLine("\nProduct Name:");
                products[productCount, 0] = Console.ReadLine();

                Console.WriteLine("Product Quantity:");
                products[productCount, 1] = Console.ReadLine();

                Console.WriteLine("Product Price:");
                products[productCount, 2] = Console.ReadLine();

                Console.WriteLine($"{products[productCount, 0]} added successfully!");

                productCount++;
            }
        }

        private static void UpdateItem()
        {
            if (productCount == 0)
            {
                Console.WriteLine("No products found");
                return;
            }

            Console.WriteLine("Enter Product Name:");
            string? name = Console.ReadLine();

            int productIndex = FindProductByName(name);

            if (productIndex == -1)
            {
                Console.WriteLine("Product not found");
                return;
            }

            Console.WriteLine("Enter New Price:");
            products[productIndex, 2] = Console.ReadLine();

            Console.WriteLine("Price updated successfully");
        }

        private static int FindProductByName(string? name)
        {
            for (int i = 0; i < productCount; i++)
            {
                if (products[i, 0] == name)
                {
                    return i;
                }
            }

            return -1;
        }

        private static void ViewItems()
        {
            if (productCount == 0)
            {
                Console.WriteLine("No products available");
                return;
            }

            Console.WriteLine("\nProducts List:\n");

            for (int i = 0; i < productCount; i++)
            {
                Console.WriteLine(
                    $"ID: {i + 1}, " +
                    $"Name: {products[i, 0]}, " +
                    $"Quantity: {products[i, 1]}, " +
                    $"Price: {products[i, 2]}"
                );
            }
        }
    }
}