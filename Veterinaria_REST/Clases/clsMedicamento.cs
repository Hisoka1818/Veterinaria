using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Veterinaria_REST.Models;

namespace Veterinaria_REST.Clases
{
    public class clsMedicamento
    {
        private VETERINARIAPROJECTEntities dbSuper = new VETERINARIAPROJECTEntities();
        public MEDICAMENTO medicamento { get; set; }

        public string Insertar()
        {
            try
            {
                dbSuper.MEDICAMENTOes.Add(medicamento);
                dbSuper.SaveChanges();
                return "Se grabo el medicamento: " + medicamento.Nombre + " correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }   
        }

        public string Actualizar()
        {
            try
            {
                MEDICAMENTO _medicamento = Consultar(medicamento.ID_Medicamento);
                if (_medicamento != null)
                {
                    dbSuper.MEDICAMENTOes.AddOrUpdate(medicamento);
                    dbSuper.SaveChanges();
                    return "Se actualizo el medicamento: " + medicamento.Nombre + " correctamente";
                }
                else
                {
                    return "El medicamento que se quiere actualizar no existe en la DB";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public MEDICAMENTO Consultar(int id_medicamento)
        {
            return dbSuper.MEDICAMENTOes.FirstOrDefault(m => m.ID_Medicamento == id_medicamento);
        }

        public string Eliminar()
        {
            try
            {
                MEDICAMENTO _medicamento = Consultar(medicamento.ID_Medicamento);
                if (_medicamento != null)
                {
                    dbSuper.MEDICAMENTOes.Remove(_medicamento);
                    dbSuper.SaveChanges();
                    return "Se elimino el medicamento: " + medicamento.Nombre + " correctamente";
                }
                else
                {
                    return "El medicamento no existe en la DB";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public IQueryable LlenarTabla()
        {

            return from m in dbSuper.Set<MEDICAMENTO>()
                   join t in dbSuper.Set<TIPO_MEDICAMENTO>()
                   on m.ID_TipoMedicamento equals t.ID_TipoMedicamento
                   select new
                   {
                       Id_Medicamento = m.ID_Medicamento,
                       Nombre_Medicamento = m.Nombre,
                       Descripcion_Medicamento = m.Descripcion,
                       Dosis_Medicamento = m.Dosis,
                       Stock_Medicamento = m.Stock,
                       Precio_Unidad = m.Precio,
                       Id_Tipo_Medicamento = t.ID_TipoMedicamento,
                       NombreTipo = t.Nombre,
                       DescripcionTipo = t.Descripcion,
                   };                       
        }
    }
}