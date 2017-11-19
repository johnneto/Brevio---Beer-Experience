using Brevio___Beer_Experience.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Brevio___Beer_Experience.DAL
{
    public class CervejariaDAO
    {
        private static Context ctx = Singleton.Instance.Context;

        public static List<Cervejaria> ListarCervejarias()
        {
            return ctx.Cervejarias.ToList();
        }

        public static bool CadastrarCervejaria(Cervejaria cervejaria)
        {
            try
            {
                ctx.Cervejarias.Add(cervejaria);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static Cervejaria BuscarCervejariaPorId(int? id)
        {
            return ctx.Cervejarias.Find(id);
        }
    }
}