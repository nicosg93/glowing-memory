using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                label2.Text = "El campo esta vacio";
                return;
            }
            int errorEspacioEnBlanco = 0;
            int noPalindroma = 0;
            int tamaño = textBox1.Text.Length;

            for (int i = 0, j = tamaño - 1; i < tamaño && j >= 0; i++, j--)
            {
                char letra = Char.ToUpper(textBox1.Text[i]) ;
                char letraPosicionOpuesta = Char.ToUpper(textBox1.Text[j]);
                if (letra == ' ')
                {
                    errorEspacioEnBlanco = 1;

                }
                if (!(letra == letraPosicionOpuesta))
                {
                    noPalindroma++;
                }

            }

            if (errorEspacioEnBlanco == 1)
            {
                label2.Text = "No deje espacios en blanco";
            }
            else
            {
                switch (noPalindroma)
                {
                    case 0:
                        label2.Text = "Es palindroma";
                        break;
                    case 2:
                        label2.Text = "Es casi palindroma";
                        break;
                    default:
                        label2.Text = "No es palindroma";
                        break;
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
