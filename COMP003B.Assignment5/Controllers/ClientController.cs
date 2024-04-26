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
            _clients.Add(new Client { Id = 1, Name = "Ted", Material = "Silver", Engraving = "None", Size = 13 });
            _clients.Add(new Client { Id = 2, Name = "Laurence", Material = "Silver", Engraving = "A sunflower", Size = 12 });
            _clients.Add(new Client { Id = 3, Name = "Daniel", Material = "Gold", Engraving = "Dance Forever", Size = 7 });
            _clients.Add(new Client { Id = 4, Name = "Cassandra", Material = "Silver", Engraving = "None", Size = 8 });
            _clients.Add(new Client { Id = 5, Name = "Danny", Material = "Gold", Engraving = "The sun", Size = 11 });
        }

        //CRUD Operations

        //Get All(read): api/clients
        [HttpGet]
        public ActionResult<IEnumerable<Client>> GetAllClients()
        {
            return _clients;
        }

        //Get by Id(read) : api/clients/5
        [HttpGet("{id}")]
        public ActionResult<Client> GetClientsById(int id)
        {
            var client = _clients.FirstOrDefault(c => c.Id == id);
            if (client == null)
            {
                return NotFound();
            }
            //return client;
            return client;
        }

        //HttpPost
        [HttpPost]
        public ActionResult<Client> CreateClient(Client client)
        {
            //Automatically Assign an Id
            client.Id = _clients.Max(c => c.Id) + 1;

            //Add to list
            _clients.Add(client);

            return CreatedAtAction(nameof(GetClientsById), new { id = client.Id }, client);
        }

        //Put(Update: api.client)
        [HttpPut]
        public ActionResult<Client> UpdateClient(int id, Client updatedClient)
        {
            //Find client by Id
            var client = _clients.Find(c => c.Id == id);

            //Return Bad Request if not found
            if(client == null)
            {
                return BadRequest();
            }

            //Update client listing
            client.Name = updatedClient.Name;
            client.Material = updatedClient.Material;
            client.Size = updatedClient.Size;
            client.Engraving = updatedClient.Engraving;
            return NoContent();
        }

        //Delete: api/client
        [HttpDelete]
        public ActionResult DeleteClient(int id)
        {
            //Find by Id
            var client = _clients.Find(c => c.Id == id);
            //Return not found if null
            if(client == null)
            {
                return NotFound();
            }

            //Remove from list
            _clients.Remove(client);
            return NoContent();
        }
    
    }
}
