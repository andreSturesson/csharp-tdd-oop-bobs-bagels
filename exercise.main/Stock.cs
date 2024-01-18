
namespace exercise.main {

public static class Stock {
    public static Dictionary<string, Bagel> Bagels { get; private set; }
    public static Dictionary<string, Coffee> Coffee { get; private set; }
    public static Dictionary<string, Filling> Filling { get; private set; }
    public static List<Discount> Discounts {get; private set;}

    static Stock() {
        Bagels = new Dictionary<string, Bagel>();
        Coffee = new Dictionary<string, Coffee>();
        Filling = new Dictionary<string, Filling>();
        Discounts = new List<Discount>();

        Bagels.Add("BGLO", new Bagel("BGLO", 0.49d, "Onion"));
        Bagels.Add("BGLP", new Bagel("BGLP", 0.39d, "Plain"));
        Bagels.Add("BGLE", new Bagel("BGLE", 0.49d, "Everything"));
        Bagels.Add("BGLS", new Bagel("BGLS", 0.49d, "Sesame"));

        Coffee.Add("COFB", new Coffee("COFB", 0.99d, "Black"));
        Coffee.Add("COFW", new Coffee("COFW", 1.19d, "White"));
        Coffee.Add("COFC", new Coffee("COFC", 1.29d, "Capuccino"));
        Coffee.Add("COFL", new Coffee("COFL", 1.29d, "Latte"));

        Filling.Add("FILB", new Filling("FILB", 0.12d, "Bacon"));
        Filling.Add("FILE", new Filling("FILE", 0.12d, "Egg"));
        Filling.Add("FILC", new Filling("FILC", 0.12d, "Cheese"));
        Filling.Add("FILX", new Filling("FILX", 0.12d, "Cream Cheese"));
        Filling.Add("FILS", new Filling("FILS", 0.12d, "Smoked Salmon"));
        Filling.Add("FILH", new Filling("FILH", 0.12d, "Ham"));

        Discounts.Add(new Discount(6, 2.49d, "Bagel"));
        Discounts.Add(new Discount(12, 3.99d, "Bagel"));
        Discounts.Add(new Discount(12, 3.99d, "Bagel"));
        Discounts.Add(new Discount(1, 1.25d, "Coffee", "Bagel"));

    }

        public static BasicItem GetItem(string sku) {
            if(sku == "")
                return null;
            if (Bagels.ContainsKey(sku)) {
                Bagel bagel = new Bagel(Bagels[sku]);
                return bagel;
            }
            if (Coffee.ContainsKey(sku))
                return Coffee[sku];
            if (Filling.ContainsKey(sku))
                return Filling[sku];
            return null;
        }

        public static double GetPrice(string Name, string Variant) {
            return GetItem(GetSkuByName(Name, Variant)).Price;
        }

        public static string GetSkuByName(string Name, string Variant) {
            if (Name == "" && Variant == "")
                return "Values cant be empty";

            switch(Variant) {
                case "Bagels": {
                    foreach (Bagel item in Bagels.Values)
                    {
                        if (item.Name == Name)
                            return item.SKU;
                    }
                    break;
                }
                case "Coffee": {
                    foreach (Coffee item in Coffee.Values)
                    {
                        if (item.Name == Name)
                            return item.SKU;
                    }
                    break;
                }
                case "Filling": {
                    foreach (Filling item in Filling.Values)
                    {
                        if (item.Name == Name)
                            return item.SKU;
                    }
                    break;
                }
            }
            return "No Item Found with that Name and Variant exists in the inventory";
        }
    }


}