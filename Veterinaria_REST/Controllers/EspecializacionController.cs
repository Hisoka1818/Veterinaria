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
    [RoutePrefix("api/Especializacion")]
    public class EspecializacionController : ApiController
    {
        [HttpGet]
        [Route("ConsultarxCodigo")]
        public ESPECIALIZACION ConsultarxCodigo(int codigo)
        {
            clsEspecializacion _especializacion = new clsEspecializacion();
            return _especializacion.Consultar(codigo);
        }

        [HttpPost]
        [Route("insertar")]
        public string insertar([FromBody] ESPECIALIZACION especializacion)
        {
            clsEspecializacion _especializacion = new clsEspecializacion();
            _especializacion.especializacion = especializacion;
            return _especializacion.Insertar();
        }

        [HttpPut]
        [Route("actualizar")]
        public string actualizar([FromBody] ESPECIALIZACION especializacion)
        {
            clsEspecializacion _especializacion = new clsEspecializacion();
            _especializacion.especializacion = especializacion;
            return _especializacion.Actualizar();
        }

        [HttpDelete]
        [Route("eliminar")]
        public string eliminar([FromBody] ESPECIALIZACION especializacion)
        {
            clsEspecializacion _especializacion = new clsEspecializacion();
            _especializacion.especializacion = especializacion;
            return _especializacion.Eliminar();
        }

        [HttpGet]
        [Route("LlenarCombo")]
        public IQueryable LlenarCombo()
        {
            clsEspecializacion _especializacion = new clsEspecializacion();
            return _especializacion.LlenarCombo();
        }

        [HttpGet]
        [Route("LlenarTabla")]
        public IQueryable LlenarTabla()
        {
            clsEspecializacion _especializacion = new clsEspecializacion();
            return _especializacion.LlenarTabla();
        }
    }
}