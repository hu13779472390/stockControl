namespace Maya.formularios
{
    partial class EntradaProductos
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbTipoProducto = new System.Windows.Forms.ComboBox();
            this.tbDescripcion = new System.Windows.Forms.TextBox();
            this.nValor = new System.Windows.Forms.NumericUpDown();
            this.cbTejedora = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.fecha_entrada = new System.Windows.Forms.DateTimePicker();
            this.aceptarButton = new System.Windows.Forms.Button();
            this.cancelarButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.chboxAgregar = new System.Windows.Forms.CheckBox();
            this.numero_repetir = new System.Windows.Forms.NumericUpDown();
            this.txIdentificador = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nValor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numero_repetir)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Identificador:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tipo de producto:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Descripción:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(67, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Valor:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(49, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Tejedora:";
            // 
            // cbTipoProducto
            // 
            this.cbTipoProducto.FormattingEnabled = true;
            this.cbTipoProducto.Location = new System.Drawing.Point(107, 38);
            this.cbTipoProducto.Name = "cbTipoProducto";
            this.cbTipoProducto.Size = new System.Drawing.Size(177, 21);
            this.cbTipoProducto.TabIndex = 6;
            this.cbTipoProducto.SelectedIndexChanged += new System.EventHandler(this.cbTipoProducto_SelectedIndexChanged);
            // 
            // tbDescripcion
            // 
            this.tbDescripcion.Location = new System.Drawing.Point(107, 74);
            this.tbDescripcion.Multiline = true;
            this.tbDescripcion.Name = "tbDescripcion";
            this.tbDescripcion.Size = new System.Drawing.Size(177, 59);
            this.tbDescripcion.TabIndex = 7;
            // 
            // nValor
            // 
            this.nValor.DecimalPlaces = 2;
            this.nValor.Location = new System.Drawing.Point(107, 145);
            this.nValor.Name = "nValor";
            this.nValor.Size = new System.Drawing.Size(120, 20);
            this.nValor.TabIndex = 8;
            // 
            // cbTejedora
            // 
            this.cbTejedora.FormattingEnabled = true;
            this.cbTejedora.Location = new System.Drawing.Point(107, 172);
            this.cbTejedora.Name = "cbTejedora";
            this.cbTejedora.Size = new System.Drawing.Size(177, 21);
            this.cbTejedora.TabIndex = 9;
            this.cbTejedora.SelectedIndexChanged += new System.EventHandler(this.cbTejedora_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 211);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Fecha de entrada:";
            // 
            // fecha_entrada
            // 
            this.fecha_entrada.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fecha_entrada.Location = new System.Drawing.Point(107, 205);
            this.fecha_entrada.Name = "fecha_entrada";
            this.fecha_entrada.Size = new System.Drawing.Size(177, 20);
            this.fecha_entrada.TabIndex = 11;
            this.fecha_entrada.ValueChanged += new System.EventHandler(this.fecha_entrada_ValueChanged);
            // 
            // aceptarButton
            // 
            this.aceptarButton.Location = new System.Drawing.Point(25, 289);
            this.aceptarButton.Name = "aceptarButton";
            this.aceptarButton.Size = new System.Drawing.Size(75, 23);
            this.aceptarButton.TabIndex = 12;
            this.aceptarButton.Text = "Aceptar";
            this.aceptarButton.UseVisualStyleBackColor = true;
            this.aceptarButton.Click += new System.EventHandler(this.aceptarButton_Click);
            // 
            // cancelarButton
            // 
            this.cancelarButton.Location = new System.Drawing.Point(208, 289);
            this.cancelarButton.Name = "cancelarButton";
            this.cancelarButton.Size = new System.Drawing.Size(75, 23);
            this.cancelarButton.TabIndex = 13;
            this.cancelarButton.Text = "Cancelar";
            this.cancelarButton.UseVisualStyleBackColor = true;
            this.cancelarButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(116, 289);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 14;
            this.button3.Text = "Limpiar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // chboxAgregar
            // 
            this.chboxAgregar.AutoSize = true;
            this.chboxAgregar.Location = new System.Drawing.Point(10, 232);
            this.chboxAgregar.Name = "chboxAgregar";
            this.chboxAgregar.Size = new System.Drawing.Size(150, 17);
            this.chboxAgregar.TabIndex = 0;
            this.chboxAgregar.Text = "Agregar elementos iguales";
            this.chboxAgregar.UseVisualStyleBackColor = true;
            this.chboxAgregar.CheckedChanged += new System.EventHandler(this.chboxAgregar_CheckedChanged);
            // 
            // numero_repetir
            // 
            this.numero_repetir.Location = new System.Drawing.Point(10, 255);
            this.numero_repetir.Name = "numero_repetir";
            this.numero_repetir.Size = new System.Drawing.Size(150, 20);
            this.numero_repetir.TabIndex = 15;
            // 
            // txIdentificador
            // 
            this.txIdentificador.Location = new System.Drawing.Point(107, 6);
            this.txIdentificador.Name = "txIdentificador";
            this.txIdentificador.Size = new System.Drawing.Size(94, 20);
            this.txIdentificador.TabIndex = 16;
            // 
            // EntradaProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 324);
            this.Controls.Add(this.txIdentificador);
            this.Controls.Add(this.numero_repetir);
            this.Controls.Add(this.chboxAgregar);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.cancelarButton);
            this.Controls.Add(this.aceptarButton);
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
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EntradaProductos";
            this.Text = "Entrada de Productos";
            this.Load += new System.EventHandler(this.EntradaProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nValor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numero_repetir)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbTipoProducto;
        private System.Windows.Forms.TextBox tbDescripcion;
        private System.Windows.Forms.NumericUpDown nValor;
        private System.Windows.Forms.ComboBox cbTejedora;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker fecha_entrada;
        private System.Windows.Forms.Button aceptarButton;
        private System.Windows.Forms.Button cancelarButton;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox chboxAgregar;
        private System.Windows.Forms.NumericUpDown numero_repetir;
        private System.Windows.Forms.TextBox txIdentificador;
    }
}