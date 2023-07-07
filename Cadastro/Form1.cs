using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cadastro
{
    public partial class Cadastr1 : Form
    {
        List<Pessoa> pessoas;
        public Cadastr1()
        {
            InitializeComponent();

            pessoas = new List<Pessoa>();

            comboBox2.Items.Add("Casado(A)");
            comboBox2.Items.Add("Solteiro(A)");
            comboBox2.Items.Add("Viuvo(A)");
            comboBox2.Items.Add("Separado(A)");

            comboBox2.SelectedIndex = 0;
        }

        private void Cadastr1_Load(object sender, EventArgs e)
        {
      

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = -1;

            foreach (Pessoa p1 in pessoas)
            {
                if (p1.Nome == textBox1.Text)
                {
                    index = pessoas.IndexOf(p1);

                }

            }

            if (textBox1.Text == "")
            {
                MessageBox.Show("Prencha o Campo Nome.");
                textBox1.Focus();
                return;
            }

            if (maskedTextBox1.Text == "(  )      -")
            {
                MessageBox.Show("Prencha o Campo Telefone");
                maskedTextBox1.Focus();
                return;
            }
            char sexo = 'p';

            if (radioButton1.Checked)
            {
                sexo = 'M';
            }
            else if (radioButton2.Checked)
            {
                sexo = 'F';
            }
            else if (radioButton3.Checked)
            {
                sexo = 'B';
            }

            Pessoa p = new Pessoa();

            p.Nome = textBox1.Text;
            p.DataNascimento = dateTimePicker1.Text;
            p.EstadoCivil = comboBox2.SelectedItem.ToString();
            p.CasaPropria = checkBox1.Checked;
            p.Veiculo = checkBox2.Checked;
            p.Telefone = maskedTextBox1.Text;
            p.Sexo = sexo;

            if (index < 0)
            {
                pessoas.Add(p);
            }
            else
            {
                pessoas[index] = p;
            }
            button3_Click(button3, EventArgs.Empty);

            Listar();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int indice = listBox1.SelectedIndex;
            pessoas.RemoveAt(indice);
            Listar();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            dateTimePicker1.Text = "";
            comboBox2.SelectedIndex = 0;
            maskedTextBox1.Text = "";
            checkBox1.Checked = false; 
            checkBox2.Checked = false; 
            radioButton1 .Checked = true;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            textBox1.Focus();


        }

        private void Listar() 
        {
           listBox1.Items.Clear();

            foreach (Pessoa p in pessoas)
            {
                listBox1.Items.Add(p.Nome);
            }
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int indice = listBox1.SelectedIndex;
            Pessoa p = pessoas[indice];

            textBox1.Text = p.Nome;
            dateTimePicker1.Text = p.DataNascimento;
            maskedTextBox1.Text = p.Telefone;
            comboBox2.SelectedItem = p.EstadoCivil;
            checkBox1 .Checked = p.CasaPropria;
            checkBox2.Checked = p.Veiculo;

            switch (p.Sexo)
            {
                case 'M':
                    radioButton1.Checked = true;
                    break;
                case 'F':
                    radioButton2 .Checked = true; 
                    break;
                case 'B':
                    radioButton3 .Checked = true;
                    break;
                default:
                    radioButton1.Checked=true;
                    break;
            }
            

        }
    }
}
