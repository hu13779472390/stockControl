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
    public partial class GestionarTejedoras : Form
    {
        private readonly mayaEntities _entities;
        private readonly usuarios _user;
        private List<int> _idTejedora;
        private int _selectedIndex;
        private bool nuevo;
        public GestionarTejedoras(usuarios user)
        {
            InitializeComponent();
            _entities = new mayaEntities();
            this._user = user;
            _idTejedora = new List<int>();
            _selectedIndex = 0;
            nuevo = false;
        }

        private void GestionarTejedoras_Load(object sender, EventArgs e)
        {
            this.Reload();
        }

        private void Reload()
        {
            //Preparando componentes
            modificarButton.Enabled = false;
            eliminarButton.Enabled = false;
            aceptarButton.Visible = false;
            cancelarButton.Visible = false;
            tbxNombre.Enabled = false;
            tbxRegistro.Enabled = false;
            tbxApellidos.Enabled = false;

            //llenando listview
            try
            {
                printableListView1.Items.Clear();
                _idTejedora = new List<int>();
                foreach (var tejedora in _entities.tejedora.Where(t => t.id != 9999))
                {
                    printableListView1.Items.Add(new ListViewItem(new[]
                                                                      {
                                                                          tejedora.id.ToString(),
                                                                          tejedora.nombre,
                                                                          tejedora.apellidos
                                                                      }));
                    _idTejedora.Add(tejedora.id);
                }
                _selectedIndex = -1;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            modificarButton.Enabled = false;
            eliminarButton.Enabled = false;
            aceptarButton.Visible = true;
            cancelarButton.Visible = true;
            tbxNombre.Enabled = true;
            tbxRegistro.Enabled = true;
            tbxApellidos.Enabled = true;
            tbxNombre.Text = "";
            tbxRegistro.Value = 0;
            tbxApellidos.Text = "";
            nuevo = true;
        }

        private void modificarButton_Click(object sender, EventArgs e)
        {
            aceptarButton.Visible = true;
            cancelarButton.Visible = true;
            tbxNombre.Enabled = true;
            tbxRegistro.Enabled = true;
            tbxApellidos.Enabled = true;
            nuevo = false;
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aceptarButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (nuevo)
                {
                    var messageValidation = ValidarEntrada((int)tbxRegistro.Value);
                    if(!string.IsNullOrEmpty(messageValidation))
                    {
                        MessageBox.Show(messageValidation, "Error en la entrada de datos", MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                        return;
                    }
                    _entities.AddTotejedora(new tejedora
                                                {
                                                    id = (int)tbxRegistro.Value,
                                                    nombre = tbxNombre.Text,
                                                    apellidos = tbxApellidos.Text
                                                });
                    _entities.AddTobitacora(new bitacora
                                                {
                                                    id_usuario = this._user.id,
                                                    descripcion = "El usuario " + this._user.nombre + " ha agregado la tejedora " + tbxNombre.Text,
                                                    fecha = DateTime.Now
                                                });
                    _entities.SaveChanges();
                    this.Reload();
                }
                else
                {
                    var messageValidation = ValidarEntrada((int)tbxRegistro.Value);
                    if (!string.IsNullOrEmpty(messageValidation))
                    {
                        MessageBox.Show(messageValidation, "Error en la entrada de datos", MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                        return;
                    }
                    tejedora aux =
                        (tejedora)_entities.GetObjectByKey(new EntityKey("mayaEntities.tejedora", "id", _idTejedora[_selectedIndex]));
                    aux.id = (int) tbxRegistro.Value;
                    aux.nombre = tbxNombre.Text;
                    aux.apellidos = tbxApellidos.Text;

                    _entities.AddTobitacora(new bitacora
                                                {
                                                    id_usuario = this._user.id,
                                                    descripcion =
                                                        "El usuario " + this._user.nombre +
                                                        " ha modificado la tejedora " + tbxNombre.Text,
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

        private string ValidarEntrada(int num_tejedora)
        {
            var message = "";
            if (tbxRegistro.Value == 0)
                message = "El número de registro de la tejedora no puede estar vacío";
            if (string.IsNullOrEmpty(tbxNombre.Text))
                message += "\nEl nombre de la tejedora no puede estar vacío";
            if (string.IsNullOrEmpty(tbxApellidos.Text))
                message += "\nLos apellidos no pueden estar vacíos";
            if (_entities.tejedora.Where(t => t.id == num_tejedora).Any() && nuevo)
                message += "\nYa existe una tejedora con ese número de registro";
            return message;
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

            tejedora t =
                (tejedora)
                _entities.GetObjectByKey(new EntityKey("mayaEntities.tejedora", "id", _idTejedora[selectedItem.Index]));
            tbxRegistro.Value = t.id;
            tbxNombre.Text = t.nombre;
            tbxApellidos.Text = t.apellidos;
        }

        private void eliminarButton_Click(object sender, EventArgs e)
        {
            try
            {
                if(MessageBox.Show("Está seguro que desea eliminar la tejedora seleccionada?", "Eliminar tejedora", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    tejedora aux =
                        (tejedora)
                        _entities.GetObjectByKey(new EntityKey("mayaEntities.tejedora", "id",
                                                               _idTejedora[_selectedIndex]));
                    if(_entities.productos.Any(p => p.tejedora.id == aux.id))
                    {
                        List<productos> lista_p = _entities.productos.Where(p => p.id_tejedora == aux.id).ToList();
                        List<productos> lista_auxiliar = new List<productos>();
                        productos prr = new productos();

                        foreach (var elemento in lista_p)
                        {
                            prr = new productos();
                            _entities.AddTobitacora(new bitacora
                                                        {
                                                            id_usuario = _user.id,
                                                            descripcion = "El usuario " + _user.nombre + "ha modificado la tejedora del producto " + elemento.id,
                                                            fecha = DateTime.Now
                                                        });

                            prr.tejedora_anterior = elemento.id_tejedora + " -- " + elemento.tejedora.nombre + " " +
                                                         elemento.tejedora.apellidos;
                            prr.id_tejedora = 9999;
                            prr.id_tipo_producto = elemento.id_tipo_producto;
                            prr.numero_producto = elemento.numero_producto;
                            prr.anno = elemento.anno;
                            prr.descripcion = elemento.descripcion;
                            prr.valor = elemento.valor;
                            prr.precio = elemento.precio ?? null;
                            prr.fecha_entrada = elemento.fecha_entrada;
                            prr.fecha_salida = elemento.fecha_salida ?? null;
                            prr.fecha_venta = elemento.fecha_venta ?? null;
                            prr.id_punto_venta = elemento.id_punto_venta ?? null;
                            prr.vendido = elemento.vendido ?? null;
                            prr.id = prr.anno.ToString() + "/" + prr.id_tejedora.ToString() + "/" +
                                     prr.id_tipo_producto.ToString() + "/" + prr.numero_producto.ToString();

                            _entities.DeleteObject(elemento);
                            lista_auxiliar.Add(prr);
                            _entities.SaveChanges();
                        }
                        foreach (var productose in lista_auxiliar)
                        {
                            _entities.AddToproductos(productose);
                            _entities.SaveChanges();
                        }
                        _entities.AddTobitacora(new bitacora
                                                    {
                                                        id_usuario = _user.id,
                                                        descripcion = "El usuario " + _user.nombre + "ha eliminado la tejedora " + aux.id + " -- " + aux.nombre,
                                                        fecha = DateTime.Now
                                                    });
                        _entities.SaveChanges();
                        _entities.DeleteObject(aux);
                        _entities.SaveChanges();
                        this.Reload();
                        return;
                    }

                    _entities.AddTobitacora(new bitacora
                                                {
                                                    id_usuario = this._user.id,
                                                    descripcion = "El usuario " + this._user.nombre + " ha eliminado la tejedora " + aux.nombre,
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.printableListView1.Title = "Tejedoras";
            this.printableListView1.PrintPreview();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.printableListView1.Title = "Tejedoras";
            this.printableListView1.Print();
        }


    }
}
