﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPCleanArchitecture.Domain
{
    public class Review
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int CustomerId { get; set; }
        public string Comment { get; set; }
        public double Rating { get; set; }
    }
}
