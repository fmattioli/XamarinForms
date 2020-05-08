using System;
using System.Collections.Generic;
using System.Text;
using Mimica.Model;
namespace Mimica.Storage
{
    public class Storage
    {
        public static Jogo Jogo { get; set; }
        public static short RodadaAtual { get; set; }
        public static string[][] palavras =
        {
            //FACEIS
            new string[] {"Olho", "Lingua", "Tenis", "Chinelo", "Penalti", "Bola", "Sapato"},
            
            //MEDIO
            new string[] {"Carpinteiro", "Dentista", "Azul", "Roxo", "Limão", "Abelha", "Corinthians"},
            
            //DIF
            new string[] {"Mosquito", "Cisterna", "Lampada", "Estádio", "Programa", "SuperMan", "SuperHeroi"},
           
        };
    }
}
