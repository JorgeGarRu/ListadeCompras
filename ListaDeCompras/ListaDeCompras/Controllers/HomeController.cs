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
            List<Models.ListaCompra> compra = Models.ListaCompra.listar();//en la variable compras, le pasamos el metodo listar, creado en "listaCompra.cs"
            return View(compra);//y lo metemos en el return para que se vea por pantalla
        }

        public ActionResult ProductosComprados()
        {
            List<Models.ListaCompra> compra = Models.ListaCompra.ListarProductosComprados();//en la variable compras, le pasamos el metodo listar, creado en "listaCompra.cs"
            return View(compra);//y lo metemos en el return para que se vea por pantalla
        }

        public ActionResult ProductosNoComprados()
        {
            List<Models.ListaCompra> compra = Models.ListaCompra.ListarProductosNoComprados();//en la variable compras, le pasamos el metodo listar, creado en "listaCompra.cs"
            return View(compra);//y lo metemos en el return para que se vea por pantalla
        }

        public ActionResult Ver(int id)//pagina de vista de un producto
        {
            Models.ListaCompra compra = Models.ListaCompra.DevuelveProducto(id);//metemos en la variable producto, el producto que tenga la id dada
            if (compra != null)//si el producto no es nulo...
            {
                return View(compra);//devolvemos el producto
            }
            else//sino...
            {
                return View("~/Views/Home/Index/");//redireccionamos a la pagina de inicio
            }

        }

        public ActionResult Crear()//pagina de creacion de un producto
        {
            Models.ListaCompra compra = new Models.ListaCompra();
            return View("~/Views/Home/ListaComprasForm.cshtml", compra);//redireccionamos al formulario de dicha compra
        }

        public ActionResult Modificar(int id = 0)
        {
            Models.ListaCompra compra = Models.ListaCompra.DevuelveProducto(id);//en la variable compra metemos el producto que tenga la id dada

            if (compra == null)//si el producto que queremos modificar no existe
            {
                return View("~/Views/Home/Crear");//lo mandamos a la pagina de crear

            }
            else
            {
                return View("~/Views/Home/ListaComprasForm.cshtml", compra);//si no, lo mandamos a la pagina de modificar de dicho producto
            }

        }

        public ActionResult Guardar(Models.ListaCompra compra)
        {
            //Guardar esos datos en la base de datos
          
                compra.Guardar();
                return Redirect("~/Home/Index/"+compra.id);//redireccionamos a la vista de dicha compra
         


        }

        public ActionResult Eliminar(int id = 0)
        {
            //eliminar la entrada si existe
           Models.ListaCompra compra = Models.ListaCompra.DevuelveProducto(id);
            if (compra!= null)
            {
                //Borrar
                compra.Eliminar();
            }
            //redireccionar
            return Redirect("~/Home/Index");
        }
    }
}