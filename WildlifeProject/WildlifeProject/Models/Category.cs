using System.ComponentModel.DataAnnotations;

namespace WildlifeProject.Model
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<Animal>? Animals { get; set; }
    }
}
