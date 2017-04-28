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
    public partial class GestionarTiposProductos : Form
    {
        private usuarios _user;
        private mayaEntities _entities;
        private List<int> _idTipo_producto;
        private int nuevo;
        private int _selectedIndex;
        public GestionarTiposProductos(usuarios user)
        {
            InitializeComponent();
            this._user = user;
            _entities = new mayaEntities();
            _idTipo_producto = new List<int>();
            nuevo = 0;
            _selectedIndex = 0;
        }

        private void GestionarTiposProductos_Load(object sender, EventArgs e)
        {
            this.Reload();
        }

        private void Reload()
        {
            try
            {
                tbxTipoProducto.ReadOnly = true;
                tbxTipoProducto.Enabled = false;
                numericIdentificador.ReadOnly = true;
                numericIdentificador.Enabled = false;
                modificarButton.Enabled = false;
                eliminarButton.Enabled = false;
                aceptarButton.Visible = false;
                cancelarButton.Visible = false;
                numericIdentificador.Value = 0;
                tbxTipoProducto.Text = "";
                printableListView1.Items.Clear();
                _idTipo_producto = new List<int>();
                foreach (var tipo_p in _entities.tipo_producto)
                {
                    printableListView1.Items.Add(new ListViewItem(new []
                                                                      {
                                                                          tipo_p.id.ToString(),
                                                                          tipo_p.valor
                }));
                    _idTipo_producto.Add(tipo_p.id);
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
            tbxTipoProducto.ReadOnly = false;
            tbxTipoProducto.Enabled = true;
            numericIdentificador.ReadOnly = false;
            numericIdentificador.Enabled = true;
            aceptarButton.Visible = true;
            cancelarButton.Visible = true;
            nuevo = 0;
        }
        private void NuevoButton_Click(object sender, EventArgs e)
        {
            modificarButton.Enabled = false;
            eliminarButton.Enabled = false;
            tbxTipoProducto.ReadOnly = false;
            tbxTipoProducto.Enabled = true;
            tbxTipoProducto.Text = "";
            numericIdentificador.ReadOnly = false;
            numericIdentificador.Enabled = true;
            numericIdentificador.Value = 0;
            aceptarButton.Visible = true;
            cancelarButton.Visible = true;
            nuevo = 1;
        }

        private void aceptarButton_Click(object sender, EventArgs e)
        {
            if(nuevo == 1)
            {
                try
                {
                    if (_entities.tipo_producto.Any(tp => tp.id == numericIdentificador.Value))
                    {
                        MessageBox.Show("Ya existe un tipo de producto con ese identificador",
                                        "Error en la entrada de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (_entities.tipo_producto.Any(tp => tp.valor.Equals(tbxTipoProducto.Text)))
                    {
                        MessageBox.Show("Ya existe un tipo de producto " + tbxTipoProducto.Text,
                                        "Error en la entrada de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if(numericIdentificador.Value == 0)
                    {
                        MessageBox.Show("Debe insertar un identificador distinto de 0",
                                        "Error en la entrada de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if(tbxTipoProducto.Text.Trim().Equals(""))
                    {
                        MessageBox.Show("Debe insertar el tipo de producto",
                                       "Error en la entrada de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _entities.AddTotipo_producto(new tipo_producto
                    {
                        id = (int)numericIdentificador.Value,
                        valor = tbxTipoProducto.Text
                    });
                    _entities.AddTobitacora(new bitacora
                    {
                        id_usuario = _user.id,
                        descripcion = "El usuario " + this._user.nombre + " ha creado un nuevo tipo de producto (" + tbxTipoProducto.Text + ")",
                        fecha = DateTime.Now
                    });
                    _entities.SaveChanges();
                    this.Reload();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                try
                {
                    if (_entities.tipo_producto.Any(tp => tp.id == numericIdentificador.Value))
                    {
                        MessageBox.Show("Ya existe un tipo de producto con ese identificador",
                                        "Error en la entrada de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    //if (_entities.tipo_producto.Any(tp => tp.valor.Equals(tbxTipoProducto.Text)))
                    //{
                    //    MessageBox.Show("Ya existe un tipo de producto " + tbxTipoProducto.Text,
                    //                    "Error en la entrada de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    return;
                    //}
                    if (numericIdentificador.Value == 0)
                    {
                        MessageBox.Show("Debe insertar un identificador distinto de 0",
                                        "Error en la entrada de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (tbxTipoProducto.Text.Trim().Equals(""))
                    {
                        MessageBox.Show("Debe insertar el tipo de producto",
                                       "Error en la entrada de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    tipo_producto tip =
                        (tipo_producto)
                        _entities.GetObjectByKey(new EntityKey("mayaEntities.tipo_producto", "id",
                                                               _idTipo_producto[_selectedIndex]));
                    tip.id = (int)numericIdentificador.Value;
                    tip.valor = tbxTipoProducto.Text;

                    _entities.AddTobitacora(new bitacora
                                                {
                                                    id_usuario = this._user.id,
                                                    descripcion =
                                                        "Se ha modificado el tipo de prodcuto " + tbxTipoProducto.Text,
                                                    fecha = DateTime.Now
                                                });
                    _entities.SaveChanges();
                }
                catch (Exception)
                {
                    
                    throw;
                }
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

            tipo_producto tp =
                (tipo_producto)
                _entities.GetObjectByKey(new EntityKey("mayaEntities.tipo_producto", "id",
                                                       _idTipo_producto[selectedItem.Index]));
            numericIdentificador.Value = tp.id;
            tbxTipoProducto.Text = tp.valor;
        }

        private void eliminarButton_Click(object sender, EventArgs e)
        {
            try
            {
                if(MessageBox.Show("Esta seguro que desea eliminar el tipo de producto?", "Eliminar tipo de producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    tipo_producto aux =
                        (tipo_producto)
                        _entities.GetObjectByKey(new EntityKey("mayaEntities.tipo_producto", "id",
                                                               _idTipo_producto[_selectedIndex]));
                    if(_entities.productos.Any(p => p.id_tipo_producto == aux.id))
                    {
                        MessageBox.Show(
                            "Es imposible borrar de momento el tipo de producto pues tiene productos\nrelacionados en inventario",
                            "Eliminar tipo de producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    _entities.AddTobitacora(new bitacora
                                                {
                                                    id_usuario = this._user.id,
                                                    descripcion = "El usuario " + this._user.nombre + " ha eliminado el tipo de producto " + aux.valor,
                                                    fecha = DateTime.Now
                                                });

                    _entities.DeleteObject(aux);
                    _entities.SaveChanges();
                    this.Reload();
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
