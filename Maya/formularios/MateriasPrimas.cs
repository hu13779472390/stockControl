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
    public partial class MateriasPrimas : Form
    {
        private readonly mayaEntities _entities;
        private readonly usuarios _user;
        private List<int> _idMateriaP;
        private int _selectedindex;
        private int _aumentar;
        public MateriasPrimas(usuarios user)
        {
            InitializeComponent();
            _entities = new mayaEntities();
            _user = user;
            _idMateriaP = new List<int>();
        }

        private string ValidarDatos()
        {
            string message = "";
            if (tbDescripcion.Text.Trim().Equals(""))
                message = "Debe introducir la descripción de la materia prima";
            if (nCantidad.Value == 0)
                message += "\nDebe introducir la cantidad que desea agregar";
            return message;
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if(_aumentar == 0)
                {
                    if (ValidarDatos().Equals(""))
                    {
                        _entities.AddTomateria_prima(new materia_prima
                        {
                            cantidad = nCantidad.Value,
                            descripcion = tbDescripcion.Text
                        });
                        _entities.AddTobitacora(new bitacora
                        {
                            id_usuario = _user.id,
                            descripcion = "EL usuario " + _user.nombre + " ha agregado " + nCantidad.Value.ToString() + " " + tbDescripcion.Text,
                            fecha = DateTime.Now
                        });
                        _entities.SaveChanges();
                        this.Reload();
                    }
                }
                else if(_aumentar == 1)
                {
                    var x = _idMateriaP[_selectedindex];
                    var mp =
                        (materia_prima) _entities.GetObjectByKey(new EntityKey("mayaEntities.materia_prima", "id", x));
                    if(nCantidad.Value == 0)
                    {
                        MessageBox.Show("Al seleccionar aumentar debe introducir una cantidad a aumentar",
                                        "Error en la entrada de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    mp.cantidad += nCantidad.Value;
                    _entities.AddTobitacora(new bitacora
                                                {
                                                    id_usuario = _user.id,
                                                    descripcion = "El usuario " + _user.nombre + " ha agregado " + nCantidad.Value.ToString() + " elementos a " + mp.descripcion,
                                                    fecha = DateTime.Now
                                                });
                    _entities.SaveChanges();
                    this.Reload();
                }
                else
                {
                    var x = _idMateriaP[_selectedindex];
                    var mp =
                        (materia_prima)_entities.GetObjectByKey(new EntityKey("mayaEntities.materia_prima", "id", x));
                    mp.descripcion = tbDescripcion.Text;
                    mp.cantidad = nCantidad.Value;
                    _entities.AddTobitacora(new bitacora
                    {
                        id_usuario = _user.id,
                        descripcion = "El usuario " + _user.nombre + " ha modificado el elementos " + mp.descripcion,
                        fecha = DateTime.Now
                    });
                    _entities.SaveChanges();
                    this.Reload();
                }
                
            }
            catch
            {
                MessageBox.Show("error en la entrada de datos, chequear los valores", "Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void Limpiar()
        {
            tbDescripcion.Text = "";
            nCantidad.Value = 0;
        }


        private void salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MateriasPrimas_Load(object sender, EventArgs e)
        {
            this.Reload();
        }
        private void Reload()
        {
            try
            {
                _aumentar = 0;
                tbDescripcion.Enabled = false;
                nCantidad.Enabled = false;
                aceptar.Visible = false;
                salir.Visible = false;
                _selectedindex = -1;
                modificarButton.Enabled = false;
                eliminarButton.Enabled = false;
                aumentar.Enabled = false;

                _idMateriaP = new List<int>();
                printableListView1.Items.Clear();

                foreach (var mp in _entities.materia_prima)
                {
                    printableListView1.Items.Add(new ListViewItem(new[]
                                                                      {
                                                                          mp.descripcion,
                                                                          mp.cantidad.ToString()
                                                                      }));
                    _idMateriaP.Add(mp.id);
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
            aumentar.Enabled = true;
            
            ListViewItem selectedItem = e.Item;
            selectedItem.Checked = true;

            if (_selectedindex != -1 && _selectedindex != e.ItemIndex)
                printableListView1.Items[_selectedindex].Checked = false;

            _selectedindex = e.ItemIndex;

            var matp =
                (materia_prima)
                _entities.GetObjectByKey(new EntityKey("mayaEntities.materia_prima", "id", _idMateriaP[e.ItemIndex]));
            tbDescripcion.Text = matp.descripcion;
            nCantidad.Value = matp.cantidad != null ? matp.cantidad.Value : 0;
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            tbDescripcion.Text = "";
            nCantidad.Value = 0;
            tbDescripcion.Enabled = true;
            nCantidad.Enabled = true;
            aceptar.Visible = true;
            salir.Visible = true;
            _aumentar = 0;
        }

        private void modificarButton_Click(object sender, EventArgs e)
        {
            tbDescripcion.Enabled = true;
            nCantidad.Enabled = true;
            aceptar.Visible = true;
            salir.Visible = true;
        }

        private void eliminarButton_Click(object sender, EventArgs e)
        {
            if(_selectedindex == -1)
            {
                MessageBox.Show("Debe seleccionar un elemento a eliminar", "Error de selección", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }
            try
            {
                var x = _idMateriaP[_selectedindex];
                var materia =
                    (materia_prima) _entities.GetObjectByKey(new EntityKey("mayaEntities.materia_prima", "id", x));
                if(materia.cantidad != 0)
                {
                    if(MessageBox.Show("Esta seguro que desea eliminar los " + materia.cantidad.ToString() + " de material " + materia.descripcion, "Eliminar materia prima", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        _entities.AddTobitacora(new bitacora
                                                    {
                                                        id_usuario = _user.id,
                                                        descripcion = "El usuario " + _user.nombre + " ha eliminado " + materia.cantidad.ToString() + " materiales de " + materia.descripcion,
                                                        fecha = DateTime.Now
                                                    });
                        
                        foreach (var m in _entities.mp_tejedora.Where(mpt => mpt.id_mp == materia.id))
                        {
                            _entities.DeleteObject(m);
                            
                        }
                        _entities.SaveChanges();
                        _entities.DeleteObject(materia);
                        _entities.SaveChanges();
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    _entities.AddTobitacora(new bitacora
                    {
                        id_usuario = _user.id,
                        descripcion = "El usuario " + _user.nombre + " ha eliminado el material " + materia.descripcion,
                        fecha = DateTime.Now
                    });
                    foreach (var m in _entities.mp_tejedora.Where(mpt => mpt.id_mp == materia.id))
                    {
                        _entities.DeleteObject(m);

                    }
                    _entities.SaveChanges();
                    _entities.DeleteObject(materia);
                    _entities.SaveChanges();
                }
                this.Reload();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void aumentar_Click(object sender, EventArgs e)
        {
            nCantidad.Enabled = true;
            nCantidad.Value = 0;
            aceptar.Visible = true;
            salir.Visible = true;
            _aumentar = 1;
        }
    }
}
