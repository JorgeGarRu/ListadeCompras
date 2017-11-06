namespace ListaDeCompras.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ListaCompraContext : DbContext
    {
        public ListaCompraContext()
            : base("name=ListaCompraContext")
        {
        }

        public virtual DbSet<ListaCompra> ListaCompra { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
