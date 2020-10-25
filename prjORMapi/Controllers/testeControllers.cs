using Microsoft.AspNetCore.Mvc;

namespace projetoORM.prjORMapi.Controllers
{
    public class testeControllers:Controller
    {
        [HttpGet("teste")]
        public IActionResult Teste(){
            return Ok("api esta funcionando ");
            
        }
        
    }
}