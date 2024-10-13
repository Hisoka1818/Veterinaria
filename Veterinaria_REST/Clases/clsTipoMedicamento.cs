using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Web;
using Veterinaria_REST.Models;

namespace Veterinaria_REST.Clases
{
    public class clsTipoMedicamento
    {
        private VETERINARIAPROJECTEntities dbSuper = new VETERINARIAPROJECTEntities();
        public TIPO_MEDICAMENTO tipoMedicamento { get; set; }

        public string Insertar()
        {
            try
            {
                dbSuper.TIPO_MEDICAMENTO.Add(tipoMedicamento);
                dbSuper.SaveChanges();
                return "El tipo de medicamento: " + tipoMedicamento.Nombre + " se guardo con exito";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public string Actualiar()
        {
            try
            {
                TIPO_MEDICAMENTO _tipoMedicamento = Consultar(tipoMedicamento.ID_TipoMedicamento);   
                if (_tipoMedicamento != null)
                {
                    dbSuper.TIPO_MEDICAMENTO.AddOrUpdate(tipoMedicamento);
                    dbSuper.SaveChanges();
                    return "El tipo de medicamento: " + tipoMedicamento.Nombre + " se actualizo con exito";
                }
                else
                {
                    return "El tipo de medicamento que quiere actualizar no se encuentra en la DB";
                }
                

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public TIPO_MEDICAMENTO Consultar(int id_tipoMed)
        {
            return dbSuper.TIPO_MEDICAMENTO.FirstOrDefault(t => t.ID_TipoMedicamento == id_tipoMed); 
        }

        public string Eliminar()
        {
            try
            {
                TIPO_MEDICAMENTO _tipoMedicamento = Consultar(tipoMedicamento.ID_TipoMedicamento);
                if (_tipoMedicamento != null)
                {
                    dbSuper.TIPO_MEDICAMENTO.Remove(tipoMedicamento);
                    dbSuper.SaveChanges();
                    return "El tipo de medicamento: " + tipoMedicamento.Nombre + " se elimino con exito";
                }
                else
                {
                    return "El tipo de medicamento no existe en la DB";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<TIPO_MEDICAMENTO> LlenarCombo()
        {
            return dbSuper.TIPO_MEDICAMENTO
                .OrderBy(t => t.Nombre)
                .ToList();
        }

    }
}