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
    public partial class ChequearAsignaciones : Form
    {
        private readonly mayaEntities _entities;
        public ChequearAsignaciones()
        {
            InitializeComponent();
            _entities = new mayaEntities();
        }

        private void ChequearAsignaciones_Load(object sender, EventArgs e)
        {
            this.Reload();
        }
        private void Reload()
        {
            try
            {
                if (fecha_inicio.Value.Date > DateTime.Now || fecha_fin.Value.Date > DateTime.Now)
                {
                    MessageBox.Show("La fecha de inicio o fin deben ser menor que la fecha actual",
                                    "Error en la entrada de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                foreach (var mpt in _entities.mp_tejedora)
                {
                    if(mpt.fehca.Date < fecha_inicio.Value.Date)
                        continue;
                    if(mpt.fehca.Date > fecha_fin.Value.Date)
                        continue;
                    printableListView1.Items.Add(new ListViewItem(new[]
                                                                      {
                                                                          mpt.materia_prima.descripcion,
                                                                          mpt.cantidad.ToString(),
                                                                          mpt.fehca.ToString("dd/MM/yyyy"),
                                                                          mpt.usuarios.nombre,
                                                                          mpt.tejedora.id.ToString() + " -- " + mpt.tejedora.nombre
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
            this.Reload();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            printableListView1.Title = "Reporte de asignación de materias primas a Tejedoras";
            this.printableListView1.PrintPreview();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            printableListView1.Title = "Reporte de asignación de materias primas a Tejedoras";
            this.printableListView1.PrintPreview();
        }
    }
}
