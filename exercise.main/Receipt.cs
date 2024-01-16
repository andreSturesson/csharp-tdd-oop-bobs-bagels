
using System.Text;
using exercise.main;

public class Receipt {

    private Basket _basket;

    public Receipt(Basket basket) {
        _basket = basket;
    }

    public StringBuilder PrintReceipt() {
        StringBuilder layout = new StringBuilder();
        DateTime dateTime = new DateTime();
        layout.AppendLine("~~~ Bob's Bagels ~~~");
        layout.AppendLine();
        layout.AppendLine("    " + dateTime.Date);
        foreach (List<Item> list in _basket.Items)
        {
            layout.AppendLine("----------------------------");
            foreach (Item item in list)
            {
                 layout.AppendFormat("{0,-18}{1,3}   £{2,4:F2}\n",
                            item.Name, list.Count, item.Price);
            }
        }
        layout.AppendLine("----------------------------");
        layout.AppendFormat("{0,-18}{1,12:F2}\n", "Total", _basket.GetTotalCost());
        layout.AppendLine();
        layout.AppendLine("        Thank you");
        layout.AppendLine("      for your order!");
        return layout;
    }
}