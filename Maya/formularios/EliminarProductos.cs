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
    public partial class EliminarProductos : Form
    {
        private readonly mayaEntities _entities;
        private readonly usuarios _user;
        private List<int> _idTejedora;
        private List<int> _idTipoProducto;
        private List<string> _idProductos;
        private int _selectedindex;
        public EliminarProductos(usuarios user)
        {
            InitializeComponent();
            _entities = new mayaEntities();
            _user = user;
            _idTejedora = new List<int>();
            _idTipoProducto = new List<int>();
            _idProductos = new List<string>();
        }

        private void EliminarProductos_Load(object sender, EventArgs e)
        {
            
            this.Reload();
        }
        private void Reload()
        {
            try
            {
                _selectedindex = -1;
                aceptar.Visible = false;
                cancelar.Visible = false;
                aceptar.Enabled = false;
                cancelar.Enabled = false;
                lbIdentificador.Text = "";
                cbTipoProducto.Enabled = false;
                cbTejedora.Enabled = false;
                nValor.Enabled = false;
                fecha_entrada.Enabled = false;
                tbDescripcion.Enabled = false;

                //Reiniciar valores
                nValor.Value = 0;
                fecha_entrada.Value = DateTime.Now;
                tbDescripcion.Text = "";

                printableListView1.Items.Clear();


                foreach (var p in _entities.productos.Where(pro => pro.id_punto_venta == null))
                {
                    printableListView1.Items.Add(new ListViewItem(new[]
                                                                      {
                                                                          p.id,
                                                                          p.descripcion,
                                                                          Math.Round(
                                                                                Convert.ToDecimal(p.valor,
                                                                                CultureInfo.InvariantCulture), 2).ToString(),
                                                                          p.id_tejedora == 9999 ? p.tejedora.nombre + " (" + p.tejedora_anterior + ")" :p.tejedora.id.ToString() + " -- " + p.tejedora.nombre,
                                                                          p.tipo_producto.valor,
                                                                          p.fecha_entrada.ToString("dd/MM/yyyy")
                                                                      }));
                    _idProductos.Add(p.id);
                }

                cbTejedora.Items.Clear();
                cbTejedora.Items.Add("--");
                _idTejedora.Add(0);
                foreach (var t in _entities.tejedora.Where(te => te.id != 9999))
                {
                    cbTejedora.Items.Add(t.id.ToString() + " -- " + t.nombre);
                    _idTejedora.Add(t.id);
                }
                cbTejedora.SelectedIndex = 0;

                cbTipoProducto.Items.Clear();
                cbTipoProducto.Items.Add("--");
                _idTipoProducto.Add(0);
                foreach (var tp in _entities.tipo_producto)
                {
                    cbTipoProducto.Items.Add(tp.id + " -- " + tp.valor);
                    _idTipoProducto.Add(tp.id);
                }
                cbTipoProducto.SelectedIndex = 0;
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

            if (_selectedindex != -1 && _selectedindex != e.ItemIndex)
                printableListView1.Items[_selectedindex].Checked = false;

            _selectedindex = e.ItemIndex;

            var aux = _idProductos[_selectedindex];
            var product = (productos) _entities.productos.Where(p => p.id.Equals(aux)).Single();

            lbIdentificador.Text = product.id;
            nValor.Value = product.valor;
            tbDescripcion.Text = product.descripcion;
            fecha_entrada.Value = product.fecha_entrada;

            int x = _idTejedora.FindIndex(el => el == product.id_tejedora);
            cbTejedora.SelectedIndex = x;

            x = _idTipoProducto.FindIndex(tp => tp == product.id_tipo_producto);
            cbTipoProducto.SelectedIndex = x;
        }

        private void modificarButton_Click(object sender, EventArgs e)
        {
            aceptar.Visible = true;
            cancelar.Visible = true;
            aceptar.Enabled = true;
            cancelar.Enabled = true;
            cbTipoProducto.Enabled = true;
            cbTejedora.Enabled = true;
            nValor.Enabled = true;
            fecha_entrada.Enabled = true;
            tbDescripcion.Enabled = true;
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                string aux = _idProductos[_selectedindex];
                var producto = (productos) _entities.productos.Where(p => p.id.Equals(aux)).Single();

                producto.id = lbIdentificador.Text;
                producto.id_tejedora = _idTejedora[cbTejedora.SelectedIndex];
                producto.id_tipo_producto = _idTipoProducto[cbTipoProducto.SelectedIndex];
                producto.fecha_entrada = fecha_entrada.Value;
                producto.valor = nValor.Value;
                producto.descripcion = tbDescripcion.Text;

                _entities.AddTobitacora(new bitacora
                                            {
                                                id_usuario = _user.id,
                                                descripcion = "El usuario " + _user.nombre + " ha modificado el producto " + aux + " con el identificador actual " + producto.id,
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

        private void cbTejedora_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(aceptar.Visible != true)
                return;
            //numero del identificador del producto
            int numero = 0;
            //obtengo el anno para convertirlo en un entero con las ultimas dos cifras
            string aux = fecha_entrada.Value.Year.ToString();
            aux = aux[2].ToString() + aux[3].ToString();
            int aux_anno = int.Parse(aux);
            //variable para obtener el numero del tipo de producto
            var tipoProducto = 0;
            //variable para obtener la tejedora
            var tejedoraa = 0;
            if (cbTejedora.SelectedIndex > 0 && cbTipoProducto.SelectedIndex > 0)
            {
                tipoProducto = _idTipoProducto[cbTipoProducto.SelectedIndex];
                tejedoraa = _idTejedora[cbTejedora.SelectedIndex];
                if (_entities.productos.Any(
                        p =>
                        p.id_tejedora == tejedoraa &&
                        p.id_tipo_producto == tipoProducto &&
                        p.anno == aux_anno))
                {
                    numero =
                    _entities.productos.Where(
                        p =>
                        p.id_tejedora == tejedoraa &&
                        p.id_tipo_producto == tipoProducto &&
                        p.anno == aux_anno).OrderBy(pi => pi.numero_producto).ToList().Last().numero_producto;
                }

            }
            else if (cbTejedora.SelectedIndex == 0 && cbTipoProducto.SelectedIndex > 0)
            {
                tipoProducto = _idTipoProducto[cbTipoProducto.SelectedIndex];
                if (_entities.productos.Any(
                        p =>
                        p.id_tipo_producto == tipoProducto &&
                        p.anno == aux_anno))
                {
                    numero =
                    _entities.productos.Where(
                        p =>
                        p.id_tipo_producto == tipoProducto &&
                        p.anno == aux_anno).OrderBy(pi => pi.numero_producto).ToList().Last().numero_producto;
                }
            }
            else if (cbTejedora.SelectedIndex > 0 && cbTipoProducto.SelectedIndex == 0)
            {
                tejedoraa = _idTejedora[cbTejedora.SelectedIndex];
                if (_entities.productos.Any(
                        p =>
                        p.id_tejedora == tejedoraa &&
                        p.anno == aux_anno))
                {
                    numero =
                    _entities.productos.Where(
                        p =>
                        p.id_tejedora == tejedoraa &&
                        p.anno == aux_anno).OrderBy(pi => pi.numero_producto).ToList().Last().numero_producto;
                }

            }
            lbIdentificador.Text = aux_anno.ToString() + "/" + _idTejedora[cbTejedora.SelectedIndex].ToString() + "/" + _idTipoProducto[cbTipoProducto.SelectedIndex].ToString() + "/" + (numero + 1).ToString();
        }

        private void cbTipoProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (aceptar.Visible != true)
                return;
            //numero del identificador del producto
            int numero = 0;
            //obtengo el anno para convertirlo en un entero con las ultimas dos cifras
            string aux = fecha_entrada.Value.Year.ToString();
            aux = aux[2].ToString() + aux[3].ToString();
            int aux_anno = int.Parse(aux);
            //variable para obtener el numero del tipo de producto
            var tipoProducto = 0;
            //variable para obtener la tejedora
            var tejedoraa = 0;
            if (cbTejedora.SelectedIndex > 0 && cbTipoProducto.SelectedIndex > 0)
            {
                tipoProducto = _idTipoProducto[cbTipoProducto.SelectedIndex];
                tejedoraa = _idTejedora[cbTejedora.SelectedIndex];
                if (_entities.productos.Any(
                        p =>
                        p.id_tejedora == tejedoraa &&
                        p.id_tipo_producto == tipoProducto &&
                        p.anno == aux_anno))
                {
                    numero =
                    _entities.productos.Where(
                        p =>
                        p.id_tejedora == tejedoraa &&
                        p.id_tipo_producto == tipoProducto &&
                        p.anno == aux_anno).OrderBy(pi => pi.numero_producto).ToList().Last().numero_producto;
                }

            }
            else if (cbTejedora.SelectedIndex == 0 && cbTipoProducto.SelectedIndex > 0)
            {
                tipoProducto = _idTipoProducto[cbTipoProducto.SelectedIndex];
                if (_entities.productos.Any(
                        p =>
                        p.id_tipo_producto == tipoProducto &&
                        p.anno == aux_anno))
                {
                    numero =
                    _entities.productos.Where(
                        p =>
                        p.id_tipo_producto == tipoProducto &&
                        p.anno == aux_anno).OrderBy(pi => pi.numero_producto).ToList().Last().numero_producto;
                }
            }
            else if (cbTejedora.SelectedIndex > 0 && cbTipoProducto.SelectedIndex == 0)
            {
                tejedoraa = _idTejedora[cbTejedora.SelectedIndex];
                if (_entities.productos.Any(
                        p =>
                        p.id_tejedora == tejedoraa &&
                        p.anno == aux_anno))
                {
                    numero =
                    _entities.productos.Where(
                        p =>
                        p.id_tejedora == tejedoraa &&
                        p.anno == aux_anno).OrderBy(pi => pi.numero_producto).ToList().Last().numero_producto;
                }

            }
            lbIdentificador.Text = aux_anno.ToString() + "/" + _idTejedora[cbTejedora.SelectedIndex].ToString() + "/" + _idTipoProducto[cbTipoProducto.SelectedIndex].ToString() + "/" + (numero + 1).ToString();
        }

        private void fecha_entrada_ValueChanged(object sender, EventArgs e)
        {
            if (aceptar.Visible != true)
                return;
            //numero del identificador del producto
            int numero = 0;
            //obtengo el anno para convertirlo en un entero con las ultimas dos cifras
            string aux = fecha_entrada.Value.Year.ToString();
            aux = aux[2].ToString() + aux[3].ToString();
            int aux_anno = int.Parse(aux);
            //variable para obtener el numero del tipo de producto
            var tipoProducto = 0;
            //variable para obtener la tejedora
            var tejedoraa = 0;
            if (cbTejedora.SelectedIndex > 0 && cbTipoProducto.SelectedIndex > 0)
            {
                tipoProducto = _idTipoProducto[cbTipoProducto.SelectedIndex];
                tejedoraa = _idTejedora[cbTejedora.SelectedIndex];
                if (_entities.productos.Any(
                        p =>
                        p.id_tejedora == tejedoraa &&
                        p.id_tipo_producto == tipoProducto &&
                        p.anno == aux_anno))
                {
                    numero =
                    _entities.productos.Where(
                        p =>
                        p.id_tejedora == tejedoraa &&
                        p.id_tipo_producto == tipoProducto &&
                        p.anno == aux_anno).OrderBy(pi => pi.numero_producto).ToList().Last().numero_producto;
                }

            }
            else if (cbTejedora.SelectedIndex == 0 && cbTipoProducto.SelectedIndex > 0)
            {
                tipoProducto = _idTipoProducto[cbTipoProducto.SelectedIndex];
                if (_entities.productos.Any(
                        p =>
                        p.id_tipo_producto == tipoProducto &&
                        p.anno == aux_anno))
                {
                    numero =
                    _entities.productos.Where(
                        p =>
                        p.id_tipo_producto == tipoProducto &&
                        p.anno == aux_anno).OrderBy(pi => pi.numero_producto).ToList().Last().numero_producto;
                }
            }
            else if (cbTejedora.SelectedIndex > 0 && cbTipoProducto.SelectedIndex == 0)
            {
                tejedoraa = _idTejedora[cbTejedora.SelectedIndex];
                if (_entities.productos.Any(
                        p =>
                        p.id_tejedora == tejedoraa &&
                        p.anno == aux_anno))
                {
                    numero =
                    _entities.productos.Where(
                        p =>
                        p.id_tejedora == tejedoraa &&
                        p.anno == aux_anno).OrderBy(pi => pi.numero_producto).ToList().Last().numero_producto;
                }

            }
            lbIdentificador.Text = aux_anno.ToString() + "/" + _idTejedora[cbTejedora.SelectedIndex].ToString() + "/" + _idTipoProducto[cbTipoProducto.SelectedIndex].ToString() + "/" + (numero + 1).ToString();
        }

        private void eliminarButton_Click(object sender, EventArgs e)
        {
            if(_selectedindex == -1)
            {
                MessageBox.Show("Debe seleccionar un producto", "Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }
            try
            {
                if (MessageBox.Show("Esta seguro que desea eliminar el producto seleccionado?", "Eliminar producto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    return;
                }
                var aux = _idProductos[_selectedindex];
                var p = (productos) _entities.productos.Where(pr => pr.id.Equals(aux)).Single();

                _entities.AddTobitacora(new bitacora
                                            {
                                                id_usuario = _user.id,
                                                descripcion = "El usuario " + _user.nombre + " ha eliminado el producto " + p.id,
                                                fecha = DateTime.Now
                                            });
                _entities.DeleteObject(p);
                _entities.SaveChanges();
                this.Reload();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
