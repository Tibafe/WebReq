using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace WebReq_V1.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        [Column("Id")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [StringLength(150, ErrorMessage = "O tamanho máximo é de 150 Caracteres")]
        [Required(ErrorMessage = "Informe o nome do Cliente")]
        [Display(Name = "Nome do Cliente")]
        [Column("Nome")]
        public string Nome { get; set; }

        [StringLength(100, ErrorMessage = "O tamanho máximo é de 100 Caracteres")]
        [Required(ErrorMessage = "Informe o endereço do Cliente")]
        [Display(Name = "Endereço")]
        [Column("Endereco")]
        public string Endereco { get; set; }

        [StringLength(50, ErrorMessage = "O tamanho máximo é de 50 Caracteres")]
        [Required(ErrorMessage = "Informe o municipio do Cliente")]
        [Display(Name = "Município")]
        [Column("Municipio")]
        public string Municipio { get; set; }

        [StringLength(2, ErrorMessage = "O tamanho máximo é de 2 Caracteres")]
        [Required(ErrorMessage = "Informe o Estado do Cliente")]
        [Display(Name = "Estado")]
        [Column("Estado")]
        public String Estado { get; set; }

        public List<Requisicao> Requisicoes { get; set; }

    }
}