using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServerAPI.Data;

namespace ServerAPI.Controllers
{
    [ApiController]
    [Route("api/commands")]
    public class RaspController : ControllerBase
    {

        private readonly MockRaspRepo _repository = new MockRaspRepo();

        

        
        [HttpGet]
        public ActionResult<IEnumerable<MRaspisanie>> GetAllRasp()
        {
            var raspItem = _repository.GetAllRasp();
            return Ok(raspItem);
        }
        
        
        
        [HttpGet("{id}")]
        public ActionResult<MRaspisanie> GetRaspById(int id)
        {
            var raspItem = _repository.GetRaspById(id);
            return Ok(raspItem);
        }
    }
}