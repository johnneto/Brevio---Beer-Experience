using Brevio___Beer_Experience.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Brevio___Beer_Experience.DAL
{
    public class AvaliacaoDAO
    {
        private static Context ctx = Singleton.Instance.Context;

        public static List<Avaliacao> ListarAvaliacoes()
        {
            return ctx.Avaliacoes.ToList();
        }

        public static bool CadastrarAvaliacao(Avaliacao avaliacao)
        {
            try
            {
                ctx.Avaliacoes.Add(avaliacao);
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