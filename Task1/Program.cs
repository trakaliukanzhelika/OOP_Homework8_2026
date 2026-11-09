// Порушено принцип єдиної відповідальності (SRP).

using System;
using System.Collections.Generic;

class Item
{
    public string Name { get; set; }
    public double Price { get; set; }

    public Item(string name, double price)
    {
        Name = name;
        Price = price;
    }
}

class Order
{
    private List<Item> itemList = new List<Item>();

    internal List<Item> ItemList
    {
        get { return itemList; }
        set { itemList = value; }
    }

    public double CalculateTotalSum()
    {
        double sum = 0;
        foreach (Item item in itemList)
            sum += item.Price;
        return sum;
    }

    public List<Item> GetItems() { return itemList; }
    public int GetItemCount() { return itemList.Count; }
    public void AddItem(Item item) { itemList.Add(item); }
    public void DeleteItem(Item item) { itemList.Remove(item); }
}

class OrderPrinter
{
    public void PrintOrder(Order order)
    {
        Console.WriteLine("Друк замовлення (кількість товарів: {0})", order.GetItemCount());
    }

    public void ShowOrder(Order order)
    {
        foreach (Item item in order.GetItems())
            Console.WriteLine("  {0} - {1}", item.Name, item.Price);
        Console.WriteLine("Разом: {0}", order.CalculateTotalSum());
    }
}

class OrderRepository
{
    public Order Load(int orderId)
    {
        Console.WriteLine("Завантаження замовлення {0}", orderId);
        return new Order();
    }

    public void Save(Order order) { Console.WriteLine("Замовлення збережено"); }
    public void Update(Order order) { Console.WriteLine("Замовлення оновлено"); }
    public void Delete(Order order) { Console.WriteLine("Замовлення видалено"); }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Order order = new Order();
        order.AddItem(new Item("Книга", 250));
        order.AddItem(new Item("Ручка", 30));

        OrderPrinter printer = new OrderPrinter();
        printer.PrintOrder(order);
        printer.ShowOrder(order);

        OrderRepository repository = new OrderRepository();
        repository.Save(order);
    }
}
