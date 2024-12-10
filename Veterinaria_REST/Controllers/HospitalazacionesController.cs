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
    [RoutePrefix("api/Hospitalizaciones")]
    public class HospitalizacionesController : ApiController
    {
        private readonly clsHospitalizacion clsHospitalizacion;
        public HospitalizacionesController()
        {
            this.clsHospitalizacion = new clsHospitalizacion();
        }

        [HttpGet]
        [Route("LlenarTabla")]
        public IQueryable LlenarTabla()
        {
            return clsHospitalizacion.LlenarTabla();
        }

        [HttpGet]
        [Route("Consultar")]
        public IQueryable Consultar()
        {
            return clsHospitalizacion.Consultar();
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] HOSPITALIZACION hospitalizacion)
        {
            clsHospitalizacion.hospitalizacion = hospitalizacion;
            return clsHospitalizacion.Insertar();
        }

        [HttpGet]
        [Route("ConsultarXID")]
        public HOSPITALIZACION ConsultarXID(int ID)
        {
            return clsHospitalizacion.Consultar(ID);
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] HOSPITALIZACION hospitalizacion)
        {
            clsHospitalizacion.hospitalizacion = hospitalizacion;
            return clsHospitalizacion.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] HOSPITALIZACION hospitalizacion)
        {
            clsHospitalizacion.hospitalizacion = hospitalizacion;
            return clsHospitalizacion.Eliminar();
        }
    }
}
