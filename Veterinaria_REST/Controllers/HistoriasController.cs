using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using vet.servicio.clases;
using Veterinaria_REST.Models;


namespace vet.servicio.Controllers
{
    [RoutePrefix("api/historias")]
    [EnableCors(origins: "https://localhost:44322", headers: "*", methods: "*")]
    public class HistoriasController : ApiController
    {
        [HttpGet]
        [Route("consulta")]

        public HISTORIA_MEDICA Consultar(int id)
        {
            clsHistorial historial = new clsHistorial();
            return historial.consultar(id);

        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] HISTORIA_MEDICA historial)
        {
            clsHistorial _historial = new clsHistorial();
            _historial.historia = historial;
            return _historial.Insertar();
        }
        [HttpGet]
        [Route("Listar")]

        public IQueryable Listar()
        {
            clsHistorial _historial = new clsHistorial();
            return _historial.Listar();
        }
    }
}