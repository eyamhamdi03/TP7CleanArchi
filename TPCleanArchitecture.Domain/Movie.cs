﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
namespace TPCleanArchitecture.Domain
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        [JsonIgnore]

        public List<Customer> Customers { get; set; } = new List<Customer>();

    }
}