/*using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using apiAndroid.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
*/
using System;
using apiAndroid.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;

namespace apiAndroid.Controllers
{
    [Produces("application/json")]
    [Route("api/BaseMenu")]
    
    public class CalptablaController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CalptablaController(AppDbContext sentContext)
        {
            this._context = sentContext;
        }

        [HttpGet]
        [Route("Mesas")]
        public IEnumerable<Malptabla> GetMenu()
        {
            return this._context.ALPTABLA;
        }

    }
}