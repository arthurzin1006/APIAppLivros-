namespace LivrosAPI.Models
{
    public class Livros
    {
        public int Id { get; set; }
        public string Titulo { get; set; }

        public string Autor { get; set; }

        public int AnoPublic { get; set; }
        public string Genero { get; set; }

        public int NumeroPag { get; set; }

        public bool? Ativo { get; set; }

    }
}
