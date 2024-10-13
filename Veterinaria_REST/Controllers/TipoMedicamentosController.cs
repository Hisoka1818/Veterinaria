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
    public class TipoMedicamentosController : ApiController
    {
        //[HttpGet]
        //[Route("ConsultarxCodigo")]
        //public TIPO_MEDICAMENTO ConsultarxCodigo(int id_tipoMed)
        //{
        //    clsTipoMedicamento tipoMedicamento = new clsTipoMedicamento();
        //    return tipoMedicamento.Consultar(id_tipoMed);
        //}

        //[HttpPost]
        //[Route("Insertar")]
        //public string Insertar([FromBody] TIPO_MEDICAMENTO TipoMedicamento)
        //{
        //    clsTipoMedicamento tipoMedicamento = new clsTipoMedicamento();
        //    tipoMedicamento.tipoMedicamento = TipoMedicamento;
        //    return tipoMedicamento.Insertar();
        //}

        //[HttpPut]
        //[Route("Actualizar")]
        //public string Actualizar([FromBody] TIPO_MEDICAMENTO TipoMedicamento)
        //{
        //    clsTipoMedicamento tipoMedicamento = new clsTipoMedicamento();
        //    tipoMedicamento.tipoMedicamento = TipoMedicamento;
        //    return tipoMedicamento.Actualiar();
        //}

        //[HttpDelete]
        //[Route("Eliminar")]
        //public string Eliminar([FromBody] TIPO_MEDICAMENTO TipoMedicamento)
        //{
        //    clsTipoMedicamento tipoMedicamento = new clsTipoMedicamento();
        //    tipoMedicamento.tipoMedicamento = TipoMedicamento;
        //    return tipoMedicamento.Eliminar();
        //}

        [HttpGet]
        [Route("LlenarCombo")]
        public List<TIPO_MEDICAMENTO> LlenarCombo()
        {
            clsTipoMedicamento tipoMedicamento = new clsTipoMedicamento();
            return tipoMedicamento.LlenarCombo();
        }
    }
}