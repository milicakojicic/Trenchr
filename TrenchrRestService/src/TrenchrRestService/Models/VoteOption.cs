﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrenchrRestService.Models
{
    public class VoteOption
    {
        public string Text { get; set; }
        public List<Student> VotedFor { get; set; }
    }
}