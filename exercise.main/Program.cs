// See https://aka.ms/new-console-template for more information
using exercise.main;

Console.WriteLine("Hello, World!");

Basket _basket = new Basket(10);
        _basket.AddItem("BGLO", "FILX");
        _basket.AddItem("BGLS");
        _basket.AddItem("COFL");
        _basket.AddItem("COFW");
        _basket.AddItem("BGLS", "FILH");
        _basket.AddItem("COFW");

Receipt receipt = new Receipt(_basket);

Console.WriteLine(receipt.PrintReceipt());