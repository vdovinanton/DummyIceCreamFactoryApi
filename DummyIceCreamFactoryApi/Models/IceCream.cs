namespace DummyIceCreamFactoryApi.Models;

public class IceCream
{
    public int Id { get; set; }
    public int Type { get; set; }
    public IceCreamTopping Toppings { get; set; }
}