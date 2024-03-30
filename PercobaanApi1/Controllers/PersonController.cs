using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PercobaanApi1.Models;
namespace PercobaanApi1.Controllers
{
    public class PersonAdd : Controller
    {
        private string __contstr;
        public PersonAdd(IConfiguration configuration)
        {
            __contstr = configuration.GetConnectionString("WebApiDatabase");
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("api/person/create")]
        public ActionResult CreatePerson(Person person) 
        {
            try
            {
                var context = new PersonContext(this.__contstr);
                context.CreatePerson(person);
                return Ok("Data berhasil ditambah");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }

    public class PersonController : Controller
    {
        private string __contstr;
        public PersonController(IConfiguration configuration)
        {
            __contstr = configuration.GetConnectionString("WebApiDatabase");
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("api/person")]
        public ActionResult<Person> ListPerson()
        {
            PersonContext context = new PersonContext(this.__contstr);
            List<Person> ListPerson = context.ListPerson();
            return Ok(ListPerson);
        }
    }

    public class PersonUpdate : Controller
    {
        private string __contstr;
        public PersonUpdate(IConfiguration configuration)
        {
            __contstr = configuration.GetConnectionString("WebApiDatabase");
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPut("api/person/update/{id_person}")]
        public ActionResult UpdatePerson(int id_person, Person person)
        {
            try
            {
                var context = new PersonContext(this.__contstr);
                context.UpdatePerson(id_person, person);
                return Ok($"Person dengan Id {id_person} sukses diupdate");
            }
             catch (Exception ex)
            {
                return BadRequest($"Gagal mengupdate user, Error: {ex.Message}");
            }
        }
    }

    public class PersonDelete : Controller
    {
        private string __contstr;

        public PersonDelete (IConfiguration configuration)
        {
            __contstr = configuration.GetConnectionString("WebApiDatabase");
        }
        public IActionResult Index ()
        {
            return View();
        }
        [HttpDelete("api/person/delete/{id_person}")]
        public ActionResult DeletePerson (int id_person)
        {
            try
            {
                var context = new PersonContext(__contstr);
                context.DeletePerson(id_person);
                return Ok($"Person dengan Id {id_person} berhasil dihapus");
                
            }
            catch (Exception ex)
            {
                return BadRequest($"Gagal menghapus user, Error: {ex.Message}");
            }
        }
    }
}
