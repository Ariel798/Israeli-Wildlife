using Microsoft.AspNetCore.Mvc;
using WildlifeProject.Model;
using WildlifeProject.Services.CommentService;

namespace WildlifeProject.Controllers
{
    public class CommentController : Controller
    {
        ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddComment(Comment newComment)
        {
            try
            {
                _commentService.AddComment(newComment);
                return Redirect(Request.Headers["Referer"].ToString());
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
