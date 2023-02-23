using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace WildlifeProject.Model
{
    public class Animal
    {
        [Key]
        [Required(ErrorMessage = "Please enter email address")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnimalId { get; set; }
        [DisplayName("Name: ")]
        [Required(ErrorMessage = "Please enter name")]
        public string? Name { get; set; }
        [DisplayName("Description: ")]
        [Required(ErrorMessage = "Please enter description")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Please enter categoryId")]
        public int? CategoryId { get; set; }
        [DisplayName("CategoryId: ")]
        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; }
        [Required(ErrorMessage = "Please enter conservation status")]
        [DisplayName("Conservation Status: ")]
        public string? ConservationStatus { get; set; }
        [DisplayName("Comments: ")]
        public virtual ICollection<Comment>? Comments { get; set; }
        [DisplayName("Image: ")]
        public byte[]? Image { get; set; }
    }
    public enum CategoryEnum
    {
        Mammals = 1,
        Birds,
        Reptiles,
        Amphibian,
    }
}
