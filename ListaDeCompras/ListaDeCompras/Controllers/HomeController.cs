using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ListaDeCompras;

namespace ListaDeCompras.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()//pagina de inicio
        {
            List<Models.ListaCompra> compras = Models.ListaCompra.listar();//en la variable compras, le pasamos el metodo listar, creado en "listaCompra.cs"
            return View(compras);//y lo metemos en el return
        }

        public ActionResult Ver(int id)//pagina de vista de un producto
        {
            Models.ListaCompra producto = Models.ListaCompra.DevuelveProducto(id);//metemos en la variable producto, el producto que tenga la id dada
            if (producto != null)//si el producto no es nulo...
            {
                return View(producto);//devolvemos el producto
            }
            else//sino...
            {
                return View("~/Views/Home/Index/");//redireccionamos a la pagina de inicio
            }

        }

        public ActionResult Crear()//pagina de creacion de un producto
        {
            Models.ListaCompra producto = new Models.ListaCompra();
            return View("~/Views/Home/ListaComprasForm.cshtml",producto);
        }

        public ActionResult Modificar(int id = 0)
        {
            Models.ListaCompra producto = Models.ListaCompra.DevuelveProducto(id);

            if (producto == null)//si el producto que queremos modificar no existe
            {
                return View("~/Views/Home/Crear");//lo mandamos a la pagina de crear

            }
            else
            {
                return View("~/Views/Home/ListaComprasForm.cshtml", producto);//si no, lo mandamos a la pagina de modificar de dicho producto
            }

        }

        public ActionResult Guardar(Models.ListaCompra producto)
        {
            //Guardar esos datos en la base de datos
            producto.Guardar();
            //Redireccionar a una vista
            return Redirect("~/Home/Ver/" + producto.id);//redirect significa a que url lo vamos a redireccionar
        }
    }
}