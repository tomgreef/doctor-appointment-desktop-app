﻿using Dapper.Contrib.Extensions;
using System;

namespace GiDapper
{
    public class Eye
    {
        public int ID { get; set; }
        public string NIF { get; set; }
        public DateTime Consulta { get; set; }
        public double OdEsfera { get; set; }
        public double OdCilindro { get; set; }
        public double OdAdicion { get; set; }
        public double OdAgudeza { get; set; }
        public double OiEsfera { get; set; }
        public double OiCilindro { get; set; }
        public double OiAdicion { get; set; }
        public double OiAgudeza { get; set; }
    }
}