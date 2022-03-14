using System.Collections.Generic ;


namespace Inventory{

    public class Program{
        
        public static void Main(string[] args)
        {

            var listofproducts = new List<Products>();
            addProducts(listofproducts, new Products("Lettuce", price: (float)10.5, quantity: 50,
                                                            ProductType.types.Leafy_green));
            addProducts(listofproducts, new Products("Cabbage", price: 20, quantity: 100,
                                                            ProductType.types.Cruciferous));
            addProducts(listofproducts, new Products("Pumpkin", price: 30, quantity: 30,
                                                            ProductType.types.Marrow));
            addProducts(listofproducts, new Products("Cauliflower", price: 10, quantity: 25,
                                                            ProductType.types.Cruciferous));
            addProducts(listofproducts, new Products("Zucchini", price: (float)20.5, quantity: 50,
                                                            ProductType.types.Marrow));
            addProducts(listofproducts, new Products("Yam", price: 30, quantity: 50,
                                                            ProductType.types.Marrow));
            addProducts(listofproducts, new Products("Spinach", price: 10, quantity: 100,
                                                            ProductType.types.Leafy_green));
            addProducts(listofproducts, new Products("Broccoli", price: (float)20.2, quantity: 75,
                                                            ProductType.types.Cruciferous));
            addProducts(listofproducts, new Products("Garlic", price: 30, quantity: 20,
                                                            ProductType.types.Leafy_green));
            addProducts(listofproducts, new Products("Silverbeet", price: 10, quantity: 50,
                                                            ProductType.types.Marrow));

            //Prints the inventory list
            Console.WriteLine("Inventory Products List :");
            givelistandcount(listofproducts);

            //Added new Product(Potato,price:10,quantity:50,type:Root)
            Console.WriteLine("Added new Product(Potato,price:10,quantity:50,type:Root)");
            addProducts(listofproducts, new Products("Potato", 10, 50, ProductType.types.Root));
            givelistandcount(listofproducts);
            System.Console.WriteLine();

            //Gives product having type:Leafy green
            Console.WriteLine("List of products having type Leafy green");
            productwithtypeleafygreen(listofproducts);
            Console.WriteLine();

            //Remove Garlic from the list
            listofproducts.RemoveAt(listofproducts.FindIndex(product => product.name == "Garlic"));
            Console.WriteLine($"As all garlic is sold out, Garlic is not in the list,so total number of products in list is: {listofproducts.Count}");
            System.Console.WriteLine();

            //Adding 50 cabbages to inventory and printing total count of cabbage
            Console.WriteLine("Adding 50 cabbages to inventory and the printing total cabbages");
            var totalcabbage = listofproducts.Where(product => product.name == "Cabbage").First().quantity += 50;
            System.Console.WriteLine(totalcabbage);
            System.Console.WriteLine();

            //After purchasing 1kg lettuce,2kg zucchini and 1kg broccoli
            Console.WriteLine("After purchasing 1kg lettuce,2kg zucchini and 1kg broccoli");
            double lettuceprice = productprice(listofproducts,"Lettuce");
            var zucchiniprice = productprice(listofproducts,"Zucchini");
            var broccoliprice = productprice(listofproducts,"Broccoli");
            Console.WriteLine($"price of lettuce: {lettuceprice}");
            Console.WriteLine($"price of zucchini: {listofproducts.ElementAt(4).price}");
            Console.WriteLine("price of broccoli: {0:0.0}", listofproducts.ElementAt(7).price);

            System.Console.WriteLine("Total price: {0:0.0}", (lettuceprice + (2 * zucchiniprice) + broccoliprice));
             listofproducts.Where(product => product.name == "Lettuce").First().quantity -= 1;
             listofproducts.Where(product => product.name == "Zucchini").First().quantity -= 2;
             listofproducts.Where(product => product.name == "Broccoli").First().quantity -= 1;

            
        }

        private static double productprice(List<Products> listofproducts, string productname)
        {
            return listofproducts.ElementAt(listofproducts.FindIndex(product => product.name == productname)).price;
        }

        private static void productwithtypeleafygreen(List<Products> listofproducts)
        {
            foreach (var product in listofproducts)
            {
                if (product.type == ProductType.types.Leafy_green)
                {
                    Console.WriteLine($"Product: {product.name}");
                }
            }
        }

        private static void givelistandcount(List<Products> listofproducts)
        {
            printInventorylist(listofproducts); Console.WriteLine($"Total: {listofproducts.Count}");
        }

        private static void printInventorylist(List<Products> listofproducts)
        {
            foreach (var product in listofproducts)
            {
                Console.WriteLine($" Product Name: {product.name}, Price: {product.price:0.0}, Quantity: {product.quantity},Type: {product.type}");
            }
        }

        private static void addProducts(List<Products> listofproducts,Products product)
        {
            listofproducts.Add(product);
        }
    }
}