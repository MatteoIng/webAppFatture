using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApp.Models;

namespace webApp.Repositorys
{
    public interface IFatturaRepository
    {
        public void save(Fattura fattura);
        public void update(Fattura fattura);
        public void datele(Fattura fattura);
        public IQueryable<Fattura> getAll();
        public Fattura getById(long id);
        public IQueryable<Fattura> getByNumeroFattura(string numeroFattura);
        public IQueryable<Fattura> getByDataFattura(DateTime dataFattura);
        public IQueryable<Fattura> getByDataRicezione(DateTime dataRicezione);
        public IQueryable<Fattura> getByNumFattDatFattFatRic(string numeroFattura, DateTime dataFattura, DateTime dataRicezione);
        public IQueryable<Fattura> getByNumFattDatFatt(string numeroFattura, DateTime dataFattura);
        public IQueryable<Fattura> getByDatFattDatRic(DateTime dataFattura, DateTime dataRicezione);
        public IQueryable<Fattura> getByNumFattDatRic(string numeroFattura, DateTime dataRicezione);
    }
}
