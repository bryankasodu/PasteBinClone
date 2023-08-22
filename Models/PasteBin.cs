using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MvcPasteBin.Models;

public class PasteBin
{
    public int Id { get; set; }
    public string? Url { get; set; }

    
    [Display(Name = "Create Date")]
    [DataType(DataType.Date)]
    public DateTime CreateDate { get; set; }
    public string? Paste { get; set; }

    
    public PasteBin()
    { 
        CreateDate = DateTime.Now;
        Url = "/PasteBin/link/"+CreateDate.ToString("Mdhms");
    }
}
