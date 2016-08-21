﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrenchrRestService.Models
{
    public class Post
    {
        public int ID{ get; set; }
        public DateTime Time { get; set; }
        public long  AuthorId { get; set; }
        public string Text { get; set; }
        public string Type { get; set; }
    }
}
