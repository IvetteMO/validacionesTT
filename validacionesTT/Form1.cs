using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace validacionesTT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese un nombre");
            this.ttMensaje.SetToolTip(this.txtEdad, "Ingrese edad");
            this.ttMensaje.SetToolTip(this.txtSalario, "Ingrese salario");
            this.ttMensaje.SetToolTip(this.txtSalario, "Ingrese Descripción");
        }

        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Patrón de expresión regular para permitir solo dígitos
            string pattern = @"^[0-9]+$";
            if (!Regex.IsMatch(e.KeyChar.ToString(), pattern) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                //MessageBox.Show("Solo se permite ingresar valores numéricos", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Patrón de expresión regular para permitir solo letras y espacios
            string pattern = @"^[a-zA-Z\s]+$";

            if (!Regex.IsMatch(e.KeyChar.ToString(), pattern) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                //return;
            }
        }

        private void txtSalario_KeyPress(object sender, KeyPressEventArgs e)
        {
            string input = (sender as TextBox).Text + e.KeyChar;

            // Patrón de expresión regular que permite números y un solo punto decimal
            string pattern = @"^[0-9]*(\.[0-9]*)?$";

            if (!Regex.IsMatch(input, pattern) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten números y un punto decimal", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lklSalir_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            txtEdad.Clear();  
            txtSalario.Clear(); 
            txtDescr.Clear();
            txtNombre.Focus();  
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Datos agregados correctamnte", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    DialogResult dr = MessageBox.Show("¿Está seguro que desea cerrar la aplicación",
        //       "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        //    if (dr == DialogResult.No)
        //    {
        //        txtNombre.Focus();
        //    }
        //    else
        //    {

        //        this.Close();

        //    }
        //}

    }
}
