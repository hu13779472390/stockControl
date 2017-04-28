namespace Maya.formularios
{
    partial class Utilidad
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
            this.fecha_fin = new System.Windows.Forms.DateTimePicker();
            this.lbl = new System.Windows.Forms.Label();
            this.fecha_inicio = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.ventas = new System.Windows.Forms.Label();
            this.gastos = new System.Windows.Forms.Label();
            this.utilidadd = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // fecha_fin
            // 
            this.fecha_fin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fecha_fin.Location = new System.Drawing.Point(120, 24);
            this.fecha_fin.Name = "fecha_fin";
            this.fecha_fin.Size = new System.Drawing.Size(102, 20);
            this.fecha_fin.TabIndex = 13;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(120, 8);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(57, 13);
            this.lbl.TabIndex = 12;
            this.lbl.Text = "Fecha Fin:";
            // 
            // fecha_inicio
            // 
            this.fecha_inicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fecha_inicio.Location = new System.Drawing.Point(12, 24);
            this.fecha_inicio.Name = "fecha_inicio";
            this.fecha_inicio.Size = new System.Drawing.Size(102, 20);
            this.fecha_inicio.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Fecha Inicio:";
            // 
            // ventas
            // 
            this.ventas.AutoSize = true;
            this.ventas.Location = new System.Drawing.Point(12, 77);
            this.ventas.Name = "ventas";
            this.ventas.Size = new System.Drawing.Size(68, 13);
            this.ventas.TabIndex = 14;
            this.ventas.Text = "Fecha Inicio:";
            // 
            // gastos
            // 
            this.gastos.AutoSize = true;
            this.gastos.Location = new System.Drawing.Point(12, 110);
            this.gastos.Name = "gastos";
            this.gastos.Size = new System.Drawing.Size(68, 13);
            this.gastos.TabIndex = 15;
            this.gastos.Text = "Fecha Inicio:";
            // 
            // utilidadd
            // 
            this.utilidadd.AutoSize = true;
            this.utilidadd.Location = new System.Drawing.Point(12, 144);
            this.utilidadd.Name = "utilidadd";
            this.utilidadd.Size = new System.Drawing.Size(68, 13);
            this.utilidadd.TabIndex = 16;
            this.utilidadd.Text = "Fecha Inicio:";
            // 
            // Utilidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 186);
            this.Controls.Add(this.utilidadd);
            this.Controls.Add(this.gastos);
            this.Controls.Add(this.ventas);
            this.Controls.Add(this.fecha_fin);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.fecha_inicio);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Utilidad";
            this.Text = "Reporte de Utilidad";
            this.Load += new System.EventHandler(this.Utilidad_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker fecha_fin;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.DateTimePicker fecha_inicio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ventas;
        private System.Windows.Forms.Label gastos;
        private System.Windows.Forms.Label utilidadd;
    }
}