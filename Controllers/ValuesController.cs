using IBKS.Data;
using IBKS.Migrations;
using IBKS.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace IBKS.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class ValuesController : ControllerBase
        {
            private readonly IBKSDbContext ibksDbContext;

            public ValuesController(IBKSDbContext ibkssDbContext)
            {
                ibksDbContext = ibkssDbContext;
            }

            // GET: api/Users
            [HttpGet]
            public async Task<ActionResult<IEnumerable<User>>> GetTodoItems()
            {
                return 
                await ibksDbContext.Users.ToListAsync();
             
            }
        

    }
}

