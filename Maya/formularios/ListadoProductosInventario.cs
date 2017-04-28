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
    public partial class ListadoProductosInventario : Form
    {
        private readonly mayaEntities _entities;
        private readonly usuarios _user;
        private punto_venta _pv;
        public ListadoProductosInventario(usuarios user, int id_punto_venta)
        {
            InitializeComponent();
            _entities = new mayaEntities();
            _user = user;
            _pv =
                (punto_venta) _entities.GetObjectByKey(new EntityKey("mayaEntities.punto_venta", "id", id_punto_venta));
        }

        private void ListadoProductosInventario_Load(object sender, EventArgs e)
        {
            this.Reload();
        }
        public void Reload()
        {
            try
            {
                decimal total = 0;
                foreach (var p in _entities.productos.Where(pr => pr.id_punto_venta == _pv.id && pr.vendido == null))
                {
                    if (p.fecha_salida != null)
                        printableListView1.Items.Add(new ListViewItem(new[]
                                                                          {
                                                                              p.id,
                                                                              p.tipo_producto.valor,
                                                                              p.descripcion,
                                                                              p.id_tejedora != 9999 ? p.tejedora.id +"--"+ p.tejedora.nombre : p.tejedora.nombre + " (" + p.tejedora_anterior + ")",
                                                                              p.fecha_salida.Value.ToString("dd/MM/yyyy"),
                                                                              Math.Round(
                                                                                Convert.ToDecimal(p.precio,
                                                                                CultureInfo.InvariantCulture), 2).ToString()
                                                                          }));
                    total += p.precio.Value;
                }
                printableListView1.Items.Add(new ListViewItem(new[]
                                                                          {
                                                                              "",
                                                                              "",
                                                                              "",
                                                                              "",
                                                                              "",
                                                                              Math.Round(
                                                                                Convert.ToDecimal(total,
                                                                                CultureInfo.InvariantCulture), 2).ToString()
                                                                          }));
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            printableListView1.PrintPreview();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            printableListView1.Print();
        }
    }
}
