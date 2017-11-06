namespace ListaDeCompras.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("ListaCompra")]
    public partial class ListaCompra
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string producto { get; set; }

        public bool comprado { get; set; }
             

        //metodos

        public static List<ListaCompra> listar()//metodo para listar la tabla de lista de compras
        {

            List<ListaCompra> compra = new List<ListaCompra>();

            try
            {
                ListaCompraContext context = new ListaCompraContext();
                compra = context.ListaCompra.ToList();//en la lista compra, metemos la lista de la tabla
            }
            catch (Exception e)
            {

                throw;
            }

            return compra;

            }

        public static ListaCompra DevuelveProducto(int id)
        {
            ListaCompra compra = null;

            try
            {
                ListaCompraContext context = new ListaCompraContext();
               compra = context.ListaCompra.Where(x => x.id == id).SingleOrDefault();//devolvemos la compra donde la id dada sea igual
            }
            catch (Exception e)
            {
                throw;
            }
            return compra;
        }

        public void Guardar()
        {
            bool crear = this.id == 0;//sera verdadero cuando la id sea 0
            try
            {
                ListaCompraContext context = new ListaCompraContext(); //creamos el contexto
                if (crear)//si se cumple crear(Su id es 0, por lo tanto es nuevo)
                {
                    context.Entry(this).State = System.Data.Entity.EntityState.Added;//añadimos el producto
                }
                else//sino...
                {
                    context.Entry(this).State = System.Data.Entity.EntityState.Modified;//modificamos el producto
                }

                context.SaveChanges(); //lo guardamos
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
