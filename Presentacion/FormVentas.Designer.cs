namespace Presentacion
{
    partial class FormVentas
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
            this.label18 = new System.Windows.Forms.Label();
            this.dgvdata = new System.Windows.Forms.DataGridView();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cantidadnumericupdown = new System.Windows.Forms.NumericUpDown();
            this.textStockProducto = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.textPrecioProducto = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtProducto = new System.Windows.Forms.TextBox();
            this.txtIdProducto = new System.Windows.Forms.TextBox();
            this.btnBuscarProducto1 = new FontAwesome.Sharp.IconButton();
            this.label21 = new System.Windows.Forms.Label();
            this.txtCodProducto = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textNombreCliente = new System.Windows.Forms.TextBox();
            this.textIdProveedor = new System.Windows.Forms.TextBox();
            this.btnbuscarCliente = new FontAwesome.Sharp.IconButton();
            this.label16 = new System.Windows.Forms.Label();
            this.textDocumentoCliente = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.CboDocumento = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textFecha = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textTotalPagar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textPagarcon = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textCambio = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCrearVenta = new FontAwesome.Sharp.IconButton();
            this.btnAgregar = new FontAwesome.Sharp.IconButton();
            this.IdProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cantidadnumericupdown)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.White;
            this.label18.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label18.Location = new System.Drawing.Point(505, 28);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(52, 13);
            this.label18.TabIndex = 35;
            this.label18.Text = ":Cantidad";
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
            this.IdProducto,
            this.Producto,
            this.Precio,
            this.Cantidad,
            this.Subtotal,
            this.btnEliminar});
            this.dgvdata.Location = new System.Drawing.Point(149, 219);
            this.dgvdata.MultiSelect = false;
            this.dgvdata.Name = "dgvdata";
            this.dgvdata.ReadOnly = true;
            this.dgvdata.RightToLeft = System.Windows.Forms.RightToLeft.No;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvdata.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvdata.RowTemplate.Height = 28;
            this.dgvdata.Size = new System.Drawing.Size(571, 187);
            this.dgvdata.TabIndex = 37;
            this.dgvdata.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvdata_CellContentClick);
            this.dgvdata.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvdata_CellPainting);
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.Color.White;
            this.groupBox6.Controls.Add(this.label18);
            this.groupBox6.Controls.Add(this.cantidadnumericupdown);
            this.groupBox6.Controls.Add(this.textStockProducto);
            this.groupBox6.Controls.Add(this.label19);
            this.groupBox6.Controls.Add(this.textPrecioProducto);
            this.groupBox6.Controls.Add(this.label20);
            this.groupBox6.Controls.Add(this.txtProducto);
            this.groupBox6.Controls.Add(this.txtIdProducto);
            this.groupBox6.Controls.Add(this.btnBuscarProducto1);
            this.groupBox6.Controls.Add(this.label21);
            this.groupBox6.Controls.Add(this.txtCodProducto);
            this.groupBox6.Controls.Add(this.label22);
            this.groupBox6.Location = new System.Drawing.Point(149, 127);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(571, 73);
            this.groupBox6.TabIndex = 36;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Informacion Producto";
            // 
            // cantidadnumericupdown
            // 
            this.cantidadnumericupdown.Location = new System.Drawing.Point(508, 43);
            this.cantidadnumericupdown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.cantidadnumericupdown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.cantidadnumericupdown.Name = "cantidadnumericupdown";
            this.cantidadnumericupdown.Size = new System.Drawing.Size(56, 20);
            this.cantidadnumericupdown.TabIndex = 34;
            this.cantidadnumericupdown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // textStockProducto
            // 
            this.textStockProducto.Location = new System.Drawing.Point(418, 44);
            this.textStockProducto.Name = "textStockProducto";
            this.textStockProducto.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textStockProducto.Size = new System.Drawing.Size(70, 20);
            this.textStockProducto.TabIndex = 33;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.White;
            this.label19.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label19.Location = new System.Drawing.Point(415, 27);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(38, 13);
            this.label19.TabIndex = 32;
            this.label19.Text = ":Stock";
            // 
            // textPrecioProducto
            // 
            this.textPrecioProducto.Location = new System.Drawing.Point(339, 43);
            this.textPrecioProducto.Name = "textPrecioProducto";
            this.textPrecioProducto.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textPrecioProducto.Size = new System.Drawing.Size(67, 20);
            this.textPrecioProducto.TabIndex = 31;
            this.textPrecioProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textPrecioProducto_KeyPress);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.White;
            this.label20.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label20.Location = new System.Drawing.Point(336, 27);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(43, 13);
            this.label20.TabIndex = 30;
            this.label20.Text = ":Precio ";
            // 
            // txtProducto
            // 
            this.txtProducto.Location = new System.Drawing.Point(177, 43);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtProducto.Size = new System.Drawing.Size(152, 20);
            this.txtProducto.TabIndex = 29;
            // 
            // txtIdProducto
            // 
            this.txtIdProducto.Location = new System.Drawing.Point(107, 21);
            this.txtIdProducto.Name = "txtIdProducto";
            this.txtIdProducto.Size = new System.Drawing.Size(26, 20);
            this.txtIdProducto.TabIndex = 28;
            this.txtIdProducto.Visible = false;
            // 
            // btnBuscarProducto1
            // 
            this.btnBuscarProducto1.BackColor = System.Drawing.Color.White;
            this.btnBuscarProducto1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarProducto1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnBuscarProducto1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarProducto1.ForeColor = System.Drawing.Color.Transparent;
            this.btnBuscarProducto1.IconChar = FontAwesome.Sharp.IconChar.Searchengin;
            this.btnBuscarProducto1.IconColor = System.Drawing.Color.Black;
            this.btnBuscarProducto1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscarProducto1.IconSize = 20;
            this.btnBuscarProducto1.Location = new System.Drawing.Point(139, 44);
            this.btnBuscarProducto1.Name = "btnBuscarProducto1";
            this.btnBuscarProducto1.Size = new System.Drawing.Size(32, 19);
            this.btnBuscarProducto1.TabIndex = 27;
            this.btnBuscarProducto1.UseVisualStyleBackColor = false;
            this.btnBuscarProducto1.Click += new System.EventHandler(this.btnBuscarProducto1_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.White;
            this.label21.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label21.Location = new System.Drawing.Point(174, 27);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(53, 13);
            this.label21.TabIndex = 14;
            this.label21.Text = ":Producto";
            // 
            // txtCodProducto
            // 
            this.txtCodProducto.Location = new System.Drawing.Point(10, 44);
            this.txtCodProducto.Name = "txtCodProducto";
            this.txtCodProducto.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCodProducto.Size = new System.Drawing.Size(123, 20);
            this.txtCodProducto.TabIndex = 8;
            this.txtCodProducto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodProducto_KeyDown);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.White;
            this.label22.Location = new System.Drawing.Point(7, 28);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(75, 13);
            this.label22.TabIndex = 7;
            this.label22.Text = ":Cod.Producto";
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.White;
            this.groupBox5.Controls.Add(this.textNombreCliente);
            this.groupBox5.Controls.Add(this.textIdProveedor);
            this.groupBox5.Controls.Add(this.btnbuscarCliente);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.textDocumentoCliente);
            this.groupBox5.Controls.Add(this.label17);
            this.groupBox5.Location = new System.Drawing.Point(466, 48);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(344, 73);
            this.groupBox5.TabIndex = 35;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Informacion Cliente";
            // 
            // textNombreCliente
            // 
            this.textNombreCliente.Location = new System.Drawing.Point(177, 43);
            this.textNombreCliente.Name = "textNombreCliente";
            this.textNombreCliente.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textNombreCliente.Size = new System.Drawing.Size(162, 20);
            this.textNombreCliente.TabIndex = 29;
            // 
            // textIdProveedor
            // 
            this.textIdProveedor.Location = new System.Drawing.Point(313, 17);
            this.textIdProveedor.Name = "textIdProveedor";
            this.textIdProveedor.Size = new System.Drawing.Size(26, 20);
            this.textIdProveedor.TabIndex = 28;
            this.textIdProveedor.Visible = false;
            // 
            // btnbuscarCliente
            // 
            this.btnbuscarCliente.BackColor = System.Drawing.Color.White;
            this.btnbuscarCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbuscarCliente.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnbuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbuscarCliente.ForeColor = System.Drawing.Color.Transparent;
            this.btnbuscarCliente.IconChar = FontAwesome.Sharp.IconChar.Searchengin;
            this.btnbuscarCliente.IconColor = System.Drawing.Color.Black;
            this.btnbuscarCliente.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnbuscarCliente.IconSize = 20;
            this.btnbuscarCliente.Location = new System.Drawing.Point(139, 44);
            this.btnbuscarCliente.Name = "btnbuscarCliente";
            this.btnbuscarCliente.Size = new System.Drawing.Size(32, 19);
            this.btnbuscarCliente.TabIndex = 27;
            this.btnbuscarCliente.UseVisualStyleBackColor = false;
            this.btnbuscarCliente.Click += new System.EventHandler(this.btnbuscarCliente_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.White;
            this.label16.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label16.Location = new System.Drawing.Point(174, 27);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(94, 13);
            this.label16.TabIndex = 14;
            this.label16.Text = ":Nombre Completo";
            // 
            // textDocumentoCliente
            // 
            this.textDocumentoCliente.Location = new System.Drawing.Point(10, 44);
            this.textDocumentoCliente.Name = "textDocumentoCliente";
            this.textDocumentoCliente.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textDocumentoCliente.Size = new System.Drawing.Size(123, 20);
            this.textDocumentoCliente.TabIndex = 8;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(7, 28);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(89, 13);
            this.label17.TabIndex = 7;
            this.label17.Text = ":Nroº Documento";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.White;
            this.groupBox4.Controls.Add(this.CboDocumento);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.textFecha);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Location = new System.Drawing.Point(149, 48);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(311, 73);
            this.groupBox4.TabIndex = 34;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Informacion Venta";
            // 
            // CboDocumento
            // 
            this.CboDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboDocumento.FormattingEnabled = true;
            this.CboDocumento.Location = new System.Drawing.Point(144, 42);
            this.CboDocumento.Name = "CboDocumento";
            this.CboDocumento.Size = new System.Drawing.Size(162, 21);
            this.CboDocumento.TabIndex = 15;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.White;
            this.label14.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label14.Location = new System.Drawing.Point(141, 27);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 13);
            this.label14.TabIndex = 14;
            this.label14.Text = ":Tipo Documento";
            // 
            // textFecha
            // 
            this.textFecha.Location = new System.Drawing.Point(10, 42);
            this.textFecha.Name = "textFecha";
            this.textFecha.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textFecha.Size = new System.Drawing.Size(123, 20);
            this.textFecha.TabIndex = 8;
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
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.White;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(144, 20);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(146, 25);
            this.label13.TabIndex = 33;
            this.label13.Text = "Registrar Venta";
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(128, 9);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.label10.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label10.Size = new System.Drawing.Size(695, 408);
            this.label10.TabIndex = 32;
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // textTotalPagar
            // 
            this.textTotalPagar.Location = new System.Drawing.Point(726, 249);
            this.textTotalPagar.Name = "textTotalPagar";
            this.textTotalPagar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textTotalPagar.Size = new System.Drawing.Size(91, 20);
            this.textTotalPagar.TabIndex = 42;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(729, 233);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = ":Total a Pagar";
            // 
            // textPagarcon
            // 
            this.textPagarcon.Location = new System.Drawing.Point(726, 288);
            this.textPagarcon.Name = "textPagarcon";
            this.textPagarcon.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textPagarcon.Size = new System.Drawing.Size(91, 20);
            this.textPagarcon.TabIndex = 44;
            this.textPagarcon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textPagarcon_KeyDown);
            this.textPagarcon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textPagarcon_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(729, 272);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 43;
            this.label2.Text = ":Paga con";
            // 
            // textCambio
            // 
            this.textCambio.Location = new System.Drawing.Point(726, 327);
            this.textCambio.Name = "textCambio";
            this.textCambio.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textCambio.Size = new System.Drawing.Size(91, 20);
            this.textCambio.TabIndex = 46;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(729, 311);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 45;
            this.label3.Text = ":Cambio";
            // 
            // btnCrearVenta
            // 
            this.btnCrearVenta.IconChar = FontAwesome.Sharp.IconChar.ExternalLinkSquareAlt;
            this.btnCrearVenta.IconColor = System.Drawing.Color.DodgerBlue;
            this.btnCrearVenta.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCrearVenta.IconSize = 18;
            this.btnCrearVenta.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCrearVenta.Location = new System.Drawing.Point(726, 353);
            this.btnCrearVenta.Name = "btnCrearVenta";
            this.btnCrearVenta.Size = new System.Drawing.Size(91, 31);
            this.btnCrearVenta.TabIndex = 40;
            this.btnCrearVenta.Text = "Crear Venta";
            this.btnCrearVenta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCrearVenta.UseVisualStyleBackColor = true;
            this.btnCrearVenta.Click += new System.EventHandler(this.btnCrearVenta_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.IconChar = FontAwesome.Sharp.IconChar.PlusSquare;
            this.btnAgregar.IconColor = System.Drawing.Color.Green;
            this.btnAgregar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAgregar.IconSize = 37;
            this.btnAgregar.Location = new System.Drawing.Point(729, 134);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 66);
            this.btnAgregar.TabIndex = 38;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // IdProducto
            // 
            this.IdProducto.HeaderText = "IdProducto";
            this.IdProducto.Name = "IdProducto";
            this.IdProducto.ReadOnly = true;
            this.IdProducto.Visible = false;
            this.IdProducto.Width = 150;
            // 
            // Producto
            // 
            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            this.Producto.ReadOnly = true;
            this.Producto.Width = 150;
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio ";
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            this.Precio.Width = 120;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // Subtotal
            // 
            this.Subtotal.HeaderText = "SubTotal";
            this.Subtotal.Name = "Subtotal";
            this.Subtotal.ReadOnly = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.HeaderText = "";
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.ReadOnly = true;
            this.btnEliminar.Width = 28;
            // 
            // FormVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 523);
            this.Controls.Add(this.textCambio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textPagarcon);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textTotalPagar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCrearVenta);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dgvdata);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label10);
            this.Name = "FormVentas";
            this.Text = "FormVentas";
            this.Load += new System.EventHandler(this.FormVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cantidadnumericupdown)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label18;
        private FontAwesome.Sharp.IconButton btnCrearVenta;
        private FontAwesome.Sharp.IconButton btnAgregar;
        private System.Windows.Forms.DataGridView dgvdata;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.NumericUpDown cantidadnumericupdown;
        private System.Windows.Forms.TextBox textStockProducto;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox textPrecioProducto;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtProducto;
        private System.Windows.Forms.TextBox txtIdProducto;
        private FontAwesome.Sharp.IconButton btnBuscarProducto1;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtCodProducto;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox textNombreCliente;
        private System.Windows.Forms.TextBox textIdProveedor;
        private FontAwesome.Sharp.IconButton btnbuscarCliente;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textDocumentoCliente;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox CboDocumento;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textFecha;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textTotalPagar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textPagarcon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textCambio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subtotal;
        private System.Windows.Forms.DataGridViewButtonColumn btnEliminar;
    }
}