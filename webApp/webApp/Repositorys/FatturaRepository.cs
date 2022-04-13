using CarEBike.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApp.Models;

namespace webApp.Repositorys
{
    public class FatturaRepository : IFatturaRepository
    {
        public StoreDbContext dbContext;

        public FatturaRepository(StoreDbContext context)
        {
            dbContext = context;
        }

        public void datele(Fattura fattura)
        {
            this.dbContext.Remove(fattura);
            this.dbContext.SaveChanges();
        }

        public IQueryable<Fattura> getAll()
        {
            return this.dbContext.fatture;
        }

        public IQueryable<Fattura> getByDataFattura(DateTime dataFattura)
        {
            return this.dbContext.fatture.Where(f => f.dataFattura == dataFattura);
        }

        public IQueryable<Fattura> getByDataRicezione(DateTime dataRicezione)
        {
            return this.dbContext.fatture.Where(f => f.dataRicezione == dataRicezione);
        }

        public IQueryable<Fattura> getByDatFattDatRic(DateTime dataFattura, DateTime dataRicezione)
        {
            return this.dbContext.fatture.Where(f => f.dataFattura == dataFattura && f.dataRicezione == dataRicezione);
        }

        public Fattura getById(long id)
        {
            return this.dbContext.fatture.Where(f => f.id == id).FirstOrDefault();
        }

        public IQueryable<Fattura> getByNumeroFattura(string numeroFattura)
        {
            return this.dbContext.fatture.Where(f => f.numeroFattura == numeroFattura);
        }

        public IQueryable<Fattura> getByNumFattDatFatt(string numeroFattura, DateTime dataFattura)
        {
            return this.dbContext.fatture.Where(f => f.numeroFattura == numeroFattura && f.dataFattura == dataFattura);
        }

        public IQueryable<Fattura> getByNumFattDatFattFatRic(string numeroFattura, DateTime dataFattura, DateTime dataRicezione)
        {
            return this.dbContext.fatture.Where(f => f.numeroFattura == numeroFattura && f.dataFattura == dataFattura && f.dataRicezione == dataRicezione);
        }

        public IQueryable<Fattura> getByNumFattDatRic(string numeroFattura, DateTime dataRicezione)
        {
            return this.dbContext.fatture.Where(f => f.numeroFattura == numeroFattura && f.dataRicezione == dataRicezione);
        }

        public void save(Fattura fattura)
        {
            this.dbContext.fatture.Add(fattura);
            this.dbContext.SaveChanges();
        }

        public void update(Fattura fattura)
        {
            this.dbContext.fatture.Update(fattura);
            this.dbContext.SaveChanges();
        }
    }
}
