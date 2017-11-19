using Brevio___Beer_Experience.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Brevio___Beer_Experience.DAL
{
    public class FamiliaDAO
    {
        private static Context ctx = Singleton.Instance.Context;

        public static List<Familia> ListarFamilias()
        {
            return ctx.Famlias.ToList();
        }

        public static bool CadastrarFamilia(Familia familia)
        {
            try
            {
                ctx.Famlias.Add(familia);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static Familia BuscarFamiliaPorId(int? id)
        {
            return ctx.Famlias.Find(id);
        }

        public static bool RemoverFamilia(Familia familia)
        {
            try
            {
                ctx.Famlias.Remove(familia);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}