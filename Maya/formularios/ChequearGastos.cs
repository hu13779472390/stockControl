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
    public partial class ChequearGastos : Form
    {
        private readonly mayaEntities _entities;
        public ChequearGastos()
        {
            InitializeComponent();
            _entities = new mayaEntities();
        }

        private void ChequearGastos_Load(object sender, EventArgs e)
        {
            this.Reload();
        }

        private void Reload()
        {
            try
            {
                decimal x = 0;
                printableListView1.Items.Clear();
                foreach (var g in _entities.gastos.OrderByDescending(f => f.fecha))
                {
                    if(g.fecha.Date < fecha_inicio.Value.Date)
                        continue;
                    if(g.fecha.Date > fecha_fin.Value.Date)
                        continue;
                    printableListView1.Items.Add(new ListViewItem(new[]
                                                                      {
                                                                          g.fecha.Date.ToString("dd/MM/yyyy"),
                                                                          g.descripcion,
                                                                          Math.Round(
                                                                              Convert.ToDecimal(g.valor,
                                                                                                CultureInfo.
                                                                                                    InvariantCulture), 2)
                                                                              .ToString()
                                                                      }));
                    x += Math.Round(
                        Convert.ToDecimal(g.valor,
                                          CultureInfo.
                                              InvariantCulture), 2);
                }
                printableListView1.Items.Add(new ListViewItem(new[]
                                                                      {
                                                                          "",
                                                                          "",
                                                                          "Total:" + x.ToString()
                                                                      }));
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void filtrar_Click(object sender, EventArgs e)
        {
            this.Reload();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.printableListView1.Title = "Gastos";
            this.printableListView1.PrintPreview();
        }

        private void Imprimir_Click(object sender, EventArgs e)
        {
            this.printableListView1.Title = "Gastos";
            this.printableListView1.Print();
        }
    }
}
