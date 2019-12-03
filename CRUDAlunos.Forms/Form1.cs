using Biblioteca;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace CRUDAlunos.Forms
{
    public partial class Form1 : Form
    {

        //Listas objetos do tipo Aluno
        List<Aluno> Alunos; // > Atributo

        int contaAlunos = 1; //para começar a mexer no Id

        public Form1()
        {
            Alunos = new List<Aluno>(); // a lista está instanciada
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Aluno novoAluno; //objeto novo do tipo aluno, para ser guardado

            if (ValidaForm())
            {
                novoAluno = new Aluno // criar objeto do tipo aluno e por ja os atributos, sem construtor (era tipo o contrtutor por parametros
                {
                    Id = contaAlunos,
                    Nome = textBox1Nome.Text,
                    Apelido = textBoxApelido.Text,
                };
                Alunos.Add(novoAluno); // agarrar no aluno e por dentro da lista, apos guardar, desaparece
                contaAlunos++;

                InitLista(); // iniciar um metodo, sem existir, ir á lampada e criar o método sozinho!
            }
            else
            {
                MessageBox.Show("Preencha corretamente os dados e tente novamente",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            textBox1Nome.Text = string.Empty;
            textBoxApelido.Text = string.Empty;
        }

        public void InitLista()
        {
            listBoxAlunos.DataSource = null;
            listBoxAlunos.DataSource = Alunos; // objetos vao passar para dentro da listBox (caixinha da Form
            //qnd sao valores que nao sao gerados atravez de codigo, tipo M ou F, editamos a listbox no form)
            listBoxAlunos.DisplayMember = "NomeCompleto"; // este atributo tem que estar na classe para ser usado aqui
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
            MessageBox.Show("O Aluno não vai ser guardado!!", "Aviso",
                   MessageBoxButtons.OK, MessageBoxIcon.Warning);

            textBox1Nome.Text = string.Empty;
            textBoxApelido.Text = string.Empty;

        }  //******************************************************************CREATE e READ criado*******************************************************

        private void btnApagarAluno_Click(object sender, EventArgs e)
        {
            //ir agarrar o objeto (Aluno)
            Aluno alunoApagar = (Aluno)listBoxAlunos.SelectedItem; //propriedade que diz aquele que o user carregou
            //ir ver á lista se lá está ou não, FAZER SEMPRE

            Aluno apagado = null;

            if (alunoApagar != null) // conseguiu converter e ta tudo bem
            {
                foreach (Aluno aluno in Alunos)
                {
                    if (alunoApagar.Id == aluno.Id) // qnd houver 2 alunos iguais na lista 
                    {
                        apagado = aluno; // aluno escolhido para dentro do apagado
                    }
                }
                if (apagado != null) 
                {
                    DialogResult respota;

                    respota = MessageBox.Show($"Tem a certeza que quer apagar o {apagado.NomeCompleto}?",
                        "Apagar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (DialogResult.OK == respota)  //*******************POR APAGAR ITEM A FALSE E POR TRUE SO QND HA ALUNOS NA LISTBOX
                    {
                        Alunos.Remove(apagado); // aqui é que realmente apaga
                        InitLista(); // iniciar a lista outra vez

                    } // *************************************************** APAGAR***************************************
                }
            }
        }

        private void btnEditarAluno_Click(object sender, EventArgs e)
        {
            Aluno alunoEditar = (Aluno)listBoxAlunos.SelectedItem;
            Aluno editado = null;

            if (alunoEditar != null)
            {
                foreach (Aluno aluno in Alunos)
                {
                    if (alunoEditar.Id == aluno.Id)
                    {
                        editado = aluno;
                    }
                }
                //abrir nova form para editar
                if (editado != null)
                {
                    EditarAluno editarAlunoForm = new EditarAluno(this, editado);
                    editarAlunoForm.Show();
                }
                
            } // *****************************************EDITAR***************************************************************
        }
    }
}
