﻿using Neo4j.Driver.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrenchrRestService.Models
{
    public class Results : Post
    {
       
        public string Path { get; set; }

        public Results() { }

        public Results(IRecord record)
        {
            Path = (string)record["putanja"];
            ID = (long)record["id"];
            CourseID = (long)record["kurs_id"];
            Type = (string)record["tip"];
            Text = (string)record["tekst"];
            Important = (string)record["indikator"];
            Time = (long)record["vreme"];
            UserId = (long)record["korisnik_id"];
            AuthorInfo = (string)record["ime_korisnika"];
            PicturePath = (string)record["putanja_korisnika"];
        }

        public long SacuvajRezultate()
        {
            var stmnt = "MATCH (ok:odrzan_kurs), (autor) " +
                        $"WHERE id(ok) = {CourseID} AND id(autor) = {UserId} " +
                        " WITH ok,autor " +
                        "CREATE (ok)-[:ima_post]->(o:rezultati{" +
                        $" tekst : '{Text}', " +
                        $" tip : '{Type}', " +
                        $" ind :' {Important}', " +
                        $" vreme : {Time}, " +
                        $" putanja : '{Path}'" +
                        "})<-[:objavio]-(autor) RETURN id(o) as id";

            var result = Neo4jClient.Execute(stmnt);
            return (long)result.FirstOrDefault()["id"];
        }
    }
}
