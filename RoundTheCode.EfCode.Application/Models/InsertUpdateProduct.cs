
namespace RoundTheCode.EFCore.Application.Models
{
    public class InsertUpdateProduct
    {
        public string? Name { get; set; }
        public string? Description { get; set; }

        public double Price { get; set; }

        public int? CategoryId { get; set; }

    }
}
