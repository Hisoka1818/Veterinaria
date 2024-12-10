using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Veterinaria_REST.Models;

namespace Veterinaria_REST.Clases
{
    public class clsLogin
    {
        public clsLogin()
        {
            loginRespuesta = new LoginRespuesta();
        }
        public VETERINARIAPROJECTEntities dbSuper = new VETERINARIAPROJECTEntities();
        public Login login { get; set; }
        public LoginRespuesta loginRespuesta { get; set; }
        public bool ValidarUsuario()
        {
            try
            {
                clsCypher cifrar = new clsCypher();
                USUARIO usuario = dbSuper.USUARIOs.FirstOrDefault(u => u.userName == login.Usuario);
                if (usuario == null)
                {
                    loginRespuesta.Autenticado = false;
                    loginRespuesta.Mensaje = "Usuario no existe";
                    return false;
                }
                byte[] arrBytesSalt = Convert.FromBase64String(usuario.Salt);
                string ClaveCifrada = cifrar.HashPassword(login.Clave, arrBytesSalt);
                login.Clave = ClaveCifrada;
                return true;
            }
            catch (Exception ex)
            {
                loginRespuesta.Autenticado = false;
                loginRespuesta.Mensaje = ex.Message;
                return false;
            }
        }
        public IQueryable<LoginRespuesta> Ingresar()
        {
            if (ValidarUsuario())
            {
                string token = TokenGenerator.GenerateTokenJwt(login.Usuario);
                return from U in dbSuper.Set<USUARIO>()
                       join UP in dbSuper.Set<USUARIO_PERFIL>()
                       on U.ID_Usuario equals UP.ID_Usuario
                       join P in dbSuper.Set<PERFIL>()
                       on UP.ID_Perfil equals P.ID_Perfil
                       where U.userName == login.Usuario &&
                             U.Clave == login.Clave
                       select new LoginRespuesta
                       {
                           Usuario = U.userName,
                           Autenticado = true,
                           Perfil = P.Nombre,
                           PaginaInicio = P.PaginaNavegar,
                           Token = token,
                           Mensaje = ""
                       };
            }
            else
            {
                //return (IQueryable<LoginRespuesta>)loginRespuesta;
                return null;
            }
        }
    }
}