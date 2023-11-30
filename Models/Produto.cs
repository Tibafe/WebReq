using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace WebReq_V1.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public int Id {get; set;}

        [StringLength(200, ErrorMessage ="O tamanho máximo é de 200 Caracteres")]
        [Required(ErrorMessage ="Informe o nome do produto")]
        [Display(Name = "Nome do produto")]
        public string Nome {get; set;}

        public List<Requisicao> Requisicoes { get; set; }

    }
}