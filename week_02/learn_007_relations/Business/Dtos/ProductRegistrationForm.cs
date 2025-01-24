namespace Business.Dtos;

public class ProductRegistrationForm
{
    public string Name { get; set; } = null!;
    public int Price { get; set; }
    public string CategoryName { get; set; } = null!;
}