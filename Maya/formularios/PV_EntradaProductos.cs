using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Maya.formularios
{
    public partial class PV_EntradaProductos : Form
    {
        private readonly mayaEntities _entities;
        private readonly usuarios _user;
        private List<int> _idPuntoVenta;
        public PV_EntradaProductos(usuarios user)
        {
            InitializeComponent();
            _user = user;
            _entities = new mayaEntities();
            _idPuntoVenta = new List<int>();
        }
        public void Reload()
        {
            try
            {
                foreach (var pv in _entities.punto_venta)
                {
                    dataGridView1.Rows.Add(new object[]
                                       {
                                           pv.valor,
                                           inventario.Text = "Inventario",
                                           entrada.Text = "Entrada",
                                           salida.Text = "Salida"
                                       });
                    _idPuntoVenta.Add(pv.id);
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        private void PV_EntradaProductos_Load(object sender, EventArgs e)
        {
            this.Reload();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == -1) return;

            if(dataGridView1.Columns[e.ColumnIndex].Name == "entrada")
            {
                
                PVListadoProductos lp = new PVListadoProductos(this._user, _idPuntoVenta[e.RowIndex]);
                lp.ShowDialog();
            }
            if(dataGridView1.Columns[e.ColumnIndex].Name == "salida")
            {
                PVSalidaProductos pvs = new PVSalidaProductos(this._user, _idPuntoVenta[e.RowIndex]);
                pvs.ShowDialog();
            }
            if(dataGridView1.Columns[e.ColumnIndex].Name == "inventario")
            {
                ListadoProductosInventario lpi = new ListadoProductosInventario(this._user, _idPuntoVenta[e.RowIndex]);
                lpi.ShowDialog();
            }
        }
    }
}
