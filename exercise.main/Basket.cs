



using System.Globalization;

namespace exercise.main {
    public class Basket {
        private List<BasicItem> _items;
        private int _capacity;
        private int _ItemsInBasket;
        private double _totalCost;

        public Basket(int Capacity) {
            _items = new List<BasicItem>();
            _capacity = Capacity;
            _ItemsInBasket = 0;
            _totalCost = 0;
        }

        public double TotalItemsInBasket { get { return _ItemsInBasket; }}
        public List<BasicItem> Items { get { return _items; }}

        public string AddItem(BasicItem item) {
            if(item is Filling) {
                return "Add filling to bagel first";
            }
            if(Stock.GetItem(item.SKU).Name == item.Name) {
                _items.Add(item);
                if(item is Bagel) {
                    Bagel bagel = (Bagel)item;
                    _ItemsInBasket += bagel.Fillings.Count + 1;
                } else
                    _ItemsInBasket +=1;
                return "Added: " + item.Name;
            }
            return "Invalid Item";
        }

    public bool Remove(string id)
    {
        BasicItem itemToRemove = _items.FirstOrDefault(item => item.Id.ToString() == id);

        if (itemToRemove != null)
        {
            _items.Remove(itemToRemove);
            _ItemsInBasket -= 1;
            return true;
        }

        foreach (BasicItem item in _items.Where(item => item is Bagel))
        {
            Bagel bagel = (Bagel)item;

            Filling fillingToRemove = bagel.Fillings.FirstOrDefault(filling => filling.Id.ToString() == id);

            if (fillingToRemove != null)
            {
                bagel.RemoveFilling(fillingToRemove);
                _ItemsInBasket -= 1;
                return true;
            }
        }
        return false;
    }
        public int ChangeCapacity(int newCapacity) {
            if(_ItemsInBasket <= newCapacity) {
                _capacity = newCapacity;
                return _capacity;
            }
            return _capacity;
        }

    }
}

