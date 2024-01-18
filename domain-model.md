### Domain Model

| Classes | Members                                                                         | Methods                                                          | Returns                                                                            |   |
|---------|---------------------------------------------------------------------------------|------------------------------------------------------------------|------------------------------------------------------------------------------------|---|
| Item    | private string _SKU :: Getter                                                   |                                                                  |                                                                                    |   |
|         | private int _price :: Getter                                                    |                                                                  |                                                                                    |   |
|         | private string _name :: Getter                                                  |                                                                  |                                                                                    |   |
|         | private string _variant :: Getter                                               |                                                                  |                                                                                    |   |
|         | private bool _couldFilling :: Getter \| If the Item is allowed to have fillings |                                                                  |                                                                                    |   |
| Stock   | public static Dictionary<string, Item> Bagels :: Getter                         | public static GetSkuByName(string Name, string Variant) : string | returns the SKU of the Item.                                                       |   |
|         | public static Dictionary<string, Item> Coffee :: Getter                         | public static GetPrice(string Name, string Variant)              | returns the price of the Item.                                                     |   |
|         | public static Dictionary<string, Item> Filling :: Getter                        |                                                                  |                                                                                    |   |
|         |                                                                                 |                                                                  |                                                                                    |   |
| Basket  | private List<List<Item>> _items                                                 | public AddItem(string sku) : Item                                | Adds an item by SKU, returns the Item added, otherwise null                        |   |
|         | private int _capacity                                                           | public RemoveBagel(Item item): bool                              | Removes the bagel by SKU, returns true if it exists in the Order, otherwise false. |   |
|         | private int ItemsInOrder :: Getter                                              | public ChangeCapacity(int capacity) : bool                       | Returns true if capacity can be changed                                            |   |
|         | private int TotalCost :: Getter                                                 |                                                                  |                                                                                    |   |
|         |                                                                                 |                                                                  |                                                                                    |   |

### Notes to self
I commited to a flawed design early on, Was determined to continue using it and not refactor. Should be more open to refactoring in the future.

### Refactored Domain Model

| Classes            | Members                                               | Methods                                                                       | Returns                                              |   |
|--------------------|-------------------------------------------------------|-------------------------------------------------------------------------------|------------------------------------------------------|---|
| Class BaseItem     | guid uuid :: Getter                                   |                                                                               |                                                      |   |
|                    | string _SKU ::Getter                                  |                                                                               |                                                      |   |
|                    | int _price ::Getter                                   |                                                                               |                                                      |   |
|                    | string _name ::Getter                                 |                                                                               |                                                      |   |
|                    | string _variant ::Getter                              |                                                                               |                                                      |   |
| Bagel : BaseItem   | private List<Filling> fillings ::Getter               | public AddFilling(Filling filling) : bool                                     | Returns True if added to the Bagel, otherwise False. |   |
| Coffee : BaseItem  |                                                       |                                                                               |                                                      |   |
| Filling : BaseItem |                                                       |                                                                               |                                                      |   |
| Discounts          | private int _quantity ::Getter                        |                                                                               |                                                      |   |
|                    | private int price ::Getter                            |                                                                               |                                                      |   |
| Stock              | public static Dictionary<string, Bagel> Bagels        |                                                                               |                                                      |   |
|                    | public static Dictionary<String, Coffee> Coffee       |                                                                               |                                                      |   |
|                    | public static Dictionary<string, Filling> Fillings    |                                                                               |                                                      |   |
|                    | public static Dictionary<string, Discounts> Discounts |                                                                               |                                                      |   |
| Basket             | private List<BaseItem> _basket                        | public Basket(int Capacity) - Overloaded to support an initial List<BaseItem> |                                                      |   |
|                    | private int _capacity                                 |                                                                               |                                                      |   |
|                    | private int _itemsInBasket                            |                                                                               |                                                      |   |
| Receipt            | private Basket _basket                                | public Receipt(Basket basket)                                                 |                                                      |   |
|                    |                                                       |                                                                               |                                                      |   |



