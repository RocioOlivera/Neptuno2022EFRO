using Neptuno2022EF.Entidades.Dtos;
using Neptuno2022EF.Entidades.Dtos.Ciudad;
using Neptuno2022EF.Entidades.Dtos.Cliente;
using Neptuno2022EF.Entidades.Dtos.Producto;
using Neptuno2022EF.Entidades.Dtos.Proveedor;
using Neptuno2022EF.Entidades.Entidades;
using Neptuno2022EF.Ioc;
using Neptuno2022EF.Servicios.Interfaces;
using System;
using System.Windows.Forms;

namespace Neptuno2022EF.Windows.Helpers
{
    public static class CombosHelper
    {
        public static void CargarComboPaises(ref ComboBox combo)
        {
            IServiciosPaises _servicio=DI.Create<IServiciosPaises>();
            var lista = _servicio.GetPaises();
            var defaultPais = new Pais
            {
                PaisId = 0,
                NombrePais = "Seleccione País"
            };
            lista.Insert(0,defaultPais);
            combo.DataSource = lista;
            combo.ValueMember = "PaisId";
            combo.DisplayMember = "NombrePais";
            combo.SelectedIndex = 0;
        }

        public static void CargarComboCategorias(ref ComboBox combo)
        {
            IServiciosCategorias _servicio = DI.Create<IServiciosCategorias>();
            var lista = _servicio.GetCategorias();
            var defaultCategoria = new Categoria
            {
                CategoriaId = 0,
                NombreCategoria = "Seleccione Categoría"
            };
            lista.Insert(0, defaultCategoria);
            combo.DataSource = lista;
            combo.ValueMember = "CategoriaId";
            combo.DisplayMember = "NombreCategoria";
            combo.SelectedIndex = 0;

        }

        public static void CargarComboCiudades(ref ComboBox combo, Pais paisSeleccionado)
        {
            IServiciosCiudades _servicio = DI.Create<IServiciosCiudades>();
            var lista = _servicio.GetCiudades(paisSeleccionado.PaisId);
            var defaultCiudad = new CiudadListDto
            {
                CiudadId = 0,
                NombreCiudad = "Seleccione Ciudad"
            };
            lista.Insert(0, defaultCiudad);
            combo.DataSource = lista;
            combo.ValueMember = "CiudadId";
            combo.DisplayMember = "NombreCiudad";
            combo.SelectedIndex = 0;
        }

        public static void CargarComboProveedores(ref ComboBox combo)
        {
            IServiciosProveedores _servicio = DI.Create<IServiciosProveedores>();
            var lista = _servicio.GetProveedores();
            var defaultProveedor = new ProveedorListDto
            {
                ProveedorId = 0,
                NombreProveedor = "Seleccione Proveedor"
            };
            lista.Insert(0, defaultProveedor);
            combo.DataSource = lista;
            combo.ValueMember = "ProveedorId";
            combo.DisplayMember = "NombreProveedor";
            combo.SelectedIndex = 0;
        }

        public static void CargarComboClientes(ref ComboBox combo)
        {
            IServiciosClientes _servicio = DI.Create<IServiciosClientes>();
            var lista = _servicio.GetClientes();
            var defaultCliente = new ClienteListDto
            {
                ClienteId = 0,
                NombreCliente = "Seleccione Cliente"
            };
            lista.Insert(0, defaultCliente);
            combo.DataSource = lista;
            combo.ValueMember = "ClienteId";
            combo.DisplayMember = "NombreCliente";
            combo.SelectedIndex = 0;
        }

        public static void CargarComboProductos(ref ComboBox combo, Categoria categoriaSeleccionada)
        {
            IServiciosProductos _servicio = DI.Create<IServiciosProductos>();
            var lista = _servicio.GetProductos(categoriaSeleccionada.CategoriaId);
            var defaultProducto = new ProductoListDto
            {
                ProductoId = 0,
                NombreProducto = "Seleccione Producto"
            };
            lista.Insert(0, defaultProducto);
            combo.DataSource = lista;
            combo.ValueMember = "ProductoId";
            combo.DisplayMember = "NombreProducto";
            combo.SelectedIndex = 0;
        }

    }
}
