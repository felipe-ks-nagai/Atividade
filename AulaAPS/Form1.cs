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
                    SelecionarRetangulo();
                    break;
                case "Círculo":
                    SelecionarCirculo();
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
            if (cmbTriangulo.Visible == false)
            {
                switch (cmbForma.Text)
                {
                    case "Quadrado":
                        CalcularQuadrado();
                        break;
                    case "Retângulo":
                        CalcularRetangulo();
                        break;
                    case "Círculo":
                        CalcularCirculo();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (cmbTriangulo.Text)
                {
                    case "Equilátero":
                        CalcularEquilatero();
                        break;
                    case "Isósceles":
                        CalcularIsosceles();
                        break;
                    case "Reto":
                        CalcularReto();
                        break;
                    default:
                        break;
                }
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

        private void cmbTriangulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTriangulo.Text)
            {
                case "Equilátero":
                    SelecionarEquilatero();
                    break;
                case "Isósceles":
                    SelecionarIsosceles();
                    break;
                case "Reto":
                    SelecionarReto();
                    break;


            }
        }


        private void CalcularCirculo()
        {
            FormaGeometrica circulo = new Circulo()
            {
                Raio = Convert.ToDouble(txtRaio.Text),
            };
            cmbObjetos.Items.Add(circulo);

        }


        private void SelecionarEquilatero()
        {
            ExibirBase(true);
            ExibirAltura(false);
            ExibirRaio(false);
        }

        private void SelecionarIsosceles()
        {
            ExibirBase(true);
            ExibirAltura(true);
            ExibirRaio(false);
        }

        private void SelecionarReto()
        {
            ExibirBase(true);
            ExibirAltura(true);
            ExibirRaio(false);
        }
        
        private void cmbObjetos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int perimetro = 0;
            int area = 0;
            bool verificarPerimetro = false;
            bool verificarArea = false;

            FormaGeometrica obj = cmbObjetos.SelectedItem as FormaGeometrica;
            for(int i = 0; i < obj.CalcularPerimetro().ToString().Length; i++)
            {
                if(obj.CalcularPerimetro().ToString().Substring(i,1) == ",")
                {
                    verificarPerimetro = true;
                    break;
                }
                else
                {
                    perimetro += 1;
                }
            }

            for (int i = 0; i < obj.CalcularArea().ToString().Length; i++)
            {
                if (obj.CalcularArea().ToString().Substring(i, 1) == ",")
                {
                   
                    verificarArea = true;
                    break;
                }
                else
                {
                    area += 1;
                }
            }
            if(verificarPerimetro)
            {
                txtPerimetro.Text = obj.CalcularPerimetro().ToString().Substring(0, perimetro + 3);
                verificarPerimetro = false;
            }
            else
            {
                txtPerimetro.Text = obj.CalcularPerimetro().ToString();
            }

            if (verificarArea)
            {
                txtArea.Text = obj.CalcularArea().ToString().Substring(0, area + 3);
                verificarArea = false;
            }
            else
            {
                txtArea.Text = obj.CalcularArea().ToString();
            }
        }

        private void CalcularIsosceles()
        {

            FormaGeometrica isosceles = new Isosceles()
            {
                Base = Convert.ToDouble(txtBase.Text),
                Altura = Convert.ToDouble(txtAltura.Text)
            };
            cmbObjetos.Items.Add(isosceles);

        }

        private void CalcularReto()
        {

            FormaGeometrica reto = new Reto()
            {
                Base = Convert.ToDouble(txtBase.Text),
                Altura = Convert.ToDouble(txtAltura.Text)
            };
            cmbObjetos.Items.Add(reto);

        }

        private void CalcularEquilatero()
        {

            FormaGeometrica equilatero = new Equilatero()
            {
                Base = Convert.ToDouble(txtBase.Text)
            };
            cmbObjetos.Items.Add(equilatero);

        }

        
    }
}
