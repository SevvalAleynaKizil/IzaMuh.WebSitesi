﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class News
    {
        public int Id { get; set; }
        public string Newsname { get; set; } // haber adı
        public string Newsdetail { get; set; } // haber detayı
        
    }
}
