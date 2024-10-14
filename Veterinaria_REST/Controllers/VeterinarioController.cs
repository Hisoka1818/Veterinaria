using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using Veterinaria_REST.Clases;
using Veterinaria_REST.Models;


namespace Veterinaria_REST.Controllers
{
    [RoutePrefix("api/veterinarios")]
    [EnableCors(origins: "https://localhost:44322", headers: "*", methods: "*")]
    public class VeterinarioController : ApiController
    {
        [HttpGet]
        [Route("Consultar")]
        public VETERINARIO Consultar(int codigo)
        {
            clsVeterinario _veterinario = new clsVeterinario();
            return _veterinario.Consultar(codigo);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] VETERINARIO veterinario)
        {
            clsVeterinario _veterinario = new clsVeterinario();
            _veterinario.veterinario = veterinario;
            return _veterinario.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] VETERINARIO veterinario)
        {
            clsVeterinario _veterinario = new clsVeterinario();
            _veterinario.veterinario = veterinario;
            return _veterinario.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] VETERINARIO veterinario)
        {
            clsVeterinario _veterinario = new clsVeterinario();
            _veterinario.veterinario = veterinario;
            return _veterinario.Eliminar();
        }

        [HttpGet]
        [Route("Listarveterinarios")]
        public IQueryable Listarveterinarios()
        {
            clsVeterinario _veterinario = new clsVeterinario();
            return _veterinario.Llenartablaconespecializacion();
        }
    }
}