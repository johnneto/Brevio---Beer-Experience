using Brevio___Beer_Experience.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Brevio___Beer_Experience.DAL
{
    public class CervejaDAO
    {
        private static Context ctx = Singleton.Instance.Context;

        public static List<Cerveja> ListarCervejas()
        {
            return ctx.Cervejas.ToList();
        }

        public static bool CadastrarCerveja(Cerveja cerveja)
        {
            try
            {
                ctx.Cervejas.Add(cerveja);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static Cerveja BuscarCervejaPorId(int? id)
        {
            return ctx.Cervejas.Find(id);
        }
       
    }
}