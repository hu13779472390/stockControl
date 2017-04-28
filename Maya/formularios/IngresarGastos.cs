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
    public partial class IngresarGastos : Form
    {
        private readonly usuarios _user;
        private readonly mayaEntities _entities;
        public IngresarGastos(usuarios user)
        {
            InitializeComponent();
            this._user = user;
            _entities = new mayaEntities();
        }

        private void IngresarGastos_Load(object sender, EventArgs e)
        {
            
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            fecha.Value = DateTime.Now;
            valor.Value = 0;
            descripcion.Text = "";
        }

        private void aceptarButton_Click(object sender, EventArgs e)
        {
            try
            {
                _entities.AddTogastos(new gastos
                                          {
                                              fecha = fecha.Value,
                                              descripcion = descripcion.Text,
                                              valor = Math.Round(
                                        Convert.ToDecimal(valor.Value,
                                          CultureInfo.InvariantCulture), 2)
                                          });
                _entities.AddTobitacora(new bitacora
                                            {
                                                id_usuario = _user.id,
                                                descripcion = "Se ha agregado un gasto.",
                                                fecha = fecha.Value
                                            });
                _entities.SaveChanges();
                fecha.Value = DateTime.Now;
                valor.Value = 0;
                descripcion.Text = "";
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
