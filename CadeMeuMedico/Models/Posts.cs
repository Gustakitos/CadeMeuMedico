using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadeMeuMedico.Models{
    public class Posts{
        public long PostID { get; set; }
        public string TituloPost { get; set; }
        public string ResumoPost { get; set; }
        public string ConteudoPost { get; set; }
        public DateTime DataPostagem { get; set; }
        public int CategoriaID { get; set; }
        [ForeignKey("CategoriaID")]
        public virtual Categorias Categorias { get; set; }

    }
}