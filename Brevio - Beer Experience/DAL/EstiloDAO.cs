using Brevio___Beer_Experience.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Brevio___Beer_Experience.DAL
{
    public class EstiloDAO
    {
        private static Context ctx = Singleton.Instance.Context;

        public static List<Estilo> ListarEstilos()
        {
            return ctx.Estilos.ToList();
        }

        public static bool CadastrarEstilo(Estilo estilo)
        {
            try
            {
                ctx.Estilos.Add(estilo);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static Estilo BuscarEstiloPorId(int? id)
        {
            return ctx.Estilos.Find(id);
        }
    }
}