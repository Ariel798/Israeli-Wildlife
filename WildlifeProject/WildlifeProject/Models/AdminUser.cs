using System.ComponentModel.DataAnnotations;

namespace WildlifeProject.Model
{
    public class AdminUser
    {
        [Key]
        public int UserKey { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
