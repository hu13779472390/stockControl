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
    public partial class Utilidad : Form
    {
        private readonly mayaEntities _entities;
        public Utilidad()
        {
            InitializeComponent();
            _entities = new mayaEntities();
        }

        private void Utilidad_Load(object sender, EventArgs e)
        {
            this.Reload();
        }
        private  void Reload()
        {
            ventas.Text = "Ventas: ";
            gastos.Text = "Gastos: ";
            utilidadd.Text = "Utilidad: ";
            try
            {
                decimal v = 0;
                decimal g = 0;
                decimal u = 0;
                if(fecha_inicio.Value.Date == fecha_fin.Value.Date)
                {
                    foreach (var p in _entities.productos.Where(pro => pro.vendido == 1))
                    {
                        if(p.fecha_venta.Value.Date != fecha_inicio.Value.Date)
                            continue;
                        v += p.precio.Value;
                    }
                    foreach (var gas in _entities.gastos)
                    {
                        if (gas.fecha.Date != fecha_inicio.Value.Date)
                            continue;
                        g += gas.valor;
                    }
                    u = v - g;
                    ventas.Text += Math.Round(
                                            Convert.ToDecimal(v,
                                            CultureInfo.
                                                InvariantCulture), 2)
                                            .ToString();
                    gastos.Text += Math.Round(
                                            Convert.ToDecimal(g,
                                            CultureInfo.
                                                InvariantCulture), 2)
                                            .ToString();
                    utilidadd.Text += Math.Round(
                                            Convert.ToDecimal(u,
                                            CultureInfo.
                                                InvariantCulture), 2)
                                            .ToString();
                }
                else
                {
                    foreach (var p in _entities.productos.Where(pro => pro.vendido == 1))
                    {
                        if (p.fecha_venta.Value.Date < fecha_inicio.Value.Date)
                            continue;
                        if (p.fecha_venta.Value.Date > fecha_fin.Value.Date)
                            continue;
                        v += p.precio.Value;
                    }
                    foreach (var gas in _entities.gastos)
                    {
                        if (gas.fecha.Date < fecha_inicio.Value.Date)
                            continue;
                        if (gas.fecha.Date > fecha_fin.Value.Date)
                            continue;
                        g += gas.valor;
                    }
                    u = v - g;
                    ventas.Text += Math.Round(
                                            Convert.ToDecimal(v,
                                            CultureInfo.
                                                InvariantCulture), 2)
                                            .ToString();
                    gastos.Text += Math.Round(
                                            Convert.ToDecimal(g,
                                            CultureInfo.
                                                InvariantCulture), 2)
                                            .ToString();
                    utilidadd.Text += Math.Round(
                                            Convert.ToDecimal(u,
                                            CultureInfo.
                                                InvariantCulture), 2)
                                            .ToString();
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
