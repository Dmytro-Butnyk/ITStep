﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_5.Models.Products
{
    public class Book : Product
    {
        public string Genre { get; set; }
        public int Pages { get; set; }
    }
}
