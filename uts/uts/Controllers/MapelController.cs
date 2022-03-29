using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using uts.Models;

namespace uts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapelController : ControllerBase
    {
        private MapelContext _context;

        public MapelController(MapelContext context)
        {
            this._context = context;
        }

        // GET: api/kelas
        [HttpGet]
        public ActionResult<IEnumerable<MapelItem>> GetMapelItems()
        {
            _context = HttpContext.RequestServices.GetService(typeof(MapelContext)) as MapelContext;
            return _context.GetAllmapel();
        }

        //Get : api/kelas/{id}
        [HttpGet("{id}", Name = "Get3")]
        public ActionResult<IEnumerable<MapelItem>> GetMapelItem(String id)
        {
            _context = HttpContext.RequestServices.GetService(typeof(MapelContext)) as MapelContext;
            return _context.Getmapel(id);
        }

        //Post: api/kelas
        [HttpPost]
        public ActionResult<MapelItem> AddMapel([FromForm] string nama_mapel, [FromForm] string deskripsi)
        {
            MapelItem ki = new MapelItem();
            ki.nama_mapel = nama_mapel;
            ki.deskripsi = deskripsi;
          

            _context = HttpContext.RequestServices.GetService(typeof(MapelContext)) as MapelContext;
            return _context.AddMapel(ki);
        }


    }
}
