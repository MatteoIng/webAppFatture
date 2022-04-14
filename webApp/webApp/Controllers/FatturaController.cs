using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApp.Models;
using webApp.Repositorys;

namespace webApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FatturaController : Controller
    {
        public IFatturaRepository fatturaRepository;

        public FatturaController(IFatturaRepository repo)
        {
            fatturaRepository = repo;
        }



        [HttpPost("saveFattura")]
        public IActionResult saveFattura([FromBody]Fattura fattura)
        {
            this.fatturaRepository.save(fattura);
            return Json(this.fatturaRepository.getAll());
        }



        [HttpDelete("deleteFattura/{id}")]
        public IActionResult deleteFattura([FromRoute] long id)
        {
            Fattura fatturaFound = this.fatturaRepository.getById(id);
            this.fatturaRepository.datele(fatturaFound);
            return Json(this.fatturaRepository.getAll());
        }



        [HttpGet("getAllFatture")]
        public IActionResult getAllFatture()
        {
            return Json(this.fatturaRepository.getAll());
        }


        [HttpGet("getFattura/{id}")]
        public IActionResult getFattura([FromRoute]long id)
        {
            return Json(this.fatturaRepository.getById(id));
        }


        [HttpPut("updateFattura")]
        public IActionResult updateFattura([FromBody]Fattura fattura)
        {
            this.fatturaRepository.update(fattura);
            return Json(this.fatturaRepository.getAll());
        }


        [HttpGet("findFatture/{numeroFattura}/{dataFattura}/{dataRicezione}")]
        public IActionResult findFatture([FromRoute]string numeroFattura,
                                            [FromRoute]string dataFattura,
                                            [FromRoute]string dataRicezione)
        {
            DateTime dataFatt;
            DateTime dataRic;
            IQueryable<Fattura> result=null;


            if (!numeroFattura.Equals("null"))
            {
                if (!dataFattura.Equals("null"))
                {
                    if (!dataRicezione.Equals("null"))
                    {
                        dataFatt = Convert.ToDateTime(dataFattura);
                        dataRic = Convert.ToDateTime(dataRicezione);
                        //query con tutti e tre
                        result = this.fatturaRepository.getByNumFattDatFattFatRic(numeroFattura, dataFatt, dataRic);
                    }
                    else
                    {
                        dataFatt = Convert.ToDateTime(dataFattura);
                        //query con primi 2
                        result = this.fatturaRepository.getByNumFattDatFatt(numeroFattura, dataFatt);
                    }
                }
                else
                {
                    if(!dataRicezione.Equals("null"))
                    {
                        dataRic = Convert.ToDateTime(dataRicezione);
                        //query con 1 e 3
                        result = this.fatturaRepository.getByNumFattDatRic(numeroFattura, dataRic);
                    }
                    else
                    {
                        //query solo il 1
                        result = this.fatturaRepository.getByNumeroFattura(numeroFattura);
                    }
                }
            }
            else
            {
                if (!dataFattura.Equals("null"))
                {
                    if (!dataRicezione.Equals("null"))
                    {
                        dataFatt = Convert.ToDateTime(dataFattura);
                        dataRic = Convert.ToDateTime(dataRicezione);
                        //query con questi 2
                        result = this.fatturaRepository.getByDatFattDatRic(dataFatt, dataRic);
                    }
                    else
                    {
                        dataFatt = Convert.ToDateTime(dataFattura);
                        //query solo col 2
                        result = this.fatturaRepository.getByDataFattura(dataFatt);
                    }
                }
                else
                {
                    if (!dataRicezione.Equals("null"))
                    {
                        dataRic = Convert.ToDateTime(dataRicezione);
                        //query solo col 3
                        result = this.fatturaRepository.getByDataRicezione(dataRic);
                    }
                    else
                    {
                        //nessuno può allora tornano tutti non sta cercando veramente
                       result = this.fatturaRepository.getAll();
                    }
                }
            }

            return Json(result);
        }
    }
}
