using System.ComponentModel.DataAnnotations;

namespace Entities.Models;
public class Product
{
    public int ProductID { get; set; }
    public String? ProductName { get; set; } = String.Empty;
    public decimal Price { get; set; }

    public int? CategoryId { get; set; }  //foreign key
    public Category? Category { get; set; }   //navigation property
}
