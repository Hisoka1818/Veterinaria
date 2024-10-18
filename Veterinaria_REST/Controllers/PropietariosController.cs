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
    [RoutePrefix("api/Propietarios")]
    public class PropietariosController : ApiController
    {
        private clsPropietario clsPropietario;
        public PropietariosController()
        {
            this.clsPropietario = new clsPropietario();
        }

        [HttpGet]
        [Route("LlenarCombo")]
        public IQueryable LlenarCombo()
        {
            return clsPropietario.LlenarCombo();
        }

        [HttpGet]
        [Route("LlenarTabla")]
        public IQueryable LlenarTabla()
        {
            return clsPropietario.LlenarTabla();
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] PROPIETARIO propietario)
        {
            clsPropietario.propietario = propietario;
            return clsPropietario.Insertar();
        }

        [HttpGet]
        [Route("ConsultarXID")]
        public PROPIETARIO ConsultarXID(int ID)
        {
            return clsPropietario.Consultar(ID);
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] PROPIETARIO propietario)
        {
            clsPropietario.propietario = propietario;
            return clsPropietario.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] PROPIETARIO propietario)
        {
            clsPropietario.propietario = propietario;
            return clsPropietario.Eliminar();
        }
    }
}