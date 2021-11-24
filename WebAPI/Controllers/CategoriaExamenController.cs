﻿using Aplicacion.CategoriaExamen;
using Dominio.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaExamenController : MiControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<List<TblCatCategoriaExamenes>>> Get()
        {
            return await Mediator.Send(new Consulta.Ejecuta());
        }
    }
}
