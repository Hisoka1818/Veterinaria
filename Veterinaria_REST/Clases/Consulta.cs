using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Veterinaria_REST.Models;


namespace vet.servicio.clases
{
    public class Consulta
    {
        private VETERINARIAPROJECTEntities dbSuper = new VETERINARIAPROJECTEntities();
        public CONSULTAMEDICA consulta {  get; set; }
        public string Insertar ()
        {
            try
            {
                dbSuper.CONSULTAMEDICAs.Add(consulta);
                dbSuper.SaveChanges();
                return " se inserto la consulta: "+consulta.ID_ConsultaMedica;
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
                dbSuper.CONSULTAMEDICAs.AddOrUpdate(consulta);
                dbSuper.SaveChanges();
                return " se actualizo la consulta: " + consulta.ID_ConsultaMedica;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public CONSULTAMEDICA consultar (int id) 
        {
            return dbSuper.CONSULTAMEDICAs.FirstOrDefault(x => x.ID_ConsultaMedica == id);
        }
        public string Eliminar() 
        {
            try
            {
                CONSULTAMEDICA _consulta = consultar(consulta.ID_ConsultaMedica);
                if (_consulta == null)
                {
                    return "el codigo de la consulta medica no existe";
                }
                else
                {
                    dbSuper.CONSULTAMEDICAs.Remove(_consulta);
                    dbSuper.SaveChanges();
                    return "se eliminaron los datos de la consulta: "+ consulta.ID_ConsultaMedica;
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public IQueryable Listarconsultas()
        {
            return from c in dbSuper.Set<CONSULTAMEDICA>()
                   join m in dbSuper.Set<MASCOTA>()
                   on c.ID_Mascota equals m.ID_Mascota
                   join v in dbSuper.Set<VETERINARIO>()
                   on c.ID_Veterinario equals v.ID_Veterinario
                   select new
                   {
                       codigoconsulta = c.ID_ConsultaMedica,
                       fechacita = c.Fecha_Cita,
                       estado = c.Estado,
                       veterinario = v.Nombre + " " + v.Apellido,
                       mascota = m.Nombre
                   };
        }
        public IQueryable Buscarmascota(int id)
        {
            return from m in dbSuper.Set<MASCOTA>()
                   where m.ID_Mascota == id
                   select new
                   {
                       nombre = m.Nombre
                   };
        }
        public IQueryable Listarveterinarios()
        {
            return from v in dbSuper.Set<VETERINARIO>()
                   orderby v.Nombre
                   select new
                   {
                       Codigo = v.ID_Veterinario,
                       Nombre = v.Nombre
                   };
        }
    }
}