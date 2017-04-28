namespace Maya.formularios
{
    partial class PV_EntradaProductos
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.punto_venta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inventario = new System.Windows.Forms.DataGridViewButtonColumn();
            this.entrada = new System.Windows.Forms.DataGridViewButtonColumn();
            this.salida = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.punto_venta,
            this.inventario,
            this.entrada,
            this.salida});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(658, 262);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // punto_venta
            // 
            this.punto_venta.HeaderText = "Punto de Venta";
            this.punto_venta.Name = "punto_venta";
            this.punto_venta.ReadOnly = true;
            // 
            // inventario
            // 
            this.inventario.HeaderText = "Inventario";
            this.inventario.Name = "inventario";
            this.inventario.ReadOnly = true;
            // 
            // entrada
            // 
            this.entrada.HeaderText = "Entrada a Productos";
            this.entrada.Name = "entrada";
            this.entrada.ReadOnly = true;
            // 
            // salida
            // 
            this.salida.HeaderText = "Salida a Productos";
            this.salida.Name = "salida";
            this.salida.ReadOnly = true;
            // 
            // PV_EntradaProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 262);
            this.Controls.Add(this.dataGridView1);
            this.Name = "PV_EntradaProductos";
            this.Text = "Punto de Ventas>Entrada de Productos";
            this.Load += new System.EventHandler(this.PV_EntradaProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn punto_venta;
        private System.Windows.Forms.DataGridViewButtonColumn inventario;
        private System.Windows.Forms.DataGridViewButtonColumn entrada;
        private System.Windows.Forms.DataGridViewButtonColumn salida;
    }
}