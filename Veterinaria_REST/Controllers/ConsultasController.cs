using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
//using System.Web.Mvc;
using vet.servicio.clases;
using Veterinaria_REST.Models;


namespace vet.servicio.Controllers
{
    [RoutePrefix("api/consultas")]
    [EnableCors(origins: "https://localhost:44322", headers: "*", methods: "*")]
    public class ConsultasController : ApiController
    {
        [HttpGet]
        [Route("consulta")]

        public CONSULTAMEDICA Consultar(int id)
        {
            Consulta consultar = new Consulta(); 
            return consultar.consultar(id);

        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody]CONSULTAMEDICA consultar )
        {
            Consulta _consulta = new Consulta();
            _consulta.consulta = consultar;
            return _consulta.Insertar();    
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] CONSULTAMEDICA consultar)
        {
            Consulta _consulta = new Consulta();
            _consulta.consulta = consultar;
            return _consulta.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] CONSULTAMEDICA consultar)
        {
            Consulta _consulta = new Consulta();
            _consulta.consulta = consultar;
            return _consulta.Eliminar();
        }

        [HttpGet]
        [Route("Listar")]
        public IQueryable Listar()
        {
            Consulta _consulta = new Consulta();
            return _consulta.Listarconsultas();
        }
        [HttpGet]
        [Route("Buscarmascota")]
        public IQueryable Buscarmascota(int id)
        {
            Consulta _consulta = new Consulta();
            return _consulta.Buscarmascota(id);
        }
        [HttpGet]
        [Route("Listarveterinarios")]
        public IQueryable Listarveterinarios()
        {
            Consulta _consulta = new Consulta();
            return _consulta.Listarveterinarios();
        }
    }
}