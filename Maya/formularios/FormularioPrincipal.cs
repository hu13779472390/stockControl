using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Maya.formularios;
using Application = System.Windows.Forms.Application;
using Maya;

namespace Maya.formularios
{
    public partial class FormularioPrincipal : Form
    {
        private Form _loguin;
        private usuarios _user;
        private bool _cambiarUsuario;
        private List<int> _idTejedoras;
        private List<int> _idTipoProductos;
        private int anno;
        private readonly mayaEntities _entities;
        public FormularioPrincipal(Form loguin, usuarios user)
        {
            InitializeComponent();
            _loguin = loguin;
            _loguin.Hide();
            this._user = user;
            _entities = new mayaEntities();
            _idTejedoras = new List<int>();
            _idTipoProductos = new List<int>();
            anno = 0;
        }

        private void FormularioPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(!_cambiarUsuario)_loguin.Close();
        }

        private void gestionarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestionarUsuarios gu = new GestionarUsuarios(this._user);
            gu.ShowDialog();
            this.Reload();
        }

        private void gestionarTejedorasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestionarTejedoras gt = new GestionarTejedoras(this._user);
            gt.ShowDialog();
            this.Reload();
        }

        private void gestionarTipoDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestionarTiposProductos gtp =  new GestionarTiposProductos(this._user);
            gtp.ShowDialog();
            this.Reload();
        }

        private void gestionarPuntosDeVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestionarPuntoVenta gpv = new GestionarPuntoVenta(this._user);
            gpv.ShowDialog();
            this.Reload();
        }

        private void entradaDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EntradaProductos ep = new EntradaProductos(this._user);
            ep.ShowDialog();
            this.Reload();
        }

        private void entradaDeProductosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PV_EntradaProductos pv = new PV_EntradaProductos(this._user);
            pv.ShowDialog();
            this.Reload();
        }

        private void FormularioPrincipal_Load(object sender, EventArgs e)
        {
            if (_user == null)
            {
                Application.Exit();
                return;
            }
            try
            {
                this.UseWaitCursor = true;
                //Lleno los combox del filtro
                cboxTejedora.Items.Add("<Seleccione>");
                _idTejedoras.Add(0);
                foreach (var tejedpra in _entities.tejedora)
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

                decimal valor = 0;
                //Lleno el Reporte de Inventario
                foreach (var p in _entities.productos.Where(pr => pr.id_punto_venta == null && pr.vendido == null))
                {
                    valor += Math.Round(
                        Convert.ToDecimal(p.valor,
                                          CultureInfo.InvariantCulture), 2);
                    printableInventario.Items.Add(new ListViewItem(new[]
                                                                       {
                                                                           p.id,
                                                                           p.id_tejedora != 9999 ? p.tejedora.id + " -- " + p.tejedora.nombre : p.tejedora.nombre + " (" + p.tejedora_anterior + ")",
                                                                           p.tipo_producto.valor,
                                                                           p.descripcion,
                                                                           p.fecha_entrada.Date.ToString("dd/MM/yyyy"),
                                                                           Math.Round(
                                                                                Convert.ToDecimal(p.valor,
                                                                                CultureInfo.InvariantCulture), 2).ToString()
                                                                       }));
                }
                    printableInventario.Items.Add(new ListViewItem(new[]
                                                                           {
                                                                               "",
                                                                               "",
                                                                               "",
                                                                               "",
                                                                               "",
                                                                               "Total:" + valor.ToString()
                                                                           }));

                //Voy creando tagsControl por la cantidad de puntos de ventas que existe y muestr dentro de las tags
                //printlistview con los elementos que tiene el punto de venta
                foreach (var pv in _entities.punto_venta)
                {
                    //Creo el tab con el nombre del punto de venta
                    TabPage nuevo_tab = new TabPage("PV--" + pv.valor);
                    //Creo el list view
                    ListView ltvw = new ListView();
                    //Agrego el listview el tag
                    nuevo_tab.Controls.Add(ltvw);
                    //Expando el listview por toda la pantalla
                    ltvw.Dock = DockStyle.Fill;
                    //Le digo al listview q el view q va utlizar es details
                    ltvw.View = View.Details;
                    //Le digo al listview que muestre las celdas
                    ltvw.GridLines = true;
                    //Comienzo a agregarle columnas a los listview
                    ltvw.Columns.Add("Identificador", 88);
                    ltvw.Columns.Add("Tejedora", 152);
                    ltvw.Columns.Add("Tipo de Productos", 158);
                    ltvw.Columns.Add("Descripción", 400);
                    ltvw.Columns.Add("Fecha de Entrada", 119);
                    ltvw.Columns.Add("Precio", 73);

                    //reinicio valor para capturar el total de cada punto de venta
                    valor = 0;

                    //Me muevo por todos los elementos que hay en el punto de venta
                    foreach (var p in _entities.productos.Where(pro => pro.id_punto_venta == pv.id && pro.vendido == null))
                    {
                        ltvw.Items.Add(new ListViewItem(new[]
                                                            {
                                                                p.id,
                                                                p.id_tejedora != 9999 ? p.tejedora.id + " -- " + p.tejedora.nombre : p.tejedora.nombre + " (" + p.tejedora_anterior + ")",
                                                                p.tipo_producto.valor,
                                                                p.descripcion,
                                                                p.fecha_entrada.Date.ToString("dd/MM/yyyy"),
                                                                Math.Round(
                                                                                Convert.ToDecimal(p.precio,
                                                                                CultureInfo.InvariantCulture), 2).ToString()
                                                            }));
                        valor += Math.Round(
                            Convert.ToDecimal(p.valor,
                                              CultureInfo.InvariantCulture), 2);
                    }
                    ltvw.Items.Add(new ListViewItem(new[]
                                                            {
                                                                "",
                                                                "",
                                                                "",
                                                                "",
                                                                "",
                                                                "Total:" + valor.ToString()
                                                            }));

                    tabControl.Controls.Add(nuevo_tab);
                }
                this.UseWaitCursor = false;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void Reload()
        {
            if (_user == null)
            {
                Application.Exit();
                return;
            }
            try
            {
                this.UseWaitCursor = true;
                //Lleno los combox del filtro
                cboxTejedora.Items.Clear();
                cboxTejedora.Items.Add("<Seleccione>");
                _idTejedoras.Add(0);
                foreach (var tejedpra in _entities.tejedora)
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

                printableInventario.Items.Clear();
                decimal valor = 0;
                //Lleno el Reporte de Inventario
                foreach (var p in _entities.productos.Where(pr => pr.id_punto_venta == null && pr.vendido == null))
                {
                    valor += Math.Round(
                        Convert.ToDecimal(p.valor,
                                          CultureInfo.InvariantCulture), 2);
                    printableInventario.Items.Add(new ListViewItem(new[]
                                                                       {
                                                                           p.id,
                                                                           p.id_tejedora != 9999 ? p.tejedora.id + " -- " + p.tejedora.nombre : p.tejedora.nombre + " (" + p.tejedora_anterior + ")",
                                                                           p.tipo_producto.valor,
                                                                           p.descripcion,
                                                                           p.fecha_entrada.Date.ToString("dd/MM/yyyy"),
                                                                           Math.Round(
                                                                                Convert.ToDecimal(p.valor,
                                                                                CultureInfo.InvariantCulture), 2).ToString()
                                                                       }));
                }
                printableInventario.Items.Add(new ListViewItem(new[]
                                                                           {
                                                                               "",
                                                                               "",
                                                                               "",
                                                                               "",
                                                                               "",
                                                                               "Total:" + valor.ToString()
                                                                           }));
                int x = tabControl.Controls.Count;
                while (x != 1)
                {
                    tabControl.Controls.RemoveAt(x -1);
                    x--;
                }
                
                //Voy creando tagsControl por la cantidad de puntos de ventas que existe y muestr dentro de las tags
                //printlistview con los elementos que tiene el punto de venta
                foreach (var pv in _entities.punto_venta)
                {
                    //Creo el tab con el nombre del punto de venta
                    TabPage nuevo_tab = new TabPage("PV--" + pv.valor);
                    //Creo el list view
                    ListView ltvw = new ListView();
                    //Agrego el listview el tag
                    nuevo_tab.Controls.Add(ltvw);
                    //Expando el listview por toda la pantalla
                    ltvw.Dock = DockStyle.Fill;
                    //Le digo al listview q el view q va utlizar es details
                    ltvw.View = View.Details;
                    //Le digo al listview que muestre las celdas
                    ltvw.GridLines = true;
                    //Comienzo a agregarle columnas a los listview
                    ltvw.Columns.Add("Identificador", 88);
                    ltvw.Columns.Add("Tejedora", 152);
                    ltvw.Columns.Add("Tipo de Productos", 158);
                    ltvw.Columns.Add("Descripción", 400);
                    ltvw.Columns.Add("Fecha de Entrada", 119);
                    ltvw.Columns.Add("Precio", 73);

                    //reinicio valor para capturar el total de cada punto de venta
                    valor = 0;

                    //Me muevo por todos los elementos que hay en el punto de venta
                    foreach (var p in _entities.productos.Where(pro => pro.id_punto_venta == pv.id && pro.vendido == null))
                    {
                        ltvw.Items.Add(new ListViewItem(new[]
                                                            {
                                                                p.id,
                                                                p.id_tejedora != 9999 ? p.tejedora.id + " -- " + p.tejedora.nombre : p.tejedora.nombre + " (" + p.tejedora_anterior + ")",
                                                                p.tipo_producto.valor,
                                                                p.descripcion,
                                                                p.fecha_entrada.Date.ToString("dd/MM/yyyy"),
                                                                Math.Round(
                                                                                Convert.ToDecimal(p.precio,
                                                                                CultureInfo.InvariantCulture), 2).ToString()
                                                            }));
                        valor += Math.Round(
                            Convert.ToDecimal(p.valor,
                                              CultureInfo.InvariantCulture), 2);
                    }
                    ltvw.Items.Add(new ListViewItem(new[]
                                                            {
                                                                "",
                                                                "",
                                                                "",
                                                                "",
                                                                "",
                                                                "Total:" + valor.ToString()
                                                            }));

                    tabControl.Controls.Add(nuevo_tab);
                }
                this.UseWaitCursor = false;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _cambiarUsuario = true;
            _loguin.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                decimal valor = 0;
                var t = _idTejedoras[cboxTejedora.SelectedIndex];
                var tp = _idTipoProductos[cboxTipoProducto.SelectedIndex];
                var a = (int) numericUpDown1.Value;
                printableInventario.Items.Clear();
                if (t == 0 && tp == 0)
                {
                    foreach (var p in _entities.productos.Where(p => p.anno == a && p.id_punto_venta == null && p.vendido == null))
                    {
                        printableInventario.Items.Add(new ListViewItem(new[]
                                                                       {
                                                                           p.id,
                                                                           p.id_tejedora != 9999 ? p.tejedora.id + " -- " + p.tejedora.nombre : p.tejedora.nombre + " (" + p.tejedora_anterior + ")",
                                                                           p.tipo_producto.valor,
                                                                           p.descripcion,
                                                                           p.fecha_entrada.Date.ToString("dd/MM/yyyy"),
                                                                           Math.Round(
                                                                                Convert.ToDecimal(p.valor,
                                                                                CultureInfo.InvariantCulture), 2).ToString()
                                                                       }));
                        valor += Math.Round(
                            Convert.ToDecimal(p.valor,
                                              CultureInfo.InvariantCulture), 2);
                    }
                    printableInventario.Items.Add(new ListViewItem(new[]
                                                                           {
                                                                               "",
                                                                               "",
                                                                               "",
                                                                               "",
                                                                               "",
                                                                               "Total:" + valor.ToString()
                                                                           }));
                }
                else if (tp != 0 && t == 0)
                {
                    foreach (var p in _entities.productos.Where(p => p.anno == a && p.id_tipo_producto == tp && p.id_punto_venta == null && p.vendido == null))
                    {
                        printableInventario.Items.Add(new ListViewItem(new[]
                                                                       {
                                                                           p.id,
                                                                           p.id_tejedora != 9999 ? p.tejedora.id + " -- " + p.tejedora.nombre : p.tejedora.nombre + " (" + p.tejedora_anterior + ")",
                                                                           p.tipo_producto.valor,
                                                                           p.descripcion,
                                                                           p.fecha_entrada.Date.ToString("dd/MM/yyyy"),
                                                                           Math.Round(
                                                                                Convert.ToDecimal(p.valor,
                                                                                CultureInfo.InvariantCulture), 2).ToString()
                                                                       }));
                        valor += Math.Round(
                           Convert.ToDecimal(p.valor,
                                             CultureInfo.InvariantCulture), 2);
                    }
                    printableInventario.Items.Add(new ListViewItem(new[]
                                                                           {
                                                                               "",
                                                                               "",
                                                                               "",
                                                                               "",
                                                                               "",
                                                                               "Total:" + valor.ToString()
                                                                           }));
                }
                else if (tp == 0 && t != 0)
                {
                    foreach (var p in _entities.productos.Where(p => p.anno == a && p.id_tejedora == t && p.id_punto_venta == null && p.vendido == null))
                    {
                        printableInventario.Items.Add(new ListViewItem(new[]
                                                                       {
                                                                           p.id,
                                                                           p.id_tejedora != 9999 ? p.tejedora.id + " -- " + p.tejedora.nombre : p.tejedora.nombre + " (" + p.tejedora_anterior + ")",
                                                                           p.tipo_producto.valor,
                                                                           p.descripcion,
                                                                           p.fecha_entrada.Date.ToString("dd/MM/yyyy"),
                                                                           Math.Round(
                                                                                Convert.ToDecimal(p.valor,
                                                                                CultureInfo.InvariantCulture), 2).ToString()
                                                                       }));
                        valor += Math.Round(
                           Convert.ToDecimal(p.valor,
                                             CultureInfo.InvariantCulture), 2);
                    }
                    printableInventario.Items.Add(new ListViewItem(new[]
                                                                           {
                                                                               "",
                                                                               "",
                                                                               "",
                                                                               "",
                                                                               "",
                                                                               "Total:" + valor.ToString()
                                                                           }));
                }
                else
                {
                    foreach (var p in _entities.productos.Where(p => p.anno == a && p.id_tejedora == t && p.id_tipo_producto == tp && p.id_punto_venta == null && p.vendido == null))
                    {
                        printableInventario.Items.Add(new ListViewItem(new[]
                                                                       {
                                                                           p.id,
                                                                           p.id_tejedora != 9999 ? p.tejedora.id + " -- " + p.tejedora.nombre : p.tejedora.nombre + " (" + p.tejedora_anterior + ")",
                                                                           p.tipo_producto.valor,
                                                                           p.descripcion,
                                                                           p.fecha_entrada.Date.ToString("dd/MM/yyyy"),
                                                                           Math.Round(
                                                                                Convert.ToDecimal(p.valor,
                                                                                CultureInfo.InvariantCulture), 2).ToString()
                                                                       }));
                        valor += Math.Round(
                           Convert.ToDecimal(p.valor,
                                             CultureInfo.InvariantCulture), 2);
                    }
                    printableInventario.Items.Add(new ListViewItem(new[]
                                                                           {
                                                                               "",
                                                                               "",
                                                                               "",
                                                                               "",
                                                                               "",
                                                                               "Total:" + valor.ToString()
                                                                           }));
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void bitácoraDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReporteBitacora rb = new ReporteBitacora();
            rb.ShowDialog();
        }

        private void ingresarGastosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IngresarGastos ig = new IngresarGastos(this._user);
            ig.ShowDialog();
        }

        private void chequearGastosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChequearGastos cg = new ChequearGastos();
            cg.ShowDialog();
            this.Reload();
        }

        private void reporteDeInventarioPorDiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InventarioXDIa ixd = new InventarioXDIa();
            ixd.ShowDialog();
            this.Reload();
        }

        private void ventaPorDiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VentaPorDias vd = new VentaPorDias();
            vd.ShowDialog();
            this.Reload();
        }

        private void reporteDeUtilidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidad u = new Utilidad();
            u.ShowDialog();
            this.Reload();
        }

        private void reporteDeLosProductosMasVendidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductosMasVendidos pmv = new ProductosMasVendidos();
            pmv.ShowDialog();
            this.Reload();
        }

        private void eliminarModificarProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EliminarProductos ep = new EliminarProductos(this._user);
            ep.ShowDialog();
            this.Reload();
        }

        private void agregarMateriasPrimasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MateriasPrimas mp = new MateriasPrimas(this._user);
            mp.ShowDialog();
        }

        private void asignarMateriasPrimasATejedorasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AsignarMPaTejedora amp = new AsignarMPaTejedora(this._user);
            amp.ShowDialog();
        }

        private void chequearAsignacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChequearAsignaciones cha = new ChequearAsignaciones();
            cha.ShowDialog();
        }
    }
}
