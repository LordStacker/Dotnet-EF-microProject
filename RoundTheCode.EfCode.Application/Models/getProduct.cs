
namespace RoundTheCode.EFCore.Application.Models
{
    public class GetProduct
    {
        public int Id { get; set; }

        public string? Name { get; set; }
        public string? Description { get; set; }

        public double Price { get; set; }

        public string? CategoryName { get; set;}
    }
}
