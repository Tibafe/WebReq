using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebReq_V1.Models
{
    [Table("Solicitante")]
    public class Solicitante
    {
        [Key]
  
        [Display(Name = "Código")]
        [Column("Id")]        
        public int Id { get; set; }

        [StringLength(150, ErrorMessage = "O tamanho máximo é de 150 Caracteres")]
        [Required(ErrorMessage = "Informe o nome do Solicitante")]        
        [Display(Name = "Nome do Solicitante")]
        [Column("Nome")]        
        public string Nome { get; set; }

        [StringLength(2, ErrorMessage = "O tamanho máximo é de 2 Caracteres")]
        [Required(ErrorMessage = "Informe o DDD")]
        [Display(Name = "DDD")]
        [Column("DDD")]
        public string Ddd { get; set; }

        [StringLength(9, MinimumLength = 8, ErrorMessage = "O tamanho mínimo é de 8 Caracteres e o máximo é de 9 Caracteres")]
        [Required(ErrorMessage = "Informe o nome numero do telefone")]
        [Display(Name = "Telefone")]
        [Column("Telefone")]        
        public string Telefone { get; set; }

        public List<Requisicao> Requisicoes { get; set; }


    }
}
