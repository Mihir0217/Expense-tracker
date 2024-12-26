using System.ComponentModel.DataAnnotations;

namespace firstmvc.Models;

public class Expense
{
 

    public int Id{get; set;}     //these three filed are associated with the database table columns

    [Required]
    public int Value{get; set;}

    
    public string? Description{get; set;}   // ? is for declaring description filed nullable 

    [DataType(DataType.Date)]
    public DateTime Date { get; set; }
}
