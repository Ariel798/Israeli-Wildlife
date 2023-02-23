using Microsoft.EntityFrameworkCore;
using WildlifeProject.Model;
using WildlifeProject.Repository;

namespace WildlifeProject.Services.CommentService
{
    public class CommentService : ICommentService
    {
        readonly AdminContext _adminContext;
        public CommentService(AdminContext adminContext)
        {
            _adminContext = adminContext;
        }
        public void AddComment(Comment newComment)
        {
            _adminContext.Database.OpenConnection();
            try
            {
                _adminContext.Comments?.Add(newComment);
                _adminContext.SaveChanges();
            }
            finally
            {
                _adminContext.Database.CloseConnection();
            }
        }
    }
}
