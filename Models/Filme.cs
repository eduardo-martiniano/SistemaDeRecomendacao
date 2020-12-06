using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaDeRecomendacao.Models
{
    public class Filme
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public List<Genero> Generos { get; set; }
        public float? Avaliacao { get; set; }
    }
}
