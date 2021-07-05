﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Alerta
    {
        public string Id { get; set; }

        public Ponto Ponto { get; set; }

        public Distrito Distrito { get; set; }

        public DateTime Tempo { get; set; }

        public string Descricao { get; set; }

        public bool Transitividade { get; set; }

        public bool Atividade { get; set; }
    }
}
