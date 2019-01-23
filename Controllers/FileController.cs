using NSIX.DAL;
using System.Web.Mvc;

namespace NSIX.Controllers
{
    public class FileController : Controller
    {
        private NSIXContext db = new NSIXContext();
        // GET: File
        public ActionResult Index(int id)
        {
            var fileToRetrieve = db.Files.Find(id);
            return File(fileToRetrieve.Content, fileToRetrieve.ContentType);
        }
    }
}