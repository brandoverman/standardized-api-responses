﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brandoverman.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            throw new ApiException(ExceptionMessages.CustomErrorResponse, null);
        }
    }
}
