


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

        public double TotalItemsInBasket { get { return _itemsInOrder; }}
        public List<List<Item>> Items { get { return _items; }}

        public Item AddItem(string sku, int quantity = 1) {
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


        private bool CheckDiscounted() {
            int NumberOfBagels = 0;
            double bagelPrice = 0;
            int NumberOfCoffee = 0;
            double newPrice = 0;
            foreach (List<Item> list in _items)
            {
                foreach (Item item in list)
                {
                    switch(item.Name) {
                        case "Bagel": {
                            NumberOfBagels += 1;
                            bagelPrice += item.Price;
                            newPrice += item.Price;
                            break;
                        }
                        case "Coffee": {
                            if(item.Variant == "Black") {
                                NumberOfCoffee +=1;
                                newPrice += item.Price;
                            }
                            break;
                        }
                    }
                    newPrice += item.Price;
                }
            }
            if (NumberOfBagels % 12 == 0) {
                double deal = NumberOfBagels / 12;
                bagelPrice =  bagelPrice - 3.99*deal;
                _totalCost -= 3.99*deal;
            }
            if (NumberOfBagels % 6 == 0) {
                double deal = NumberOfBagels / 6;
                bagelPrice =  bagelPrice - 2.49*deal;
                _totalCost -= bagelPrice;
            }
            if (NumberOfCoffee > 1 && NumberOfBagels > 1) {
                if(NumberOfBagels > NumberOfCoffee) {
                    _totalCost -= 0.99 - 1.25*NumberOfCoffee;
                }
            }
            return false;
        }

        public List<Item> AddItem(string sku, string fillingSku, int quantity = 1) {
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

        public double GetTotalCost() {
            CheckDiscounted();
            return _totalCost;
        }
    }
}

