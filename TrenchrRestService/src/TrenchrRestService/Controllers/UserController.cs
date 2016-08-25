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
    public class UserController : ApiController
    {

        [Route("studenti")]
        [HttpGet]
        public IActionResult GetAllStudents()
        {

            var stmnt = "MATCH (s:student)-[:na_fakultetu]-(fakultet),(s:student)-[:na_smeru]-(smer)  return id(s) as id, s.ime as ime, s.prezime as prezime, s.generacija as generacija, s.email as email, s.indeks as indeks, s.putanja as slika, fakultet.name as fakultet, fakultet.university as univerzitet, smer.name as smer";
            var resultStudents = Neo4jClient.Execute(stmnt);
            var students = new List<Student>();
            foreach (var s in resultStudents)
                students.Add(new Student(s));

            return Ok(JsonConvert.SerializeObject(students, Formatting.Indented));

        }

        [Route("studenti/{id}")]
        [HttpGet]
        public IActionResult GetStudent(long id)
        {

            var stmnt = $"MATCH (s:student)-[:na_fakultetu]-(fakultet),(s:student)-[:na_smeru]-(smer) where id(s) = {id} return id(s) as id, s.ime as ime, s.prezime as prezime, s.generacija as generacija, s.email as email, s.indeks as indeks, s.putanja as slika, fakultet.name as fakultet, fakultet.university as univerzitet, smer.name as smer";
            var resultStudents = Neo4jClient.Execute(stmnt);
            var student = new Student(resultStudents.FirstOrDefault());

            return Ok(JsonConvert.SerializeObject(student, Formatting.Indented));

        }

        //za prikaz u post-u
        [Route("korisnici/{id}")]
        [HttpGet]
        public IActionResult vratiKorisnika(long id)
        {

            var stmnt = $"MATCH (a) where id(a) = {id} return id(a) as id, a.email as email, a.ime as ime, a.prezime as prezime, a.putanja as slika, labels(a) as oznaka";
            var resultUser = Neo4jClient.Execute(stmnt);
            var user = resultUser.FirstOrDefault();

            var o = user["oznaka"].ToString();


            if (o == "student")
            {
                var student = new Student(user);
                return Ok(JsonConvert.SerializeObject(student, Formatting.Indented));

            }

            else if (o == "asistent")
            {
                var asistent = new Assistant(user);
                return Ok(JsonConvert.SerializeObject(asistent, Formatting.Indented));
            }

            else
            {
                var profesor = new Professor(user);
                return Ok(JsonConvert.SerializeObject(profesor, Formatting.Indented));
            }

        } 
    }
}
