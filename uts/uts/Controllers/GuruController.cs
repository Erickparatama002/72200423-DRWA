using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using uts.Models;

namespace uts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuruController : ControllerBase
    {
        private GuruContext _context;

        public GuruController(GuruContext context)
        {
            this._context = context;
        }

        // GET: api/kelas
        [HttpGet]
        public ActionResult<IEnumerable<GuruItem>> GetGuruItems()
        {
            _context = HttpContext.RequestServices.GetService(typeof(GuruContext)) as GuruContext;
            return _context.GetAllguru();
        }

        //Get : api/kelas/{id}
        [HttpGet("{nip}", Name = "Get")]
        public ActionResult<IEnumerable<GuruItem>> GetGuruItem(String nip)
        {
            _context = HttpContext.RequestServices.GetService(typeof(GuruContext)) as GuruContext;
            return _context.Getguru(nip);
        }

        //Post: api/kelas
        [HttpPost]
        public ActionResult<GuruItem> AddGuru([FromForm] string rfid, [FromForm] string nip, [FromForm] string nama_guru, [FromForm] string alamat, [FromForm] int status_guru)
        {
            GuruItem ki = new GuruItem();
            ki.rfid = rfid;
            ki.nip = nip;
            ki.nama_guru = nama_guru;
            ki.alamat = alamat;
            ki.status_guru = status_guru;


            _context = HttpContext.RequestServices.GetService(typeof(GuruContext)) as GuruContext;
            return _context.Addguru(ki);
        }
            

    }
}
