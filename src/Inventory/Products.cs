using System.Reflection ;

namespace Inventory {

    public class Products{

        public string name{
            get;
        }
        public double price{
            get;
        }
        public int quantity{
            get;
            set;
        }

        public ProductType.types type;

        public Products(string name, float price, int quantity,ProductType.types type)
        {
            this.name = name;
            this.price = price;
            this.quantity = quantity;
            this.type = type ;
                    
        }

    }
}