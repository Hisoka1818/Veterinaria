using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Veterinaria_REST.Models;

namespace Veterinaria_REST.Clases
{
    public class clsCirugia
    {
        public VETERINARIAPROJECTEntities dbSuper = new VETERINARIAPROJECTEntities();
        public CIRUGIA Cirugia { get; set; }

        public IQueryable Consultar()
        {
            return from p in dbSuper.Set<CIRUGIA>()
                   orderby p.Descripcion
                   select p;
        }

        public IQueryable LlenarTabla()
        {
            return from h in dbSuper.Set<CIRUGIA>()
                   orderby h.Descripcion
                   select h;

        }

        public string Insertar()
        {
            try
            {
                CIRUGIA EntidadInsertada = dbSuper.CIRUGIAs.Add(Cirugia);
                dbSuper.SaveChanges();
                return $"Se grabó la cirugía con ID {EntidadInsertada.ID_Cirugia}";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public CIRUGIA ConsultarXId(int ID)
        {
            return dbSuper.CIRUGIAs.FirstOrDefault(h => h.ID_Cirugia == ID);
        }

        public string Actualizar()
        {
            try
            {
                CIRUGIA productoExistente = ConsultarXId(Cirugia.ID_Cirugia);
                if (productoExistente != null)
                {
                    dbSuper.CIRUGIAs.AddOrUpdate(Cirugia);
                    dbSuper.SaveChanges();
                    return $"Se actualizaron los datos de la cirugía con ID: {Cirugia.ID_Cirugia}";
                }
                else
                {
                    return $"La cirugía con ID {Cirugia.ID_Cirugia} no existe en la base de datos";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Eliminar()
        {
            try
            {
                CIRUGIA entidadExistente = ConsultarXId(Cirugia.ID_Cirugia);
                if (entidadExistente != null)
                {
                    dbSuper.CIRUGIAs.Remove(entidadExistente);
                    dbSuper.SaveChanges();
                    return $"Se eliminó la cirugía con ID: {entidadExistente.ID_Cirugia}"; ;
                }
                else
                {
                    return $"La cirugía con ID {Cirugia.ID_Cirugia} no existe en la base de datos";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}