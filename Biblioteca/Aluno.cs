namespace Biblioteca
{
    public class Aluno
    { 
        //Modelo de dados, serve para suportar os dados da aplicaçao
        //SQL as tabelas sao os objetos aqui e a descriçao das tabelas sao as propriedades
        //Ex: 5 tabelas em SQL 5 classes...
        //daqui qnd fizermos uma base de dados em SQL, ele faz sozinho!!

        public int Id { get; set; }

        public string  Nome { get; set; }

        public string Apelido { get; set; }

        public string NomeCompleto 
        {

            get
            {

                return $"{Nome} {Apelido}";
            }
        }
        //Classe objetc PAI advem tudo de lá.
        //agora vamos dizer que queremos que os métodos retornem o que queremos e nao o que retorna por defeito, do PAI
        public override string ToString()// permite usar o POLIMORFISMO
            // a um metodo que ja existe. "nestes casos usa o meu, em vez do teu"
        {
            return $"{Id} {Nome} {Apelido}";
        }
    }
}
