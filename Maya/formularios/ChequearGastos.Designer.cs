namespace Maya.formularios
{
    partial class ChequearGastos
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
            this.label1 = new System.Windows.Forms.Label();
            this.fecha_inicio = new System.Windows.Forms.DateTimePicker();
            this.fecha_fin = new System.Windows.Forms.DateTimePicker();
            this.lbl = new System.Windows.Forms.Label();
            this.filtrar = new System.Windows.Forms.Button();
            this.Imprimir = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // printableListView1
            // 
            this.printableListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.printableListView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.printableListView1.FitToPage = false;
            this.printableListView1.GridLines = true;
            this.printableListView1.Location = new System.Drawing.Point(0, 51);
            this.printableListView1.Name = "printableListView1";
            this.printableListView1.Size = new System.Drawing.Size(633, 365);
            this.printableListView1.TabIndex = 0;
            this.printableListView1.Title = "";
            this.printableListView1.UseCompatibleStateImageBehavior = false;
            this.printableListView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Fecha";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Descripción";
            this.columnHeader2.Width = 450;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Valor";
            this.columnHeader3.Width = 78;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fecha Inicio:";
            // 
            // fecha_inicio
            // 
            this.fecha_inicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fecha_inicio.Location = new System.Drawing.Point(12, 25);
            this.fecha_inicio.Name = "fecha_inicio";
            this.fecha_inicio.Size = new System.Drawing.Size(102, 20);
            this.fecha_inicio.TabIndex = 2;
            // 
            // fecha_fin
            // 
            this.fecha_fin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fecha_fin.Location = new System.Drawing.Point(120, 25);
            this.fecha_fin.Name = "fecha_fin";
            this.fecha_fin.Size = new System.Drawing.Size(102, 20);
            this.fecha_fin.TabIndex = 4;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(120, 9);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(57, 13);
            this.lbl.TabIndex = 3;
            this.lbl.Text = "Fecha Fin:";
            // 
            // filtrar
            // 
            this.filtrar.Location = new System.Drawing.Point(228, 9);
            this.filtrar.Name = "filtrar";
            this.filtrar.Size = new System.Drawing.Size(46, 36);
            this.filtrar.TabIndex = 5;
            this.filtrar.Text = "Filtrar";
            this.filtrar.UseVisualStyleBackColor = true;
            this.filtrar.Click += new System.EventHandler(this.filtrar_Click);
            // 
            // Imprimir
            // 
            this.Imprimir.Location = new System.Drawing.Point(546, 16);
            this.Imprimir.Name = "Imprimir";
            this.Imprimir.Size = new System.Drawing.Size(75, 23);
            this.Imprimir.TabIndex = 6;
            this.Imprimir.Text = "Imprimir";
            this.Imprimir.UseVisualStyleBackColor = true;
            this.Imprimir.Click += new System.EventHandler(this.Imprimir_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(465, 16);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Vista Previa";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ChequearGastos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 416);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Imprimir);
            this.Controls.Add(this.filtrar);
            this.Controls.Add(this.fecha_fin);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.fecha_inicio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.printableListView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChequearGastos";
            this.Text = "Chequear Gastos";
            this.Load += new System.EventHandler(this.ChequearGastos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PrintableListView.PrintableListView printableListView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker fecha_inicio;
        private System.Windows.Forms.DateTimePicker fecha_fin;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Button filtrar;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button Imprimir;
        private System.Windows.Forms.Button button2;
    }
}