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
    public partial class ReporteBitacora : Form
    {
        private readonly mayaEntities _entities;
        private List<int> _idUsuario;
        public ReporteBitacora()
        {
            InitializeComponent();
            _idUsuario = new List<int>();
            _entities = new mayaEntities();
        }

        private void ReporteBitacora_Load(object sender, EventArgs e)
        {
            try
            {
                //Lleno los combox de los filtros
                cbUsuario.Items.Add("<Seleccione>");
                _idUsuario.Add(0);
                foreach (var u in _entities.usuarios.Where(us => us.id != 3))
                {
                    cbUsuario.Items.Add(u.nombre);
                    _idUsuario.Add(u.id);
                }
                cbUsuario.SelectedIndex = 0;

                foreach (var b in _entities.bitacora.OrderByDescending(bs => bs.fecha))
                {
                    printableListView1.Items.Add(new ListViewItem(new[]
                                                                      {
                                                                          b.usuarios.nombre,
                                                                          b.descripcion,
                                                                          b.fecha.Value.ToString("dd/MM/yyyy")
                                                                      }));
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
                printableListView1.Items.Clear();
                var user = _idUsuario[cbUsuario.SelectedIndex];
                if(fecha.Value.Date != DateTime.Now && cbUsuario.SelectedIndex != 0 && !descripcion.Text.Equals(""))
                {
                    foreach (var b in _entities.bitacora.Where(bi => bi.usuarios.id == user && bi.fecha.Value.Year == fecha.Value.Year && bi.fecha.Value.Month == fecha.Value.Month && bi.fecha.Value.Day == fecha.Value.Day && bi.descripcion.Contains(descripcion.Text)).OrderByDescending(bs => bs.fecha))
                    {
                        printableListView1.Items.Add(new ListViewItem(new[]
                                                                      {
                                                                          b.usuarios.nombre,
                                                                          b.descripcion,
                                                                          b.fecha.Value.ToString("dd/MM/yyyy")
                                                                      }));
                    }
                }
                else if (fecha.Value.Date != DateTime.Now && cbUsuario.SelectedIndex != 0 && descripcion.Text.Equals(""))
                {
                    foreach (var b in _entities.bitacora.Where(bi => bi.usuarios.id == user && bi.fecha.Value.Year == fecha.Value.Year && bi.fecha.Value.Month == fecha.Value.Month && bi.fecha.Value.Day == fecha.Value.Day).OrderByDescending(bs => bs.fecha))
                    {
                        printableListView1.Items.Add(new ListViewItem(new[]
                                                                      {
                                                                          b.usuarios.nombre,
                                                                          b.descripcion,
                                                                          b.fecha.Value.ToString("dd/MM/yyyy")
                                                                      }));
                    }
                }
                else if (fecha.Value.Date != DateTime.Now && cbUsuario.SelectedIndex == 0 && descripcion.Text.Equals(""))
                {
                    foreach (var b in _entities.bitacora.Where(bi => bi.fecha.Value.Year == fecha.Value.Year && bi.fecha.Value.Month == fecha.Value.Month && bi.fecha.Value.Day == fecha.Value.Day).OrderByDescending(bs => bs.fecha))
                    {
                        printableListView1.Items.Add(new ListViewItem(new[]
                                                                      {
                                                                          b.usuarios.nombre,
                                                                          b.descripcion,
                                                                          b.fecha.Value.ToString("dd/MM/yyyy")
                                                                      }));
                    }
                }
                else if (fecha.Value.Date == DateTime.Now && cbUsuario.SelectedIndex != 0 && !descripcion.Text.Equals(""))
                {
                    foreach (var b in _entities.bitacora.Where(bi => bi.usuarios.id == user && bi.descripcion.Contains(descripcion.Text)).OrderByDescending(bs => bs.fecha))
                    {
                        printableListView1.Items.Add(new ListViewItem(new[]
                                                                      {
                                                                          b.usuarios.nombre,
                                                                          b.descripcion,
                                                                          b.fecha.Value.ToString("dd/MM/yyyy")
                                                                      }));
                    }
                }
                else if (fecha.Value.Date == DateTime.Now && cbUsuario.SelectedIndex == 0 && !descripcion.Text.Equals(""))
                {
                    foreach (var b in _entities.bitacora.Where(bi => bi.descripcion.Contains(descripcion.Text)).OrderByDescending(bs => bs.fecha))
                    {
                        printableListView1.Items.Add(new ListViewItem(new[]
                                                                      {
                                                                          b.usuarios.nombre,
                                                                          b.descripcion,
                                                                          b.fecha.Value.ToString("dd/MM/yyyy")
                                                                      }));
                    }
                }
                else if (fecha.Value.Date == DateTime.Now && cbUsuario.SelectedIndex != 0 && descripcion.Text.Equals(""))
                {
                    foreach (var b in _entities.bitacora.Where(bi => bi.usuarios.id == user).OrderByDescending(bs => bs.fecha))
                    {
                        printableListView1.Items.Add(new ListViewItem(new[]
                                                                      {
                                                                          b.usuarios.nombre,
                                                                          b.descripcion,
                                                                          b.fecha.Value.ToString("dd/MM/yyyy")
                                                                      }));
                    }
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
