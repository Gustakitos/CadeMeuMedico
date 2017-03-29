using System.Collections.Generic;

namespace CadeMeuMedico.Models{
    public class Categorias{

        public int CategoriaID { get; set; }
        public string Categoria { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<Posts> Posts { get; set;}
    }
}