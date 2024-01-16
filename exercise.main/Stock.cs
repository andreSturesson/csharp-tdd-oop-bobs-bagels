
namespace exercise.main {

public static class Stock {
    public static Dictionary<string, Item> Bagels { get; private set; }
    public static Dictionary<string, Item> Coffee { get; private set; }
    public static Dictionary<string, Item> Filling { get; private set; }

    static Stock() {
        Bagels = new Dictionary<string, Item>();
        Coffee = new Dictionary<string, Item>();
        Filling = new Dictionary<string, Item>();

        Bagels.Add("BGLO", new Item("BGLO", 0.49, "Bagel", "Onion", true));
        Bagels.Add("BGLP", new Item("BGLP", 0.39, "Bagel", "Plain", true));
        Bagels.Add("BGLE", new Item("BGLE", 0.49, "Bagel", "Everything", true));
        Bagels.Add("BGLS", new Item("BGLS", 0.49, "Bagel", "Sesame", true));

        Coffee.Add("COFB", new Item("COFB", 0.99, "Coffee", "Black"));
        Coffee.Add("COFW", new Item("COFW", 1.19, "Coffee", "White"));
        Coffee.Add("COFC", new Item("COFC", 1.29, "Coffee", "Capuccino"));
        Coffee.Add("COFL", new Item("COFL", 1.29, "Coffee", "Latte"));

        Filling.Add("FILB", new Item("FILB", 0.12, "Filling", "Bacon"));
        Filling.Add("FILE", new Item("FILE", 0.12, "Filling", "Egg"));
        Filling.Add("FILC", new Item("FILC", 0.12, "Filling", "Cheese"));
        Filling.Add("FILX", new Item("FILX", 0.12, "Filling", "Cream Cheese"));
        Filling.Add("FILS", new Item("FILS", 0.12, "Filling", "Smoked Salmon"));
        Filling.Add("FILH", new Item("FILH", 0.12, "Filling", "Ham"));
    }

        public static Item GetItem(string sku) {
            if(sku == "")
                return null;
            if (Bagels.ContainsKey(sku))
                return Bagels[sku];
            if (Coffee.ContainsKey(sku))
                return Coffee[sku];
            if (Filling.ContainsKey(sku))
                return Filling[sku];
            return null;
        }

        public static double GetFillingPrice(string name) {
            return GetItem(GetSkuByName(name, "Filling")).Price;
        }

        public static string GetSkuByName(string Name, string Variant) {
            if (Name == "" && Variant == "")
                return "Values cant be empty";

            switch(Variant) {
                case "Bagels": {
                    foreach (Item item in Bagels.Values)
                    {
                        if (item.Name == Name)
                            return item.SKU;
                    }
                    break;
                }
                case "Coffee": {
                    foreach (Item item in Coffee.Values)
                    {
                        if (item.Name == Name)
                            return item.SKU;
                    }
                    break;
                }
                case "Filling": {
                    foreach (Item item in Filling.Values)
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