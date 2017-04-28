namespace Maya.formularios
{
    partial class EliminarProductos
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
            this.printableListView1 = new PrintableListView.PrintableListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.eliminarButton = new System.Windows.Forms.Button();
            this.modificarButton = new System.Windows.Forms.Button();
            this.cancelar = new System.Windows.Forms.Button();
            this.aceptar = new System.Windows.Forms.Button();
            this.lbIdentificador = new System.Windows.Forms.Label();
            this.fecha_entrada = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.cbTejedora = new System.Windows.Forms.ComboBox();
            this.nValor = new System.Windows.Forms.NumericUpDown();
            this.tbDescripcion = new System.Windows.Forms.TextBox();
            this.cbTipoProducto = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.nValor)).BeginInit();
            this.SuspendLayout();
            // 
            // printableListView1
            // 
            this.printableListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.printableListView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.printableListView1.FitToPage = false;
            this.printableListView1.GridLines = true;
            this.printableListView1.Location = new System.Drawing.Point(0, 0);
            this.printableListView1.Name = "printableListView1";
            this.printableListView1.Size = new System.Drawing.Size(812, 252);
            this.printableListView1.TabIndex = 0;
            this.printableListView1.Title = "";
            this.printableListView1.UseCompatibleStateImageBehavior = false;
            this.printableListView1.View = System.Windows.Forms.View.Details;
            this.printableListView1.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.printableListView1_ItemSelectionChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Identificador";
            this.columnHeader1.Width = 96;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Descripcion";
            this.columnHeader2.Width = 238;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Valor";
            this.columnHeader3.Width = 65;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Tejedora";
            this.columnHeader4.Width = 168;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Tipo de Producto";
            this.columnHeader5.Width = 166;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 301);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Identificador:";
            // 
            // eliminarButton
            // 
            this.eliminarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eliminarButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.eliminarButton.Location = new System.Drawing.Point(86, 258);
            this.eliminarButton.Name = "eliminarButton";
            this.eliminarButton.Size = new System.Drawing.Size(77, 26);
            this.eliminarButton.TabIndex = 46;
            this.eliminarButton.Text = "&Eliminar";
            this.eliminarButton.UseVisualStyleBackColor = true;
            this.eliminarButton.Click += new System.EventHandler(this.eliminarButton_Click);
            // 
            // modificarButton
            // 
            this.modificarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modificarButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.modificarButton.Location = new System.Drawing.Point(8, 258);
            this.modificarButton.Name = "modificarButton";
            this.modificarButton.Size = new System.Drawing.Size(72, 26);
            this.modificarButton.TabIndex = 45;
            this.modificarButton.Text = "&Modificar";
            this.modificarButton.UseVisualStyleBackColor = true;
            this.modificarButton.Click += new System.EventHandler(this.modificarButton_Click);
            // 
            // cancelar
            // 
            this.cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelar.Location = new System.Drawing.Point(656, 358);
            this.cancelar.Name = "cancelar";
            this.cancelar.Size = new System.Drawing.Size(75, 23);
            this.cancelar.TabIndex = 50;
            this.cancelar.Text = "Cancelar";
            this.cancelar.UseVisualStyleBackColor = true;
            this.cancelar.Click += new System.EventHandler(this.cancelar_Click);
            // 
            // aceptar
            // 
            this.aceptar.Location = new System.Drawing.Point(573, 358);
            this.aceptar.Name = "aceptar";
            this.aceptar.Size = new System.Drawing.Size(75, 23);
            this.aceptar.TabIndex = 49;
            this.aceptar.Text = "Aceptar";
            this.aceptar.UseVisualStyleBackColor = true;
            this.aceptar.Click += new System.EventHandler(this.aceptar_Click);
            // 
            // lbIdentificador
            // 
            this.lbIdentificador.AutoSize = true;
            this.lbIdentificador.Location = new System.Drawing.Point(105, 301);
            this.lbIdentificador.Name = "lbIdentificador";
            this.lbIdentificador.Size = new System.Drawing.Size(30, 13);
            this.lbIdentificador.TabIndex = 51;
            this.lbIdentificador.Text = "texto";
            // 
            // fecha_entrada
            // 
            this.fecha_entrada.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fecha_entrada.Location = new System.Drawing.Point(350, 347);
            this.fecha_entrada.Name = "fecha_entrada";
            this.fecha_entrada.Size = new System.Drawing.Size(177, 20);
            this.fecha_entrada.TabIndex = 61;
            this.fecha_entrada.ValueChanged += new System.EventHandler(this.fecha_entrada_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(250, 353);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 13);
            this.label6.TabIndex = 60;
            this.label6.Text = "Fecha de entrada:";
            // 
            // cbTejedora
            // 
            this.cbTejedora.FormattingEnabled = true;
            this.cbTejedora.Location = new System.Drawing.Point(350, 320);
            this.cbTejedora.Name = "cbTejedora";
            this.cbTejedora.Size = new System.Drawing.Size(177, 21);
            this.cbTejedora.TabIndex = 59;
            this.cbTejedora.SelectedIndexChanged += new System.EventHandler(this.cbTejedora_SelectedIndexChanged);
            // 
            // nValor
            // 
            this.nValor.DecimalPlaces = 2;
            this.nValor.Location = new System.Drawing.Point(108, 347);
            this.nValor.Name = "nValor";
            this.nValor.Size = new System.Drawing.Size(120, 20);
            this.nValor.TabIndex = 58;
            // 
            // tbDescripcion
            // 
            this.tbDescripcion.Location = new System.Drawing.Point(555, 286);
            this.tbDescripcion.Multiline = true;
            this.tbDescripcion.Name = "tbDescripcion";
            this.tbDescripcion.Size = new System.Drawing.Size(177, 59);
            this.tbDescripcion.TabIndex = 57;
            // 
            // cbTipoProducto
            // 
            this.cbTipoProducto.FormattingEnabled = true;
            this.cbTipoProducto.Location = new System.Drawing.Point(108, 320);
            this.cbTipoProducto.Name = "cbTipoProducto";
            this.cbTipoProducto.Size = new System.Drawing.Size(177, 21);
            this.cbTipoProducto.TabIndex = 56;
            this.cbTipoProducto.SelectedIndexChanged += new System.EventHandler(this.cbTipoProducto_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(292, 323);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 55;
            this.label5.Text = "Tejedora:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(68, 349);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 54;
            this.label4.Text = "Valor:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(483, 289);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 53;
            this.label3.Text = "Descripción:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 323);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 52;
            this.label2.Text = "Tipo de producto:";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Fecha de Entrada";
            this.columnHeader6.Width = 121;
            // 
            // EliminarProductos
            // 
            this.AcceptButton = this.aceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelar;
            this.ClientSize = new System.Drawing.Size(812, 393);
            this.Controls.Add(this.fecha_entrada);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbTejedora);
            this.Controls.Add(this.nValor);
            this.Controls.Add(this.tbDescripcion);
            this.Controls.Add(this.cbTipoProducto);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbIdentificador);
            this.Controls.Add(this.cancelar);
            this.Controls.Add(this.aceptar);
            this.Controls.Add(this.eliminarButton);
            this.Controls.Add(this.modificarButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.printableListView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EliminarProductos";
            this.Text = "EliminarProductos";
            this.Load += new System.EventHandler(this.EliminarProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nValor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PrintableListView.PrintableListView printableListView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button eliminarButton;
        private System.Windows.Forms.Button modificarButton;
        private System.Windows.Forms.Button cancelar;
        private System.Windows.Forms.Button aceptar;
        private System.Windows.Forms.Label lbIdentificador;
        private System.Windows.Forms.DateTimePicker fecha_entrada;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbTejedora;
        private System.Windows.Forms.NumericUpDown nValor;
        private System.Windows.Forms.TextBox tbDescripcion;
        private System.Windows.Forms.ComboBox cbTipoProducto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}