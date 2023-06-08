namespace Neptuno2022EF.Windows
{
    partial class frmVentaAE
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label address1Label;
            System.Windows.Forms.Label cityLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAgregarPais = new System.Windows.Forms.Button();
            this.cboClientes = new System.Windows.Forms.ComboBox();
            this.txtCiudad = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtPais = new System.Windows.Forms.TextBox();
            this.txtCodigoPostal = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpFechaVenta = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboProducto = new System.Windows.Forms.ComboBox();
            this.cboCategorias = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.txtPrecioUnit = new System.Windows.Forms.TextBox();
            this.btnCancelarProducto = new System.Windows.Forms.Button();
            this.btnAceptarProducto = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPrecioTotal = new System.Windows.Forms.TextBox();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtTotalVenta = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.cmnProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnPrecioUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBorrar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            nameLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            address1Label = new System.Windows.Forms.Label();
            cityLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(24, 28);
            nameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(51, 16);
            nameLabel.TabIndex = 18;
            nameLabel.Text = "Cliente:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(27, 94);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(53, 16);
            label1.TabIndex = 20;
            label1.Text = "Ciudad:";
            // 
            // address1Label
            // 
            address1Label.AutoSize = true;
            address1Label.Location = new System.Drawing.Point(27, 62);
            address1Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            address1Label.Name = "address1Label";
            address1Label.Size = new System.Drawing.Size(67, 16);
            address1Label.TabIndex = 20;
            address1Label.Text = "Dirección:";
            // 
            // cityLabel
            // 
            cityLabel.AutoSize = true;
            cityLabel.Location = new System.Drawing.Point(24, 126);
            cityLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            cityLabel.Name = "cityLabel";
            cityLabel.Size = new System.Drawing.Size(70, 16);
            cityLabel.TabIndex = 23;
            cityLabel.Text = "País , C.P.:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnCancelar);
            this.splitContainer1.Panel2.Controls.Add(this.btnOk);
            this.splitContainer1.Panel2.Controls.Add(this.txtTotalVenta);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.dgvDatos);
            this.splitContainer1.Size = new System.Drawing.Size(1159, 826);
            this.splitContainer1.SplitterDistance = 390;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAgregarPais);
            this.groupBox1.Controls.Add(this.cboClientes);
            this.groupBox1.Controls.Add(nameLabel);
            this.groupBox1.Controls.Add(label1);
            this.groupBox1.Controls.Add(address1Label);
            this.groupBox1.Controls.Add(this.txtCiudad);
            this.groupBox1.Controls.Add(this.txtDireccion);
            this.groupBox1.Controls.Add(cityLabel);
            this.groupBox1.Controls.Add(this.txtPais);
            this.groupBox1.Controls.Add(this.txtCodigoPostal);
            this.groupBox1.Location = new System.Drawing.Point(24, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(791, 164);
            this.groupBox1.TabIndex = 66;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cliente";
            // 
            // btnAgregarPais
            // 
            this.btnAgregarPais.Image = global::Neptuno2022EF.Windows.Properties.Resources.plus_24px;
            this.btnAgregarPais.Location = new System.Drawing.Point(632, 14);
            this.btnAgregarPais.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregarPais.Name = "btnAgregarPais";
            this.btnAgregarPais.Size = new System.Drawing.Size(48, 38);
            this.btnAgregarPais.TabIndex = 28;
            this.btnAgregarPais.UseVisualStyleBackColor = true;
            this.btnAgregarPais.Click += new System.EventHandler(this.btnAgregarPais_Click);
            // 
            // cboClientes
            // 
            this.cboClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClientes.FormattingEnabled = true;
            this.cboClientes.Location = new System.Drawing.Point(112, 17);
            this.cboClientes.Margin = new System.Windows.Forms.Padding(4);
            this.cboClientes.Name = "cboClientes";
            this.cboClientes.Size = new System.Drawing.Size(499, 24);
            this.cboClientes.TabIndex = 0;
            this.cboClientes.SelectedIndexChanged += new System.EventHandler(this.cboClientes_SelectedIndexChanged);
            // 
            // txtCiudad
            // 
            this.txtCiudad.Location = new System.Drawing.Point(111, 90);
            this.txtCiudad.Margin = new System.Windows.Forms.Padding(4);
            this.txtCiudad.Name = "txtCiudad";
            this.txtCiudad.ReadOnly = true;
            this.txtCiudad.Size = new System.Drawing.Size(499, 22);
            this.txtCiudad.TabIndex = 21;
            this.txtCiudad.TabStop = false;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(112, 58);
            this.txtDireccion.Margin = new System.Windows.Forms.Padding(4);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.ReadOnly = true;
            this.txtDireccion.Size = new System.Drawing.Size(643, 22);
            this.txtDireccion.TabIndex = 21;
            this.txtDireccion.TabStop = false;
            // 
            // txtPais
            // 
            this.txtPais.Location = new System.Drawing.Point(111, 122);
            this.txtPais.Margin = new System.Windows.Forms.Padding(4);
            this.txtPais.Name = "txtPais";
            this.txtPais.ReadOnly = true;
            this.txtPais.Size = new System.Drawing.Size(229, 22);
            this.txtPais.TabIndex = 24;
            this.txtPais.TabStop = false;
            // 
            // txtCodigoPostal
            // 
            this.txtCodigoPostal.Location = new System.Drawing.Point(367, 122);
            this.txtCodigoPostal.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigoPostal.Name = "txtCodigoPostal";
            this.txtCodigoPostal.ReadOnly = true;
            this.txtCodigoPostal.Size = new System.Drawing.Size(132, 22);
            this.txtCodigoPostal.TabIndex = 26;
            this.txtCodigoPostal.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtpFechaVenta);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(839, 21);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(267, 71);
            this.groupBox2.TabIndex = 67;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " Fecha  ";
            // 
            // dtpFechaVenta
            // 
            this.dtpFechaVenta.Checked = false;
            this.dtpFechaVenta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaVenta.Location = new System.Drawing.Point(96, 21);
            this.dtpFechaVenta.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFechaVenta.Name = "dtpFechaVenta";
            this.dtpFechaVenta.Size = new System.Drawing.Size(161, 22);
            this.dtpFechaVenta.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 25);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Venta:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cboProducto);
            this.groupBox3.Controls.Add(this.cboCategorias);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.nudCantidad);
            this.groupBox3.Controls.Add(this.txtPrecioUnit);
            this.groupBox3.Controls.Add(this.btnCancelarProducto);
            this.groupBox3.Controls.Add(this.btnAceptarProducto);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtPrecioTotal);
            this.groupBox3.Controls.Add(this.txtStock);
            this.groupBox3.Location = new System.Drawing.Point(16, 186);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(1100, 149);
            this.groupBox3.TabIndex = 65;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = " Producto ";
            // 
            // cboProducto
            // 
            this.cboProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProducto.FormattingEnabled = true;
            this.cboProducto.Location = new System.Drawing.Point(96, 62);
            this.cboProducto.Margin = new System.Windows.Forms.Padding(4);
            this.cboProducto.Name = "cboProducto";
            this.cboProducto.Size = new System.Drawing.Size(411, 24);
            this.cboProducto.TabIndex = 1;
            this.cboProducto.SelectedIndexChanged += new System.EventHandler(this.cboProducto_SelectedIndexChanged);
            // 
            // cboCategorias
            // 
            this.cboCategorias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategorias.FormattingEnabled = true;
            this.cboCategorias.Location = new System.Drawing.Point(96, 25);
            this.cboCategorias.Margin = new System.Windows.Forms.Padding(4);
            this.cboCategorias.Name = "cboCategorias";
            this.cboCategorias.Size = new System.Drawing.Size(343, 24);
            this.cboCategorias.TabIndex = 0;
            this.cboCategorias.SelectedIndexChanged += new System.EventHandler(this.cboCategorias_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 65);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 31;
            this.label5.Text = "Producto:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 28);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 16);
            this.label7.TabIndex = 33;
            this.label7.Text = "Categoría:";
            // 
            // nudCantidad
            // 
            this.nudCantidad.Enabled = false;
            this.nudCantidad.Location = new System.Drawing.Point(637, 26);
            this.nudCantidad.Margin = new System.Windows.Forms.Padding(4);
            this.nudCantidad.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(160, 22);
            this.nudCantidad.TabIndex = 2;
            this.nudCantidad.ValueChanged += new System.EventHandler(this.nudCantidad_ValueChanged);
            // 
            // txtPrecioUnit
            // 
            this.txtPrecioUnit.Location = new System.Drawing.Point(260, 106);
            this.txtPrecioUnit.Margin = new System.Windows.Forms.Padding(4);
            this.txtPrecioUnit.Name = "txtPrecioUnit";
            this.txtPrecioUnit.ReadOnly = true;
            this.txtPrecioUnit.Size = new System.Drawing.Size(124, 22);
            this.txtPrecioUnit.TabIndex = 2;
            // 
            // btnCancelarProducto
            // 
            this.btnCancelarProducto.Location = new System.Drawing.Point(904, 84);
            this.btnCancelarProducto.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelarProducto.Name = "btnCancelarProducto";
            this.btnCancelarProducto.Size = new System.Drawing.Size(176, 53);
            this.btnCancelarProducto.TabIndex = 4;
            this.btnCancelarProducto.Text = "Cancelar";
            this.btnCancelarProducto.UseVisualStyleBackColor = true;
            this.btnCancelarProducto.Click += new System.EventHandler(this.btnCancelarProducto_Click);
            // 
            // btnAceptarProducto
            // 
            this.btnAceptarProducto.Location = new System.Drawing.Point(905, 23);
            this.btnAceptarProducto.Margin = new System.Windows.Forms.Padding(4);
            this.btnAceptarProducto.Name = "btnAceptarProducto";
            this.btnAceptarProducto.Size = new System.Drawing.Size(175, 53);
            this.btnAceptarProducto.TabIndex = 3;
            this.btnAceptarProducto.Text = "Aceptar";
            this.btnAceptarProducto.UseVisualStyleBackColor = true;
            this.btnAceptarProducto.Click += new System.EventHandler(this.btnAceptarProducto_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(564, 28);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 16);
            this.label10.TabIndex = 28;
            this.label10.Text = "Cantidad:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(544, 65);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 16);
            this.label11.TabIndex = 28;
            this.label11.Text = "Precio Total:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(169, 111);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 16);
            this.label9.TabIndex = 28;
            this.label9.Text = "Precio Unit:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 111);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 16);
            this.label8.TabIndex = 28;
            this.label8.Text = "Stock:";
            // 
            // txtPrecioTotal
            // 
            this.txtPrecioTotal.Location = new System.Drawing.Point(641, 62);
            this.txtPrecioTotal.Margin = new System.Windows.Forms.Padding(4);
            this.txtPrecioTotal.Name = "txtPrecioTotal";
            this.txtPrecioTotal.ReadOnly = true;
            this.txtPrecioTotal.Size = new System.Drawing.Size(121, 22);
            this.txtPrecioTotal.TabIndex = 4;
            this.txtPrecioTotal.TabStop = false;
            this.txtPrecioTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtStock
            // 
            this.txtStock.Location = new System.Drawing.Point(93, 107);
            this.txtStock.Margin = new System.Windows.Forms.Padding(4);
            this.txtStock.Name = "txtStock";
            this.txtStock.ReadOnly = true;
            this.txtStock.Size = new System.Drawing.Size(67, 22);
            this.txtStock.TabIndex = 24;
            this.txtStock.TabStop = false;
            this.txtStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(627, 305);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 62);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.CancelarButton_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(309, 305);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(120, 62);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK";
            this.btnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtTotalVenta
            // 
            this.txtTotalVenta.Location = new System.Drawing.Point(864, 288);
            this.txtTotalVenta.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotalVenta.Name = "txtTotalVenta";
            this.txtTotalVenta.ReadOnly = true;
            this.txtTotalVenta.Size = new System.Drawing.Size(137, 22);
            this.txtTotalVenta.TabIndex = 65;
            this.txtTotalVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(795, 292);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 16);
            this.label6.TabIndex = 64;
            this.label6.Text = "Total:";
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AllowUserToDeleteRows = false;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cmnProducto,
            this.cmnPrecioUnitario,
            this.cmnCantidad,
            this.cmnTotal,
            this.btnBorrar});
            this.dgvDatos.Location = new System.Drawing.Point(24, 23);
            this.dgvDatos.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDatos.MultiSelect = false;
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            this.dgvDatos.RowHeadersVisible = false;
            this.dgvDatos.RowHeadersWidth = 51;
            this.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatos.Size = new System.Drawing.Size(1084, 257);
            this.dgvDatos.TabIndex = 63;
            // 
            // cmnProducto
            // 
            this.cmnProducto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnProducto.HeaderText = "Producto";
            this.cmnProducto.MinimumWidth = 6;
            this.cmnProducto.Name = "cmnProducto";
            this.cmnProducto.ReadOnly = true;
            // 
            // cmnPrecioUnitario
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.cmnPrecioUnitario.DefaultCellStyle = dataGridViewCellStyle1;
            this.cmnPrecioUnitario.HeaderText = "Precio Unitario";
            this.cmnPrecioUnitario.MinimumWidth = 6;
            this.cmnPrecioUnitario.Name = "cmnPrecioUnitario";
            this.cmnPrecioUnitario.ReadOnly = true;
            this.cmnPrecioUnitario.Width = 125;
            // 
            // cmnCantidad
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.cmnCantidad.DefaultCellStyle = dataGridViewCellStyle2;
            this.cmnCantidad.HeaderText = "Cantidad";
            this.cmnCantidad.MinimumWidth = 6;
            this.cmnCantidad.Name = "cmnCantidad";
            this.cmnCantidad.ReadOnly = true;
            this.cmnCantidad.Width = 125;
            // 
            // cmnTotal
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.cmnTotal.DefaultCellStyle = dataGridViewCellStyle3;
            this.cmnTotal.HeaderText = "Total";
            this.cmnTotal.MinimumWidth = 6;
            this.cmnTotal.Name = "cmnTotal";
            this.cmnTotal.ReadOnly = true;
            this.cmnTotal.Width = 125;
            // 
            // btnBorrar
            // 
            this.btnBorrar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.btnBorrar.HeaderText = "Borrar";
            this.btnBorrar.MinimumWidth = 6;
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.ReadOnly = true;
            this.btnBorrar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnBorrar.Width = 50;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmVentaAE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1159, 826);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmVentaAE";
            this.Text = "frmVentaAE";
            this.Load += new System.EventHandler(this.frmVentaAE_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAgregarPais;
        private System.Windows.Forms.ComboBox cboClientes;
        private System.Windows.Forms.TextBox txtCiudad;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtPais;
        private System.Windows.Forms.TextBox txtCodigoPostal;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtpFechaVenta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cboProducto;
        private System.Windows.Forms.ComboBox cboCategorias;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.TextBox txtPrecioUnit;
        private System.Windows.Forms.Button btnCancelarProducto;
        private System.Windows.Forms.Button btnAceptarProducto;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPrecioTotal;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txtTotalVenta;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnPrecioUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnTotal;
        private System.Windows.Forms.DataGridViewButtonColumn btnBorrar;
    }
}