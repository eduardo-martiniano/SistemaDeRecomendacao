using ClosedXML.Excel;
using SistemaDeRecomendacao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaDeRecomendacao.Services
{
    public class FilmeService
    {
        public static List<Filme> CarregarFilmes(string path)
        {
            var wb = new XLWorkbook(path);
            var planilha = wb.Worksheet(1);
            var generos = new List<Genero>();
            var filmes = new List<Filme>();

            var linha = 2;

            while (true)
            {
                var filmeId = planilha.Cell("A" + linha.ToString()).Value.ToString();
                var titulo = planilha.Cell("B" + linha.ToString()).Value.ToString();
                var txtgeneros = planilha.Cell("C" + linha.ToString()).Value.ToString().Split("|");
                var nota = planilha.Cell("D" + linha.ToString()).Value.ToString();

                if (string.IsNullOrEmpty(filmeId)) break;

                foreach (var item in txtgeneros)
                {
                    generos.Add(new Genero { Nome = item });
                }

                filmes.Add(new Filme
                {
                    Id = Convert.ToInt32(filmeId),
                    Titulo = titulo,
                    Avaliacao = float.Parse(nota),
                    Generos = generos
                });

                generos = new List<Genero>();

                linha++;
            }
            return filmes;
        }
    }
}
