using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScriptureJournal.Models
{
  public class Entry
  {
    public int ID { get; set; }
    [Display(Name = "Date Added")]
    [DataType(DataType.Date)]
    [Required]
    public DateTime DateAdded { get; set; } = DateTime.Today;
    [Required]
    public string Book { get; set; }
    [Required]
    public string Chapter { get; set; } = string.Empty;
    [Required]
    public string Verse { get; set; } = string.Empty;
    //Note not required
    public string Note { get; set; } = string.Empty;

  }
}
