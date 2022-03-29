using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using uts.Models;

namespace uts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JadwalController : ControllerBase
    {
        private JadwalContext _context;

        public JadwalController(JadwalContext context)
        {
            this._context = context;
        }

        // GET: api/kelas
        [HttpGet]
        public ActionResult<IEnumerable<JadwalItem>> GetJadwalItems()
        {
            _context = HttpContext.RequestServices.GetService(typeof(JadwalContext)) as JadwalContext;
            return _context.GetAlljadwal();
        }

        //Get : api/kelas/{id}
        [HttpGet("id_mapel/{id_mapel}", Name = "Getidm")]
        public ActionResult<IEnumerable<JadwalItem>> GetJadwalItem(String id_mapel)
        {
            _context = HttpContext.RequestServices.GetService(typeof(JadwalContext)) as JadwalContext;
            return _context.Getjadwal(id_mapel);
        }

        [HttpGet("nip/{nip}", Name = "Get2nip")]
        public ActionResult<IEnumerable<JadwalItem>> GetJadwalnipItem(String nip)
        {
            _context = HttpContext.RequestServices.GetService(typeof(JadwalContext)) as JadwalContext;
            return _context.Getjadwal(nip);
        }

        //Post: api/kelas
        [HttpPost]
        public ActionResult<JadwalItem> AddJadwal([FromForm] int id_jadwal_guru, [FromForm] string tahun_akademik, [FromForm] string semester, [FromForm] int id_guru,
            [FromForm] string hari, [FromForm] int id_kelas, [FromForm] int id_mapel, [FromForm] string jam_mulai, [FromForm] string jam_selesai)
        {
            JadwalItem ki = new JadwalItem();
            ki.tahun_akademik = tahun_akademik;
            ki.semester = semester;
            ki.id_guru = id_guru;
            ki.hari = hari;
            ki.id_kelas = id_kelas;
            ki.id_mapel = id_mapel;
            ki.jam_mulai = jam_mulai;   
            ki.jam_selesai = jam_selesai;   



            _context = HttpContext.RequestServices.GetService(typeof(JadwalContext)) as JadwalContext;
            return _context.Addjadwal(ki);
        }


    }
}
