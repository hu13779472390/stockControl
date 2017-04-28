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
    public partial class EntradaProductos : Form
    {
        private readonly mayaEntities _entities;
        private List<int> _idTipoProductos;
        private List<int> _idTejedora;
        private readonly usuarios _user;
        public EntradaProductos(usuarios user)
        {
            InitializeComponent();
            _entities = new mayaEntities();
            _idTejedora = new List<int>();
            _idTipoProductos = new List<int>();
            _user = user;
        }
        public void Reload()
        {
            txIdentificador.Text = "0";
            txIdentificador.ReadOnly = true;
            tbDescripcion.Text = "";
            nValor.Value = 0;
            numero_repetir.Enabled = false;
            numero_repetir.Value = 0;
            chboxAgregar.Checked = false;
            _idTipoProductos = new List<int>();
            _idTejedora = new List<int>();
            cbTipoProducto.Items.Clear();
            cbTejedora.Items.Clear();
            try
            {
                _idTipoProductos.Add(0);
                cbTipoProducto.Items.Add("<Seleccione>");
                foreach (var tp in _entities.tipo_producto.OrderBy(p => p.valor))
                {
                    cbTipoProducto.Items.Add(tp.valor);
                    _idTipoProductos.Add(tp.id);
                }
                cbTipoProducto.SelectedIndex = 0;

                _idTejedora.Add(0);
                cbTejedora.Items.Add("<Seleccione>");
                foreach (var tejedora in _entities.tejedora.Where(t => t.id != 9999))
                {
                    cbTejedora.Items.Add(tejedora.id + " " + tejedora.nombre + " " + tejedora.apellidos);
                    _idTejedora.Add(tejedora.id);
                }
                cbTejedora.SelectedIndex = 0;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Reload();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EntradaProductos_Load(object sender, EventArgs e)
        {
            this.Reload();
        }

        private void chboxAgregar_CheckedChanged(object sender, EventArgs e)
        {
            if (chboxAgregar.Checked)
            {
                numero_repetir.Enabled = true;
            }
            else
            {
                numero_repetir.Enabled = false;
            }
        }

        private string ValidarDatos()
        {
            string message = "";
            if(cbTipoProducto.SelectedIndex == 0)
            {
                message = "Debe seleccionar un tipo de producto";
            }
            if (cbTejedora.SelectedIndex == 0)
                message += "\nDebe seleccionar una tejedora";
            if (tbDescripcion.Text.Trim().Equals(""))
            {
                message += "\nDebe introducir una desciprción para el producto";
            }
            if (nValor.Value == 0)
                message += "\nDebe introducir el valor del producto";
            if (fecha_entrada.Value.Date > DateTime.Now)
                message += "\nLa fecha de entrada no puede ser mayor que la fecha actual";
            return message;
        }

        private void aceptarButton_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.ValidarDatos().Equals(""))
                {
                    if (!chboxAgregar.Checked)
                    {
                        //obtengo las dos ultimos cifras del anno
                        string aux1 = fecha_entrada.Value.Year.ToString();
                        aux1 = aux1[2].ToString() + aux1[3].ToString();
                        int aux_anno = int.Parse(aux1);

                        var aux = new productos
                        {
                            valor = nValor.Value,
                            anno = aux_anno,
                            fecha_entrada = fecha_entrada.Value,
                            id_tipo_producto = _idTipoProductos[cbTipoProducto.SelectedIndex],
                            id_tejedora = _idTejedora[cbTejedora.SelectedIndex],
                            descripcion = tbDescripcion.Text,
                            numero_producto = int.Parse(txIdentificador.Text)
                        };
                        aux.id = aux_anno.ToString() + "/" + aux.id_tejedora.ToString() + "/" +
                                 aux.id_tipo_producto.ToString() + "/" + aux.numero_producto.ToString();
                        _entities.AddToproductos(aux);
                        _entities.SaveChanges();
                        this.Reload();
                    }
                    else
                    {
                        //obtengo las dos ultimos cifras del anno
                        string aux1 = fecha_entrada.Value.Year.ToString();
                        aux1 = aux1[2].ToString() + aux1[3].ToString();
                        int aux_anno = int.Parse(aux1);

                        for (int i = 0; i < numero_repetir.Value; i++)
                        {
                            var aux = new productos
                            {
                                valor = nValor.Value,
                                anno = aux_anno,
                                fecha_entrada = fecha_entrada.Value,
                                id_tipo_producto = _idTipoProductos[cbTipoProducto.SelectedIndex],
                                id_tejedora = _idTejedora[cbTejedora.SelectedIndex],
                                descripcion = tbDescripcion.Text,
                                numero_producto = int.Parse(txIdentificador.Text) + i
                            };
                            aux.id = aux_anno.ToString() + "/" + aux.id_tejedora.ToString() + "/" +
                                     aux.id_tipo_producto.ToString() + "/" + aux.numero_producto.ToString();
                            _entities.AddToproductos(aux);
                            _entities.SaveChanges();
                        }
                        _entities.SaveChanges();
                        this.Reload();
                    }
                }
                else
                {
                    MessageBox.Show(ValidarDatos(), "Error en la entrada de datos", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                throw;
            }
        }

        private void cbTipoProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            //numero del identificador del producto
            int numero = 0;
            //obtengo el anno para convertirlo en un entero con las ultimas dos cifras
            string aux = fecha_entrada.Value.Year.ToString();
            aux = aux[2].ToString() + aux[3].ToString();
            int aux_anno = int.Parse(aux);
            //variable para obtener el numero del tipo de producto
            var tipoProducto = 0;
            //variable para obtener la tejedora
            var tejedoraa = 0;
            if (cbTejedora.SelectedIndex > 0 && cbTipoProducto.SelectedIndex > 0)
            {
                tipoProducto = _idTipoProductos[cbTipoProducto.SelectedIndex];
                tejedoraa = _idTejedora[cbTejedora.SelectedIndex];
                if (_entities.productos.Any(
                        p =>
                        p.id_tejedora == tejedoraa &&
                        p.id_tipo_producto == tipoProducto &&
                        p.anno == aux_anno))
                {
                    numero =
                    _entities.productos.Where(
                        p =>
                        p.id_tejedora == tejedoraa &&
                        p.id_tipo_producto == tipoProducto &&
                        p.anno == aux_anno).OrderBy(pi => pi.numero_producto).ToList().Last().numero_producto;
                }

            }
            else if (cbTejedora.SelectedIndex == 0 && cbTipoProducto.SelectedIndex > 0)
            {
                tipoProducto = _idTipoProductos[cbTipoProducto.SelectedIndex];
                if (_entities.productos.Any(
                        p =>
                        p.id_tipo_producto == tipoProducto &&
                        p.anno == aux_anno))
                {
                    numero =
                    _entities.productos.Where(
                        p =>
                        p.id_tipo_producto == tipoProducto &&
                        p.anno == aux_anno).OrderBy(pi => pi.numero_producto).ToList().Last().numero_producto;
                }
            }
            else if (cbTejedora.SelectedIndex > 0 && cbTipoProducto.SelectedIndex == 0)
            {
                tejedoraa = _idTejedora[cbTejedora.SelectedIndex];
                if (_entities.productos.Any(
                        p =>
                        p.id_tejedora == tejedoraa &&
                        p.anno == aux_anno))
                {
                    numero =
                    _entities.productos.Where(
                        p =>
                        p.id_tejedora == tejedoraa &&
                        p.anno == aux_anno).OrderBy(pi => pi.numero_producto).ToList().Last().numero_producto;
                }

            }
            txIdentificador.Text = (numero + 1).ToString();
        }

        private void cbTejedora_SelectedIndexChanged(object sender, EventArgs e)
        {
            //numero del identificador del producto
            int numero = 0;
            //obtengo el anno para convertirlo en un entero con las ultimas dos cifras
            string aux = fecha_entrada.Value.Year.ToString();
            aux = aux[2].ToString() + aux[3].ToString();
            int aux_anno = int.Parse(aux);
            //variable para obtener el numero del tipo de producto
            var tipoProducto = 0;
            //variable para obtener la tejedora
            var tejedoraa = 0;
            if (cbTejedora.SelectedIndex > 0 && cbTipoProducto.SelectedIndex > 0)
            {
                tipoProducto = _idTipoProductos[cbTipoProducto.SelectedIndex];
                tejedoraa = _idTejedora[cbTejedora.SelectedIndex];
                if (_entities.productos.Any(
                        p =>
                        p.id_tejedora == tejedoraa &&
                        p.id_tipo_producto == tipoProducto &&
                        p.anno == aux_anno))
                {
                    numero =
                    _entities.productos.Where(
                        p =>
                        p.id_tejedora == tejedoraa &&
                        p.id_tipo_producto == tipoProducto &&
                        p.anno == aux_anno).OrderBy(pi => pi.numero_producto).ToList().Last().numero_producto;
                }

            }
            else if (cbTejedora.SelectedIndex == 0 && cbTipoProducto.SelectedIndex > 0)
            {
                tipoProducto = _idTipoProductos[cbTipoProducto.SelectedIndex];
                if (_entities.productos.Any(
                        p =>
                        p.id_tipo_producto == tipoProducto &&
                        p.anno == aux_anno))
                {
                    numero =
                    _entities.productos.Where(
                        p =>
                        p.id_tipo_producto == tipoProducto &&
                        p.anno == aux_anno).OrderBy(pi => pi.numero_producto).ToList().Last().numero_producto;
                }
            }
            else if (cbTejedora.SelectedIndex > 0 && cbTipoProducto.SelectedIndex == 0)
            {
                tejedoraa = _idTejedora[cbTejedora.SelectedIndex];
                if (_entities.productos.Any(
                        p =>
                        p.id_tejedora == tejedoraa &&
                        p.anno == aux_anno))
                {
                    numero =
                    _entities.productos.Where(
                        p =>
                        p.id_tejedora == tejedoraa &&
                        p.anno == aux_anno).OrderBy(pi => pi.numero_producto).ToList().Last().numero_producto;
                }

            }
            txIdentificador.Text = (numero + 1).ToString();
        }

        private void fecha_entrada_ValueChanged(object sender, EventArgs e)
        {
            //numero del identificador del producto
            int numero = 0;
            //obtengo el anno para convertirlo en un entero con las ultimas dos cifras
            string aux = fecha_entrada.Value.Year.ToString();
            aux = aux[2].ToString() + aux[3].ToString();
            int aux_anno = int.Parse(aux);
            //variable para obtener el numero del tipo de producto
            var tipoProducto = 0;
            //variable para obtener la tejedora
            var tejedoraa = 0;
            if (cbTejedora.SelectedIndex > 0 && cbTipoProducto.SelectedIndex > 0)
            {
                tipoProducto = _idTipoProductos[cbTipoProducto.SelectedIndex];
                tejedoraa = _idTejedora[cbTejedora.SelectedIndex];
                if (_entities.productos.Any(
                        p =>
                        p.id_tejedora == tejedoraa &&
                        p.id_tipo_producto == tipoProducto &&
                        p.anno == aux_anno))
                {
                    numero =
                    _entities.productos.Where(
                        p =>
                        p.id_tejedora == tejedoraa &&
                        p.id_tipo_producto == tipoProducto &&
                        p.anno == aux_anno).OrderBy(pi => pi.numero_producto).ToList().Last().numero_producto;
                }

            }
            else if (cbTejedora.SelectedIndex == 0 && cbTipoProducto.SelectedIndex > 0)
            {
                tipoProducto = _idTipoProductos[cbTipoProducto.SelectedIndex];
                if (_entities.productos.Any(
                        p =>
                        p.id_tipo_producto == tipoProducto &&
                        p.anno == aux_anno))
                {
                    numero =
                    _entities.productos.Where(
                        p =>
                        p.id_tipo_producto == tipoProducto &&
                        p.anno == aux_anno).OrderBy(pi => pi.numero_producto).ToList().Last().numero_producto;
                }
            }
            else if (cbTejedora.SelectedIndex > 0 && cbTipoProducto.SelectedIndex == 0)
            {
                tejedoraa = _idTejedora[cbTejedora.SelectedIndex];
                if (_entities.productos.Any(
                        p =>
                        p.id_tejedora == tejedoraa &&
                        p.anno == aux_anno))
                {
                    numero =
                    _entities.productos.Where(
                        p =>
                        p.id_tejedora == tejedoraa &&
                        p.anno == aux_anno).OrderBy(pi => pi.numero_producto).ToList().Last().numero_producto;
                }

            }
            txIdentificador.Text = (numero + 1).ToString();
        }
    }
}
