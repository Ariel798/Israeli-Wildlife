using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WildlifeProject.Model
{
    public class Comment
    {

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentId { get; set; }
        [DisplayName("Comment Text: ")]
        public string? CommentText { get; set; }
        public int AnimalId { get; set; }
        [ForeignKey("AnimalId")]
        public virtual Animal? Animal { get; set; }
    }
}
