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
    [RoutePrefix("api/Cirugias")]
    public class CirugiasController : ApiController
    {
        private readonly clsCirugia clsCirugia;
        public CirugiasController()
        {
            this.clsCirugia = new clsCirugia();
        }

        [HttpGet]
        [Route("LlenarTabla")]
        public IQueryable LlenarTabla()
        {
            return clsCirugia.LlenarTabla();
        }

        [HttpGet]
        [Route("Consultar")]
        public IQueryable Consultar()
        {
            return clsCirugia.Consultar();
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] CIRUGIA Cirugia)
        {
            clsCirugia.Cirugia = Cirugia;
            return clsCirugia.Insertar();
        }

        [HttpGet]
        [Route("ConsultarXID")]
        public CIRUGIA ConsultarXID(int ID)
        {
            return clsCirugia.ConsultarXId(ID);
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] CIRUGIA Cirugia)
        {
            clsCirugia.Cirugia = Cirugia;
            return clsCirugia.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] CIRUGIA Cirugia)
        {
            clsCirugia.Cirugia = Cirugia;
            return clsCirugia.Eliminar();
        }
    }
}
