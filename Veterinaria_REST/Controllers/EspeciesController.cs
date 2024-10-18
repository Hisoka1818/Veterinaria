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
    [RoutePrefix("api/Especies")]
    public class EspeciesController : ApiController
    {

        private clsEspecie clsEspecie;
        public EspeciesController()
        {
            this.clsEspecie = new clsEspecie();
        }

        [HttpGet]
        [Route("LlenarCombo")]
        public IQueryable LlenarCombo()
        {
            return clsEspecie.LlenarCombo();
        }

        [HttpGet]
        [Route("LlenarTabla")]
        public IQueryable LlenarTabla()
        {
            return clsEspecie.LlenarTabla();
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] ESPECIE especie)
        {
            clsEspecie.especie = especie;
            return clsEspecie.Insertar();
        }

        [HttpGet]
        [Route("ConsultarXID")]
        public ESPECIE ConsultarXID(int ID)
        {
            return clsEspecie.Consultar(ID);
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] ESPECIE especie)
        {
            clsEspecie.especie = especie;
            return clsEspecie.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] ESPECIE especie)
        {
            clsEspecie.especie = especie;
            return clsEspecie.Eliminar();
        }
    }
}