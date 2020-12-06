using SistemaDeRecomendacao.Services;
using System;

namespace SistemaDeRecomendacao
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Carregando filmes...");
            var catalogo = FilmeService.CarregarFilmes(@"C:\upload\Filmes.xlsx");
            
            
            Console.WriteLine("Sistema de recomendação");
        }
    }
}
