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

            
            /*
            if (numeroFattura != null)
            {
                if (dataFattura != null)
                {
                    if (dataRicezione != null)
                    {
                        dataFatt = Convert.ToDateTime(dataFattura);
                        dataRic = Convert.ToDateTime(dataRicezione);
                        //query con tutti e tre
                        result=this.fatturaRepository.getByNumFattDatFattFatRic(numeroFattura,dataFatt,da)
                    }
                    else
                    {
                        dataFatt = Convert.ToDateTime(dataFattura);
                        //query con primi 2
                    }
                }
                else
                {
                    result = this.fatturaRepository.getByNumeroFattura(numeroFattura);
                }
            }
            else
            {
                if (dataFattura != null)
                {
                    if (dataRicezione != null)
                    {
                        dataFatt = Convert.ToDateTime(dataFattura);
                        dataRic = Convert.ToDateTime(dataRicezione);
                        //query con questi 2
                    }
                }
                else
                {
                    if (dataRicezione != null)
                    {

                        dataRic = Convert.ToDateTime(dataRicezione);
                        result = this.fatturaRepository.getByDataRicezione(dataRic);
                    }
                    else
                    {
                       result = this.fatturaRepository.getAll();
                    }
                }
            }

            */
            return Json(result);
        }
    }
}
