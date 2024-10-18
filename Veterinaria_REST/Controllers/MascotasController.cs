using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Veterinaria_REST.Clases;
using Veterinaria_REST.Models;

namespace Veterinaria_REST.Controllers
{
    [EnableCors(origins: "https://localhost:44322", headers: "*", methods: "*")]
    [RoutePrefix("api/Mascotas")]
    public class MascotasController : ApiController
    {
        private clsMascota clsMascota;
        public MascotasController()
        {
            this.clsMascota = new clsMascota();
        }

        [HttpGet]
        [Route("LlenarTabla")]
        public IQueryable LlenarTabla()
        {
            return clsMascota.LlenarTabla();
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] MASCOTA mascota)
        {
            clsMascota.mascota = mascota;
            return clsMascota.Insertar();
        }

        [HttpGet]
        [Route("ConsultarXID")]
        public MASCOTA ConsultarXID(int ID)
        {
            return clsMascota.Consultar(ID);
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] MASCOTA mascota)
        {
            clsMascota.mascota = mascota;
            return clsMascota.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] MASCOTA mascota)
        {
            clsMascota.mascota = mascota;
            return clsMascota.Eliminar();
        }
    }
}