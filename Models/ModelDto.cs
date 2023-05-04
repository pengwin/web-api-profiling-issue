namespace Models;

public class ModelDto
{
    public string Name { get; set; }

    public int Amount { get; set; }

    public static ModelDto[] CreateData(int count = 90000) => Enumerable
        .Range(0, count)
        .Select(_ => new ModelDto
        {
            Name = "ABC",
            Amount = 1000
        })
        .ToArray();
}