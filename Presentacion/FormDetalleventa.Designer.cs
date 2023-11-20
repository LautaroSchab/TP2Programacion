namespace Presentacion
{
    partial class FormDetalleventa
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnLimpiarBuscador = new FontAwesome.Sharp.IconButton();
            this.btnBuscar = new FontAwesome.Sharp.IconButton();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.textFecha = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.texttipoDocumento = new System.Windows.Forms.TextBox();
            this.textUsuario = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textnumeroDocumento = new System.Windows.Forms.TextBox();
            this.textNombreCliente = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textDocCliente = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvdata = new System.Windows.Forms.DataGridView();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDescargarPdf = new FontAwesome.Sharp.IconButton();
            this.textMontoTotal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textMontoPago = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textMontoCambio = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(211, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(572, 441);
            this.label1.TabIndex = 1;
            // 
            // btnLimpiarBuscador
            // 
            this.btnLimpiarBuscador.BackColor = System.Drawing.Color.White;
            this.btnLimpiarBuscador.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiarBuscador.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnLimpiarBuscador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarBuscador.ForeColor = System.Drawing.Color.Black;
            this.btnLimpiarBuscador.IconChar = FontAwesome.Sharp.IconChar.Broom;
            this.btnLimpiarBuscador.IconColor = System.Drawing.Color.Black;
            this.btnLimpiarBuscador.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLimpiarBuscador.IconSize = 20;
            this.btnLimpiarBuscador.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiarBuscador.Location = new System.Drawing.Point(704, 51);
            this.btnLimpiarBuscador.Name = "btnLimpiarBuscador";
            this.btnLimpiarBuscador.Size = new System.Drawing.Size(66, 22);
            this.btnLimpiarBuscador.TabIndex = 62;
            this.btnLimpiarBuscador.Text = "Limpiar";
            this.btnLimpiarBuscador.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpiarBuscador.UseVisualStyleBackColor = false;
            this.btnLimpiarBuscador.Click += new System.EventHandler(this.btnLimpiarBuscador_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.White;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.ForeColor = System.Drawing.Color.Black;
            this.btnBuscar.IconChar = FontAwesome.Sharp.IconChar.Searchengin;
            this.btnBuscar.IconColor = System.Drawing.Color.Black;
            this.btnBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscar.IconSize = 20;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(632, 51);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(66, 22);
            this.btnBuscar.TabIndex = 61;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Location = new System.Drawing.Point(496, 51);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBusqueda.Size = new System.Drawing.Size(129, 20);
            this.txtBusqueda.TabIndex = 60;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(401, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 59;
            this.label3.Text = ":Nroº Documento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(227, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 24);
            this.label2.TabIndex = 58;
            this.label2.Text = "Detalle Venta";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(7, 27);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(40, 13);
            this.label15.TabIndex = 7;
            this.label15.Text = ":Fecha";
            // 
            // textFecha
            // 
            this.textFecha.Location = new System.Drawing.Point(10, 42);
            this.textFecha.Name = "textFecha";
            this.textFecha.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textFecha.Size = new System.Drawing.Size(125, 20);
            this.textFecha.TabIndex = 8;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.White;
            this.label14.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label14.Location = new System.Drawing.Point(159, 26);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 13);
            this.label14.TabIndex = 14;
            this.label14.Text = ":Tipo Documento";
            // 
            // texttipoDocumento
            // 
            this.texttipoDocumento.Location = new System.Drawing.Point(162, 42);
            this.texttipoDocumento.Name = "texttipoDocumento";
            this.texttipoDocumento.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.texttipoDocumento.Size = new System.Drawing.Size(184, 20);
            this.texttipoDocumento.TabIndex = 15;
            // 
            // textUsuario
            // 
            this.textUsuario.Location = new System.Drawing.Point(368, 42);
            this.textUsuario.Name = "textUsuario";
            this.textUsuario.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textUsuario.Size = new System.Drawing.Size(169, 20);
            this.textUsuario.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(365, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = ":Usuario";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.White;
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.textUsuario);
            this.groupBox4.Controls.Add(this.texttipoDocumento);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.textFecha);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Location = new System.Drawing.Point(228, 79);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox4.Size = new System.Drawing.Size(543, 73);
            this.groupBox4.TabIndex = 68;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Informacion Venta";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.textnumeroDocumento);
            this.groupBox1.Controls.Add(this.textNombreCliente);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textDocCliente);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(228, 158);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(543, 72);
            this.groupBox1.TabIndex = 69;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informacion Cliente";
            // 
            // textnumeroDocumento
            // 
            this.textnumeroDocumento.Location = new System.Drawing.Point(502, 42);
            this.textnumeroDocumento.Name = "textnumeroDocumento";
            this.textnumeroDocumento.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textnumeroDocumento.Size = new System.Drawing.Size(35, 20);
            this.textnumeroDocumento.TabIndex = 55;
            this.textnumeroDocumento.Visible = false;
            // 
            // textNombreCliente
            // 
            this.textNombreCliente.Location = new System.Drawing.Point(150, 42);
            this.textNombreCliente.Name = "textNombreCliente";
            this.textNombreCliente.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textNombreCliente.Size = new System.Drawing.Size(172, 20);
            this.textNombreCliente.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(147, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = ":Razon Social";
            // 
            // textDocCliente
            // 
            this.textDocCliente.Location = new System.Drawing.Point(10, 42);
            this.textDocCliente.Name = "textDocCliente";
            this.textDocCliente.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textDocCliente.Size = new System.Drawing.Size(125, 20);
            this.textDocCliente.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(7, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = ":Numero Documento";
            // 
            // dgvdata
            // 
            this.dgvdata.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvdata.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdata.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Producto,
            this.PrecioCompra,
            this.Cantidad,
            this.Subtotal});
            this.dgvdata.Location = new System.Drawing.Point(227, 236);
            this.dgvdata.MultiSelect = false;
            this.dgvdata.Name = "dgvdata";
            this.dgvdata.ReadOnly = true;
            this.dgvdata.RightToLeft = System.Windows.Forms.RightToLeft.No;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvdata.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvdata.RowTemplate.Height = 28;
            this.dgvdata.Size = new System.Drawing.Size(543, 174);
            this.dgvdata.TabIndex = 70;
            // 
            // Producto
            // 
            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            this.Producto.ReadOnly = true;
            this.Producto.Width = 150;
            // 
            // PrecioCompra
            // 
            this.PrecioCompra.HeaderText = "Precio Compra";
            this.PrecioCompra.Name = "PrecioCompra";
            this.PrecioCompra.ReadOnly = true;
            this.PrecioCompra.Width = 120;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // Subtotal
            // 
            this.Subtotal.HeaderText = "Sub Total";
            this.Subtotal.Name = "Subtotal";
            this.Subtotal.ReadOnly = true;
            // 
            // btnDescargarPdf
            // 
            this.btnDescargarPdf.BackColor = System.Drawing.Color.Silver;
            this.btnDescargarPdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDescargarPdf.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnDescargarPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDescargarPdf.ForeColor = System.Drawing.Color.Black;
            this.btnDescargarPdf.IconChar = FontAwesome.Sharp.IconChar.Download;
            this.btnDescargarPdf.IconColor = System.Drawing.Color.Black;
            this.btnDescargarPdf.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDescargarPdf.IconSize = 20;
            this.btnDescargarPdf.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDescargarPdf.Location = new System.Drawing.Point(649, 420);
            this.btnDescargarPdf.Name = "btnDescargarPdf";
            this.btnDescargarPdf.Size = new System.Drawing.Size(122, 22);
            this.btnDescargarPdf.TabIndex = 73;
            this.btnDescargarPdf.Text = "Descargar en PDF";
            this.btnDescargarPdf.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDescargarPdf.UseVisualStyleBackColor = false;
            this.btnDescargarPdf.Click += new System.EventHandler(this.btnDescargarPdf_Click);
            // 
            // textMontoTotal
            // 
            this.textMontoTotal.Location = new System.Drawing.Point(297, 422);
            this.textMontoTotal.Name = "textMontoTotal";
            this.textMontoTotal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textMontoTotal.Size = new System.Drawing.Size(51, 20);
            this.textMontoTotal.TabIndex = 72;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(225, 426);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 71;
            this.label5.Text = ":Monto Total";
            // 
            // textMontoPago
            // 
            this.textMontoPago.Location = new System.Drawing.Point(422, 422);
            this.textMontoPago.Name = "textMontoPago";
            this.textMontoPago.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textMontoPago.Size = new System.Drawing.Size(54, 20);
            this.textMontoPago.TabIndex = 75;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(355, 426);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 13);
            this.label8.TabIndex = 74;
            this.label8.Text = ":Monto Pago";
            // 
            // textMontoCambio
            // 
            this.textMontoCambio.Location = new System.Drawing.Point(561, 423);
            this.textMontoCambio.Name = "textMontoCambio";
            this.textMontoCambio.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textMontoCambio.Size = new System.Drawing.Size(55, 20);
            this.textMontoCambio.TabIndex = 74;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(486, 425);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 13);
            this.label9.TabIndex = 73;
            this.label9.Text = ":Monto Cambio";
            // 
            // FormDetalleventa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 532);
            this.Controls.Add(this.textMontoCambio);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textMontoPago);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnDescargarPdf);
            this.Controls.Add(this.textMontoTotal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvdata);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnLimpiarBuscador);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtBusqueda);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormDetalleventa";
            this.Text = "FormDetalleventa";
            this.Load += new System.EventHandler(this.FormDetalleventa_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton btnLimpiarBuscador;
        private FontAwesome.Sharp.IconButton btnBuscar;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textFecha;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox texttipoDocumento;
        private System.Windows.Forms.TextBox textUsuario;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textnumeroDocumento;
        private System.Windows.Forms.TextBox textNombreCliente;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textDocCliente;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvdata;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subtotal;
        private FontAwesome.Sharp.IconButton btnDescargarPdf;
        private System.Windows.Forms.TextBox textMontoTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textMontoPago;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textMontoCambio;
        private System.Windows.Forms.Label label9;
    }
}