using System;
using System.IO;

namespace TextEditor {

    class Program {
        static void Main(string[] args) {
        Menu();
        }

        static void Menu() {

            Console.Clear();
            Console.WriteLine("O que você deseja fazer?");
            Console.WriteLine("1 - Abrir arquivo");
            Console.WriteLine("2 - Criar arquivo");
            Console.WriteLine("0 - Sair");
            short option = short.Parse(Console.ReadLine());

            switch(option){
                case 0: System.Environment.Exit(0);
                break;
                case 1: Abrir();
                break;
                case 2: Editar();
                break;
                default: Menu();
                break;
            }

        }

        static void Abrir() {
            Console.Clear();

            Console.WriteLine("Qual o caminho do arquivo?");
            string path = Console.ReadLine();

            using(var file = new StreamReader(path)){
                string text = file.ReadToEnd(); //Abrir o texto até o fim em seu local de armazenamento (path) - com o ReadToEnd(path)
                Console.WriteLine(text);
            }
                Console.WriteLine("");
                Console.ReadLine();
                Menu();
        }

        static void Editar() {
            Console.Clear();
            Console.WriteLine("Digite seu texto abaixo: (ESC para sair)");
            Console.WriteLine("----------------");
            string text = "";
           
           do {
            /* text + = para o programa junte tudo o que o usuário já digitou + o novo conteúdo.
                 Se colocar só o = ele vai substituir o texto e o que precisamos é concatenar os conteúdos */
                text += Console.ReadLine(); // Console.ReadLine para ler a linha digitada.
                text += Environment.NewLine; // Environment.NewLine para "adicionaar" uma nova linha a cada leitura  
           
            /* Laço de repetição para que seja armazenado tudo o que o usuário digitar, 
            com exceção da tecla ESC (Comando pra sair)  - Console.ReadKey().Key é o 
            comando que fica "escutando" se a tecla definida (ESC) será digitada. Se a 
            tecla for digitada ele sai do laço*/
           } while (Console.ReadKey().Key != ConsoleKey.Escape);

                Salvar(text);
            

        }

        static void Salvar(string text){
            Console.Clear();
            Console.WriteLine(" Qual o caminho para salvar o arquivo?");
            var path = Console.ReadLine();

            using(var file = new StreamWriter(path)){//O using() vai criar, usar e fechar automaticamente qq objeto passado como parâmetro. Neste caso utilizaremos o Fluxo de escrita (StreamWriter) com o parâmetro "path" indicando o caminho onde o arquivo deverá ser salvo
                file.Write(text);
            }
                Console.WriteLine($"Arquivo {path} salvo com sucesso!");
                Console.ReadLine();
                Menu();
        }
    }
}
