using menu.util;

namespace menu;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Vending Machine");
        // Console.WriteLine("Displaying items available in the Vending Machine");
        List<Product> products =  Util.ReadFromJSONFile();

        

        while(true){

            Console.WriteLine("########## Main Menu #########");

            Console.WriteLine("1. Display items from Vending Machine");
            Console.WriteLine("2. CheckOut an item from Vending Machine");        
            Console.WriteLine("3. Quit");
            Console.WriteLine("#########################");
            Console.WriteLine("Enter the Option: ");

            int userInput = Util.CheckUserInput(Console.ReadLine());
            // Console.WriteLine(userInput);

            switch(userInput)
            {
                case 1:
                    Console.WriteLine("------------------------------");
                    Console.WriteLine("Below are the Available Products and their Count");
                    foreach (Product product in products)
                    {
                        Console.WriteLine(product.ToString());
                    }
                    Console.WriteLine("------------------------------");
                    
                    break;
                case 2:
                    Console.WriteLine("Choose from the below list");
                    Console.WriteLine("Product_ID");
                    Console.WriteLine("----------");
                    foreach(var product in products){
                        Console.WriteLine(product.ItemId);
                    }
                    Console.WriteLine("#########################");
                    Console.WriteLine("Enter the Option: ");

                    int CheckOutInput = Util.CheckUserInput(Console.ReadLine());
                    switch(CheckOutInput)
                    {
                        case 1:
                            
                            foreach ( var product in products.Where(w => w.Name == "Soda")) {
                                product.Count -= 1;
                                if (product.Count < 1 ) {
                                    Console.WriteLine("Soda is Out of Stock");
                                } else {
                                    Console.WriteLine("......... Dispensing Soda ....");
                                }
                            }
                            break;
                        case 2:
                            // Console.WriteLine(".......... Dispensing Chips ....");
                            foreach ( var product in products.Where(w => w.Name == "Chips")) {
                                product.Count -= 1;
                                if (product.Count < 1 ) {
                                    Console.WriteLine("Chips is Out of Stock");
                                } else {
                                    Console.WriteLine("......... Dispensing Soda ....");
                                }
                            }
                            break;
                        case 3:
                            // Console.WriteLine("........... Dispensing IceCream ....");
                            foreach ( var product in products.Where(w => w.Name == "IceCream")) {
                                product.Count -= 1;
                                if (product.Count < 1 ) {
                                    Console.WriteLine("IceCream is Out of Stock");
                                } else {
                                    Console.WriteLine("......... Dispensing Soda ....");
                                }
                            }
                            break;
                        
                    }


                    break;
                case 3:
                    // Utilities.SaveTasks(myAssign, saveFile);
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }
    }
}


