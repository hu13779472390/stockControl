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
    public partial class AsignarMPaTejedora : Form
    {
        private readonly mayaEntities _entities;
        private readonly usuarios _user;
        private List<int> _idTejedora;
        private List<int> _idMateriasP;
        public AsignarMPaTejedora(usuarios user)
        {
            InitializeComponent();
            _user = user;
            _idTejedora = new List<int>();
            _entities = new mayaEntities();
            _idMateriasP = new List<int>();
        }
        private void Reload()
        {
            try
            {
                Tejedora.Items.Clear();
                Tejedora.Items.Add("<Seleccione>");
                Tejedora.DefaultCellStyle.NullValue = "<Seleccione>";
                _idTejedora.Add(0);

                foreach (var t in _entities.tejedora.Where(te => te.id != 9999))
                {
                    Tejedora.Items.Add(t.id.ToString() + " -- " + t.nombre);
                    _idTejedora.Add(t.id);
                }
                dataGridView1.Rows.Clear();

                foreach (var mp in _entities.materia_prima.Where(mp => mp.cantidad != 0))
                {
                    dataGridView1.Rows.Add(new object[]
                                               {
                                                   mp.descripcion,
                                                   mp.cantidad.ToString()
                                               });
                    _idMateriasP.Add(mp.id);
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void AsignarMPaTejedora_Load(object sender, EventArgs e)
        {
            this.Reload();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells["Cantidad_a_Asignar"].Value == null)
                return;
            try
            {
                var x = dataGridView1.Rows[e.RowIndex].Cells["Cantidad_a_Asignar"].Value.ToString();
                decimal.Parse(x);
            }
            catch (Exception)
            {
                MessageBox.Show("La cantidad a asignar debe ser un número", "Error en la entrada de datos",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int pos_select = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells["Tejedora"].Value == null && dataGridView1.Rows[i].Cells["Cantidad_a_Asignar"].Value != null)
                    {
                        MessageBox.Show("Debe seleccionar una tejedora a la cual asignarle las materias primas",
                                        "Error en la entrada de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    if (dataGridView1.Rows[i].Cells["Tejedora"].Value != null && dataGridView1.Rows[i].Cells["Cantidad_a_Asignar"].Value == null)
                    {
                        MessageBox.Show(
                            "Debe introducir la cantidad de materias primas que desea asignar a la tejedora",
                            "Error en la entrada de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    if (dataGridView1.Rows[i].Cells["Tejedora"].Value == null && dataGridView1.Rows[i].Cells["Cantidad_a_Asignar"].Value == null)
                        continue;
                    List<char> aux = new List<char>();
                    string id = "";
                    aux = dataGridView1.Rows[i].Cells["Tejedora"].Value.ToString().ToList();

                    foreach (var elemento in aux)
                    {
                        if(elemento.Equals(' '))
                            break;
                        id += elemento;
                    }
                    materia_prima mp =
                        (materia_prima)_entities.GetObjectByKey(new EntityKey("mayaEntities.materia_prima", "id", _idMateriasP[i]));
                    tejedora t =
                        (tejedora) _entities.GetObjectByKey(new EntityKey("mayaEntities.tejedora", "id", int.Parse(id)));
                    decimal variable = decimal.Parse(dataGridView1.Rows[i].Cells["Cantidad_a_Asignar"].Value.ToString());
                    if(mp.cantidad - variable < 0)
                    {
                        MessageBox.Show(
                            "No se pudo rebajar la cantidad especificada de la materia prima\n" + "(" + mp.descripcion + ") existe menos cantidad de lo que se desea rebajar",
                            "No se puede realizar la operación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        continue;
                    }
                    else
                    {
                        mp.cantidad -= variable;
                        _entities.AddTomp_tejedora(new mp_tejedora
                                                       {
                                                           id_mp = mp.id,
                                                           id_tejedora = int.Parse(id),
                                                           fehca = DateTime.Now,
                                                           cantidad = variable,
                                                           id_usuario = _user.id
                                                       });
                        _entities.AddTobitacora(new bitacora
                                                    {
                                                        id_usuario = _user.id,
                                                        descripcion = "El usuario " + _user.nombre + " ha asignado " + variable.ToString() + " unidades de " + mp.descripcion + "\na la tejedora " + t.id.ToString() + " -- " + t.nombre,
                                                        fecha = DateTime.Now
                                                    });
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
