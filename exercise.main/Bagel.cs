
public class Bagel : BasicItem {

    private List<Filling> fillings;

    public Bagel(string sku, double price, string variant) : base(sku, price, variant)
    {
        fillings = new List<Filling>();
        Name = "Bagel";
    }

    public Bagel(Bagel bagel) : base(bagel)
    {
        fillings = new List<Filling>(bagel.fillings);
    }


    public List<Filling> Fillings { get { return fillings; }}

    public bool AddFilling(Filling filling) {
        fillings.Add(filling);
        return true;
    }

    public bool RemoveFilling(Filling filling) {
        fillings.Remove(filling);
        return true;
    }
}