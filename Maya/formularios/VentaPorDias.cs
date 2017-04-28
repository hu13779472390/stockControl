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
    public partial class VentaPorDias : Form
    {
        private readonly mayaEntities _entities;
        private List<int> _idPuntoVenta;
        private List<int> _idTejedora;
        public VentaPorDias()
        {
            InitializeComponent();
            _entities = new mayaEntities();
            _idTejedora = new List<int>();
            _idPuntoVenta = new List<int>();
        }

        private void VentaPorDias_Load(object sender, EventArgs e)
        {
            try
            {
                cbPuntoVenta.Items.Add("<Seleccione>");
                _idPuntoVenta.Add(0);
                cbTejedora.Items.Add("<Seleccione>");
                _idTejedora.Add(0);
                foreach (var t  in _entities.tejedora)
                {
                    cbTejedora.Items.Add(t.id.ToString() + " -- " + t.nombre);
                    _idTejedora.Add(t.id);
                }
                cbTejedora.SelectedIndex = 0;
                foreach (var pv in _entities.punto_venta)
                {
                    cbPuntoVenta.Items.Add(pv.valor);
                    _idPuntoVenta.Add(pv.id);
                }
                cbPuntoVenta.SelectedIndex = 0;
                this.Reload();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        private void Reload()
        {
            try
            {
                printableListView1.Items.Clear();
                decimal total_valor = 0;
                int tejedora = 0;
                int punto_venta = 0;
                if(fecha_inicio.Value.Date == fecha_fin.Value.Date && cbTejedora.SelectedIndex == 0 && cbPuntoVenta.SelectedIndex == 0)
                {
                    foreach (var p in _entities.productos.Where(pro => pro.vendido == 1))
                    {
                        if(p.fecha_venta.Value.Date != fecha_inicio.Value.Date)
                            continue;
                        printableListView1.Items.Add(new ListViewItem(new[]
                                                                          {
                                                                              p.id,
                                                                              p.fecha_venta.Value.Date.ToString("dd/MM/yyyy"),
                                                                              p.id_tejedora != 9999 ? p.tejedora.id +"--"+ p.tejedora.nombre : p.tejedora.nombre + " (" + p.tejedora_anterior + ")",
                                                                              p.punto_venta.valor,
                                                                              Math.Round(
                                                                              Convert.ToDecimal(p.precio,
                                                                                                CultureInfo.
                                                                                                    InvariantCulture), 2)
                                                                              .ToString()
                                                                          }));
                        total_valor += Math.Round(
                            Convert.ToDecimal(p.precio,
                                              CultureInfo.
                                                  InvariantCulture), 2);
                    }
                    printableListView1.Items.Add(new ListViewItem(new[]
                                                                          {
                                                                              "",
                                                                              "",
                                                                              "",
                                                                              "",
                                                                                "Total:" + total_valor.ToString()
                                                                          }));
                }
                else if(fecha_inicio.Value.Date == fecha_fin.Value.Date && cbTejedora.SelectedIndex != 0 && cbPuntoVenta.SelectedIndex == 0)
                {
                    tejedora = _idTejedora[cbTejedora.SelectedIndex];
                    foreach (var p in _entities.productos.Where(pro => pro.vendido == 1 && pro.id_tejedora == tejedora))
                    {
                        if(p.fecha_venta.Value.Date != fecha_inicio.Value.Date)
                            continue;
                        printableListView1.Items.Add(new ListViewItem(new[]
                                                                          {
                                                                              p.id,
                                                                              p.fecha_venta.Value.Date.ToString("dd/MM/yyyy"),
                                                                              p.id_tejedora != 9999 ? p.tejedora.id +"--"+ p.tejedora.nombre : p.tejedora.nombre + " (" + p.tejedora_anterior + ")",
                                                                              p.punto_venta.valor,
                                                                              Math.Round(
                                                                              Convert.ToDecimal(p.precio,
                                                                                                CultureInfo.
                                                                                                    InvariantCulture), 2)
                                                                              .ToString()
                                                                          }));
                        total_valor += Math.Round(
                            Convert.ToDecimal(p.precio,
                                              CultureInfo.
                                                  InvariantCulture), 2);
                    }
                    printableListView1.Items.Add(new ListViewItem(new[]
                                                                          {
                                                                              "",
                                                                              "",
                                                                              "",
                                                                              "",
                                                                                "Total:" + total_valor.ToString()
                                                                          }));
                }
                else if (fecha_inicio.Value.Date == fecha_fin.Value.Date && cbTejedora.SelectedIndex == 0 && cbPuntoVenta.SelectedIndex != 0)
                {
                    punto_venta = _idPuntoVenta[cbPuntoVenta.SelectedIndex];
                    foreach (var p in _entities.productos.Where(pro => pro.vendido == 1 && pro.id_punto_venta == punto_venta))
                    {
                        if (p.fecha_venta.Value.Date != fecha_inicio.Value.Date)
                            continue;
                        printableListView1.Items.Add(new ListViewItem(new[]
                                                                          {
                                                                              p.id,
                                                                              p.fecha_venta.Value.Date.ToString("dd/MM/yyyy"),
                                                                              p.id_tejedora != 9999 ? p.tejedora.id +"--"+ p.tejedora.nombre : p.tejedora.nombre + " (" + p.tejedora_anterior + ")",
                                                                              p.punto_venta.valor,
                                                                              Math.Round(
                                                                              Convert.ToDecimal(p.precio,
                                                                                                CultureInfo.
                                                                                                    InvariantCulture), 2)
                                                                              .ToString()
                                                                          }));
                        total_valor += Math.Round(
                            Convert.ToDecimal(p.precio,
                                              CultureInfo.
                                                  InvariantCulture), 2);
                    }
                    printableListView1.Items.Add(new ListViewItem(new[]
                                                                          {
                                                                              "",
                                                                              "",
                                                                              "",
                                                                              "",
                                                                                "Total:" + total_valor.ToString()
                                                                          }));
                }
                else if (fecha_inicio.Value.Date != fecha_fin.Value.Date && cbTejedora.SelectedIndex == 0 && cbPuntoVenta.SelectedIndex == 0)
                {
                    foreach (var p in _entities.productos.Where(pro => pro.vendido == 1))
                    {
                        if (p.fecha_venta.Value.Date < fecha_inicio.Value.Date)
                            continue;
                        if(p.fecha_venta.Value.Date > fecha_fin.Value.Date)
                            continue;
                        printableListView1.Items.Add(new ListViewItem(new[]
                                                                          {
                                                                              p.id,
                                                                              p.fecha_venta.Value.Date.ToString("dd/MM/yyyy"),
                                                                              p.id_tejedora != 9999 ? p.tejedora.id +"--"+ p.tejedora.nombre : p.tejedora.nombre + " (" + p.tejedora_anterior + ")",
                                                                              p.punto_venta.valor,
                                                                              Math.Round(
                                                                              Convert.ToDecimal(p.precio,
                                                                                                CultureInfo.
                                                                                                    InvariantCulture), 2)
                                                                              .ToString()
                                                                          }));
                        total_valor += Math.Round(
                            Convert.ToDecimal(p.precio,
                                              CultureInfo.
                                                  InvariantCulture), 2);
                    }
                    printableListView1.Items.Add(new ListViewItem(new[]
                                                                          {
                                                                              "",
                                                                              "",
                                                                              "",
                                                                              "",
                                                                                "Total:" + total_valor.ToString()
                                                                          }));
                }
                else if (fecha_inicio.Value.Date != fecha_fin.Value.Date && cbTejedora.SelectedIndex != 0 && cbPuntoVenta.SelectedIndex == 0)
                {
                    tejedora = _idTejedora[cbTejedora.SelectedIndex];
                    foreach (var p in _entities.productos.Where(pro => pro.vendido == 1 && pro.id_tejedora == tejedora))
                    {
                        if (p.fecha_venta.Value.Date < fecha_inicio.Value.Date)
                            continue;
                        if (p.fecha_venta.Value.Date > fecha_fin.Value.Date)
                            continue;
                        printableListView1.Items.Add(new ListViewItem(new[]
                                                                          {
                                                                              p.id,
                                                                              p.fecha_venta.Value.Date.ToString("dd/MM/yyyy"),
                                                                              p.id_tejedora != 9999 ? p.tejedora.id +"--"+ p.tejedora.nombre : p.tejedora.nombre + " (" + p.tejedora_anterior + ")",
                                                                              p.punto_venta.valor,
                                                                              Math.Round(
                                                                              Convert.ToDecimal(p.precio,
                                                                                                CultureInfo.
                                                                                                    InvariantCulture), 2)
                                                                              .ToString()
                                                                          }));
                        total_valor += Math.Round(
                            Convert.ToDecimal(p.precio,
                                              CultureInfo.
                                                  InvariantCulture), 2);
                    }
                    printableListView1.Items.Add(new ListViewItem(new[]
                                                                          {
                                                                              "",
                                                                              "",
                                                                              "",
                                                                              "",
                                                                                "Total:" + total_valor.ToString()
                                                                          }));
                }
                else if (fecha_inicio.Value.Date != fecha_fin.Value.Date && cbTejedora.SelectedIndex == 0 && cbPuntoVenta.SelectedIndex != 0)
                {
                    punto_venta = _idPuntoVenta[cbPuntoVenta.SelectedIndex];
                    foreach (var p in _entities.productos.Where(pro => pro.vendido == 1 && pro.id_punto_venta == punto_venta))
                    {
                        if (p.fecha_venta.Value.Date < fecha_inicio.Value.Date)
                            continue;
                        if (p.fecha_venta.Value.Date > fecha_fin.Value.Date)
                            continue;
                        printableListView1.Items.Add(new ListViewItem(new[]
                                                                          {
                                                                              p.id,
                                                                              p.fecha_venta.Value.Date.ToString("dd/MM/yyyy"),
                                                                              p.id_tejedora != 9999 ? p.tejedora.id +"--"+ p.tejedora.nombre : p.tejedora.nombre + " (" + p.tejedora_anterior + ")",
                                                                              p.punto_venta.valor,
                                                                              Math.Round(
                                                                              Convert.ToDecimal(p.precio,
                                                                                                CultureInfo.
                                                                                                    InvariantCulture), 2)
                                                                              .ToString()
                                                                          }));
                        total_valor += Math.Round(
                            Convert.ToDecimal(p.precio,
                                              CultureInfo.
                                                  InvariantCulture), 2);
                    }
                    printableListView1.Items.Add(new ListViewItem(new[]
                                                                          {
                                                                              "",
                                                                              "",
                                                                              "",
                                                                              "",
                                                                                "Total:" + total_valor.ToString()
                                                                          }));
                }
                
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void filtrar_Click(object sender, EventArgs e)
        {
            if (fecha_inicio.Value.Date > DateTime.Now.Date || fecha_fin.Value.Date > DateTime.Now.Date)
            {
                MessageBox.Show("La fecha de inicio y la fecha de fin no pueden ser mayor que la fecha actual",
                                "Error en la entrada de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (fecha_inicio.Value.Date > fecha_fin.Value.Date)
            {
                MessageBox.Show("La fecha de inicio debe ser menor que la fecha de fin",
                                "Error en la entrada de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.Reload();
        }
    }
}
