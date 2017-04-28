namespace Maya.formularios
{
    partial class GestionarTiposProductos
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
            this.eliminarButton = new System.Windows.Forms.Button();
            this.modificarButton = new System.Windows.Forms.Button();
            this.NuevoButton = new System.Windows.Forms.Button();
            this.printableListView1 = new PrintableListView.PrintableListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.tbxTipoProducto = new System.Windows.Forms.TextBox();
            this.aceptarButton = new System.Windows.Forms.Button();
            this.cancelarButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.numericIdentificador = new System.Windows.Forms.NumericUpDown();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.numericIdentificador)).BeginInit();
            this.SuspendLayout();
            // 
            // eliminarButton
            // 
            this.eliminarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eliminarButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.eliminarButton.Location = new System.Drawing.Point(193, 234);
            this.eliminarButton.Name = "eliminarButton";
            this.eliminarButton.Size = new System.Drawing.Size(77, 26);
            this.eliminarButton.TabIndex = 52;
            this.eliminarButton.Text = "&Eliminar";
            this.eliminarButton.UseVisualStyleBackColor = true;
            this.eliminarButton.Click += new System.EventHandler(this.eliminarButton_Click);
            // 
            // modificarButton
            // 
            this.modificarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modificarButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.modificarButton.Location = new System.Drawing.Point(100, 234);
            this.modificarButton.Name = "modificarButton";
            this.modificarButton.Size = new System.Drawing.Size(72, 26);
            this.modificarButton.TabIndex = 51;
            this.modificarButton.Text = "&Modificar";
            this.modificarButton.UseVisualStyleBackColor = true;
            this.modificarButton.Click += new System.EventHandler(this.modificarButton_Click);
            // 
            // NuevoButton
            // 
            this.NuevoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NuevoButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.NuevoButton.Location = new System.Drawing.Point(19, 234);
            this.NuevoButton.Name = "NuevoButton";
            this.NuevoButton.Size = new System.Drawing.Size(64, 26);
            this.NuevoButton.TabIndex = 50;
            this.NuevoButton.Text = "&Nuevo";
            this.NuevoButton.UseVisualStyleBackColor = true;
            this.NuevoButton.Click += new System.EventHandler(this.NuevoButton_Click);
            // 
            // printableListView1
            // 
            this.printableListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader1});
            this.printableListView1.FitToPage = false;
            this.printableListView1.GridLines = true;
            this.printableListView1.Location = new System.Drawing.Point(-1, -2);
            this.printableListView1.Name = "printableListView1";
            this.printableListView1.Size = new System.Drawing.Size(296, 230);
            this.printableListView1.TabIndex = 53;
            this.printableListView1.Title = "";
            this.printableListView1.UseCompatibleStateImageBehavior = false;
            this.printableListView1.View = System.Windows.Forms.View.Details;
            this.printableListView1.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.printableListView1_ItemSelectionChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.DisplayIndex = 0;
            this.columnHeader1.Text = "Tipo de Producto";
            this.columnHeader1.Width = 217;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 310);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 54;
            this.label1.Text = "Tipo de Producto:";
            // 
            // tbxTipoProducto
            // 
            this.tbxTipoProducto.Location = new System.Drawing.Point(116, 307);
            this.tbxTipoProducto.Name = "tbxTipoProducto";
            this.tbxTipoProducto.Size = new System.Drawing.Size(156, 20);
            this.tbxTipoProducto.TabIndex = 55;
            // 
            // aceptarButton
            // 
            this.aceptarButton.Location = new System.Drawing.Point(116, 333);
            this.aceptarButton.Name = "aceptarButton";
            this.aceptarButton.Size = new System.Drawing.Size(75, 23);
            this.aceptarButton.TabIndex = 56;
            this.aceptarButton.Text = "Aceptar";
            this.aceptarButton.UseVisualStyleBackColor = true;
            this.aceptarButton.Click += new System.EventHandler(this.aceptarButton_Click);
            // 
            // cancelarButton
            // 
            this.cancelarButton.Location = new System.Drawing.Point(210, 333);
            this.cancelarButton.Name = "cancelarButton";
            this.cancelarButton.Size = new System.Drawing.Size(75, 23);
            this.cancelarButton.TabIndex = 57;
            this.cancelarButton.Text = "Cancelar";
            this.cancelarButton.UseVisualStyleBackColor = true;
            this.cancelarButton.Click += new System.EventHandler(this.cancelarButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 280);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 58;
            this.label2.Text = "Identificador:";
            // 
            // numericIdentificador
            // 
            this.numericIdentificador.Location = new System.Drawing.Point(116, 278);
            this.numericIdentificador.Name = "numericIdentificador";
            this.numericIdentificador.Size = new System.Drawing.Size(156, 20);
            this.numericIdentificador.TabIndex = 59;
            // 
            // columnHeader2
            // 
            this.columnHeader2.DisplayIndex = 1;
            this.columnHeader2.Text = "Identificador";
            this.columnHeader2.Width = 72;
            // 
            // GestionarTiposProductos
            // 
            this.AcceptButton = this.aceptarButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelarButton;
            this.ClientSize = new System.Drawing.Size(293, 368);
            this.Controls.Add(this.numericIdentificador);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cancelarButton);
            this.Controls.Add(this.aceptarButton);
            this.Controls.Add(this.tbxTipoProducto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.printableListView1);
            this.Controls.Add(this.eliminarButton);
            this.Controls.Add(this.modificarButton);
            this.Controls.Add(this.NuevoButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "GestionarTiposProductos";
            this.Text = "Gestionar los Tipos de Productos";
            this.Load += new System.EventHandler(this.GestionarTiposProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericIdentificador)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button eliminarButton;
        private System.Windows.Forms.Button modificarButton;
        private System.Windows.Forms.Button NuevoButton;
        private PrintableListView.PrintableListView printableListView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxTipoProducto;
        private System.Windows.Forms.Button aceptarButton;
        private System.Windows.Forms.Button cancelarButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericIdentificador;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}