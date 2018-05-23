using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Empresa_Agropecuaria
{
    public partial class Ventana_Principal : Form
    {
        private List<ProductosFrescos> ProductosFrescos = new List<ProductosFrescos>();
        private List<ProductoRefrigerado> ProductosRefrigerados = new List<ProductoRefrigerado>();
        private List<ProductoCongeladoAgua> ProductosCongeladosAgua = new List<ProductoCongeladoAgua>();
        private List<ProductoCongeladoNitrogeno> ProductosCongeladosNitrogeno = new List<ProductoCongeladoNitrogeno>();
        private List<ProductoCongeladoAire> ProductosCongeladosAire = new List<ProductoCongeladoAire>();
        private int index1 = 0;
        private int index2 = 0;
        public Ventana_Principal()
        {
            InitializeComponent();
            rellenarListas();
            iniciarDataGridView();
            //dgvproductosfrescos.DataSource = ProductosFrescos;
        }

        private void cbtipoproducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbtipoproducto.SelectedIndex == 0) index1 = 1;
            else if (cbtipoproducto.SelectedIndex == 1) index1 = 2;
            else if (cbtipoproducto.SelectedIndex == 2) index1 = 3;

            habilitarPrimeraZona();
        }

        public void habilitarPrimeraZona()
        {
            dtpenvasado.Enabled = false;
            txtpais.Enabled = false;
            txttemperatura.Enabled = false;
            txtcodigo.Enabled = false;
            cbtipocongelamiento.Enabled = false;
            btnguardar.Enabled = false;

            switch (index1)
            {
                case 1: //Frescos
                    dtpenvasado.Enabled = true;
                    txtpais.Enabled = true;
                    btnguardar.Enabled = true;
                    break;
                case 2: //Refrigerados
                    dtpenvasado.Enabled = true;
                    txtpais.Enabled = true;
                    txttemperatura.Enabled = true;
                    txtcodigo.Enabled = true;
                    btnguardar.Enabled = true;
                    break;
                case 3: //Congelados
                    dtpenvasado.Enabled = true;
                    txtpais.Enabled = true;
                    txttemperatura.Enabled = true;
                    cbtipocongelamiento.Enabled = true;
                    break;
            }
        }

        private void cbtipocongelamiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbtipocongelamiento.SelectedIndex == 0) index2 = 1;
            else if (cbtipocongelamiento.SelectedIndex == 1) index2 = 2;
            else if (cbtipocongelamiento.SelectedIndex == 2) index2 = 3;

            habilitarSegundaZona();
        }

        public void habilitarSegundaZona()
        {
            txtsalinidad.Enabled = false;
            txtmetodocongelacion.Enabled = false;
            txttiempoexposicion.Enabled = false;
            txtporcentajenitrogeno.Enabled = false;
            txtporcentajeoxigeno.Enabled = false;
            txtporcentajeco2.Enabled = false;
            txtporcentajevaporagua.Enabled = false;
            btnguardar.Enabled = false;

            switch (index2)
            {
                case 1: //Agua
                    txtsalinidad.Enabled = true;
                    btnguardar.Enabled = true;
                    break;
                case 2: //Nitrogeno
                    txtmetodocongelacion.Enabled = true;
                    txttiempoexposicion.Enabled = true;
                    btnguardar.Enabled = true;
                    break;
                case 3: //Aire
                    txtporcentajenitrogeno.Enabled = true;
                    txtporcentajeoxigeno.Enabled = true;
                    txtporcentajeco2.Enabled = true;
                    txtporcentajevaporagua.Enabled = true;
                    btnguardar.Enabled = true;
                    break;
            }
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            if(index1 == 1) //Productos Frescos
            {
                if (txtnombre.Text == "")
                {
                    errorProvider1.SetError(txtnombre, "Debe ingresar un nombre");
                    txtnombre.Focus();
                    return;
                }
                errorProvider1.SetError(txtnombre, "");

                double nLote;
                if (!Double.TryParse(txtnumerolote.Text, out nLote))
                {
                    errorProvider1.SetError(txtnumerolote, "Debe ingresar numeros en el campo numero de lotes");
                    txtnumerolote.Focus();
                    return;
                }
                errorProvider1.SetError(txtnumerolote, "");

                if (nLote < 0)
                {
                    errorProvider1.SetError(txtnumerolote, "Debe ingresar un numero de lote valido");
                    txtnumerolote.Focus();
                    return;
                }
                errorProvider1.SetError(txtnumerolote, "");

                if (txtpais.Text == "")
                {
                    errorProvider1.SetError(txtpais, "Debe ingresar un pais");
                    txtpais.Focus();
                    return;
                }
                errorProvider1.SetError(txtpais, "");

                ProductosFrescos.Add(new ProductosFrescos(txtnombre.Text, dtpcaducidad.Value, Convert.ToInt16(txtnumerolote.Text), 
                    dtpenvasado.Value, txtpais.Text));
                for (int i = 0; i < ProductosFrescos.Count; i++)
                {
                    dgvproductosfrescos.Rows.Add();
                    dgvproductosfrescos.Rows[i].Cells[0].Value = ProductosFrescos[i].nombre;
                    dgvproductosfrescos.Rows[i].Cells[1].Value = ProductosFrescos[i].numeroLote;
                    dgvproductosfrescos.Rows[i].Cells[2].Value = ProductosFrescos[i].fechaCaducidad;
                    dgvproductosfrescos.Rows[i].Cells[3].Value = ProductosFrescos[i].fechaEnvasado;
                    dgvproductosfrescos.Rows[i].Cells[4].Value = ProductosFrescos[i].paisDeOrigen;
                }
                limpiarCampos();
            }
            else if(index1 == 2) //Productos Refrigerados
            {
                if (txtnombre.Text == "")
                {
                    errorProvider1.SetError(txtnombre, "Debe ingresar un nombre");
                    txtnombre.Focus();
                    return;
                }
                errorProvider1.SetError(txtnombre, "");

                double nLote;
                if (!Double.TryParse(txtnumerolote.Text, out nLote))
                {
                    errorProvider1.SetError(txtnumerolote, "Debe ingresar numeros en el campo numero de lotes");
                    txtnumerolote.Focus();
                    return;
                }
                errorProvider1.SetError(txtnumerolote, "");

                if (nLote < 0)
                {
                    errorProvider1.SetError(txtnumerolote, "Debe ingresar un numero de lote valido");
                    txtnumerolote.Focus();
                    return;
                }
                errorProvider1.SetError(txtnumerolote, "");

                if (txtpais.Text == "")
                {
                    errorProvider1.SetError(txtpais, "Debe ingresar un pais");
                    txtpais.Focus();
                    return;
                }
                errorProvider1.SetError(txtpais, "");

                double temp;
                if (!Double.TryParse(txttemperatura.Text, out temp))
                {
                    errorProvider1.SetError(txttemperatura, "Debe ingresar numeros en el campo temperatura recomendada");
                    txttemperatura.Focus();
                    return;
                }
                errorProvider1.SetError(txttemperatura, "");

                if (txtcodigo.Text == "")
                {
                    errorProvider1.SetError(txtcodigo, "Debe ingresar un pais");
                    txtcodigo.Focus();
                    return;
                }
                errorProvider1.SetError(txtcodigo, "");

                ProductosRefrigerados.Add(new ProductoRefrigerado(txtnombre.Text, dtpcaducidad.Value, Convert.ToInt16(txtnumerolote.Text),
                    dtpenvasado.Value, txtpais.Text, Convert.ToDouble(txttemperatura.Text), txtcodigo.Text));
                for (int i = 0; i < ProductosRefrigerados.Count; i++)
                {
                    dgvproductosrefrigerados.Rows.Add();
                    dgvproductosrefrigerados.Rows[i].Cells[0].Value = ProductosRefrigerados[i].nombre;
                    dgvproductosrefrigerados.Rows[i].Cells[1].Value = ProductosRefrigerados[i].numeroLote;
                    dgvproductosrefrigerados.Rows[i].Cells[2].Value = ProductosRefrigerados[i].fechaCaducidad;
                    dgvproductosrefrigerados.Rows[i].Cells[3].Value = ProductosRefrigerados[i].fechaEnvasado;
                    dgvproductosrefrigerados.Rows[i].Cells[4].Value = ProductosRefrigerados[i].paisDeOrigen;
                    dgvproductosrefrigerados.Rows[i].Cells[5].Value = ProductosRefrigerados[i].tempMantenimiento;
                    dgvproductosrefrigerados.Rows[i].Cells[6].Value = ProductosRefrigerados[i].codigoSupAlimentaria;
                }
                limpiarCampos();
            }
            else if(index1 == 3) //Productos Congelados
            {
                if(index2 == 1) //Agua
                {
                    if (txtnombre.Text == "")
                    {
                        errorProvider1.SetError(txtnombre, "Debe ingresar un nombre");
                        txtnombre.Focus();
                        return;
                    }
                    errorProvider1.SetError(txtnombre, "");

                    double nLote;
                    if (!Double.TryParse(txtnumerolote.Text, out nLote))
                    {
                        errorProvider1.SetError(txtnumerolote, "Debe ingresar numeros en el campo numero de lotes");
                        txtnumerolote.Focus();
                        return;
                    }
                    errorProvider1.SetError(txtnumerolote, "");

                    if (nLote < 0)
                    {
                        errorProvider1.SetError(txtnumerolote, "Debe ingresar un numero de lote valido");
                        txtnumerolote.Focus();
                        return;
                    }
                    errorProvider1.SetError(txtnumerolote, "");

                    if (txtpais.Text == "")
                    {
                        errorProvider1.SetError(txtpais, "Debe ingresar un pais");
                        txtpais.Focus();
                        return;
                    }
                    errorProvider1.SetError(txtpais, "");

                    double temp;
                    if (!Double.TryParse(txttemperatura.Text, out temp))
                    {
                        errorProvider1.SetError(txttemperatura, "Debe ingresar numeros en el campo temperatura recomendada");
                        txttemperatura.Focus();
                        return;
                    }
                    errorProvider1.SetError(txttemperatura, "");

                    double sal;
                    if (!Double.TryParse(txtsalinidad.Text, out sal))
                    {
                        errorProvider1.SetError(txtsalinidad, "Debe ingresar numeros en el campo salinidad");
                        txtsalinidad.Focus();
                        return;
                    }
                    errorProvider1.SetError(txtsalinidad, "");

                    if (sal < 0)
                    {
                        errorProvider1.SetError(txtsalinidad, "Debe ingresar un numero de salinidad valido");
                        txtsalinidad.Focus();
                        return;
                    }
                    errorProvider1.SetError(txtsalinidad, "");

                    ProductosCongeladosAgua.Add(new ProductoCongeladoAgua(txtnombre.Text, dtpcaducidad.Value, Convert.ToInt16(txtnumerolote.Text),
                    dtpenvasado.Value, txtpais.Text, Convert.ToDouble(txttemperatura.Text), Convert.ToDouble(txtsalinidad.Text)));
                    for (int i = 0; i < ProductosCongeladosAgua.Count; i++)
                    {
                        dgvproductoscongeladosagua.Rows.Add();
                        dgvproductoscongeladosagua.Rows[i].Cells[0].Value = ProductosCongeladosAgua[i].nombre;
                        dgvproductoscongeladosagua.Rows[i].Cells[1].Value = ProductosCongeladosAgua[i].numeroLote;
                        dgvproductoscongeladosagua.Rows[i].Cells[2].Value = ProductosCongeladosAgua[i].fechaCaducidad;
                        dgvproductoscongeladosagua.Rows[i].Cells[3].Value = ProductosCongeladosAgua[i].fechaEnvasado;
                        dgvproductoscongeladosagua.Rows[i].Cells[4].Value = ProductosCongeladosAgua[i].paisDeOrigen;
                        dgvproductoscongeladosagua.Rows[i].Cells[5].Value = ProductosCongeladosAgua[i].tempMantenimiento;
                        dgvproductoscongeladosagua.Rows[i].Cells[6].Value = ProductosCongeladosAgua[i].salinidadAgua;
                    }
                    limpiarCampos();
                }
                else if(index2 == 2) //Nitrogeno
                {
                    if (txtnombre.Text == "")
                    {
                        errorProvider1.SetError(txtnombre, "Debe ingresar un nombre");
                        txtnombre.Focus();
                        return;
                    }
                    errorProvider1.SetError(txtnombre, "");

                    double nLote;
                    if (!Double.TryParse(txtnumerolote.Text, out nLote))
                    {
                        errorProvider1.SetError(txtnumerolote, "Debe ingresar numeros en el campo numero de lotes");
                        txtnumerolote.Focus();
                        return;
                    }
                    errorProvider1.SetError(txtnumerolote, "");

                    if (nLote < 0)
                    {
                        errorProvider1.SetError(txtnumerolote, "Debe ingresar un numero de lote valido");
                        txtnumerolote.Focus();
                        return;
                    }
                    errorProvider1.SetError(txtnumerolote, "");

                    if (txtpais.Text == "")
                    {
                        errorProvider1.SetError(txtpais, "Debe ingresar un pais");
                        txtpais.Focus();
                        return;
                    }
                    errorProvider1.SetError(txtpais, "");

                    double temp;
                    if (!Double.TryParse(txttemperatura.Text, out temp))
                    {
                        errorProvider1.SetError(txttemperatura, "Debe ingresar numeros en el campo temperatura recomendada");
                        txttemperatura.Focus();
                        return;
                    }
                    errorProvider1.SetError(txttemperatura, "");

                    if (txtmetodocongelacion.Text == "")
                    {
                        errorProvider1.SetError(txtmetodocongelacion, "Debe ingresar un metodo de congelacion");
                        txtmetodocongelacion.Focus();
                        return;
                    }
                    errorProvider1.SetError(txtmetodocongelacion, "");

                    double tiempo;
                    if (!Double.TryParse(txttiempoexposicion.Text, out tiempo))
                    {
                        errorProvider1.SetError(txttiempoexposicion, "Debe ingresar numeros en el campo tiempo de exposicion");
                        txttiempoexposicion.Focus();
                        return;
                    }
                    errorProvider1.SetError(txttiempoexposicion, "");

                    if (tiempo < 0)
                    {
                        errorProvider1.SetError(txttiempoexposicion, "Debe ingresar un tiempo de exposicion valido");
                        txttiempoexposicion.Focus();
                        return;
                    }
                    errorProvider1.SetError(txttiempoexposicion, "");

                    ProductosCongeladosNitrogeno.Add(new ProductoCongeladoNitrogeno(txtnombre.Text, dtpcaducidad.Value, Convert.ToInt16(txtnumerolote.Text),
                    dtpenvasado.Value, txtpais.Text, Convert.ToDouble(txttemperatura.Text), txtmetodocongelacion.Text, Convert.ToInt16(txttiempoexposicion.Text)));
                    for (int i = 0; i < ProductosCongeladosNitrogeno.Count; i++)
                    {
                        dgvproductoscongeladosnitrogeno.Rows.Add();
                        dgvproductoscongeladosnitrogeno.Rows[i].Cells[0].Value = ProductosCongeladosNitrogeno[i].nombre;
                        dgvproductoscongeladosnitrogeno.Rows[i].Cells[1].Value = ProductosCongeladosNitrogeno[i].numeroLote;
                        dgvproductoscongeladosnitrogeno.Rows[i].Cells[2].Value = ProductosCongeladosNitrogeno[i].fechaCaducidad;
                        dgvproductoscongeladosnitrogeno.Rows[i].Cells[3].Value = ProductosCongeladosNitrogeno[i].fechaEnvasado;
                        dgvproductoscongeladosnitrogeno.Rows[i].Cells[4].Value = ProductosCongeladosNitrogeno[i].paisDeOrigen;
                        dgvproductoscongeladosnitrogeno.Rows[i].Cells[5].Value = ProductosCongeladosNitrogeno[i].tempMantenimiento;
                        dgvproductoscongeladosnitrogeno.Rows[i].Cells[6].Value = ProductosCongeladosNitrogeno[i].metodoCongelacion;
                        dgvproductoscongeladosnitrogeno.Rows[i].Cells[7].Value = ProductosCongeladosNitrogeno[i].tiempoExposicion;
                    }
                    limpiarCampos();
                }
                else if(index2 == 3) //Aire
                {
                    if (txtnombre.Text == "")
                    {
                        errorProvider1.SetError(txtnombre, "Debe ingresar un nombre");
                        txtnombre.Focus();
                        return;
                    }
                    errorProvider1.SetError(txtnombre, "");

                    double nLote;
                    if (!Double.TryParse(txtnumerolote.Text, out nLote))
                    {
                        errorProvider1.SetError(txtnumerolote, "Debe ingresar numeros en el campo numero de lotes");
                        txtnumerolote.Focus();
                        return;
                    }
                    errorProvider1.SetError(txtnumerolote, "");

                    if (nLote < 0)
                    {
                        errorProvider1.SetError(txtnumerolote, "Debe ingresar un numero de lote valido");
                        txtnumerolote.Focus();
                        return;
                    }
                    errorProvider1.SetError(txtnumerolote, "");

                    if (txtpais.Text == "")
                    {
                        errorProvider1.SetError(txtpais, "Debe ingresar un pais");
                        txtpais.Focus();
                        return;
                    }
                    errorProvider1.SetError(txtpais, "");

                    double temp;
                    if (!Double.TryParse(txttemperatura.Text, out temp))
                    {
                        errorProvider1.SetError(txttemperatura, "Debe ingresar numeros en el campo temperatura recomendada");
                        txttemperatura.Focus();
                        return;
                    }
                    errorProvider1.SetError(txttemperatura, "");

                    double pnitro;
                    if (!Double.TryParse(txtporcentajenitrogeno.Text, out pnitro))
                    {
                        errorProvider1.SetError(txtporcentajenitrogeno, "Debe ingresar numeros en el campo numero de lotes");
                        txtporcentajenitrogeno.Focus();
                        return;
                    }
                    errorProvider1.SetError(txtporcentajenitrogeno, "");

                    if (pnitro < 0)
                    {
                        errorProvider1.SetError(txtporcentajenitrogeno, "Debe ingresar un numero de lote valido");
                        txtporcentajenitrogeno.Focus();
                        return;
                    }
                    errorProvider1.SetError(txtporcentajenitrogeno, "");

                    double poxi;
                    if (!Double.TryParse(txtporcentajeoxigeno.Text, out poxi))
                    {
                        errorProvider1.SetError(txtporcentajeoxigeno, "Debe ingresar numeros en el campo numero de lotes");
                        txtporcentajeoxigeno.Focus();
                        return;
                    }
                    errorProvider1.SetError(txtporcentajeoxigeno, "");

                    if (poxi < 0)
                    {
                        errorProvider1.SetError(txtporcentajeoxigeno, "Debe ingresar un numero de lote valido");
                        txtporcentajeoxigeno.Focus();
                        return;
                    }
                    errorProvider1.SetError(txtporcentajeoxigeno, "");

                    double pco2;
                    if (!Double.TryParse(txtporcentajeco2.Text, out pco2))
                    {
                        errorProvider1.SetError(txtporcentajeco2, "Debe ingresar numeros en el campo numero de lotes");
                        txtporcentajeco2.Focus();
                        return;
                    }
                    errorProvider1.SetError(txtporcentajeco2, "");

                    if (pco2 < 0)
                    {
                        errorProvider1.SetError(txtporcentajeco2, "Debe ingresar un numero de lote valido");
                        txtporcentajeco2.Focus();
                        return;
                    }
                    errorProvider1.SetError(txtporcentajeco2, "");

                    double pvapor;
                    if (!Double.TryParse(txtporcentajevaporagua.Text, out pvapor))
                    {
                        errorProvider1.SetError(txtporcentajevaporagua, "Debe ingresar numeros en el campo numero de lotes");
                        txtporcentajevaporagua.Focus();
                        return;
                    }
                    errorProvider1.SetError(txtporcentajevaporagua, "");

                    if (pvapor < 0)
                    {
                        errorProvider1.SetError(txtporcentajevaporagua, "Debe ingresar un numero de lote valido");
                        txtporcentajevaporagua.Focus();
                        return;
                    }
                    errorProvider1.SetError(txtporcentajevaporagua, "");

                    ProductosCongeladosAire.Add(new ProductoCongeladoAire(txtnombre.Text, dtpcaducidad.Value, Convert.ToInt16(txtnumerolote.Text),
                    dtpenvasado.Value, txtpais.Text, Convert.ToDouble(txttemperatura.Text), Convert.ToDouble(txtporcentajenitrogeno.Text),
                    Convert.ToDouble(txtporcentajeoxigeno.Text), Convert.ToDouble(txtporcentajeco2.Text), Convert.ToDouble(txtporcentajevaporagua.Text)));
                    for (int i = 0; i < ProductosCongeladosAire.Count; i++)
                    {
                        dgvproductoscongeladosaire.Rows.Add();
                        dgvproductoscongeladosaire.Rows[i].Cells[0].Value = ProductosCongeladosAire[i].nombre;
                        dgvproductoscongeladosaire.Rows[i].Cells[1].Value = ProductosCongeladosAire[i].numeroLote;
                        dgvproductoscongeladosaire.Rows[i].Cells[2].Value = ProductosCongeladosAire[i].fechaCaducidad;
                        dgvproductoscongeladosaire.Rows[i].Cells[3].Value = ProductosCongeladosAire[i].fechaEnvasado;
                        dgvproductoscongeladosaire.Rows[i].Cells[4].Value = ProductosCongeladosAire[i].paisDeOrigen;
                        dgvproductoscongeladosaire.Rows[i].Cells[5].Value = ProductosCongeladosAire[i].tempMantenimiento;
                        dgvproductoscongeladosaire.Rows[i].Cells[6].Value = ProductosCongeladosAire[i].porcentajeNitrogeno;
                        dgvproductoscongeladosaire.Rows[i].Cells[7].Value = ProductosCongeladosAire[i].porcentajeOxigeno;
                        dgvproductoscongeladosaire.Rows[i].Cells[8].Value = ProductosCongeladosAire[i].porcentajeDioxidoCarbono;
                        dgvproductoscongeladosaire.Rows[i].Cells[9].Value = ProductosCongeladosAire[i].porcentajeVaporAgua;
                    }
                    limpiarCampos();
                }
            }
        }

        public void iniciarDataGridView()
        {
            
            for (int i=0; i<ProductosFrescos.Count; i++)
            {
                dgvproductosfrescos.Rows.Add();
                dgvproductosfrescos.Rows[i].Cells[0].Value = ProductosFrescos[i].nombre;
                dgvproductosfrescos.Rows[i].Cells[1].Value = ProductosFrescos[i].numeroLote;
                dgvproductosfrescos.Rows[i].Cells[2].Value = ProductosFrescos[i].fechaCaducidad;
                dgvproductosfrescos.Rows[i].Cells[3].Value = ProductosFrescos[i].fechaEnvasado;
                dgvproductosfrescos.Rows[i].Cells[4].Value = ProductosFrescos[i].paisDeOrigen;
            }

            
            for (int i = 0; i < ProductosRefrigerados.Count; i++)
            {
                dgvproductosrefrigerados.Rows.Add();
                dgvproductosrefrigerados.Rows[i].Cells[0].Value = ProductosRefrigerados[i].nombre;
                dgvproductosrefrigerados.Rows[i].Cells[1].Value = ProductosRefrigerados[i].numeroLote;
                dgvproductosrefrigerados.Rows[i].Cells[2].Value = ProductosRefrigerados[i].fechaCaducidad;
                dgvproductosrefrigerados.Rows[i].Cells[3].Value = ProductosRefrigerados[i].fechaEnvasado;
                dgvproductosrefrigerados.Rows[i].Cells[4].Value = ProductosRefrigerados[i].paisDeOrigen;
                dgvproductosrefrigerados.Rows[i].Cells[5].Value = ProductosRefrigerados[i].tempMantenimiento;
                dgvproductosrefrigerados.Rows[i].Cells[6].Value = ProductosRefrigerados[i].codigoSupAlimentaria;
            }

            for (int i = 0; i < ProductosCongeladosAgua.Count; i++)
            {
                dgvproductoscongeladosagua.Rows.Add();
                dgvproductoscongeladosagua.Rows[i].Cells[0].Value = ProductosCongeladosAgua[i].nombre;
                dgvproductoscongeladosagua.Rows[i].Cells[1].Value = ProductosCongeladosAgua[i].numeroLote;
                dgvproductoscongeladosagua.Rows[i].Cells[2].Value = ProductosCongeladosAgua[i].fechaCaducidad;
                dgvproductoscongeladosagua.Rows[i].Cells[3].Value = ProductosCongeladosAgua[i].fechaEnvasado;
                dgvproductoscongeladosagua.Rows[i].Cells[4].Value = ProductosCongeladosAgua[i].paisDeOrigen;
                dgvproductoscongeladosagua.Rows[i].Cells[5].Value = ProductosCongeladosAgua[i].tempMantenimiento;
                dgvproductoscongeladosagua.Rows[i].Cells[6].Value = ProductosCongeladosAgua[i].salinidadAgua;
            }

            for (int i = 0; i < ProductosCongeladosNitrogeno.Count; i++)
            {
                dgvproductoscongeladosnitrogeno.Rows.Add();
                dgvproductoscongeladosnitrogeno.Rows[i].Cells[0].Value = ProductosCongeladosNitrogeno[i].nombre;
                dgvproductoscongeladosnitrogeno.Rows[i].Cells[1].Value = ProductosCongeladosNitrogeno[i].numeroLote;
                dgvproductoscongeladosnitrogeno.Rows[i].Cells[2].Value = ProductosCongeladosNitrogeno[i].fechaCaducidad;
                dgvproductoscongeladosnitrogeno.Rows[i].Cells[3].Value = ProductosCongeladosNitrogeno[i].fechaEnvasado;
                dgvproductoscongeladosnitrogeno.Rows[i].Cells[4].Value = ProductosCongeladosNitrogeno[i].paisDeOrigen;
                dgvproductoscongeladosnitrogeno.Rows[i].Cells[5].Value = ProductosCongeladosNitrogeno[i].tempMantenimiento;
                dgvproductoscongeladosnitrogeno.Rows[i].Cells[6].Value = ProductosCongeladosNitrogeno[i].metodoCongelacion;
                dgvproductoscongeladosnitrogeno.Rows[i].Cells[7].Value = ProductosCongeladosNitrogeno[i].tiempoExposicion;
            }

            for (int i = 0; i < ProductosCongeladosAire.Count; i++)
            {
                dgvproductoscongeladosaire.Rows.Add();
                dgvproductoscongeladosaire.Rows[i].Cells[0].Value = ProductosCongeladosAire[i].nombre;
                dgvproductoscongeladosaire.Rows[i].Cells[1].Value = ProductosCongeladosAire[i].numeroLote;
                dgvproductoscongeladosaire.Rows[i].Cells[2].Value = ProductosCongeladosAire[i].fechaCaducidad;
                dgvproductoscongeladosaire.Rows[i].Cells[3].Value = ProductosCongeladosAire[i].fechaEnvasado;
                dgvproductoscongeladosaire.Rows[i].Cells[4].Value = ProductosCongeladosAire[i].paisDeOrigen;
                dgvproductoscongeladosaire.Rows[i].Cells[5].Value = ProductosCongeladosAire[i].tempMantenimiento;
                dgvproductoscongeladosaire.Rows[i].Cells[6].Value = ProductosCongeladosAire[i].porcentajeNitrogeno;
                dgvproductoscongeladosaire.Rows[i].Cells[7].Value = ProductosCongeladosAire[i].porcentajeOxigeno;
                dgvproductoscongeladosaire.Rows[i].Cells[8].Value = ProductosCongeladosAire[i].porcentajeDioxidoCarbono;
                dgvproductoscongeladosaire.Rows[i].Cells[9].Value = ProductosCongeladosAire[i].porcentajeVaporAgua;
            }
        }

        public void rellenarListas()
        {
            ProductosFrescos.Add(new ProductosFrescos("Lechuga", new DateTime(2018, 04, 13), 1236, new DateTime(2018, 12, 23), "Nicaragua"));
            ProductosFrescos.Add(new ProductosFrescos("Pepinillos", new DateTime(2018, 04, 13), 1237, new DateTime(2019, 03, 17), "Costa Rica"));

            ProductosRefrigerados.Add(new ProductoRefrigerado("Carne", new DateTime(2018, 04, 13), 1536, new DateTime(2018, 03, 7), "Belice", 6.3, "1315a"));
            ProductosRefrigerados.Add(new ProductoRefrigerado("Pollo", new DateTime(2018, 04, 13), 1537, new DateTime(2018, 01, 19), "El Salvador", 7.5, "1486b"));
            ProductosRefrigerados.Add(new ProductoRefrigerado("Cerdo", new DateTime(2018, 04, 13), 1538, new DateTime(2018, 02, 14), "Honduras", 8.1, "1568c"));

            ProductosCongeladosAgua.Add(new ProductoCongeladoAgua("Helados", new DateTime(2018, 04, 13), 2465, new DateTime(2020, 07, 12), "Guatemala", -15.5, 5.3));
            ProductosCongeladosAgua.Add(new ProductoCongeladoAgua("Tortas de Pollo", new DateTime(2018, 04, 13), 2466, new DateTime(2020, 09, 1), "Guatemala", -12.3, 8.3));

            ProductosCongeladosNitrogeno.Add(new ProductoCongeladoNitrogeno("Camaron", new DateTime(2018, 04, 13), 2466, new DateTime(2021, 06, 5), "Mexico", -22.8, "Criogenizacion", 30));

            ProductosCongeladosAire.Add(new ProductoCongeladoAire("Carnes Rojas", new DateTime(2018, 04, 13), 3256, new DateTime(2019, 03, 15), "Nicaragua", -21.6, 2.3, 1.6, 0.6, 4.6));
            ProductosCongeladosAire.Add(new ProductoCongeladoAire("Chuleta de Pescado", new DateTime(2018, 04, 13), 2467, new DateTime(2021, 04, 19), "Mexico", -21.2, 1.6, 2.4, 0.2, 3.7));
        }

        public void limpiarCampos()
        {
            txtnombre.Text = "";
            txtnumerolote.Text = "";
            txtpais.Text = "";
            txttemperatura.Text = "";
            txtcodigo.Text = "";
            txtsalinidad.Text = "";
            txtmetodocongelacion.Text = "";
            txttiempoexposicion.Text = "";
            txtporcentajenitrogeno.Text = "";
            txtporcentajeoxigeno.Text = "";
            txtporcentajeco2.Text = "";
            txtporcentajevaporagua.Text = "";
        }
    }
}
