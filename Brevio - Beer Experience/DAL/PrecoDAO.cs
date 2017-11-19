using Brevio___Beer_Experience.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Brevio___Beer_Experience.DAL
{
    public class PrecoDAO
    {
        private static Context ctx = Singleton.Instance.Context;

        public static List<Preco> ListarPrecos()
        {
            return ctx.Precos.ToList();
        }

        public static bool CadastrarPreco(Preco preco)
        {
            try
            {
                ctx.Precos.Add(preco);
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