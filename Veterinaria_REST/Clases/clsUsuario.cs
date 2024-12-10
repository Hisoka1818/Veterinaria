using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Veterinaria_REST.Models;

namespace Veterinaria_REST.Clases
{
    public class clsUsuario
    {
        private VETERINARIAPROJECTEntities dbSuper = new VETERINARIAPROJECTEntities();
        public USUARIO usuario { get; set; }
        public USUARIO_PERFIL usuarioPerfil { get; set; }
        public string Actualizar(int Perfil)
        {
            try
            {
                clsCypher cifrar = new clsCypher();
                cifrar.Password = usuario.Clave;
                if (cifrar.CifrarClave())
                {
                    //Se debe consultar el id del usuario y el id del usuario perfil
                    USUARIO _usuario = Consultar(usuario.ID_Propietario);
                    if (_usuario == null)
                    {
                        return "No existe el usuario";
                    }
                    usuario.ID_Usuario = _usuario.ID_Usuario;
                    usuario.Salt = cifrar.Salt;
                    usuario.Clave = cifrar.PasswordCifrado;
                    dbSuper.USUARIOs.AddOrUpdate(usuario);
                    dbSuper.SaveChanges();

                    //Agregar el perfil del usuario
                    usuarioPerfil = ConsultarUsuarioPerfil(usuario.ID_Usuario);
                    usuarioPerfil.ID_Usuario = usuario.ID_Usuario;
                    usuarioPerfil.ID_Perfil = Perfil;
                    usuarioPerfil.Activo = true;
                    dbSuper.USUARIO_PERFIL.AddOrUpdate(usuarioPerfil);
                    dbSuper.SaveChanges();

                    return "Se actualizó el usuario: " + usuario.userName;
                }
                else
                {
                    return "No pudo cifrar la clave.";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public USUARIO Consultar(Nullable<int> ID)
        {
            return dbSuper.USUARIOs.FirstOrDefault(U => U.ID_Propietario == ID);
        }


        public USUARIO_PERFIL ConsultarUsuarioPerfil(int idUsuario)
        {
            return dbSuper.USUARIO_PERFIL.FirstOrDefault(UP => UP.ID_Usuario == idUsuario);
        }
        public string Insertar(int idPerfil)
        {
            try
            {
                clsCypher cifrar = new clsCypher();
                cifrar.Password = usuario.Clave;
                if (cifrar.CifrarClave())
                {
                    usuario.Salt = cifrar.Salt;
                    usuario.Clave = cifrar.PasswordCifrado;
                    dbSuper.USUARIOs.Add(usuario);
                    dbSuper.SaveChanges();

                    //Agregar el perfil del usuario
                    usuarioPerfil = new USUARIO_PERFIL();
                    usuarioPerfil.ID_Usuario = usuario.ID_Usuario;
                    usuarioPerfil.ID_Perfil = idPerfil;
                    usuarioPerfil.Id_UsuarioPerfil = usuario.ID_Usuario;
                    usuarioPerfil.Activo = true;
                    dbSuper.USUARIO_PERFIL.Add(usuarioPerfil);
                    dbSuper.SaveChanges();

                    return "Se insertó el usuario: " + usuario.userName;
                }
                else
                {
                    return "No pudo cifrar la clave.";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Activar(int idUsuarioPerfil, bool Activo)
        {
            try
            {
                USUARIO_PERFIL usuario_Perfil = dbSuper.USUARIO_PERFIL.FirstOrDefault(u => u.Id_UsuarioPerfil == idUsuarioPerfil);
                if (usuario_Perfil != null)
                {
                    usuario_Perfil.Activo = Activo;
                    dbSuper.SaveChanges();
                    return "Se actualizó el estado del usario a " + (Activo ? "ACTIVO" : "INACTIVO");
                }
                return "El usuario no existe en la base de datos";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public IQueryable ListarUsuarios()
        {
            return from U in dbSuper.Set<USUARIO>()
                   join UP in dbSuper.Set<USUARIO_PERFIL>()
                   on U.ID_Usuario equals UP.ID_Usuario
                   join P in dbSuper.Set<PERFIL>()
                   on UP.ID_Perfil equals P.ID_Perfil
                   join Pr in dbSuper.Set<PROPIETARIO>()
                   on U.ID_Propietario equals Pr.ID_Propietario
                   select new
                   {
                       Editar = "<img src=\"../Paginas/Imagenes/Editar.png\"  style=\"cursor:grab;\" onclick=\"Editar('" + U.ID_Usuario + "', '" +
                                 Pr.ID_Propietario + "', '" + Pr.Nombre + " " + Pr.Apellido +
                                 "', '" + U.userName + "', '" + P.ID_Perfil + "', '" + UP.Id_UsuarioPerfil + "')\" />"
                                 + "&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"../Paginas/Imagenes/activarbtn.png\" onclick=\"Activar('" + UP.Id_UsuarioPerfil + "', " +
                                 (UP.Activo ? "false" : "true") + ", '" + U.userName + "')\"/>",
                       Propietario = Pr.ID_Propietario,
                       Nombre = Pr.Nombre,
                       Usuario = U.userName,
                       Perfil = P.Nombre,
                       Activo = UP.Activo ? "SI" : "NO"
                   };
        }
    }
}