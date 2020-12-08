using RecomendacaoConsole.Models;
using SistemaDeRecomendacao.Models;
using SistemaDeRecomendacao.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RecomendacaoConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Carregando filmes...");

            var generosFavoritos = new List<Genero>();
            var filmesAssistidos = new List<Filme>();

            var catalogo = FilmeService.CarregarFilmes(@"C:\Users\anton\Downloads\filmes.xlsx");

            Console.WriteLine("Olá! Busque um filme por Nome:");
            var filmeNome = Console.ReadLine();

            var filme = FilmeService.BuscaPorNome(filmeNome, catalogo);

            if (filme == null) Console.WriteLine("Filme não encontrado!");
           
            FilmeService.PrintarFilme(filme);
            filmesAssistidos.Add(filme);

            Console.WriteLine("Você curtiu esse filme? [s/n]");
            var resposta = Console.ReadLine();

            if ( resposta == "s")
            {
                generosFavoritos = filme.Generos;
            }
            if (resposta == "n")
            {
                while (true)
                {
                    Console.WriteLine("Procure por outro filme:");
                    filmeNome = Console.ReadLine();
                    filme = FilmeService.BuscaPorNome(filmeNome, catalogo);

                    if (filme == null) Console.WriteLine("Filme não encontrado!");
                    
                    FilmeService.PrintarFilme(filme);
                    Console.WriteLine("Você curtiu esse filme? [s/n]");
                    resposta = Console.ReadLine();
                    generosFavoritos = filme.Generos;

                    if (resposta == "s") break;
                }
                
            }

            var recomendados = FilmeService.BuscarFilmesComEssesGeneros(generosFavoritos, catalogo).Where(f => f.Avaliacao > 40).ToList();

            var filmesPraExibir = new List<Filme>();

            var gerador = new Random();

            var valorInteiro = 1;

            for (int i = 0; i < 10; i++)
            {
                valorInteiro = gerador.Next(1, recomendados.Count());
                if (!filmesAssistidos.Contains(recomendados[valorInteiro]))
                {
                    filmesPraExibir.Add(recomendados[valorInteiro]);
                }
            }

            foreach (var ff in filmesPraExibir)
            {
                FilmeService.PrintarFilmeRecomendado(ff);
            }
                        
            Console.WriteLine("Finished");
        }
    }
}
