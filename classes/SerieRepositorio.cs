using System;
using System.Collections.Generic;
using Super.Series.Interfaces;

namespace Super.Series 
{
    public class SerieRepositorio : IRepositori<Series>
    {
        private List<Series> listaSerie = new List<Series>();

        public void Atualiza(int id, Series objeto)
        {
            listaSerie[id] = objeto;
        }
        public void Exclui(int id)
        {
            listaSerie[id].Excluir();
        }
        public void Insere(Series objeto)
        {
            listaSerie.Add(objeto);
        }
        public List<Series> Lista()
        {
            return listaSerie;
        }
        public int ProximoId()
        {
            return listaSerie.Count;
        }

        public Series RetornaPorId(int id)
        {
            return listaSerie[id];
        }
    }
}