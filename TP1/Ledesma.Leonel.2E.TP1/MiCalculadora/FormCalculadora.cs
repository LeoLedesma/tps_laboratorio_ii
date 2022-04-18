using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Al cargar el formulario, limpia todos los valores.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            limpiar();
        }

        /// <summary>
        /// Limpia las cajas de texto de operandos, operador y resultado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        /// <summary>
        /// Asigna "" a las caja de texto de operandos, operador y al lblResultado asigna "0"
        /// </summary>
        private void limpiar()
        {
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.cmbOperador.SelectedIndex = 0;
            this.lblResultado.Text = "0";
            this.btnConvertirABinario.Enabled = false;
            this.btnConvertirADecimal.Enabled = false;
        }

        /// <summary>
        /// Realiza la operacion designada por operador entre numero1 y numero2.
        /// </summary>
        /// <param name="numero1">Primer operando</param>
        /// <param name="numero2">Segundo operando</param>
        /// <param name="operador">Operador</param>
        /// <returns></returns>
        static double Operar(string numero1, string numero2, string operador)
        {
            Operando operando1 = new Operando(numero1);
            Operando operando2 = new Operando(numero2);

            if (operador == "")
            {
                operador = " ";
            }

            return Calculadora.Operar(operando1, operando2, operador[0]);
        }

        /// <summary>
        /// Realiza la correspondiente operacion entre los 2 operandos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            if (this.txtNumero1.Text != "" && this.txtNumero2.Text != "")
            {
                double resultado = Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text);
                resultado = Math.Round(resultado, 5);

                if (this.cmbOperador.Text == "")
                {
                    this.cmbOperador.Text = "+";
                }

                if (resultado != double.MinValue)
                {
                    this.lblResultado.Text = resultado.ToString();

                    double.TryParse(this.txtNumero1.Text, out double num1);
                    double.TryParse(this.txtNumero2.Text, out double num2);

                    this.lstOperaciones.Items.Add($"{num1} {this.cmbOperador.Text} {num2} = {this.lblResultado.Text}");

                    this.btnConvertirADecimal.Enabled = true;
                    this.btnConvertirABinario.Enabled = true;
                }
                else
                {
                    lblResultado.Text = "Error. Operación invalida";
                }
            }
            else
            {
                lblResultado.Text = "Error. Operación invalida";
            }
        }

        /// <summary>
        /// Realiza la llamada a cerrar el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Convierte el lblResultado a binario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Operando operandoAConvertir = new Operando();
            this.lblResultado.Text = operandoAConvertir.DecimalBinario(this.lblResultado.Text);            
        }

        /// <summary>
        /// Convierte el lblResultado a decimal si este estuviera en binario o solo contenga unos y ceros.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Operando operandoAConvertir = new Operando();
            this.lblResultado.Text = operandoAConvertir.BinarioDecimal(this.lblResultado.Text);            

            if (this.lblResultado.Text == "Valor Invalido")
            {
                this.btnConvertirADecimal.Enabled = false;
                this.btnConvertirABinario.Enabled = false;
            }
        }

        /// <summary>
        /// Lanza un MessageBox esperando confirmacion si se quiere cerrar el formulario o no.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
