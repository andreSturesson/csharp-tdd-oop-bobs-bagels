// See https://aka.ms/new-console-template for more information
using exercise.main;

Console.WriteLine("Hello, World!");


Basket basket = new Basket(10);

basket.AddItem(Stock.GetItem("BGLO"));

basket.AddItem(Stock.GetItem("BGLO"));

basket.AddItem(Stock.GetItem("COFW"));

Bagel bagel = (Bagel)Stock.GetItem("BGLO");
bagel.AddFilling((Filling)Stock.GetItem("FILB"));
bagel.AddFilling((Filling)Stock.GetItem("FILX"));

basket.AddItem(bagel);

basket.AddItem(Stock.GetItem("COFL"));

Receipt re = new Receipt(basket);
Console.WriteLine(re.PrintReceipt());

Basket basket1 = new Basket(10);

basket1.AddItem(Stock.GetItem("BGLO"));

basket1.AddItem(Stock.GetItem("BGLO"));

basket1.AddItem(Stock.GetItem("BGLO"));

basket1.AddItem(Stock.GetItem("BGLO"));

basket1.AddItem(Stock.GetItem("BGLO"));


Bagel bagel1 = (Bagel)Stock.GetItem("BGLO");
bagel1.AddFilling((Filling)Stock.GetItem("FILB"));
bagel1.AddFilling((Filling)Stock.GetItem("FILX"));

basket1.AddItem(bagel);

basket1.AddItem(Stock.GetItem("COFL"));

Receipt re1 = new Receipt(basket);
re1.GetTotalCost();
Console.WriteLine(re1.PrintReceipt());