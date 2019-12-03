using Biblioteca;
using System;
using System.Windows.Forms;

namespace CRUDAlunos.Forms
{
    public partial class EditarAluno : Form
    {
        Aluno editado; //passar por parametros, para aqui, o que quero editar

        Form1 form; // para depois iniciar a lista / atualizar

        public EditarAluno(Form1 frm, Aluno editado)
        {
            InitializeComponent();

            this.editado = editado;
            form = frm;

            //"Novo" constrtutor
            textBoxId.Text = editado.Id.ToString();
            textBox1Nome.Text = editado.Nome;
            textBoxApelido.Text = editado.Apelido;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidaForm())
            {
                editado.Nome = textBox1Nome.Text;
                editado.Apelido = textBoxApelido.Text;
                form.InitLista();
                this.Close();
            }
        }

        private bool ValidaForm()
        {
            bool output = true;

            if (string.IsNullOrEmpty(textBox1Nome.Text))
            {
                MessageBox.Show("Insira o seu Primeiro Nome", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                output = false;
            }

            if (string.IsNullOrEmpty(textBoxApelido.Text))
            {
                MessageBox.Show("Insira o seu Apelido", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                output = false;
            }
            return output;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
