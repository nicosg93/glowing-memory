using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Ejercicio4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.ShowDialog();

                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = fbd.SelectedPath;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string rutaDirectorio = textBox1.Text + "\\";
            string rutaArchivo = rutaDirectorio + "inputdata.in";
            string rutaDestino = rutaDirectorio + "outputdata.out";
            if (File.Exists(rutaArchivo))
            {
                StreamReader sr = new StreamReader(rutaArchivo);
                List<Cliente> clientes = new List<Cliente>();
                clientes = registrarClientes(sr);
                clientes = filtrarClientes(clientes);
                generarArchivoSalida(clientes, rutaDestino);
                label2.Text = "Se genero el archivo correctamente";
            }
            else
            {
                label2.Text ="Archivo no encontrado";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private  List<Cliente> filtrarClientes(List<Cliente> clientes)
        {
            return clientes.OrderByDescending(c => c.Peso).ToList();
        }

        private List<Cliente> registrarClientes(StreamReader sr)
        {
            List<Cliente> clientes = new List<Cliente>();
            while (sr.Peek() >= 0)
            {
                string registro = sr.ReadLine();
                Cliente cliente = new Cliente();
                cliente = parsearCliente(registro);
                clientes.Add(cliente);
            }

            return clientes;
        }

        private Cliente parsearCliente(string cliente)

        {
            Cliente c = new Cliente();

            string[] palabras = cliente.Split('|');

            if (palabras[0] != "")
            {
                c.PersonId = int.Parse(palabras[0]);
            }
            else
            {
                c.PersonId = null;
            }
            c.Name = palabras[1];
            c.LastName = palabras[2];
            c.CurrentRole = palabras[3];
            c.Country = palabras[4];
            c.Industry = palabras[5];
            if (palabras[6] != "")
            {
                c.NumberOfRecommendations = int.Parse(palabras[6]);
            }
            else
            {
                c.NumberOfRecommendations = null;
            }
            if (palabras[7] != "")
            {
                c.NumberOfConnections = int.Parse(palabras[7]);
            }
            else
            {
                c.NumberOfConnections = null;
            }
            c.Peso = calcularPeso(c.NumberOfRecommendations, c.NumberOfConnections); 

            return c;


        }

        private void generarArchivoSalida(List<Cliente> clientes, string ruta)
        {
            StreamWriter sw = new StreamWriter(ruta);

            List<Cliente> mejores = obtenerMejores(clientes, 100);
            foreach (Cliente cliente in mejores)
            {
                    sw.WriteLine(cliente.PersonId);
                    
            }

            sw.Close();
        }

        private List<Cliente> obtenerMejores(List<Cliente> clientes, int cantidad)
        {
            List<Cliente> mejor = new List<Cliente>();
            for (int i = 0; i < 100; i++)
            {
                mejor.Add(clientes[i]);
            }
            return mejor;
        }
        private double calcularPeso(int? recomendaciones, int? conexiones)
        {
            if (recomendaciones == null && conexiones == null)
            {
                return -5;
            }
            if (recomendaciones == null && conexiones != null)
            {
                return -4;
            }
            if(recomendaciones != null && conexiones == null)
            {
                return -3;
            }
            if (recomendaciones == 0 && conexiones != null)
            {
                return -2;
            }
            if (recomendaciones == 0 && conexiones == 0)
            {
                return -1;
            }
            else
            {
                return (double) (conexiones / recomendaciones);
            }
        }
    }
}