using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Maya.formularios;

namespace Maya
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (var entities = new mayaEntities())
                {
                    usuarios loguin_user =
                        entities.usuarios.Where(
                            u => u.usuario.Equals(textBox1.Text) && u.pass.Equals(textBox2.Text) && u.id != 3).
                            SingleOrDefault();
                    if(loguin_user != null)
                    {
                        entities.AddTobitacora(new bitacora
                                                   {
                                                       fecha = DateTime.Now,
                                                       id_usuario = loguin_user.id,
                                                       descripcion = "El usuario " + loguin_user.nombre + " " + loguin_user.apellidos + " se ha autenticado en el sistema"
                                                   });
                        entities.SaveChanges();
                        FormularioPrincipal fp = new FormularioPrincipal(this, loguin_user);
                        fp.Show();
                    }
                    else
                    {
                        entities.AddTobitacora(new bitacora
                                                   {
                                                       fecha = DateTime.Now,
                                                       id_usuario =  3,
                                                       descripcion = "Error en el intento de autenticarse con el usuario " + textBox1.Text
                                                   });
                        entities.SaveChanges();
                        MessageBox.Show("Usuario o contraseña no válidos", "Error en la entrada de datos",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de conexión con las Base de Datos", "Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                throw;
            }
        }
    }
}
