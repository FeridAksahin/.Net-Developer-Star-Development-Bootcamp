﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YesilEv.Entity.Concrete.DTO
{
    public class BuAyKaraListeVeFavoriyeAlınanUrunlerDTO
    {
        public string Username { get; set; }
        public string ProductName { get; set; }
        public string SituationType { get; set; }
        public DateTime? Date { get; set; }
    }
}
