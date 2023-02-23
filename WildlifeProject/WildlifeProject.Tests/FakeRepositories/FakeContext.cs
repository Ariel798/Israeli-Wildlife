using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildlifeProject.Model;

namespace WildlifeProjectTests.FakeRepositories
{
    public class FakeContext : DbContext
    {
        public List<AdminUser> AdminUsers { get; set; }
        public List<Animal> Animals { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Category> Categories { get; set; }
        public FakeContext()
        {
            AdminUsers = new List<AdminUser>();
            Animals = new List<Animal>();
            Comments = new List<Comment>();
            Categories = new List<Category>();
            AdminUsers!.Add(new AdminUser { UserKey = 1, UserName = "ArielJoseph111", Password = "ArielJoseph111" });
            Categories!.Add(new Category { CategoryId = 1, Name = "Mammels" });
            Animals!.Add(new Animal { AnimalId = 1, Name = "Honey Badger", Description = "~/Information/honey-badger.txt", CategoryId = 1, ConservationStatus = "Extinct in the wild" });
            Comments!.Add(new Comment { CommentId = 1, CommentText = "beautifull!", AnimalId = 1 });
        }
    }
}
