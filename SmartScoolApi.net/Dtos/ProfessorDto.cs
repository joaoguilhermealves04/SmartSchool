﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartScoolApi.net.Dtos
{
    public class ProfessorDto
    {
        public int Id { get; set; }
        public int Registro { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataMatricula { get; set; } 
        public DateTime? DataFim { get; set; } 
        public bool Ativo { get; set; } 
    }
}