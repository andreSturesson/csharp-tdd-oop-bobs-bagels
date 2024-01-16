
namespace exercise.main {
    public class Item {
        private string _SKU;
        private double _price;
        private string _name;
        private string _variant;
        private int _quantity;
        private bool _couldFilling;

        public Item(string sku, double price, string name, string variant, bool couldFilling = false) {
            _SKU = sku;
            _price = price;
            _name = name;
            _variant = variant;
            _couldFilling = couldFilling;
        }

        public string Name { get { return _name; }}
        public string SKU { get { return _SKU; }}
        public string Variant { get { return _variant; }}
        public double Price { get { return _price; }}
        public bool CouldFilling { get { return _couldFilling; }}
    }
}

