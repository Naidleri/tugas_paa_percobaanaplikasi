using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PercobaanApi1.Models;
namespace PercobaanApi1.Controllers
{
    public class MuridAdd : Controller
    {
        private string __contstr;
        public MuridAdd(IConfiguration configuration)
        {
            __contstr = configuration.GetConnectionString("WebApiDatabase");
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("api/murid/create")]
        public ActionResult CreateMurid(Murid murid)
        {
            try
            {
                var context = new MuridContext(this.__contstr);
                context.CreateMurid(murid);
                return Ok("Data murid berhasil ditambah");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }

    public class MuridList : Controller
    {
        private string __contstr;
        public MuridList(IConfiguration configuration)
        {
            __contstr = configuration.GetConnectionString("WebApiDatabase");
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("api/murid")]
        public ActionResult<Murid> ListPerson()
        {
            MuridContext context = new MuridContext(this.__contstr);
            List<Murid> ListMurid = context.ListMurid();
            return Ok(ListMurid);
        }
    }

    public class MuridUpdate : Controller
    {
        private string __contstr;
        public MuridUpdate(IConfiguration configuration)
        {
            __contstr = configuration.GetConnectionString("WebApiDatabase");
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPut("api/murid/update/{id_person}")]
        public ActionResult UpdateMurid(int id_murid, Murid murid)
        {
            try
            {
                var context = new MuridContext(this.__contstr);
                context.UpdateMurid(id_murid, murid);
                return Ok($"Murid dengan Id {id_murid} sukses diupdate");
            }
            catch (Exception ex)
            {
                return BadRequest($"Gagal mengupdate murid, Error: {ex.Message}");
            }
        }
    }

    public class MuridDelete : Controller
    {
        private string __contstr;

        public MuridDelete(IConfiguration configuration)
        {
            __contstr = configuration.GetConnectionString("WebApiDatabase");
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpDelete("api/murid/delete/{id_murid}")]
        public ActionResult DeletePerson(int id_murid)
        {
            try
            {
                var context = new MuridContext(__contstr);
                context.DeleteMurid(id_murid);
                return Ok($"Murid dengan Id {id_murid} berhasil dihapus");

            }   
            catch (Exception ex)
            {
                return BadRequest($"Gagal menghapus murid, Error: {ex.Message}");
            }
        }
    }
}
