namespace Neptuno2022EF.Windows
{
    partial class frmDetalleCtaCte
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TotalesPanel = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtSaldoTotal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTotalVta = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMovimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDebe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHaber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EncabezadoPanel = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.txtDomicilio = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnIngresarPago = new System.Windows.Forms.Button();
            this.TotalesPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.EncabezadoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TotalesPanel
            // 
            this.TotalesPanel.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.TotalesPanel.Controls.Add(this.btnCancelar);
            this.TotalesPanel.Controls.Add(this.btnOk);
            this.TotalesPanel.Controls.Add(this.txtSaldoTotal);
            this.TotalesPanel.Controls.Add(this.label6);
            this.TotalesPanel.Controls.Add(this.txtTotalVta);
            this.TotalesPanel.Controls.Add(this.label4);
            this.TotalesPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TotalesPanel.Location = new System.Drawing.Point(0, 358);
            this.TotalesPanel.Margin = new System.Windows.Forms.Padding(4);
            this.TotalesPanel.Name = "TotalesPanel";
            this.TotalesPanel.Size = new System.Drawing.Size(800, 92);
            this.TotalesPanel.TabIndex = 7;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(173, 17);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 62);
            this.btnCancelar.TabIndex = 67;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(13, 17);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(120, 62);
            this.btnOk.TabIndex = 66;
            this.btnOk.Text = "OK";
            this.btnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtSaldoTotal
            // 
            this.txtSaldoTotal.Enabled = false;
            this.txtSaldoTotal.Location = new System.Drawing.Point(499, 17);
            this.txtSaldoTotal.Margin = new System.Windows.Forms.Padding(4);
            this.txtSaldoTotal.Name = "txtSaldoTotal";
            this.txtSaldoTotal.ReadOnly = true;
            this.txtSaldoTotal.Size = new System.Drawing.Size(137, 22);
            this.txtSaldoTotal.TabIndex = 69;
            this.txtSaldoTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(430, 21);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 16);
            this.label6.TabIndex = 68;
            this.label6.Text = "Total:";
            // 
            // txtTotalVta
            // 
            this.txtTotalVta.Enabled = false;
            this.txtTotalVta.Location = new System.Drawing.Point(971, 7);
            this.txtTotalVta.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotalVta.Name = "txtTotalVta";
            this.txtTotalVta.Size = new System.Drawing.Size(79, 22);
            this.txtTotalVta.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(917, 11);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Total:";
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AllowUserToDeleteRows = false;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFecha,
            this.colMovimiento,
            this.colDebe,
            this.colHaber});
            this.dgvDatos.Location = new System.Drawing.Point(13, 130);
            this.dgvDatos.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            this.dgvDatos.RowHeadersVisible = false;
            this.dgvDatos.RowHeadersWidth = 51;
            this.dgvDatos.Size = new System.Drawing.Size(623, 203);
            this.dgvDatos.TabIndex = 5;
            // 
            // colFecha
            // 
            this.colFecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.MinimumWidth = 6;
            this.colFecha.Name = "colFecha";
            this.colFecha.ReadOnly = true;
            // 
            // colMovimiento
            // 
            this.colMovimiento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colMovimiento.DefaultCellStyle = dataGridViewCellStyle1;
            this.colMovimiento.HeaderText = "Movimiento";
            this.colMovimiento.MinimumWidth = 6;
            this.colMovimiento.Name = "colMovimiento";
            this.colMovimiento.ReadOnly = true;
            // 
            // colDebe
            // 
            this.colDebe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colDebe.DefaultCellStyle = dataGridViewCellStyle2;
            this.colDebe.HeaderText = "Debe";
            this.colDebe.MinimumWidth = 6;
            this.colDebe.Name = "colDebe";
            this.colDebe.ReadOnly = true;
            this.colDebe.Width = 70;
            // 
            // colHaber
            // 
            this.colHaber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colHaber.DefaultCellStyle = dataGridViewCellStyle3;
            this.colHaber.HeaderText = "Haber";
            this.colHaber.MinimumWidth = 6;
            this.colHaber.Name = "colHaber";
            this.colHaber.ReadOnly = true;
            this.colHaber.Width = 74;
            // 
            // EncabezadoPanel
            // 
            this.EncabezadoPanel.BackColor = System.Drawing.Color.LightGray;
            this.EncabezadoPanel.Controls.Add(this.btnCerrar);
            this.EncabezadoPanel.Controls.Add(this.txtDomicilio);
            this.EncabezadoPanel.Controls.Add(this.label3);
            this.EncabezadoPanel.Controls.Add(this.txtCliente);
            this.EncabezadoPanel.Controls.Add(this.label1);
            this.EncabezadoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.EncabezadoPanel.Location = new System.Drawing.Point(0, 0);
            this.EncabezadoPanel.Margin = new System.Windows.Forms.Padding(4);
            this.EncabezadoPanel.Name = "EncabezadoPanel";
            this.EncabezadoPanel.Size = new System.Drawing.Size(800, 113);
            this.EncabezadoPanel.TabIndex = 6;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Image = global::Neptuno2022EF.Windows.Properties.Resources.cancel_24px;
            this.btnCerrar.Location = new System.Drawing.Point(951, 14);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(100, 63);
            this.btnCerrar.TabIndex = 29;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCerrar.UseVisualStyleBackColor = true;
            // 
            // txtDomicilio
            // 
            this.txtDomicilio.Enabled = false;
            this.txtDomicilio.Location = new System.Drawing.Point(120, 57);
            this.txtDomicilio.Margin = new System.Windows.Forms.Padding(4);
            this.txtDomicilio.Name = "txtDomicilio";
            this.txtDomicilio.Size = new System.Drawing.Size(173, 22);
            this.txtDomicilio.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 60);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Domicilio:";
            // 
            // txtCliente
            // 
            this.txtCliente.Enabled = false;
            this.txtCliente.Location = new System.Drawing.Point(120, 13);
            this.txtCliente.Margin = new System.Windows.Forms.Padding(4);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(579, 22);
            this.txtCliente.TabIndex = 1;
            this.txtCliente.TextChanged += new System.EventHandler(this.txtCliente_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cliente:";
            // 
            // btnIngresarPago
            // 
            this.btnIngresarPago.Location = new System.Drawing.Point(662, 191);
            this.btnIngresarPago.Margin = new System.Windows.Forms.Padding(4);
            this.btnIngresarPago.Name = "btnIngresarPago";
            this.btnIngresarPago.Size = new System.Drawing.Size(125, 81);
            this.btnIngresarPago.TabIndex = 8;
            this.btnIngresarPago.Text = "Ingresar Pago";
            this.btnIngresarPago.UseVisualStyleBackColor = true;
            this.btnIngresarPago.Click += new System.EventHandler(this.btnIngresarPago_Click);
            // 
            // frmDetalleCtaCte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnIngresarPago);
            this.Controls.Add(this.TotalesPanel);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.EncabezadoPanel);
            this.Name = "frmDetalleCtaCte";
            this.Text = "frmDetalleCtaCte";
            this.Load += new System.EventHandler(this.frmDetalleCtaCte_Load);
            this.TotalesPanel.ResumeLayout(false);
            this.TotalesPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.EncabezadoPanel.ResumeLayout(false);
            this.EncabezadoPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TotalesPanel;
        private System.Windows.Forms.TextBox txtTotalVta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.Panel EncabezadoPanel;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.TextBox txtDomicilio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMovimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDebe;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHaber;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnIngresarPago;
        private System.Windows.Forms.TextBox txtSaldoTotal;
    }
}