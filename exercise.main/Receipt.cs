
using System.Runtime.InteropServices;
using System.Text;
using exercise.main;

public class Receipt {

    public StringBuilder layout;
    private Basket _basket;
    private double _totalCost;

    private double _savings;
    public Receipt(Basket basket) {
        _basket = basket;
        _savings = 0;
        _totalCost = 0;
        layout = new StringBuilder();
    }

    public StringBuilder PrintReceipt() {
        GetTotalCost();
        StringBuilder layout = new StringBuilder();
        DateTime dateTime = new DateTime();
        layout.AppendLine("~~~ Bob's Bagels ~~~");
        layout.AppendLine();
        layout.AppendLine("    " + dateTime.Date);
        layout.AppendLine("----------------------------");
        foreach (BasicItem item in _basket.Items)
        {
            layout.AppendLine(item.Name + " " + item.Variant+ "       " + item.Price + "£");
            if(item is Bagel) {
                Bagel b = (Bagel)item;
                foreach (Filling filling in b.Fillings)
                {
                    layout.AppendLine("   " + filling.Name + " " + filling.Variant + "       " + filling.Price + "£");
                }
            }
            layout.AppendLine("----------------------------");
        }
        
        layout.AppendFormat("{0,-18}{1,12:F2}\n", "Total", _totalCost  + "£");
        layout.AppendLine();
        layout.AppendLine("You saved: " + _savings + "£");
        layout.AppendLine("        Thank you");
        layout.AppendLine("      for your order!");
        return layout;
    }

    public double GetTotalCost()
    {
        foreach (BasicItem item in _basket.Items)
        {
            if (item is Coffee coffee)
            {
                _totalCost += coffee.Price;
            }
            else if (item is Bagel bagel)
            {
                _totalCost += bagel.Price;

                foreach (Filling filling in bagel.Fillings)
                {
                    _totalCost += filling.Price;
                }
            }
        }

        List<Bagel> bagels = _basket.Items.OfType<Bagel>().ToList();
        List<Coffee> Coffee = _basket.Items.OfType<Coffee>().ToList();
        foreach (Discount discount in Stock.Discounts)
        {
            if(bagels.Count % discount.Quantity == 0 && discount.Quantity > 1) {
                int multiplier = bagels.Count / discount.Quantity;
                if (IsWholeNumber(multiplier) && multiplier > 0) {
                    double d = CalculateItemOffSet(bagels, discount.Quantity);
                    _savings += d;
                    _totalCost = _totalCost-d + discount.NewPrice;
                }
            }
            else if (discount.Identifier == "Coffee" && discount.Identifier2 == "Bagel") {
                int multiplier = 0;
                if(bagels.Count > Coffee.Count && bagels.Count > 1 && Coffee.Count > 1) {
                    multiplier = bagels.Count - Coffee.Count;
                }
                multiplier = Math.Min(bagels.Count, Coffee.Count);
                if(multiplier < 0) {
                    break;
                }
                if(multiplier == 0)
                    multiplier = Coffee.Count;
                multiplier = Math.Min(bagels.Count, Coffee.Count);
                double b = CalculateItemOffSet(bagels, multiplier);
                double c = CalculateItemOffSet(Coffee, multiplier);
                _savings += b+c;
                _totalCost = _totalCost-(b+c) + discount.NewPrice*multiplier;
            }
        }
        return _totalCost;
    }

    private bool IsWholeNumber(int number)
    {
        return number > 0 && number % 1 == 0;
}

    public double CalculateItemOffSet(List<Bagel> items, int count) {
        int counter = 0;
        double number = 0;
            foreach (Bagel bagel in items)
            {
                if(counter == count)
                    break;
                number += bagel.Price;
                counter += 1;
            }
            return number;
    }

    public double CalculateItemOffSet(List<Coffee> items, int count) {
        int counter = 0;
        double number = 0;
            foreach (Coffee bagel in items)
            {
                if(counter == count)
                    break;
                number += bagel.Price;
                counter += 1;
            }
            return number;
    }

}