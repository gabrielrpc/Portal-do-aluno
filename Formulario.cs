using Portal_do_aluno.Infra;

namespace Portal_do_aluno
{
    public partial class Formulario : Form
    {
        public List<Aluno> Alunos { get; private set; } = new List<Aluno>();


        public Formulario()
        {
            InitializeComponent();

            // chama método que lista alunos
            ObterAlunos();
        }

        private void ObterAlunos()
        {
            var alunoRepositorio = new AlunoRepositorio();

            Alunos = alunoRepositorio.Get();

            foreach (var aluno in Alunos)
            {
                lv_alunos.Items.Add(new ListViewItem(new String[] { aluno.nome, aluno.idade.ToString(), aluno.curso }));
            }
        }

        private void btn_adicionar_Click(object sender, EventArgs e)
        {
            try
            {
                // captura os dados inseridos 
                var nome = txt_nome.Text;
                var idade = txt_idade.Text;
                var curso = txt_curso.Text;

                // verifica se aluno já está cadastrado
                foreach (var item in Alunos)
                {
                    if (item.nome == nome)
                    {
                        MessageBox.Show($"{nome} já está cadastrado no sistema.");
                        return;
                    }
                }

                // adiciona novo aluno
                var aluno = new Aluno(nome, idade, curso);
                Alunos.Add(aluno);

                // adiciona no banco
                var alunoRepositorio = new AlunoRepositorio();
                alunoRepositorio.Add(aluno);

                // adiciona aluno em tela
                lv_alunos.Items.Add(new ListViewItem(new String[] { nome, idade, curso }));

                MessageBox.Show("Aluno adicionado com sucesso.");

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
    }
}
