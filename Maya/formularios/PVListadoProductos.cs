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
    public partial class PVListadoProductos : Form
    {
        private readonly mayaEntities _entities;
        private readonly usuarios _user;
        private int _idPuntoVenta;
        private List<int> _idTipoProductos;
        private List<int> _idTejedoras;
        private List<string> _idProductos;
        private int anno;
        public PVListadoProductos(usuarios user, int idPuntoVenta)
        {
            InitializeComponent();
            _entities = new mayaEntities();
            _user = user;
            _idPuntoVenta = idPuntoVenta;
            _idTipoProductos = new List<int>();
            _idTejedoras = new List<int>();
            _idProductos = new List<string>();
            anno = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PVListadoProductos_Load(object sender, EventArgs e)
        {
            this.Reload();
        }
        public void Reload()
        {
            try
            {
                dataGridView1.Rows.Clear();
                _idProductos = new List<string>();
                foreach (var p in _entities.productos.Where(p => p.id_punto_venta == null))
                {
                    dataGridView1.Rows.Add(new object[]
                                       {
                                            p.id,
                                            p.tipo_producto.valor,
                                            p.id_tejedora != 9999 ? p.tejedora.id +"--"+ p.tejedora.nombre : p.tejedora.nombre + " (" + p.tejedora_anterior + ")",
                                            p.descripcion,
                                            0,
                                            elem_seleccionado.Selected = false
                                       });
                    _idProductos.Add(p.id);

                }

                cboxTejedora.Items.Add("<Seleccione>");
                _idTejedoras.Add(0);
                foreach (var tejedpra in _entities.tejedora.Where(t => t.id != 9999))
                {
                    cboxTejedora.Items.Add(tejedpra.id.ToString() + " -- " + tejedpra.nombre);
                    _idTejedoras.Add(tejedpra.id);
                }
                cboxTejedora.SelectedIndex = 0;

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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var t = _idTejedoras[cboxTejedora.SelectedIndex];
                var tp = _idTipoProductos[cboxTipoProducto.SelectedIndex];
                var a = (int) numericUpDown1.Value;
                dataGridView1.Rows.Clear();
                _idProductos = new List<string>();
                if (t == 0 && tp == 0)
                {
                    foreach (var p in _entities.productos.Where(p => p.anno == a && p.id_punto_venta == null))
                    {
                        dataGridView1.Rows.Add(new object[]
                                       {
                                            p.id,
                                            p.tipo_producto.valor,
                                            p.tejedora.id.ToString() + p.tejedora.nombre,
                                            p.descripcion,
                                            0,
                                            elem_seleccionado.Selected = false
                                       });
                        _idProductos.Add(p.id);
                    }
                }
                else if (tp != 0 && t == 0)
                {
                    foreach (var p in _entities.productos.Where(p => p.anno == a && p.id_tipo_producto == tp && p.id_punto_venta == null))
                    {
                        dataGridView1.Rows.Add(new object[]
                                       {
                                            p.id,
                                            p.tipo_producto.valor,
                                            p.tejedora.id.ToString() + p.tejedora.nombre,
                                            p.descripcion,
                                            0,
                                            elem_seleccionado.Selected = false
                                       });
                        _idProductos.Add(p.id);
                    }
                }
                else if (tp == 0 && t != 0)
                {
                    foreach (var p in _entities.productos.Where(p => p.anno == a && p.id_tejedora == t && p.id_punto_venta == null))
                    {
                        dataGridView1.Rows.Add(new object[]
                                       {
                                            p.id,
                                            p.tipo_producto.valor,
                                            p.tejedora.id.ToString() + p.tejedora.nombre,
                                            p.descripcion,
                                            0,
                                            elem_seleccionado.Selected = false
                                       });
                        _idProductos.Add(p.id);
                    }
                }
                else
                {
                    foreach (var p in _entities.productos.Where(p => p.anno == a && p.id_tejedora == t && p.id_tipo_producto == tp && p.id_punto_venta == null))
                    {
                        dataGridView1.Rows.Add(new object[]
                                       {
                                            p.id,
                                            p.tipo_producto.valor,
                                            p.tejedora.id.ToString() + p.tejedora.nombre,
                                            p.descripcion,
                                            0,
                                            elem_seleccionado.Selected = false
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
                if(MessageBox.Show("Esta seguro que desea enviar todos los elementos seleccionados\nal punto de venta?", "Enviar elementos al punto de venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //hago un recorrido por todos los elementos de la tabla
                    for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                    {
                        //pregunto si el elemento de la celda esta seleccionado
                        if ((bool)dataGridView1.Rows[i].Cells["elem_seleccionado"].Value &&
                            !dataGridView1.Rows[i].Cells["precio"].Value.ToString().Equals("0"))
                        {
                            var identificador = _idProductos[i];
                            var aux =
                                (productos)
                                _entities.productos.Where(p => p.id.Equals(identificador)).Single();
                            //actualizo el campo id_punto_venta
                            aux.id_punto_venta = _idPuntoVenta;
                            aux.precio = Math.Round(
                                        Convert.ToDecimal(dataGridView1.Rows[i].Cells["precio"].Value,
                                          CultureInfo.InvariantCulture), 2);

                            aux.fecha_salida = DateTime.Now;
                            //se registra el movimiento en la bitacora del sistema
                            _entities.AddTobitacora(new bitacora
                            {
                                id_usuario = this._user.id,
                                descripcion =
                                    "El usuario " + _user.nombre + " ha trasladado el producto " +
                                    aux.id + " hacia el punto de venta " + aux.punto_venta.valor,
                                fecha = DateTime.Now
                            });
                            _entities.SaveChanges();
                        }
                    }
                }
                this.Reload();
                
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message + "Error al realizar la operación, trate de ejecutarla nuevamente",
                                "Error en la operación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string value = e.FormattedValue == null ? "" : e.FormattedValue.ToString().Trim();

            // Validar que el plus sea un número positivo.
            if (dataGridView1.Columns[e.ColumnIndex].Name == "precio")
            {
                decimal plus;
                if (!decimal.TryParse(value, out plus) || plus < 0)
                {
                    dataGridView1.Rows[e.RowIndex].ErrorText =
                        "El precio no puede ser un número negtivo";
                    e.Cancel = true;
                }
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].ErrorText = String.Empty;

            if(dataGridView1.Columns[e.ColumnIndex].Name.Equals("precio"))
            {
                dataGridView1.Rows[e.RowIndex].Cells["precio"].Value = Math.Round(
                    Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["precio"].Value,
                                      CultureInfo.InvariantCulture), 2);
            }
        }
    }
}
