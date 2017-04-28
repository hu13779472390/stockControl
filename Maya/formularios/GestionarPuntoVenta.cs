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
    public partial class GestionarPuntoVenta : Form
    {
        private readonly mayaEntities _entities;
        private readonly usuarios _user;
        private List<int> _idPuntoVenta;
        private int _selectedIndex;
        private bool nuevo;
        public GestionarPuntoVenta(usuarios user)
        {
            InitializeComponent();
            _entities = new mayaEntities();
            this._user = user;
            _idPuntoVenta = new List<int>();
            _selectedIndex = 0;
            nuevo = false;
        }

        private void GestionarPuntoVenta_Load(object sender, EventArgs e)
        {
            this.Reload();
        }
        private void Reload()
        {
            tbxPuntoVenta.Enabled = false;
            tbxPuntoVenta.Text = "";
            modificarButton.Enabled = false;
            eliminarButton.Enabled = false;
            aceptarButton.Visible = false;
            cancelarButton.Visible = false;

            try
            {
                printableListView1.Items.Clear();
                _idPuntoVenta = new List<int>();
                foreach (var pventa in _entities.punto_venta)
                {
                    printableListView1.Items.Add(pventa.valor);
                    _idPuntoVenta.Add(pventa.id);
                }
                _selectedIndex = -1;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void modificarButton_Click(object sender, EventArgs e)
        {
            tbxPuntoVenta.Enabled = true;
            aceptarButton.Visible = true;
            cancelarButton.Visible = true;
            nuevo = false;
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            tbxPuntoVenta.Enabled = true;
            aceptarButton.Visible = true;
            cancelarButton.Visible = true;
            tbxPuntoVenta.Text = "";
            nuevo = true;
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aceptarButton_Click(object sender, EventArgs e)
        {
            try
            {
                if(nuevo)
                {
                    if(string.IsNullOrEmpty(tbxPuntoVenta.Text))
                    {
                        MessageBox.Show("El punto de venta no puede ser vacío", "Error en la entrada de datos",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _entities.AddTopunto_venta(new punto_venta
                                                   {
                                                       valor = tbxPuntoVenta.Text
                                                   });
                    _entities.AddTobitacora(new bitacora
                                                {
                                                    id_usuario = this._user.id,
                                                    descripcion = "El usuario " + this._user.nombre + " ha creado el punto de venta " + tbxPuntoVenta.Text,
                                                    fecha = DateTime.Now
                                                });
                    _entities.SaveChanges();
                    this.Reload();

                }
                else
                {
                    punto_venta pv =
                        (punto_venta)
                        _entities.GetObjectByKey(new EntityKey("mayaEntities.punto_venta", "id",
                                                               _idPuntoVenta[_selectedIndex]));
                    if(pv.valor.Equals(tbxPuntoVenta.Text))
                        return;
                    pv.valor = tbxPuntoVenta.Text;

                    _entities.AddTobitacora(new bitacora
                                                {
                                                    id_usuario = _user.id,
                                                    descripcion = "El usuario " + _user.nombre + " ha modificado el punto de venta " + pv.valor,
                                                    fecha = DateTime.Now
                                                });
                    _entities.SaveChanges();
                    this.Reload();
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void printableListView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            modificarButton.Enabled = true;
            eliminarButton.Enabled = true;

            ListViewItem selectedItem = e.Item;
            selectedItem.Checked = true;

            if (_selectedIndex != -1 && _selectedIndex != e.ItemIndex)
                printableListView1.Items[_selectedIndex].Checked = false;

            _selectedIndex = e.ItemIndex;

            punto_venta aux =
                (punto_venta)
                _entities.GetObjectByKey(new EntityKey("mayaEntities.punto_venta", "id",
                                                       _idPuntoVenta[selectedItem.Index]));
            tbxPuntoVenta.Text = aux.valor;
        }

        private void eliminarButton_Click(object sender, EventArgs e)
        {
            try
            {
                if(MessageBox.Show("Está seguro que desa eliminar el punto de venta?", "Eliminar punto de venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    punto_venta pv =
                        (punto_venta)
                        _entities.GetObjectByKey(new EntityKey("mayaEntities.punto_venta", "id",
                                                               _idPuntoVenta[_selectedIndex]));
                    if(_entities.productos.Any(p => p.punto_venta.id == pv.id))
                    {
                        MessageBox.Show("No se puede eliminar el punto de venta pues tiene productos",
                                        "Eliminar punto de venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    _entities.DeleteObject(pv);
                    _entities.AddTobitacora(new bitacora
                                                {
                                                    id_usuario = _user.id,
                                                    descripcion = "El usuario " + _user.nombre + " ha eliminado el punto de venta " + tbxPuntoVenta.Text,
                                                    fecha = DateTime.Now
                                                 });
                    _entities.SaveChanges();
                    this.Reload();
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
