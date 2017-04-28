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
    public partial class InventarioXDIa : Form
    {
        private readonly mayaEntities _entities;
        private List<int> _idPuntoVenta;
        private List<int> _idTejedora;
        private List<int> _idTipoProducto;
        public InventarioXDIa()
        {
            InitializeComponent();
            _entities = new mayaEntities();
            _idPuntoVenta = new List<int>();
            _idTejedora = new List<int>();
            _idTipoProducto = new List<int>();
        }

        private void InventarioXDIa_Load(object sender, EventArgs e)
        {
            ResetCombox();
            this.Reload();
        }
        private void ResetCombox()
        {
            //Lleno el combo
            comboBox1.Items.Clear();
            comboBox1.Items.Add("<Seleccione>");
            _idPuntoVenta.Add(0);
            comboBox1.Items.Add("Almacén");
            _idPuntoVenta.Add(0);

            foreach (var pv in _entities.punto_venta)
            {
                comboBox1.Items.Add(pv.valor);
                _idPuntoVenta.Add(pv.id);
            }
            comboBox1.SelectedIndex = 0;

            cbTejedora.Items.Clear();
            cbTejedora.Items.Add("<Seleccione>");
            _idTejedora.Add(0);
            foreach (var t in _entities.tejedora.Where(t => t.id != 9999))
            {
                cbTejedora.Items.Add(t.id.ToString() + " -- " + t.nombre);
                _idTejedora.Add(t.id);
            }
            cbTejedora.SelectedIndex = 0;

            cboxTipoProducto.Items.Clear();
            cboxTipoProducto.Items.Add("<Seleccione>");
            _idTipoProducto.Add(0);
            foreach (var tp in _entities.tipo_producto)
            {
                cboxTipoProducto.Items.Add(tp.valor);
                _idTipoProducto.Add(tp.id);
            }
            cboxTipoProducto.SelectedIndex = 0;

        }
        private void Reload()
        {
            try
            {
                this.printableListView1.Items.Clear();

                

                if (fecha_inicio.Value.Date > fecha_fin.Value.Date)
                {
                    MessageBox.Show("La fecha de inicio debe ser menor que la fecha final",
                                    "Error en la entrada de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //Variable para los valores totales por dias del punto de venta
                decimal valor = 0;
                int tejedora = 0;
                int tipoProducto = 0;

                //Caso en que se levanta la ventana por defecto o si selecciona el almacen
                if (comboBox1.SelectedIndex == 0 || comboBox1.SelectedIndex == 1)
                {
                    if (fecha_inicio.Value.Date == fecha_fin.Value.Date && cbTejedora.SelectedIndex == 0 && cboxTipoProducto.SelectedIndex == 0)
                    {
                        valor += Enumerable.Sum(_entities.productos.Where(pro => pro.id_punto_venta == null), p => p.valor);
                        this.printableListView1.Items.Add(new ListViewItem(new[]
                                                                           {
                                                                               fecha_inicio.Value.Date.ToString("dd/MM/yyyy"),
                                                                               "Almacén",
                                                                               Math.Round(
                                                                              Convert.ToDecimal(valor,
                                                                                                CultureInfo.
                                                                                                    InvariantCulture), 2)
                                                                              .ToString()
                                                                            }));
                    }
                    else if (fecha_inicio.Value.Date == fecha_fin.Value.Date && cbTejedora.SelectedIndex != 0 && cboxTipoProducto.SelectedIndex == 0)
                    {
                        tejedora = _idTejedora[cbTejedora.SelectedIndex];
                        valor += Enumerable.Sum(_entities.productos.Where(pro => pro.id_punto_venta == null && pro.id_tejedora == tejedora), p => p.valor);
                        this.printableListView1.Items.Add(new ListViewItem(new[]
                                                                           {
                                                                               fecha_inicio.Value.Date.ToString("dd/MM/yyyy"),
                                                                               "Almacén",
                                                                               Math.Round(
                                                                              Convert.ToDecimal(valor,
                                                                                                CultureInfo.
                                                                                                    InvariantCulture), 2)
                                                                              .ToString()
                                                                            }));
                    }
                    else if (fecha_inicio.Value.Date == fecha_fin.Value.Date && cbTejedora.SelectedIndex == 0 && cboxTipoProducto.SelectedIndex != 0)
                    {
                        tipoProducto = _idTipoProducto[cboxTipoProducto.SelectedIndex];
                        valor += Enumerable.Sum(_entities.productos.Where(pro => pro.id_punto_venta == null && pro.id_tipo_producto == tipoProducto), p => p.valor);
                        this.printableListView1.Items.Add(new ListViewItem(new[]
                                                                           {
                                                                               fecha_inicio.Value.Date.ToString("dd/MM/yyyy"),
                                                                               "Almacén",
                                                                               Math.Round(
                                                                              Convert.ToDecimal(valor,
                                                                                                CultureInfo.
                                                                                                    InvariantCulture), 2)
                                                                              .ToString()
                                                                            }));
                    }
                    else if (fecha_inicio.Value.Date == fecha_fin.Value.Date && cbTejedora.SelectedIndex != 0 && cboxTipoProducto.SelectedIndex != 0)
                    {
                        tipoProducto = _idTipoProducto[cboxTipoProducto.SelectedIndex];
                        tejedora = _idTejedora[cbTejedora.SelectedIndex];
                        valor += Enumerable.Sum(_entities.productos.Where(pro => pro.id_punto_venta == null && pro.id_tipo_producto == tipoProducto && pro.id_tejedora == tejedora), p => p.valor);
                        this.printableListView1.Items.Add(new ListViewItem(new[]
                                                                           {
                                                                               fecha_inicio.Value.Date.ToString("dd/MM/yyyy"),
                                                                               "Almacén",
                                                                               Math.Round(
                                                                              Convert.ToDecimal(valor,
                                                                                                CultureInfo.
                                                                                                    InvariantCulture), 2)
                                                                              .ToString()
                                                                            }));
                    }
                    else if (fecha_inicio.Value.Date != fecha_fin.Value.Date && cbTejedora.SelectedIndex == 0 && cboxTipoProducto.SelectedIndex == 0)
                    {
                        int cant_dias = fecha_fin.Value.Date.DayOfYear - fecha_inicio.Value.Date.DayOfYear;
                        for (int i = 0; i <= cant_dias; i++)
                        {
                            valor = 0;
                            foreach (var p in _entities.productos)
                            {
                                if (p.fecha_entrada.DayOfYear <= fecha_inicio.Value.DayOfYear + i)
                                {
                                    if (p.fecha_salida == null)
                                    {
                                        if (p.fecha_devolucion == null)
                                            valor += p.valor;
                                        else
                                        {
                                            if (p.fecha_devolucion.Value.DayOfYear <= fecha_inicio.Value.DayOfYear + i)
                                                valor += p.valor;
                                        }
                                    }

                                }
                            }
                            DateTime aux = fecha_inicio.Value.AddDays(i);
                            this.printableListView1.Items.Add(new ListViewItem(new[]
                                                                           {
                                                                               aux.Date.ToString("dd/MM/yyyy"),
                                                                               "Almacén",
                                                                               Math.Round(
                                                                              Convert.ToDecimal(valor,
                                                                                                CultureInfo.
                                                                                                    InvariantCulture), 2)
                                                                              .ToString()
                                                                            }));
                        }
                    }
                    else if (fecha_inicio.Value.Date != fecha_fin.Value.Date && cbTejedora.SelectedIndex != 0 && cboxTipoProducto.SelectedIndex == 0)
                    {
                        int cant_dias = fecha_fin.Value.Date.DayOfYear - fecha_inicio.Value.Date.DayOfYear;
                        tejedora = _idTejedora[cbTejedora.SelectedIndex];
                        for (int i = 0; i <= cant_dias; i++)
                        {
                            valor = 0;
                            foreach (var p in _entities.productos.Where(pro => pro.id_tejedora == tejedora))
                            {
                                if (p.fecha_entrada.DayOfYear <= fecha_inicio.Value.DayOfYear + i)
                                {
                                    if (p.fecha_salida == null)
                                    {
                                        if (p.fecha_devolucion == null)
                                            valor += p.valor;
                                        else
                                        {
                                            if (p.fecha_devolucion.Value.DayOfYear <= fecha_inicio.Value.DayOfYear + i)
                                                valor += p.valor;
                                        }
                                    }

                                }
                            }
                            DateTime aux = fecha_inicio.Value.AddDays(i);
                            this.printableListView1.Items.Add(new ListViewItem(new[]
                                                                           {
                                                                               aux.Date.ToString("dd/MM/yyyy"),
                                                                               "Almacén",
                                                                               Math.Round(
                                                                              Convert.ToDecimal(valor,
                                                                                                CultureInfo.
                                                                                                    InvariantCulture), 2)
                                                                              .ToString()
                                                                            }));
                        }
                    }
                    else if (fecha_inicio.Value.Date != fecha_fin.Value.Date && cbTejedora.SelectedIndex == 0 && cboxTipoProducto.SelectedIndex != 0)
                    {
                        int cant_dias = fecha_fin.Value.Date.DayOfYear - fecha_inicio.Value.Date.DayOfYear;
                        tipoProducto = _idTipoProducto[cboxTipoProducto.SelectedIndex];
                        for (int i = 0; i <= cant_dias; i++)
                        {
                            valor = 0;
                            foreach (var p in _entities.productos.Where(pro => pro.id_tipo_producto == tipoProducto))
                            {
                                if (p.fecha_entrada.DayOfYear <= fecha_inicio.Value.DayOfYear + i)
                                {
                                    if (p.fecha_salida == null)
                                    {
                                        if (p.fecha_devolucion == null)
                                            valor += p.valor;
                                        else
                                        {
                                            if (p.fecha_devolucion.Value.DayOfYear <= fecha_inicio.Value.DayOfYear + i)
                                                valor += p.valor;
                                        }
                                    }

                                }
                            }
                            DateTime aux = fecha_inicio.Value.AddDays(i);
                            this.printableListView1.Items.Add(new ListViewItem(new[]
                                                                           {
                                                                               aux.Date.ToString("dd/MM/yyyy"),
                                                                               "Almacén",
                                                                               Math.Round(
                                                                              Convert.ToDecimal(valor,
                                                                                                CultureInfo.
                                                                                                    InvariantCulture), 2)
                                                                              .ToString()
                                                                            }));
                        }
                    }
                    else if (fecha_inicio.Value.Date != fecha_fin.Value.Date && cbTejedora.SelectedIndex != 0 && cboxTipoProducto.SelectedIndex != 0)
                    {
                        int cant_dias = fecha_fin.Value.Date.DayOfYear - fecha_inicio.Value.Date.DayOfYear;
                        tipoProducto = _idTipoProducto[cboxTipoProducto.SelectedIndex];
                        tejedora = _idTejedora[cbTejedora.SelectedIndex];
                        for (int i = 0; i <= cant_dias; i++)
                        {
                            valor = 0;
                            foreach (var p in _entities.productos.Where(pro => pro.id_tipo_producto == tipoProducto && pro.id_tejedora == tejedora))
                            {
                                if (p.fecha_entrada.DayOfYear <= fecha_inicio.Value.DayOfYear + i)
                                {
                                    if (p.fecha_salida == null)
                                    {
                                        if (p.fecha_devolucion == null)
                                            valor += p.valor;
                                        else
                                        {
                                            if (p.fecha_devolucion.Value.DayOfYear <= fecha_inicio.Value.DayOfYear + i)
                                                valor += p.valor;
                                        }
                                    }

                                }
                            }
                            DateTime aux = fecha_inicio.Value.AddDays(i);
                            this.printableListView1.Items.Add(new ListViewItem(new[]
                                                                           {
                                                                               aux.Date.ToString("dd/MM/yyyy"),
                                                                               "Almacén",
                                                                               Math.Round(
                                                                              Convert.ToDecimal(valor,
                                                                                                CultureInfo.
                                                                                                    InvariantCulture), 2)
                                                                              .ToString()
                                                                            }));
                        }
                    }
                }
                //Caso en que sean puntos de ventas
                else
                {
                    if (fecha_inicio.Value.Date == fecha_fin.Value.Date && cbTejedora.SelectedIndex == 0 && cboxTipoProducto.SelectedIndex == 0)
                    {
                        var indice =
                            (punto_venta)
                            _entities.GetObjectByKey(new EntityKey("mayaEntities.punto_venta", "id",
                                                                   _idPuntoVenta[comboBox1.SelectedIndex]));
                        valor += Enumerable.Sum(_entities.productos.Where(pro => pro.id_punto_venta == indice.id),
                                                p => p.valor);
                        this.printableListView1.Items.Add(new ListViewItem(new[]
                                                                               {
                                                                                   fecha_inicio.Value.Date.ToString(
                                                                                       "dd/MM/yyyy"),
                                                                                   indice.valor,
                                                                                   Math.Round(
                                                                                       Convert.ToDecimal(valor,
                                                                                                         CultureInfo.
                                                                                                             InvariantCulture),
                                                                                       2)
                                                                                       .ToString()
                                                                               }));
                    }
                    else if (fecha_inicio.Value.Date == fecha_fin.Value.Date && cbTejedora.SelectedIndex != 0 && cboxTipoProducto.SelectedIndex == 0)
                    {
                        var indice =
                            (punto_venta)
                            _entities.GetObjectByKey(new EntityKey("mayaEntities.punto_venta", "id",
                                                                   _idPuntoVenta[comboBox1.SelectedIndex]));
                        tejedora = _idTejedora[cbTejedora.SelectedIndex];
                        valor += Enumerable.Sum(_entities.productos.Where(pro => pro.id_punto_venta == indice.id && pro.id_tejedora == tejedora),
                                                p => p.valor);
                        this.printableListView1.Items.Add(new ListViewItem(new[]
                                                                               {
                                                                                   fecha_inicio.Value.Date.ToString(
                                                                                       "dd/MM/yyyy"),
                                                                                   indice.valor,
                                                                                   Math.Round(
                                                                                       Convert.ToDecimal(valor,
                                                                                                         CultureInfo.
                                                                                                             InvariantCulture),
                                                                                       2)
                                                                                       .ToString()
                                                                               }));
                    }
                    else if (fecha_inicio.Value.Date == fecha_fin.Value.Date && cbTejedora.SelectedIndex != 0 && cboxTipoProducto.SelectedIndex != 0)
                    {
                        var indice =
                            (punto_venta)
                            _entities.GetObjectByKey(new EntityKey("mayaEntities.punto_venta", "id",
                                                                   _idPuntoVenta[comboBox1.SelectedIndex]));
                        tejedora = _idTejedora[cbTejedora.SelectedIndex];
                        tipoProducto = _idTipoProducto[cboxTipoProducto.SelectedIndex];
                        valor += Enumerable.Sum(_entities.productos.Where(pro => pro.id_punto_venta == indice.id && pro.id_tejedora == tejedora && pro.id_tipo_producto == tipoProducto),
                                                p => p.valor);
                        this.printableListView1.Items.Add(new ListViewItem(new[]
                                                                               {
                                                                                   fecha_inicio.Value.Date.ToString(
                                                                                       "dd/MM/yyyy"),
                                                                                   indice.valor,
                                                                                   Math.Round(
                                                                                       Convert.ToDecimal(valor,
                                                                                                         CultureInfo.
                                                                                                             InvariantCulture),
                                                                                       2)
                                                                                       .ToString()
                                                                               }));
                    }
                    else if (fecha_inicio.Value.Date == fecha_fin.Value.Date && cbTejedora.SelectedIndex == 0 && cboxTipoProducto.SelectedIndex != 0)
                    {
                        var indice =
                            (punto_venta)
                            _entities.GetObjectByKey(new EntityKey("mayaEntities.punto_venta", "id",
                                                                   _idPuntoVenta[comboBox1.SelectedIndex]));
                        tipoProducto = _idTipoProducto[cboxTipoProducto.SelectedIndex];
                        valor += Enumerable.Sum(_entities.productos.Where(pro => pro.id_punto_venta == indice.id && pro.id_tipo_producto == tipoProducto),
                                                p => p.valor);
                        this.printableListView1.Items.Add(new ListViewItem(new[]
                                                                               {
                                                                                   fecha_inicio.Value.Date.ToString(
                                                                                       "dd/MM/yyyy"),
                                                                                   indice.valor,
                                                                                   Math.Round(
                                                                                       Convert.ToDecimal(valor,
                                                                                                         CultureInfo.
                                                                                                             InvariantCulture),
                                                                                       2)
                                                                                       .ToString()
                                                                               }));
                    }
                    else
                    {
                        if(cbTejedora.SelectedIndex == 0 && cboxTipoProducto.SelectedIndex == 0)
                        {
                            var indice =
                            (punto_venta)
                            _entities.GetObjectByKey(new EntityKey("mayaEntities.punto_venta", "id",
                                                                   _idPuntoVenta[comboBox1.SelectedIndex]));
                            int cant_dias = fecha_fin.Value.Date.DayOfYear - fecha_inicio.Value.Date.DayOfYear;
                            for (int i = 0; i <= cant_dias; i++)
                            {
                                valor = 0;
                                foreach (var p in _entities.productos.Where(pro => pro.id_punto_venta == indice.id))
                                {
                                    if (p.fecha_salida != null)
                                        if (p.fecha_salida.Value.DayOfYear <= fecha_inicio.Value.DayOfYear + i)
                                        {
                                            if (p.fecha_venta == null)
                                                valor += p.valor;
                                            else if (p.fecha_venta.Value.DayOfYear > fecha_inicio.Value.DayOfYear + i)
                                                valor += p.valor;
                                        }
                                }
                                DateTime aux = fecha_inicio.Value.AddDays(i);
                                this.printableListView1.Items.Add(new ListViewItem(new[]
                                                                                   {
                                                                                       aux.Date.ToString("dd/MM/yyyy"),
                                                                                       indice.valor,
                                                                                       Math.Round(
                                                                                           Convert.ToDecimal(valor,
                                                                                                             CultureInfo
                                                                                                                 .
                                                                                                                 InvariantCulture),
                                                                                           2)
                                                                                           .ToString()
                                                                                   }));
                            }
                        }
                        else if (cbTejedora.SelectedIndex != 0 && cboxTipoProducto.SelectedIndex != 0)
                        {
                            var indice =
                            (punto_venta)
                            _entities.GetObjectByKey(new EntityKey("mayaEntities.punto_venta", "id",
                                                                   _idPuntoVenta[comboBox1.SelectedIndex]));
                            tejedora = _idTejedora[cbTejedora.SelectedIndex];
                            tipoProducto = _idTipoProducto[cboxTipoProducto.SelectedIndex];
                            int cant_dias = fecha_fin.Value.Date.DayOfYear - fecha_inicio.Value.Date.DayOfYear;
                            for (int i = 0; i <= cant_dias; i++)
                            {
                                valor = 0;
                                foreach (var p in _entities.productos.Where(pro => pro.id_punto_venta == indice.id && pro.id_tejedora == tejedora && pro.id_tipo_producto == tipoProducto))
                                {
                                    if (p.fecha_salida != null)
                                        if (p.fecha_salida.Value.DayOfYear <= fecha_inicio.Value.DayOfYear + i)
                                        {
                                            if (p.fecha_venta == null)
                                                valor += p.valor;
                                            else if (p.fecha_venta.Value.DayOfYear > fecha_inicio.Value.DayOfYear + i)
                                                valor += p.valor;
                                        }
                                }
                                DateTime aux = fecha_inicio.Value.AddDays(i);
                                this.printableListView1.Items.Add(new ListViewItem(new[]
                                                                                   {
                                                                                       aux.Date.ToString("dd/MM/yyyy"),
                                                                                       indice.valor,
                                                                                       Math.Round(
                                                                                           Convert.ToDecimal(valor,
                                                                                                             CultureInfo
                                                                                                                 .
                                                                                                                 InvariantCulture),
                                                                                           2)
                                                                                           .ToString()
                                                                                   }));
                            }
                        }
                        else if (cbTejedora.SelectedIndex != 0 && cboxTipoProducto.SelectedIndex == 0)
                        {
                            var indice =
                            (punto_venta)
                            _entities.GetObjectByKey(new EntityKey("mayaEntities.punto_venta", "id",
                                                                   _idPuntoVenta[comboBox1.SelectedIndex]));
                            tejedora = _idTejedora[cbTejedora.SelectedIndex];
                            int cant_dias = fecha_fin.Value.Date.DayOfYear - fecha_inicio.Value.Date.DayOfYear;
                            for (int i = 0; i <= cant_dias; i++)
                            {
                                valor = 0;
                                foreach (var p in _entities.productos.Where(pro => pro.id_punto_venta == indice.id && pro.id_tejedora == tejedora))
                                {
                                    if (p.fecha_salida != null)
                                        if (p.fecha_salida.Value.DayOfYear <= fecha_inicio.Value.DayOfYear + i)
                                        {
                                            if (p.fecha_venta == null)
                                                valor += p.valor;
                                            else if (p.fecha_venta.Value.DayOfYear > fecha_inicio.Value.DayOfYear + i)
                                                valor += p.valor;
                                        }
                                }
                                DateTime aux = fecha_inicio.Value.AddDays(i);
                                this.printableListView1.Items.Add(new ListViewItem(new[]
                                                                                   {
                                                                                       aux.Date.ToString("dd/MM/yyyy"),
                                                                                       indice.valor,
                                                                                       Math.Round(
                                                                                           Convert.ToDecimal(valor,
                                                                                                             CultureInfo
                                                                                                                 .
                                                                                                                 InvariantCulture),
                                                                                           2)
                                                                                           .ToString()
                                                                                   }));
                            }
                        }
                        else if (cbTejedora.SelectedIndex == 0 && cboxTipoProducto.SelectedIndex != 0)
                        {
                            var indice =
                            (punto_venta)
                            _entities.GetObjectByKey(new EntityKey("mayaEntities.punto_venta", "id",
                                                                   _idPuntoVenta[comboBox1.SelectedIndex]));
                            tipoProducto = _idTipoProducto[cboxTipoProducto.SelectedIndex];
                            int cant_dias = fecha_fin.Value.Date.DayOfYear - fecha_inicio.Value.Date.DayOfYear;
                            for (int i = 0; i <= cant_dias; i++)
                            {
                                valor = 0;
                                foreach (var p in _entities.productos.Where(pro => pro.id_punto_venta == indice.id && pro.id_tipo_producto == tipoProducto))
                                {
                                    if (p.fecha_salida != null)
                                        if (p.fecha_salida.Value.DayOfYear <= fecha_inicio.Value.DayOfYear + i)
                                        {
                                            if (p.fecha_venta == null)
                                                valor += p.valor;
                                            else if (p.fecha_venta.Value.DayOfYear > fecha_inicio.Value.DayOfYear + i)
                                                valor += p.valor;
                                        }
                                }
                                DateTime aux = fecha_inicio.Value.AddDays(i);
                                this.printableListView1.Items.Add(new ListViewItem(new[]
                                                                                   {
                                                                                       aux.Date.ToString("dd/MM/yyyy"),
                                                                                       indice.valor,
                                                                                       Math.Round(
                                                                                           Convert.ToDecimal(valor,
                                                                                                             CultureInfo
                                                                                                                 .
                                                                                                                 InvariantCulture),
                                                                                           2)
                                                                                           .ToString()
                                                                                   }));
                            }
                        }
                    }

                }
                ResetCombox();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
        }

        private void filtrar_Click(object sender, EventArgs e)
        {
            this.Reload();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.printableListView1.Title = "Inventario por Dias";
            this.printableListView1.PrintPreview();
        }

        private void Imprimir_Click(object sender, EventArgs e)
        {
            this.printableListView1.Title = "Inventario por Dias";
            this.printableListView1.Print();
        }
    }
}
