using Microsoft.EntityFrameworkCore;
using WebReq_V1.Models;
using WebReq_V1.Context;

namespace WebReq_V1.Context
    {
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)

        {
        }
        public DbSet<WebReq_V1.Models.Cliente> Cliente { get; set; }
        public DbSet<WebReq_V1.Models.Solicitante> Solicitante { get; set; }
        public DbSet<WebReq_V1.Models.Produto> Produto { get; set; }
        public DbSet<WebReq_V1.Models.Requisicao> Requisicao { get; set; }

    }

}
