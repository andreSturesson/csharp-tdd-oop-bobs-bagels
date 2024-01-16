

namespace exercise.main {
    public class Basket {
        private List<Item> _items;
        private int _capacity;
        private int _itemsInOrder;

        private int _totalCost;

        public Basket(int Capacity) {
            _items = new List<Item>();
            _capacity = Capacity;
            _itemsInOrder = 0;
            _totalCost = 0;
        }

        public bool AddItem(string sku) {
            return false;
        }

        public bool RemoveBagel(string sku) {
            return false;
        }

        public bool ChangeCapacity() {
            return false;
        }
    }
}

