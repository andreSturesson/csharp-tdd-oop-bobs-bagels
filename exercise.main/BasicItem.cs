
public abstract class BasicItem {

        public Guid Id {get;}
        public string SKU {get;}
        public double Price {get;}
        public string Name;
        public string Variant {get;}

        protected BasicItem(string sku, double price, string variant) {
            Id = new Guid();
            SKU = sku;
            Price = price;
            Name = "Unknown";
            Variant = variant;
        }

        protected BasicItem(BasicItem basicItem) {
            Id = new Guid();
            SKU = basicItem.SKU;
            Price = basicItem.Price;
            Name = basicItem.Name;
            Variant = basicItem.Variant;
        }
        
    }
