

public class Discount {
    private int _quantity;
    private double _newPrice;

    private string _name;

    private string _variant;
    private string _identifier;
    private string _identifier2;

    public Discount(int quantity = 0, double newPrice = 0, string name = "", string variant = "", string identifier = "", string identifier2 = "") {
        _quantity = quantity;
        _newPrice = newPrice;
        _name = name;
        _variant = variant;
        _identifier = identifier;
        _identifier2 = identifier2;
    }

    public int Quantity { get { return _quantity; }}
    public double NewPrice { get { return _newPrice; }}
    public string Identifier { get { return _identifier; }}
    public string Identifier2 { get { return _identifier2; }}


}