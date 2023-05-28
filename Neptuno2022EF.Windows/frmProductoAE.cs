using Neptuno2022EF.Entidades.Entidades;
using Neptuno2022EF.Servicios.Interfaces;
using Neptuno2022EF.Windows.Helpers;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Neptuno2022EF.Windows
{
    public partial class frmProductoAE : Form
    {
        private string imagenNoDisponible = Environment.CurrentDirectory + @"\Imagenes\SinImagenDisponible.jpg";
        private string archivoNoEncontrado = Environment.CurrentDirectory + @"\Imagenes\ArchivoNoEncontrado.jpg";
        private string archivoImagen = string.Empty;
        private readonly IServiciosProductos _servicio;
        private bool esEdicion=false;
        public frmProductoAE(IServiciosProductos servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }
        private Producto producto;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            esEdicion = true;
            CombosHelper.CargarComboCategorias(ref cboCategorias);
            CombosHelper.CargarComboProveedores(ref cboProveedores);
            if (producto != null)
            {
                txtProducto.Text = producto.NombreProducto;
                txtPrecioVta.Text = producto.PrecioUnitario.ToString();
                nudStock.Value = producto.Stock;
                cboCategorias.SelectedValue = producto.CategoriaId;
                cboProveedores.SelectedValue = producto.ProveedorId;
                nudMinimo.Value = producto.StockMinimo;
                chkSuspendido.Checked = producto.Suspendido;
                //Veo si el producto tiene alguna imagen asociada
                if (producto.Imagen != string.Empty)
                {
                    //Me aseguro que esa imagen exista
                    if (!File.Exists(producto.Imagen))
                    {
                        //Si no existe, muestro la imagen de archivo no encontrado
                        pbImagen.Image = Image.FromFile(archivoNoEncontrado);
                    }
                    else
                    {
                        //Caso contrario muestro la imagen
                        pbImagen.Image = Image.FromFile(producto.Imagen);
                    }
                }
                else
                {
                    //Si no tiene imagen muestro Sin Imagen 
                    pbImagen.Image = Image.FromFile(imagenNoDisponible);
                }
            }

        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //Seteo del openFileDialog
            openFileDialog1.Multiselect = false;
            openFileDialog1.InitialDirectory = Environment.CurrentDirectory + @"\Imagenes\";
            openFileDialog1.Filter = "Archivos jpg (*.jpg)|*.jpg|Archivos png (*.png)|*.png|Archivos jfif (*.jfif)|*.jfif";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            DialogResult dr = openFileDialog1.ShowDialog(this);//muestro el openFileDialog

            if (dr == DialogResult.OK)
            {
                //Veo si tengo algun imagen seleccionada
                if (openFileDialog1.FileName == null)
                {
                    return;//sino me voy
                }
                //Tomo el nombre del archivo de imagen con su ruta
                //archivoNombreConRuta = openFileDialog1.FileName;
                pbImagen.Image = Image.FromFile(openFileDialog1.FileName);
                archivoImagen = openFileDialog1.FileName;//Tomo la ruta y el nombre del archivo
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (producto == null)
                {
                    producto = new Producto();
                }

                producto.NombreProducto = txtProducto.Text;
                producto.CategoriaId = (int)cboCategorias.SelectedValue;
                producto.ProveedorId = (int)cboProveedores.SelectedValue;
                producto.Stock = (int)nudStock.Value;
                producto.StockMinimo = (int)nudMinimo.Value;
                producto.PrecioUnitario = decimal.Parse(txtPrecioVta.Text);
                producto.Suspendido = chkSuspendido.Checked;
                producto.Imagen = archivoImagen;

                DialogResult = DialogResult.OK;
                try
                {

                    if (!_servicio.Existe(producto))
                    {
                        _servicio.Guardar(producto);

                        MessageBox.Show("Registro agregado satisfactoriamente", "Mensaje",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (!esEdicion)
                        {
                            DialogResult dr = MessageBox.Show("¿Desea agregar otro registro?",
                        "Confirmar",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2);
                            if (dr == DialogResult.No)
                            {
                                DialogResult = DialogResult.OK;
                                return;
                            }
                            producto = null;
                            InicialControles();

                        }
                        else
                        {
                            DialogResult = DialogResult.OK;
                            return;
                        }
                    }
                    else
                    {
                        errorProvider1.SetError(txtProducto, "Producto existente!!!");

                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Error al intentar agregar un registro", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }

        }

        private void InicialControles()
        {
            throw new NotImplementedException();
        }

        private bool ValidarDatos()
        {
            return true;
        }

        internal void SetProducto(Producto producto)
        {
            throw new NotImplementedException();
        }
    }
}
