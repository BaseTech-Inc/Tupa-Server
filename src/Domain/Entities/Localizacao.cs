﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Localizacao
    {
        public string Id { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}
