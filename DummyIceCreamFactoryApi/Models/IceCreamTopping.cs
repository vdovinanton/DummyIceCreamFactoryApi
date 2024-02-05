namespace DummyIceCreamFactoryApi.Models;

[Flags]
public enum IceCreamTopping
{
    None               = 0,
    ChoppedPeanuts     = 1,
    WhippedCream       = 2,
    RainbowSprinkles   = 4,
    ChocolateSprinkles = 8,
    Nonpareils         = 16,
    Liqueur            = 32,
    Granola            = 64,
    Cereal             = 128
}