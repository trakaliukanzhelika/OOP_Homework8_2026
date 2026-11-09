// Порушено принцип розділення інтерфейсу (ISP).

using System;

interface IPriced
{
    void SetPrice(double price);
}

interface IDiscountable
{
    void ApplyDiscount(String discount);
    void ApplyPromocode(String promocode);
}

interface IColored
{
    void SetColor(byte color);
}

interface ISized
{
    void SetSize(byte size);
}

class Book : IPriced, IDiscountable
{
    public string Title { get; }
    private double price;
    private string discount = "немає";
    private string promocode = "немає";

    public Book(string title)
    {
        Title = title;
    }

    public void SetPrice(double price) { this.price = price; }
    public void ApplyDiscount(String discount) { this.discount = discount; }
    public void ApplyPromocode(String promocode) { this.promocode = promocode; }

    public void Info()
    {
        Console.WriteLine("Книжка \"{0}\": ціна {1}, знижка {2}, промокод {3}",
            Title, price, discount, promocode);
    }
}

class Outerwear : IPriced, IDiscountable, IColored, ISized
{
    public string Name { get; }
    private double price;
    private byte color;
    private byte size;
    private string discount = "немає";
    private string promocode = "немає";

    public Outerwear(string name)
    {
        Name = name;
    }

    public void SetPrice(double price) { this.price = price; }
    public void ApplyDiscount(String discount) { this.discount = discount; }
    public void ApplyPromocode(String promocode) { this.promocode = promocode; }
    public void SetColor(byte color) { this.color = color; }
    public void SetSize(byte size) { this.size = size; }

    public void Info()
    {
        Console.WriteLine("Одяг \"{0}\": ціна {1}, колір {2}, розмір {3}, знижка {4}, промокод {5}",
            Name, price, color, size, discount, promocode);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Book book = new Book("Чистий код");
        book.SetPrice(450);
        book.ApplyDiscount("10%");
        book.Info();

        Outerwear jacket = new Outerwear("Куртка");
        jacket.SetPrice(2500);
        jacket.SetColor(3);
        jacket.SetSize(48);
        jacket.ApplyPromocode("WINTER");
        jacket.Info();
    }
}
