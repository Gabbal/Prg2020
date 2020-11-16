using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BA;

namespace Calculadora
{
    public partial class Form1 : Form
    {
        private decimal valor1;
        private decimal valor2;

        private decimal resultado;

        public int operacion;

        DataTable tabla = new DataTable();

        public Form1()
        {
            InitializeComponent();
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            //Número 0
            tbDisplay.Text = tbDisplay.Text + "0";
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            //Número 1
            tbDisplay.Text = tbDisplay.Text + "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            //Número 2
            tbDisplay.Text = tbDisplay.Text + "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            //Número 3
            tbDisplay.Text = tbDisplay.Text + "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            //Número 4
            tbDisplay.Text = tbDisplay.Text + "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            //Número 5
            tbDisplay.Text = tbDisplay.Text + "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            //Número 6
            tbDisplay.Text = tbDisplay.Text + "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            //Número 7
            tbDisplay.Text = tbDisplay.Text + "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            //Número 8
            tbDisplay.Text = tbDisplay.Text + "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            //Número 9
            tbDisplay.Text = tbDisplay.Text + "9";
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            //Botón borrar
            tbDisplay.Text = "";
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            //Botón Igual
            valor2 = Convert.ToDecimal(tbDisplay.Text);

            
            switch (operacion)
            {
                case 1:
                    resultado = valor1 + valor2;
                    break;

                case 2:
                    resultado = valor1 - valor2;
                    break;

                case 3:
                    resultado = valor1 * valor2;
                    break;

                case 4:
                    resultado = valor1 / valor2;
                    break;
            }

            tbDisplay.Text = decimal.Round(resultado, 4).ToString();

            //IGUAL operador = new IGUAL();

        }

        private void btnSuma_Click(object sender, EventArgs e)
        {
            //Botón SUMA
            operacion = 1;
            valor1 = Convert.ToDecimal(tbDisplay.Text);
            tbDisplay.Text = "";
        }

        private void btnResta_Click(object sender, EventArgs e)
        {
            //Botón RESTA
            operacion = 2;
            valor1 = Convert.ToDecimal(tbDisplay.Text);
            tbDisplay.Text = "";
        }

        private void btnMultiplicación_Click(object sender, EventArgs e)
        {
            //Botón MULTIPLICACION
            operacion = 3;
            valor1 = Convert.ToDecimal(tbDisplay.Text);
            tbDisplay.Text = "";
        }

        private void btnDivisión_Click(object sender, EventArgs e)
        {
            //Botón DIVISION
            operacion = 4;
            valor1 = Convert.ToDecimal(tbDisplay.Text);
            tbDisplay.Text = "";
        }

        private void btnPunto_Click(object sender, EventArgs e)
        {
            //Botón Punto
            tbDisplay.Text = tbDisplay.Text + ",";
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            tabla.TableName = "Historial";
            tabla.Columns.Add("Resultado", typeof(string));

            DGV.DataSource = tabla;

            DGV.Text = resultado.ToString();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            tabla.WriteXml(@"HistorialReesultado.xml");

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                tabla.Rows.Add();

                tabla.Rows[tabla.Rows.Count - 1]["Resultado"] = System.Convert.ToDouble(tbDisplay.Text);

            }
            catch (Exception ee)
            {
                MessageBox.Show("Error:\r\n"
                                 + ee.Message
                                 + "\r\n" + ee.StackTrace);

            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            tabla.ReadXml(@"HistorialReesultado.xml");

            DGV.DataSource = tabla;
        }
    }
}
