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
    public partial class Form1 : Form
    {
        List<Pessoa> pessoas;

        public Form1()
        {
            InitializeComponent();
            pessoas = new List<Pessoa>();
            cbLane.Items.Add("Top");
            cbLane.Items.Add("Jungle");
            cbLane.Items.Add("Mid");
            cbLane.Items.Add("Adc");
            cbLane.Items.Add("Suporte");
            comboBox2.Items.Add("Ferro");
            comboBox2.Items.Add("Bronze");
            comboBox2.Items.Add("Prata");
            comboBox2.Items.Add("Ouro");
            comboBox2.Items.Add("Platina");
            comboBox2.Items.Add("Diamante");
            comboBox2.Items.Add("Mestre");
            comboBox2.Items.Add("Grão-Mestre");
            comboBox2.Items.Add("Desafiante");
            cbLane.Text = "";
            comboBox2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = -1;

            foreach (Pessoa pessoa in pessoas)
            {
                if (pessoa.Nome == textBoxNome.Text)
                {
                    index = pessoas.IndexOf(pessoa);
                }
                
            }
            if (textBoxNome.Text == "") //Campos criados a seguir para verificar e avisar caso um campo esteja vazio
            {
                MessageBox.Show("Campo \"Nome\" não preenchido!");
                textBoxNome.Focus();
                return;
            }
            if (textBox1.Text == "")
            {
                MessageBox.Show("Campo \"Usuario\" não preenchido!");
                textBox1.Focus();
                return;
            }
            if (cbLane.Text == "")
            {
                MessageBox.Show("Campo \"Campo de jogo\" não selecionado!");
                cbLane.Focus();
                return;
            }
            if (comboBox2.Text == "")
            {
                MessageBox.Show("Campo \"Elo\" não selecionado" +
                    "" +
                    "!");
                comboBox2.Focus();
                return;
            }

            Pessoa p = new Pessoa();
            p.Nome = textBoxNome.Text;
            p.DataNascimento = dateTimePicker1.Text;
            p.User = textBox1.Text;
            p.Lane = cbLane.SelectedItem.ToString();
            p.Elo = comboBox2.SelectedItem.ToString();
            // variavel criada a partir da classe 
            if (index < 0)
            {
                pessoas.Add(p);
            }
            else
            {
                pessoas[index] = p;

            }
            btnExcluir_Click(btnLimpar, EventArgs.Empty);
            Listar();

        }



        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Limpar();
        }
        private void Limpar()
        {
            textBoxNome.Text = null;
            textBox1.Text = null;
            dateTimePicker1.Text = null;
            cbLane.Text = null;
            comboBox2.Text = null;
            textBoxNome.Focus();
            //botao usado para limpar os campos preenchidos
        }
        private void Listar()//metodo a parte
        {
            lista.Items.Clear();
            foreach (Pessoa p in pessoas)
            {
                lista.Items.Add(p.Nome);
            }
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {

            int indice = lista.SelectedIndex;
            if (lista.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione o Cadastro que deseja apagar.");
                return;
            }
                pessoas.RemoveAt(indice);
            Listar();
            Limpar();
        }

        private void lista_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = lista.SelectedIndex;
            if (indice == -1)
            {
                return;
            }
            Pessoa p = pessoas[indice];
            textBoxNome.Text = p.Nome;
            textBox1.Text = p.User;
            dateTimePicker1.Text = p.DataNascimento;
            cbLane.SelectedItem = p.Lane;
            comboBox2.SelectedItem = p.Elo;
        }

        private void lista_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int indice = lista.SelectedIndex;
            if (lista.SelectedIndex == -1)
            {
                return;
            }
            Pessoa p = pessoas[indice];    
            textBoxNome.Text = p.Nome;
            dateTimePicker1.Text = p.DataNascimento;
            textBox1.Text = p.User;
            cbLane.SelectedItem = p.Lane;
            comboBox2.SelectedItem = p.Elo;
        }
    }
}
