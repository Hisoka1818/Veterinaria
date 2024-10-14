using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Veterinaria_REST.Models;

namespace Veterinaria_REST.Clases
{
    public class clsEspecializacion
    {
        private VETERINARIAPROJECTEntities DBSuper = new VETERINARIAPROJECTEntities();
        public ESPECIALIZACION especializacion { get; set; }

        public string Insertar()
        {
            try
            {
                DBSuper.ESPECIALIZACIONs.Add(especializacion);
                DBSuper.SaveChanges();
                return "se inserto la especializacion: " + especializacion.Nombre;
            }
            catch (Exception e)
            {

                return e.Message;
            }
        }
        public string Actualizar()
        {
            try
            {
                DBSuper.ESPECIALIZACIONs.AddOrUpdate(especializacion);
                DBSuper.SaveChanges();
                return "se actualizo la especializacion: " + especializacion.Nombre;
            }
            catch (Exception e)
            {

                return e.Message;
            }
        }
        public ESPECIALIZACION Consultar(int codigo)
        {
            return DBSuper.ESPECIALIZACIONs.FirstOrDefault(e => e.ID_Especializacion == codigo);
        }
        public string Eliminar()
        {
            try
            {
                ESPECIALIZACION _especializacion = Consultar(especializacion.ID_Especializacion);

                if (_especializacion == null)
                {
                    return "el codigo de la especializacion no existe";
                }

                DBSuper.ESPECIALIZACIONs.Remove(_especializacion);
                DBSuper.SaveChanges();
                return "se elimino la especialiacion " + especializacion.Nombre;
            }
            catch (Exception e)
            {

                return e.Message;
            }
        }
        public IQueryable LlenarCombo()
        {
            return from C in DBSuper.Set<ESPECIALIZACION>()
                   orderby C.Nombre
                   select new
                   {
                       Codigo = C.ID_Especializacion,
                       Nombre = C.Nombre
                   };
        }
        public IQueryable LlenarTabla()
        {
            return from e in DBSuper.Set<ESPECIALIZACION>()
                   select new
                   {
                       ID_Especializacion = e.ID_Especializacion,
                       Nombre = e.Nombre,
                       Descripcion = e.Descripcion,
                   };
        }
    }
}