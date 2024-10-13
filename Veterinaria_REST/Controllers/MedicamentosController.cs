using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Veterinaria_REST.Clases;
using Veterinaria_REST.Models;

namespace Veterinaria_REST.Controllers
{
    public class MedicamentosController : ApiController
    {
        [HttpGet]
        [Route("ConsultarxCodigo")]
        public MEDICAMENTO ConsultarxCodigo(int id_medi)
        {
            clsMedicamento medicamento = new clsMedicamento();
            return medicamento.Consultar(id_medi);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] MEDICAMENTO Medicamento)
        {
            clsMedicamento medicamento = new clsMedicamento();
            medicamento.medicamento = Medicamento;
            return medicamento.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] MEDICAMENTO Medicamento)
        {
            clsMedicamento medicamento = new clsMedicamento();
            medicamento.medicamento = Medicamento;
            return medicamento.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] MEDICAMENTO Medicamento)
        {
            clsMedicamento medicamento = new clsMedicamento();
            medicamento.medicamento = Medicamento;
            return medicamento.Eliminar();
        }

        [HttpGet]
        [Route("LlenarTabla")]
        public IQueryable LlenarTabla()
        {
            clsMedicamento medicamento = new clsMedicamento();
            return medicamento.LlenarTabla();
        }
    }
}