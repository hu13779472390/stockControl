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
    public partial class GestionarUsuarios : Form
    {
        private readonly usuarios _user;
        private readonly mayaEntities _entities;
        private List<int> _idrol;
        private List<int> _idUser;
        private int _selectedindex;
        private int nuevo;
        public GestionarUsuarios(usuarios user)
        {
            InitializeComponent();
            this._user = user;
            _idrol = new List<int>();
            _idUser = new List<int>();
            _entities = new mayaEntities();
            nuevo = 0;
        }

        private void GestionarUsuarios_Load(object sender, EventArgs e)
        {
            modificarButton.Enabled = false;
            eliminarButton.Enabled = false;
            this.Reload();
        }

        public void Reload()
        {
            try
            {
                printableListView1.Items.Clear();
                _idUser = new List<int>();
                //cargando los elementos en el printlistview
                foreach (var user in _entities.usuarios.Where(u => u.id != 3))
                {
                    printableListView1.Items.Add(new ListViewItem(new []
                                                                        {
                                                                            user.nombre,
                                                                            user.apellidos,
                                                                            user.usuario,
                                                                        }));
                    _idUser.Add(user.id);
                }
                comboBox1.Items.Add("<Seleccione>");
                _idrol.Add(0);
                foreach (var rol in _entities.rol)
                {
                    comboBox1.Items.Add(rol.valor);
                    _idrol.Add(rol.id);
                }
                comboBox1.SelectedIndex = 0;
                _selectedindex = -1;
                this.ResetComponents(true);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void ResetComponents(bool reset = false)
        {
            tboxNombre.ReadOnly = true;
            tboxApellidos.ReadOnly = true;
            tboxUsuarios.ReadOnly = true;
            tboxPass.ReadOnly = true;
            tboxPass2.ReadOnly = true;
            comboBox1.Enabled = false;
            aceptar.Visible = false;
            cancelar.Visible = false;
            
            if (!reset) return;
            tboxNombre.Text = "";
            tboxApellidos.Text = "";
            tboxUsuarios.Text = "";
            tboxPass.Text = "";
            tboxPass2.Text = "";
            comboBox1.SelectedIndex = 0;

        }

        private void printableListView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            modificarButton.Enabled = true;
            eliminarButton.Enabled = true;
            
            ListViewItem selectedItem = e.Item;
            selectedItem.Checked = true;

            if (_selectedindex != -1 && _selectedindex != e.ItemIndex)
                printableListView1.Items[_selectedindex].Checked = false;

            _selectedindex = e.ItemIndex;

            //Cargo los valores del elemento seleccionado en los componentes
            var user =
                (usuarios)_entities.GetObjectByKey(new EntityKey("mayaEntities.usuarios", "id", _idUser[selectedItem.Index]));

            tboxNombre.Text = user.nombre;
            tboxApellidos.Text = user.apellidos;
            tboxUsuarios.Text = user.usuario;
            tboxPass.Text = user.pass;
            tboxPass2.Text = user.pass;

            //busco los roles del usuario
            int index_rol = _idrol.FindIndex(r => r == user.id_rol);
            comboBox1.SelectedIndex = index_rol;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            printableListView1.Title = "Usuarios";
            printableListView1.PrintPreview();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            printableListView1.Title = "Usuarios";
            printableListView1.Print();
        }

        private void modificarButton_Click(object sender, EventArgs e)
        {
            tboxNombre.ReadOnly = false;
            tboxApellidos.ReadOnly = false;
            tboxUsuarios.ReadOnly = false;
            tboxPass.ReadOnly = false;
            tboxPass2.ReadOnly = false;
            comboBox1.Enabled = true;
            //habilito los botones de aceptar y cancelar
            aceptar.Visible = true;
            cancelar.Visible = true;
            this.AcceptButton = aceptar;
            this.CancelButton = cancelar;
            nuevo = 0;
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            tboxNombre.ReadOnly = false;
            tboxApellidos.ReadOnly = false;
            tboxUsuarios.ReadOnly = false;
            tboxPass.ReadOnly = false;
            tboxPass2.ReadOnly = false;
            comboBox1.Enabled = true;

            tboxNombre.Text = "";
            tboxApellidos.Text = "";
            tboxUsuarios.Text = "";
            tboxPass.Text = "";
            tboxPass2.Text = "";
            comboBox1.SelectedIndex = 0;
            //habilito los botones de aceptar y cancelar
            aceptar.Visible = true;
            cancelar.Visible = true;
            this.AcceptButton = aceptar;
            this.CancelButton = cancelar;
            nuevo = 1;
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (nuevo == 1)
                {
                    string validationMessage = ValidarDatos(0);
                    if (!string.IsNullOrEmpty(validationMessage))
                    {
                        MessageBox.Show(validationMessage, "Error en la entrada de datos", MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                        return;
                    }
                    else
                    {
                        _entities.AddTousuarios(new usuarios
                        {
                            nombre = tboxNombre.Text,
                            apellidos = tboxApellidos.Text,
                            usuario = tboxUsuarios.Text,
                            pass = tboxPass.Text,
                            id_rol = _idrol[comboBox1.SelectedIndex]
                        });
                        _entities.AddTobitacora(new bitacora
                        {
                            descripcion = "El usuario " + this._user.nombre + " ha creado el usuario " + tboxNombre.Text,
                            fecha = DateTime.Now,
                            id_usuario = this._user.id
                        });
                        _entities.SaveChanges();
                        this.Reload();
                    }

                }
                else
                {
                    string validationMessage = ValidarDatos(0);
                    if (!string.IsNullOrEmpty(validationMessage))
                    {
                        MessageBox.Show(validationMessage, "Error en la entrada de datos", MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                        return;
                    }
                    usuarios user =
                        (usuarios) _entities.GetObjectByKey(new EntityKey("mayaEntities.usuarios", "id", _idUser[_selectedindex]));
                    user.nombre = tboxNombre.Text;
                    user.apellidos = tboxApellidos.Text;
                    user.pass = tboxPass.Text;
                    user.id_rol = _idrol[comboBox1.SelectedIndex];
                    _entities.AddTobitacora(new bitacora
                                                {
                                                    descripcion = "El usuario " + this._user.nombre + " ha modificado el usuario " + user.nombre,
                                                    fecha = DateTime.Now,
                                                    id_usuario = this._user.id
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
        private string ValidarDatos(int id_usuario)
        {
            string validation = "";
            if(string.IsNullOrEmpty(tboxUsuarios.Text.Trim()))
                validation = "El nombre del usuario no puede estar vacío";
            if (string.IsNullOrEmpty(tboxApellidos.Text.Trim()))
                validation += "\nEl apellido del usuario no puede estar vacío";
            if (string.IsNullOrEmpty(tboxUsuarios.Text.Trim()))
                validation += "\nEl campo usuario no puede estar vacío";
            if (tboxPass.Text != tboxPass2.Text)
                validation += "\nLas contraseñas no coinciden";
            if (string.IsNullOrEmpty(tboxPass.Text))
                validation += "\nEl campo de contraseña no debe estar vacío";
            if (string.IsNullOrEmpty(tboxPass2.Text))
                validation += "\nEl campo de comprobación de la contraseña no puede estar vacío";
            if (_entities.usuarios.Any(u => u.id != id_usuario && u.usuario.Equals(tboxUsuarios.Text)) && nuevo == 1)
                validation += "\nYa existe un usuario con el nombre de usuario especificado";
            if (comboBox1.SelectedIndex == 0)
                validation += "\nDebe seleccionar un rol para el usuario";
            return validation;
        }

        private void eliminarButton_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Esta seguro que desea eliminar el usuario?", "Eliminar usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                usuarios user =
                    (usuarios)
                    _entities.GetObjectByKey(new EntityKey("mayaEntities.usuarios", "id", _idUser[_selectedindex]));
                if (user.id == 2)
                {
                    MessageBox.Show("Imposible eliminar al usuario admininistrador", "Error", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }
               _entities.DeleteObject(user);
               _entities.SaveChanges();
                this.Reload();
            }
        }
        
    }
}
