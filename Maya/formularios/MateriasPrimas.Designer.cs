namespace Maya.formularios
{
    partial class MateriasPrimas
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDescripcion = new System.Windows.Forms.TextBox();
            this.nCantidad = new System.Windows.Forms.NumericUpDown();
            this.aceptar = new System.Windows.Forms.Button();
            this.salir = new System.Windows.Forms.Button();
            this.printableListView1 = new PrintableListView.PrintableListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.eliminarButton = new System.Windows.Forms.Button();
            this.modificarButton = new System.Windows.Forms.Button();
            this.NuevoButton = new System.Windows.Forms.Button();
            this.aumentar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nCantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 298);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descripción:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 352);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cantidad:";
            // 
            // tbDescripcion
            // 
            this.tbDescripcion.Location = new System.Drawing.Point(90, 295);
            this.tbDescripcion.Multiline = true;
            this.tbDescripcion.Name = "tbDescripcion";
            this.tbDescripcion.Size = new System.Drawing.Size(174, 50);
            this.tbDescripcion.TabIndex = 2;
            // 
            // nCantidad
            // 
            this.nCantidad.DecimalPlaces = 2;
            this.nCantidad.Location = new System.Drawing.Point(90, 350);
            this.nCantidad.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nCantidad.Name = "nCantidad";
            this.nCantidad.Size = new System.Drawing.Size(82, 20);
            this.nCantidad.TabIndex = 3;
            // 
            // aceptar
            // 
            this.aceptar.Location = new System.Drawing.Point(143, 379);
            this.aceptar.Name = "aceptar";
            this.aceptar.Size = new System.Drawing.Size(72, 23);
            this.aceptar.TabIndex = 4;
            this.aceptar.Text = "Aceptar";
            this.aceptar.UseVisualStyleBackColor = true;
            this.aceptar.Click += new System.EventHandler(this.aceptar_Click);
            // 
            // salir
            // 
            this.salir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.salir.Location = new System.Drawing.Point(221, 379);
            this.salir.Name = "salir";
            this.salir.Size = new System.Drawing.Size(72, 23);
            this.salir.TabIndex = 6;
            this.salir.Text = "Salir";
            this.salir.UseVisualStyleBackColor = true;
            this.salir.Click += new System.EventHandler(this.salir_Click);
            // 
            // printableListView1
            // 
            this.printableListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.printableListView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.printableListView1.FitToPage = false;
            this.printableListView1.GridLines = true;
            this.printableListView1.Location = new System.Drawing.Point(0, 0);
            this.printableListView1.Name = "printableListView1";
            this.printableListView1.Size = new System.Drawing.Size(309, 238);
            this.printableListView1.TabIndex = 7;
            this.printableListView1.Title = "";
            this.printableListView1.UseCompatibleStateImageBehavior = false;
            this.printableListView1.View = System.Windows.Forms.View.Details;
            this.printableListView1.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.printableListView1_ItemSelectionChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Descripción";
            this.columnHeader1.Width = 196;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Cantidad";
            this.columnHeader2.Width = 107;
            // 
            // eliminarButton
            // 
            this.eliminarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eliminarButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.eliminarButton.Location = new System.Drawing.Point(153, 244);
            this.eliminarButton.Name = "eliminarButton";
            this.eliminarButton.Size = new System.Drawing.Size(67, 26);
            this.eliminarButton.TabIndex = 47;
            this.eliminarButton.Text = "&Eliminar";
            this.eliminarButton.UseVisualStyleBackColor = true;
            this.eliminarButton.Click += new System.EventHandler(this.eliminarButton_Click);
            // 
            // modificarButton
            // 
            this.modificarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modificarButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.modificarButton.Location = new System.Drawing.Point(76, 244);
            this.modificarButton.Name = "modificarButton";
            this.modificarButton.Size = new System.Drawing.Size(71, 26);
            this.modificarButton.TabIndex = 46;
            this.modificarButton.Text = "&Modificar";
            this.modificarButton.UseVisualStyleBackColor = true;
            this.modificarButton.Click += new System.EventHandler(this.modificarButton_Click);
            // 
            // NuevoButton
            // 
            this.NuevoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NuevoButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.NuevoButton.Location = new System.Drawing.Point(6, 244);
            this.NuevoButton.Name = "NuevoButton";
            this.NuevoButton.Size = new System.Drawing.Size(64, 26);
            this.NuevoButton.TabIndex = 45;
            this.NuevoButton.Text = "&Nuevo";
            this.NuevoButton.UseVisualStyleBackColor = true;
            this.NuevoButton.Click += new System.EventHandler(this.NuevoButton_Click);
            // 
            // aumentar
            // 
            this.aumentar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aumentar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.aumentar.Location = new System.Drawing.Point(226, 244);
            this.aumentar.Name = "aumentar";
            this.aumentar.Size = new System.Drawing.Size(74, 26);
            this.aumentar.TabIndex = 48;
            this.aumentar.Text = "Aumentar";
            this.aumentar.UseVisualStyleBackColor = true;
            this.aumentar.Click += new System.EventHandler(this.aumentar_Click);
            // 
            // MateriasPrimas
            // 
            this.AcceptButton = this.aceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.salir;
            this.ClientSize = new System.Drawing.Size(309, 413);
            this.Controls.Add(this.aumentar);
            this.Controls.Add(this.eliminarButton);
            this.Controls.Add(this.modificarButton);
            this.Controls.Add(this.NuevoButton);
            this.Controls.Add(this.printableListView1);
            this.Controls.Add(this.salir);
            this.Controls.Add(this.aceptar);
            this.Controls.Add(this.nCantidad);
            this.Controls.Add(this.tbDescripcion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MateriasPrimas";
            this.Text = "Agregar Materias Primas";
            this.Load += new System.EventHandler(this.MateriasPrimas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nCantidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbDescripcion;
        private System.Windows.Forms.NumericUpDown nCantidad;
        private System.Windows.Forms.Button aceptar;
        private System.Windows.Forms.Button salir;
        private PrintableListView.PrintableListView printableListView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button eliminarButton;
        private System.Windows.Forms.Button modificarButton;
        private System.Windows.Forms.Button NuevoButton;
        private System.Windows.Forms.Button aumentar;
    }
}