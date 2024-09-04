using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AulaAPS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cmbForma_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbForma.Text)
            {
                case "Quadrado":
                    SelecionarQuadrado();
                    break;
                case "Triângulo":
                    SelecionarTriangulo();
                    break;
                case "Retângulo":
                    break;
                case "Círculo":
                    break;
                default:
                    break;
            }
        }

        private void SelecionarQuadrado()
        {
            ExibirBase(true);
            ExibirAltura(false);
            ExibirRaio(false);
            FormatoTriang(false);
        }
        private void SelecionarTriangulo()
        {
            ExibirBase(true);
            ExibirAltura(true);
            ExibirRaio(false);
            FormatoTriang(true);
        }

        private void SelecionarRetangulo()
        {
            ExibirBase(true);
            ExibirAltura(true);
            ExibirRaio(false);
            FormatoTriang(false);

        }

        private void SelecionarCirculo()
        {
            ExibirBase(false);
            ExibirAltura(false);
            ExibirRaio(true);
            FormatoTriang(false);

        }


        private void ExibirRaio(bool visivel)
        {
            lblRaio.Visible = txtRaio.Visible = visivel;
        }

        private void ExibirBase(bool visivel)
        {
            lblBase.Visible = txtBase.Visible = visivel;
        }
        private void FormatoTriang(bool visivel)
        {
            cmbTriangulo.Visible = visivel;
        }

        private void ExibirAltura(bool visivel)
        {
            lblAltura.Visible = txtAltura.Visible = visivel;
        }

        private void btnCriar_Click(object sender, EventArgs e)
        {

            switch (cmbForma.Text)
            {
                case "Quadrado":
                    CalcularQuadrado();
                    break;
                case "Triângulo":

                    break;
                case "Retângulo":
                    CalcularRetangulo();
                    break;
                case "Círculo":
                    break;
                default:
                    break;
            }
            
        }

        private void CalcularQuadrado()
        {
            FormaGeometrica quadrado = new Quadrado()
            {
                Lado = Convert.ToDouble(txtBase.Text),
            };
            cmbObjetos.Items.Add(quadrado);
        }

        private void CalcularRetangulo()
        {
            FormaGeometrica retangulo = new Retangulo()
            {
                Base = Convert.ToDouble(txtBase.Text),
                Altura = Convert.ToDouble(txtAltura.Text)
            };
            cmbObjetos.Items.Add(retangulo);
        }

        private void CalcularTriangulo()
        {
            FormaGeometrica triangulo = new Triangulo()
            {
                Base = Convert.ToDouble(txtBase.Text),
               
            }
        }
        '
        private void cmbObjetos_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormaGeometrica obj = cmbObjetos.SelectedItem as FormaGeometrica;
            txtArea.Text = obj.CalcularArea().ToString();
            txtPerimetro.Text = obj.CalcularPerimetro().ToString();
        }

    }
}
