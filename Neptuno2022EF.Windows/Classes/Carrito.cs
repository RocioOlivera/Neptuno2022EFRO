using System.Collections.Generic;
using System.Linq;

namespace Neptuno2022EF.Windows.Classes
{
    public class Carrito
    {
        private List<ItemCarrito> listaItems;
        public static Carrito instancia = null;

        public static Carrito GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new Carrito();
            }

            return instancia;
        }

        private Carrito()
        {
            listaItems = new List<ItemCarrito>();
        }

        public void Agregar(ItemCarrito item)
        {
            var productoEnCarrito = listaItems
                .SingleOrDefault(i => i.ProductoId == item.ProductoId);
            if (productoEnCarrito == null)
            {
                listaItems.Add(item);

            }
            else
            {
                productoEnCarrito.Cantidad += item.Cantidad;
            }
        }

        public List<ItemCarrito> GetItems()
        {
            return listaItems;
        }

        public decimal GetTotal()
        {
            return listaItems.Sum(i => i.Subtotal);
        }

        public int GetCantidad()
        {
            return listaItems.Sum(i => i.Cantidad);
        }

        public void LimpiarCarrito()
        {
            listaItems.Clear();
        }

        public void QuitarItem(ItemCarrito item)
        {
            var itemEnCarrito = listaItems.SingleOrDefault(i => i.ProductoId == item.ProductoId);
            listaItems.Remove(itemEnCarrito);
        }

    }
}
