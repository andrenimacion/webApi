using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using apiAndroid.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace apiAndroid.Controllers
{
    [Produces("application/json")]
    [Route("api/Meseros")]
    public class Cdp03a110Controller : ControllerBase
    {
        private readonly AppDbContext _context;
        public Cdp03a110Controller(AppDbContext sentContext)
        {
            this._context = sentContext;
        }

        [HttpGet]
        [Route("GetMenuBase")]
        public IEnumerable<Mdp03a110> GetMenu()
        {
            return this._context.DP03A110;
        }

        //string SelectSQL = "SELECT codigo, nombre, campo2 FROM ALPTABLA WHERE MASTER = (select codigo from alptabla where rtrim(ltrim(coalesce(master,'')))='' and nomtag='I_BODE')";I_BODE

        

        [HttpGet]
        [Route("GetTable/{campo}")]
        public ActionResult<DataTable> GetTable([FromRoute] String campo)
        {
            
            string Sentencia = "SELECT ltrim(rtrim(codigo))codigo, ltrim(rtrim(nombre))nombre, ltrim(rtrim(campo2))campo2 FROM ALPTABLA WHERE MASTER " +
                "= (select codigo from alptabla where rtrim(ltrim(coalesce(master,'')))='' and nomtag=@campo)";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Sentencia, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.SelectCommand.CommandType = CommandType.Text;

                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@campo", campo));
                    adapter.Fill(dt);
                }
            }


            if (dt == null)
            { 
                return NotFound("");
            }
           
            return Ok(dt);
           
        }


    }
}