using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Veterinaria_REST.Models;

namespace Veterinaria_REST.Clases
{
    public class clsEspecie
    {
        public VETERINARIAPROJECTEntities dbSuper = new VETERINARIAPROJECTEntities();
        public ESPECIE especie { get; set; }

        public IQueryable LlenarCombo()
        {
            return from e in dbSuper.Set<ESPECIE>()
                   orderby e.Nombre
                   select new
                   {
                       Codigo = e.ID_Especie,
                       e.Nombre,
                   };
        }

        public IQueryable LlenarTabla()
        {
            return from e in dbSuper.Set<ESPECIE>()
                   orderby e.Nombre
                   select new
                   {
                       e.ID_Especie,
                       e.Nombre,
                       e.Descripcion,
                   };

        }

        public string Insertar()
        {
            try
            {
                ESPECIE especieInsertada = dbSuper.ESPECIEs.Add(especie);
                dbSuper.SaveChanges();
                return $"Se grabó la especie {especieInsertada.Nombre} con ID {especieInsertada.ID_Especie}";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public ESPECIE Consultar(int ID)
        {
            return dbSuper.ESPECIEs.FirstOrDefault(e => e.ID_Especie == ID);
        }

        public string Actualizar()
        {
            try
            {
                ESPECIE productoExistente = Consultar(especie.ID_Especie);
                if (productoExistente != null)
                {
                    dbSuper.ESPECIEs.AddOrUpdate(especie);
                    dbSuper.SaveChanges();
                    return $"Se actualizaron los datos de la especi con ID: {especie.ID_Especie}";
                }
                else
                {
                    return $"la especie con ID {especie.ID_Especie} no existe en la base de datos";
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
                ESPECIE especieExistente = Consultar(especie.ID_Especie);
                if (especieExistente != null)
                {
                    dbSuper.ESPECIEs.Remove(especieExistente);
                    dbSuper.SaveChanges();
                    return $"Se eliminó la especie con ID: {especieExistente.ID_Especie}"; ;
                }
                else
                {
                    return $"La especie con ID {especie.ID_Especie} no existe en la base de datos";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}