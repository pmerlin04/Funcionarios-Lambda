using ExercicioLINQ2.Entities;
using System.Globalization;

namespace ExercicioLINQ2
{
    class Program
    {

  
        static void Main(string[] args)
        {
            //buscando fonte de dados através de um arquivo
            string path = @"D:\C#\Secao17-Lambda\ExercicioLINQ2\in.txt";

            //pedindo um valor mínimo para usar como ponto de referência
            Console.WriteLine("Entre salary: ");
            double valor = double.Parse(Console.ReadLine());

            //criando uma List com dados do funcionario
            List<Funcionarios> func = new List<Funcionarios>();

            try
            {
            
                using(StreamReader sr = new StreamReader(path))
                {
                    //enquanto não chegar no final do arquivo, vai continuar repetindo
                    while (!sr.EndOfStream)
                    {
                        //repartindo cada linha do arquivo em um vetor, separando por virgula
                        string [] fields = sr.ReadLine().Split(',');

                        //armazenando as partes nas variáveis
                        string name = fields[0];
                        string email = fields[1];
                        double salary = double.Parse(fields[2]);

                        //atribuindo no obj func da classe Funcionarios
                        func.Add(new Funcionarios(name, email, salary));

                       
                    }//final do while
                }//final do using

                //variável que retorna um IEnumberable, com o resultado dos salarios maiores que o valor, em ordem alfabetica
                var salMaior = func.Where(p => p.Salary > valor).OrderBy(p => p.Name).Select(p => p.Email);
                Console.WriteLine("Email of people whose salary is more than " + valor + ":");
                foreach (string name in salMaior)
                {
                    Console.WriteLine(name);
                }

                //variável que retorna um IEnumberable, com o resultado da soma dos salários com nomes com a letra inical 'M'
                var salMedia = func.Where(p => p.Name[0] == 'M').Sum(p => p.Salary).ToString("F2", CultureInfo.InvariantCulture);
                Console.WriteLine("Sum of salary of people whose name starts with 'M':" +  salMedia);

            }
            catch (Exception ex)
            {

                Console.WriteLine("Arquivo não encontrado");
            }
        }
    }
}
