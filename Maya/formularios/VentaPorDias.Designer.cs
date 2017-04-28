namespace Maya.formularios
{
    partial class VentaPorDias
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
            this.filtrar = new System.Windows.Forms.Button();
            this.fecha_fin = new System.Windows.Forms.DateTimePicker();
            this.lbl = new System.Windows.Forms.Label();
            this.fecha_inicio = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbPuntoVenta = new System.Windows.Forms.ComboBox();
            this.cbTejedora = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.Imprimir = new System.Windows.Forms.Button();
            this.printableListView1 = new PrintableListView.PrintableListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // filtrar
            // 
            this.filtrar.Location = new System.Drawing.Point(480, 10);
            this.filtrar.Name = "filtrar";
            this.filtrar.Size = new System.Drawing.Size(46, 36);
            this.filtrar.TabIndex = 10;
            this.filtrar.Text = "Filtrar";
            this.filtrar.UseVisualStyleBackColor = true;
            this.filtrar.Click += new System.EventHandler(this.filtrar_Click);
            // 
            // fecha_fin
            // 
            this.fecha_fin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fecha_fin.Location = new System.Drawing.Point(118, 26);
            this.fecha_fin.Name = "fecha_fin";
            this.fecha_fin.Size = new System.Drawing.Size(102, 20);
            this.fecha_fin.TabIndex = 9;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(118, 10);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(57, 13);
            this.lbl.TabIndex = 8;
            this.lbl.Text = "Fecha Fin:";
            // 
            // fecha_inicio
            // 
            this.fecha_inicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fecha_inicio.Location = new System.Drawing.Point(10, 26);
            this.fecha_inicio.Name = "fecha_inicio";
            this.fecha_inicio.Size = new System.Drawing.Size(102, 20);
            this.fecha_inicio.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Fecha Inicio:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(350, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Tejedoras:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(226, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Punto de Venta:";
            // 
            // cbPuntoVenta
            // 
            this.cbPuntoVenta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbPuntoVenta.FormattingEnabled = true;
            this.cbPuntoVenta.Location = new System.Drawing.Point(226, 25);
            this.cbPuntoVenta.Name = "cbPuntoVenta";
            this.cbPuntoVenta.Size = new System.Drawing.Size(121, 21);
            this.cbPuntoVenta.TabIndex = 13;
            // 
            // cbTejedora
            // 
            this.cbTejedora.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbTejedora.FormattingEnabled = true;
            this.cbTejedora.Location = new System.Drawing.Point(353, 25);
            this.cbTejedora.Name = "cbTejedora";
            this.cbTejedora.Size = new System.Drawing.Size(121, 21);
            this.cbTejedora.TabIndex = 14;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(533, 17);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "Vista Previa";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Imprimir
            // 
            this.Imprimir.Location = new System.Drawing.Point(614, 17);
            this.Imprimir.Name = "Imprimir";
            this.Imprimir.Size = new System.Drawing.Size(75, 23);
            this.Imprimir.TabIndex = 15;
            this.Imprimir.Text = "Imprimir";
            this.Imprimir.UseVisualStyleBackColor = true;
            // 
            // printableListView1
            // 
            this.printableListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.printableListView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.printableListView1.FitToPage = false;
            this.printableListView1.GridLines = true;
            this.printableListView1.Location = new System.Drawing.Point(0, 52);
            this.printableListView1.Name = "printableListView1";
            this.printableListView1.Size = new System.Drawing.Size(697, 359);
            this.printableListView1.TabIndex = 17;
            this.printableListView1.Title = "";
            this.printableListView1.UseCompatibleStateImageBehavior = false;
            this.printableListView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Identificador";
            this.columnHeader1.Width = 84;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Fecha de Venta";
            this.columnHeader2.Width = 93;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Tejedora";
            this.columnHeader3.Width = 191;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Punto de venta";
            this.columnHeader4.Width = 218;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Precio";
            this.columnHeader5.Width = 106;
            // 
            // VentaPorDias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 411);
            this.Controls.Add(this.printableListView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Imprimir);
            this.Controls.Add(this.cbTejedora);
            this.Controls.Add(this.cbPuntoVenta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.filtrar);
            this.Controls.Add(this.fecha_fin);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.fecha_inicio);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VentaPorDias";
            this.Text = "Venta Por Dias";
            this.Load += new System.EventHandler(this.VentaPorDias_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button filtrar;
        private System.Windows.Forms.DateTimePicker fecha_fin;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.DateTimePicker fecha_inicio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbPuntoVenta;
        private System.Windows.Forms.ComboBox cbTejedora;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button Imprimir;
        private PrintableListView.PrintableListView printableListView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}