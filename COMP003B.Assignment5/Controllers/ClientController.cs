using Microsoft.AspNetCore.Mvc;
using COMP003B.Assignment5.Models;

namespace COMP003B.Assignment5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ClientController : Controller
    {
        //Create new private list
        private List<Client> _clients = new List<Client>();

        //Add pre-filled options to the list
        public ClientController()
        {
            _clients.Add(new Client { });
        }
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
