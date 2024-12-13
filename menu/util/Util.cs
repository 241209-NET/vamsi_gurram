
namespace menu.util;
using System.Text.Json;

public  class Util {


    public static int CheckUserInput(string? input)
    {
        try
        {
            List<int> list = [1,2,3];
            int userInput = Convert.ToInt32(input);
            if (list.Contains(userInput)){
                return userInput;
            } else {
                Console.WriteLine("Invalid Input. Valid Choices are 1 OR 2 OR 3"); 
                return -1;
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine("Invalid Input. Valid Choices are 1 OR 2 OR 3"); 
            return -1;
        }
    }

    public static List<Product> ReadFromJSONFile(){
        List<Product> products = new List<Product>();  
  
        using (StreamReader r = new StreamReader("util/items.json"))  
        {  
            string json = r.ReadToEnd();  
            products = JsonSerializer.Deserialize<List<Product>>(json);   
            // products = JsonConvert.DeserializeObject<List<Product>>(json);   
        }  
        // return products;
        
        return products;
    }
}

public class Product{
    public int ItemId {get; set;}
    public string Name {get; set;} = "";
    public int Count {get; set;}

    public override string ToString(){
        return $"{ItemId}. {Name} {Count}";
    }
}