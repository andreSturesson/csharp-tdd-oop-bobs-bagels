


namespace exercise.main {
    public class Basket {
        private List<List<Item>> _items;
        private int _capacity;
        private int _itemsInOrder;
        private double _totalCost;

        public Basket(int Capacity) {
            _items = new List<List<Item>>();
            _capacity = Capacity;
            _itemsInOrder = 0;
            _totalCost = 0;
        }

        public double TotalCost { get { return _totalCost; }}
        public double TotalItemsInBasket { get { return _itemsInOrder; }}

        public Item AddItem(string sku) {
            if (_itemsInOrder == _capacity)
                return null;
            Item temp = Stock.GetItem(sku);
            _totalCost += temp.Price;
            if(temp != null) {
                List<Item> items = [temp];
                _items.Add(items);
            }
            return temp;
        }

        public List<Item> AddItem(string sku, string fillingSku) {
            if (_itemsInOrder == _capacity)
                return null;
            Item temp = Stock.GetItem(sku);
            if(temp != null && temp.CouldFilling == true) {
                Item filling = Stock.GetItem(fillingSku);
                _totalCost += temp.Price + filling.Price;
                List<Item> items = [temp, filling];
                _items.Add(items);
                return items;
            }
            return null;
        }

        public bool RemoveBagel(Item item) {
            foreach (List<Item> list in _items)
            {
                foreach (Item i in list)
                {
                    if(item == i) {
                        if(item.CouldFilling) {
                            _items.Remove(list);
                            return true;
                        }
                        else {
                            list.Remove(i);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public int ChangeCapacity(int newCapacity) {
            if(_itemsInOrder <= newCapacity) {
                _capacity = newCapacity;
                return _capacity;
            }
            return _capacity;
        }
    }
}

