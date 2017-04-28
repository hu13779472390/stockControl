using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Maya.formularios
{
    public partial class ProductosMasVendidos : Form
    {
        private readonly mayaEntities _entities;
        public ProductosMasVendidos()
        {
            InitializeComponent();
            _entities = new mayaEntities();
        }

        private void ProductosMasVendidos_Load(object sender, EventArgs e)
        {
            this.Reload();
        }
        private void Reload()
        {
            try
            {
                decimal valor = 0;
                var cantidad = 0;
                List<productos> aux = new List<productos>();
                foreach (var tp in _entities.tipo_producto)
                {
                    aux = _entities.productos.Where(p => p.vendido == 1 && p.id_tipo_producto == tp.id).ToList();
                    if(aux.Count == 0)
                        continue;
                    cantidad = aux.Where(p => p.fecha_venta.Value.DayOfYear >= fecha_inicio.Value.DayOfYear && p.fecha_venta.Value.DayOfYear <= fecha_fin.Value.DayOfYear).Count();
                    valor = Enumerable.Sum(
                        aux.Where(p => p.fecha_venta.Value.DayOfYear >= fecha_inicio.Value.DayOfYear && p.fecha_venta.Value.DayOfYear <= fecha_fin.Value.DayOfYear), pro => pro.precio).Value;
                    if(cantidad != 0 && valor != 0)
                    {
                        printableListView1.Items.Add(new ListViewItem(new[]
                                                                          {
                                                                              tp.valor,
                                                                              cantidad.ToString(),
                                                                              Math.Round(
                                                                                       Convert.ToDecimal(valor,
                                                                                                         CultureInfo.
                                                                                                             InvariantCulture),
                                                                                       2)
                                                                                       .ToString()
                                                                          }));
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error en el sistema, intente realizar la operación nuevaente", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void filtrar_Click(object sender, EventArgs e)
        {
            this.Reload();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.printableListView1.Title = "Reporte de productos que más se venden";
            this.printableListView1.PrintPreview();
        }

        private void Imprimir_Click(object sender, EventArgs e)
        {
            this.printableListView1.Title = "Reporte de productos que más se venden";
            this.printableListView1.Print();
        }
    }
}
