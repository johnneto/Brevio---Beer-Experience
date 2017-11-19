using Brevio___Beer_Experience.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Brevio___Beer_Experience.DAL
{
    public class UsuarioDAO
    {
        private static Context ctx = Singleton.Instance.Context;

        public static List<Usuario> ListarUsuarios()
        {
            return ctx.Usuarios.ToList();
        }

        public static bool CadastrarUsuario(Usuario usuario)
        {
            try
            {
                ctx.Usuarios.Add(usuario);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static Usuario BuscarUsuarioPorEmail(String email)
        {
            return ctx.Usuarios.FirstOrDefault(x => x.Email.Equals(email));
        }

        public static Usuario BuscarUsuarioPorEmailSenha(Usuario usuario)
        {
            return ctx.Usuarios.
                FirstOrDefault(x => x.Email.Equals(usuario.Email) &&
                x.Senha.Equals(usuario.Senha));
        }

        public static Usuario BuscarUsuarioPorId(int? id)
        {
            return ctx.Usuarios.Find(id);
        }

        public static bool RemoverUsuario(Usuario usuario)
        {
            try
            {
                ctx.Usuarios.Remove(usuario);
                ctx.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

     }
}