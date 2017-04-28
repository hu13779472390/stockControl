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
    public partial class PVSalidaProductos : Form
    {
        private List<string> _estados;
        private readonly usuarios _user;
        private int _idPuntoVenta;
        private readonly mayaEntities _entities;
        private List<string> _idProductos;
        private List<int> _idTipoProductos;
        private List<int> _idTejedoras;
        private int anno;
        public PVSalidaProductos(usuarios user, int idPuntoVenta)
        {
            InitializeComponent();
            this._user = user;
            this._idPuntoVenta = idPuntoVenta;
            _entities = new mayaEntities();
            _estados = new List<string>();
            _idProductos = new List<string>();
            _idTejedoras = new List<int>();
            _idTipoProductos = new List<int>();
            anno = 0;
        }

        private void PVSalidaProductos_Load(object sender, EventArgs e)
        {
            estado.ValueType = typeof (string);
            estado.AutoComplete = true;
            this.Reload();
        }
        public void Reload()
        {
            try
            {
                fechaSalida.Value = DateTime.Now;
                //Limpio loas valores para el combobox
                estado.Items.Clear();
                estado.Items.Add("<Seleccione>");
                estado.DefaultCellStyle.NullValue = "<Seleccione>";
                estado.Items.Add("Vendida");
                estado.Items.Add("Almacén");
                estado.Items.Add("Devolución");
                dataGridView1.Rows.Clear();
                _idProductos = new List<string>();

                foreach (var p in _entities.productos.Where(pro => pro.id_punto_venta == _idPuntoVenta && pro.vendido == null))
                {
                    dataGridView1.Rows.Add(new object[]
                                       {
                                           p.id,
                                           p.id_tejedora != 9999 ? p.tejedora.id +"--"+ p.tejedora.nombre : p.tejedora.nombre + " (" + p.tejedora_anterior + ")",
                                           p.tipo_producto.valor,
                                           p.descripcion,
                                           Math.Round(
                                            Convert.ToDecimal(p.precio,
                                            CultureInfo.InvariantCulture), 2)
                                       });
                    _idProductos.Add(p.id);
                }

                cboxTejedora.Items.Clear();
                cboxTejedora.Items.Add("<Seleccione>");
                _idTejedoras.Add(0);
                foreach (var tejedpra in _entities.tejedora.Where(t => t.id != 9999))
                {
                    cboxTejedora.Items.Add(tejedpra.id.ToString() + " -- " + tejedpra.nombre);
                    _idTejedoras.Add(tejedpra.id);
                }
                cboxTejedora.SelectedIndex = 0;

                cboxTipoProducto.Items.Clear();
                cboxTipoProducto.Items.Add("<Seleccione>");
                _idTipoProductos.Add(0);
                foreach (var tp in _entities.tipo_producto)
                {
                    cboxTipoProducto.Items.Add(tp.valor);
                    _idTipoProductos.Add(tp.id);
                }
                cboxTipoProducto.SelectedIndex = 0;
                string aux = DateTime.Now.Year.ToString();
                aux = aux[2].ToString() + aux[3].ToString();
                numericUpDown1.Value = int.Parse(aux);
                anno = int.Parse(aux);
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

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].ErrorText = String.Empty;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                cboxTejedora.Items.Clear();
                cboxTejedora.Items.Add("<Seleccione>");
                _idTejedoras.Add(0);
                foreach (var tejedpra in _entities.tejedora.Where(tr => tr.id != 9999))
                {
                    cboxTejedora.Items.Add(tejedpra.id.ToString() + " -- " + tejedpra.nombre);
                    _idTejedoras.Add(tejedpra.id);
                }
                cboxTejedora.SelectedIndex = 0;

                cboxTipoProducto.Items.Clear();
                cboxTipoProducto.Items.Add("<Seleccione>");
                _idTipoProductos.Add(0);
                foreach (var tp1 in _entities.tipo_producto)
                {
                    cboxTipoProducto.Items.Add(tp1.valor);
                    _idTipoProductos.Add(tp1.id);
                }
                cboxTipoProducto.SelectedIndex = 0;
                string aux = DateTime.Now.Year.ToString();
                aux = aux[2].ToString() + aux[3].ToString();
                numericUpDown1.Value = int.Parse(aux);
                anno = int.Parse(aux);


                var t = _idTejedoras[cboxTejedora.SelectedIndex];
                var tp = _idTipoProductos[cboxTipoProducto.SelectedIndex];
                var a = (int) numericUpDown1.Value;
                dataGridView1.Rows.Clear();
                _idProductos = new List<string>();
                if (t == 0 && tp == 0)
                {
                    foreach (var p in _entities.productos.Where(p => p.anno == a && p.id_punto_venta == _idPuntoVenta && p.vendido == null))
                    {
                        dataGridView1.Rows.Add(new object[]
                                       {
                                             p.id,
                                           p.id_tejedora != 9999 ? p.tejedora.id +"--"+ p.tejedora.nombre : p.tejedora.nombre + " (" + p.tejedora_anterior + ")",
                                           p.tipo_producto.valor,
                                           p.descripcion,
                                           Math.Round(
                                            Convert.ToDecimal(p.precio,
                                            CultureInfo.InvariantCulture), 2)
                                       });
                        _idProductos.Add(p.id);
                    }
                }
                else if (tp != 0 && t == 0)
                {
                    foreach (var p in _entities.productos.Where(p => p.anno == a && p.id_tipo_producto == tp && p.id_punto_venta == _idPuntoVenta && p.vendido == null))
                    {
                        dataGridView1.Rows.Add(new object[]
                                       {
                                            p.id,
                                           p.id_tejedora != 9999 ? p.tejedora.id +"--"+ p.tejedora.nombre : p.tejedora.nombre + " (" + p.tejedora_anterior + ")",
                                           p.tipo_producto.valor,
                                           p.descripcion,
                                           Math.Round(
                                            Convert.ToDecimal(p.precio,
                                            CultureInfo.InvariantCulture), 2)
                                       });
                        _idProductos.Add(p.id);
                    }
                }
                else if (tp == 0 && t != 0)
                {
                    foreach (var p in _entities.productos.Where(p => p.anno == a && p.id_tejedora == t && p.id_punto_venta == _idPuntoVenta && p.vendido == null))
                    {
                        dataGridView1.Rows.Add(new object[]
                                       {
                                            p.id,
                                           p.id_tejedora != 9999 ? p.tejedora.id +"--"+ p.tejedora.nombre : p.tejedora.nombre + " (" + p.tejedora_anterior + ")",
                                           p.tipo_producto.valor,
                                           p.descripcion,
                                           Math.Round(
                                            Convert.ToDecimal(p.precio,
                                            CultureInfo.InvariantCulture), 2)
                                       });
                        _idProductos.Add(p.id);
                    }
                }
                else
                {
                    foreach (var p in _entities.productos.Where(p => p.anno == a && p.id_tejedora == t && p.id_tipo_producto == tp && p.id_punto_venta == _idPuntoVenta && p.vendido == null))
                    {
                        dataGridView1.Rows.Add(new object[]
                                       {
                                            p.id,
                                           p.id_tejedora != 9999 ? p.tejedora.id +"--"+ p.tejedora.nombre : p.tejedora.nombre + " (" + p.tejedora_anterior + ")",
                                           p.tipo_producto.valor,
                                           p.descripcion,
                                           Math.Round(
                                            Convert.ToDecimal(p.precio,
                                            CultureInfo.InvariantCulture), 2)
                                       });
                        _idProductos.Add(p.id);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                {
                    if (dataGridView1.Rows[i].Cells["estado"].Value == null)
                        continue;
                    if (dataGridView1.Rows[i].Cells["estado"].Value.Equals("Vendida"))
                    {
                        var identificador = _idProductos[i];
                        var aux = (productos) _entities.productos.Where(p => p.id.Equals(identificador)).Single();
                        aux.vendido = 1;
                        aux.fecha_venta = fechaSalida.Value.Date;

                        _entities.AddTobitacora(new bitacora
                                                    {
                                                        id_usuario = this._user.id,
                                                        descripcion = "El usuario " + this._user.nombre + " ha establecido el producto " + aux.id + " como vendido",
                                                        fecha = DateTime.Now
                                                    });
                        _entities.SaveChanges();
                    }
                    else if (dataGridView1.Rows[i].Cells["estado"].Value.Equals("Almacén"))
                    {
                        var identificador = _idProductos[i];
                        var aux = (productos)_entities.productos.Where(p => p.id.Equals(identificador)).Single();
                        aux.id_punto_venta = null;
                        aux.fecha_devolucion = fechaSalida.Value.Date;
                        aux.fecha_salida = null;
                        aux.precio = null;

                        _entities.AddTobitacora(new bitacora
                                                    {
                                                        id_usuario = _user.id,
                                                        descripcion =
                                                            "El usuario " + _user.nombre +
                                                            " he devuelto al almacén el producto " + aux.id,
                                                        fecha = DateTime.Now
                                                    });
                        _entities.SaveChanges();
                    }
                    else if (dataGridView1.Rows[i].Cells["estado"].Value.Equals("Devolución"))
                    {
                        var identificador = _idProductos[i];
                        var aux = (productos)_entities.productos.Where(p => p.id.Equals(identificador)).Single();
                        
                        _entities.AddTobitacora(new bitacora
                                                    {
                                                        id_usuario = _user.id,
                                                        descripcion = "El usuario " + _user.nombre + " ha declarado el producto " + aux.id + " como devuelto",
                                                        fecha = DateTime.Now
                                                    });
                        _entities.DeleteObject(aux);
                        _entities.SaveChanges();
                    }
                }
                this.Reload();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

    }
}
