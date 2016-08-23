﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using TrenchrRestService;
using TrenchrRestService.Models;

namespace TrenchrRestService.Controllers
{
    [Route("kursevi")]
    public class HeldCourseController : ApiController
    {

        [HttpGet]
        public IActionResult GetAllGroups()
        {
            var stmnt = "MATCH (o:odrzan_kurs) return id(o) as id, o.name as name, o.espb as espb, o.tip as tip, o.nivo as nivo, o.godina as godina";
            var resultCourses = Neo4jClient.Execute(stmnt);
            var courses = new List<HeldCourse>();
            foreach (var o in resultCourses)
                courses.Add(new HeldCourse(o));

            return Ok(JsonConvert.SerializeObject(courses, Formatting.Indented));
        }

    }
}