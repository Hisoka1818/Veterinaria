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
        [Route("consultar")]
        public ESPECIALIZACION consultar(int codigo)
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
        [Route("llenarCombo")]
        public IQueryable llenarCombo()
        {
            clsEspecializacion _especializacion = new clsEspecializacion();
            return _especializacion.llenarCombo();
        }

        [HttpGet]
        [Route("llenartabla")]
        public List<ESPECIALIZACION> llenartabla()
        {
            clsEspecializacion _especializacion = new clsEspecializacion();
            return _especializacion.llenartablaespecializacion();
        }
    }
}