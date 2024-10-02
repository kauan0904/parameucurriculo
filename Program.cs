using System;
using System.Collections.Generic;

class Program
{
    // Classe que representa um compromisso
    public class Compromisso
    {
        public DateTime DataHora { get; set; } // Data e hora do compromisso
        public string Servico { get; set; }    // Tipo de serviço agendado
        public string Cliente { get; set; }    // Nome do cliente

        // Método para representar o compromisso como uma string
        public override string ToString()
        {
            return $"{DataHora}: {Servico} para {Cliente}";
        }
    }

    // Lista para armazenar os compromissos
    static List<Compromisso> compromissos = new List<Compromisso>();

    // Método principal que executa o programa
    static void Main(string[] args)
    {
        // Loop infinito para exibir o menu até que o usuário decida sair
        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Adicionar Compromisso");
            Console.WriteLine("2. Remover Compromisso");
            Console.WriteLine("3. Visualizar Compromissos");
            Console.WriteLine("4. Sair");
            Console.Write("Escolha uma opção: ");
            
            string opcao = Console.ReadLine(); // Lê a opção escolhida pelo usuário

            // Processa a opção escolhida
            switch (opcao)
            {
                case "1":
                    AdicionarCompromisso(); // Chama o método para adicionar compromisso
                    break;
                case "2":
                    RemoverCompromisso(); // Chama o método para remover compromisso
                    break;
                case "3":
                    VisualizarCompromissos(); // Chama o método para visualizar compromissos
                    break;
                case "4":
                    return; // Sai do programa
                default:
                    Console.WriteLine("Opção inválida, tente novamente."); // Mensagem de erro para opção inválida
                    break;
            }
        }
    }

    // Método para adicionar um novo compromisso
    static void AdicionarCompromisso()
    {
        // Solicita a data do compromisso
        Console.Write("Informe a data (dd/MM/yyyy): ");
        DateTime data = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
        
        // Solicita a hora do compromisso
        Console.Write("Informe a hora (HH:mm): ");
        TimeSpan hora = TimeSpan.Parse(Console.ReadLine());

        // Solicita o tipo de serviço
        Console.Write("Informe o serviço: ");
        string servico = Console.ReadLine();

        // Solicita o nome do cliente
        Console.Write("Informe o nome do cliente: ");
        string cliente = Console.ReadLine();

        // Cria um novo compromisso e adiciona à lista
        Compromisso compromisso = new Compromisso
        {
            DataHora = data.Date.Add(hora), // Combina a data e a hora
            Servico = servico,
            Cliente = cliente
        };

        compromissos.Add(compromisso); // Adiciona o compromisso à lista
        Console.WriteLine("Compromisso adicionado com sucesso!");
    }

    // Método para remover um compromisso
    static void RemoverCompromisso()
    {
        // Solicita a data do compromisso a ser removido
        Console.Write("Informe a data (dd/MM/yyyy): ");
        DateTime data = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
        
        // Solicita a hora do compromisso a ser removido
        Console.Write("Informe a hora (HH:mm): ");
        TimeSpan hora = TimeSpan.Parse(Console.ReadLine());

        DateTime dataHora = data.Date.Add(hora); // Combina a data e a hora
        // Busca o compromisso na lista
        var compromisso = compromissos.Find(c => c.DataHora == dataHora);

        if (compromisso != null)
        {
            compromissos.Remove(compromisso); // Remove o compromisso encontrado
            Console.WriteLine("Compromisso removido com sucesso.");
        }
        else
        {
            Console.WriteLine("Compromisso não encontrado."); // Mensagem caso o compromisso não exista
        }
    }

    // Método para visualizar todos os compromissos
    static void VisualizarCompromissos()
    {
        // Verifica se a lista está vazia
        if (compromissos.Count == 0)
        {
            Console.WriteLine("Nenhum compromisso agendado.");
            return;
        }

        // Exibe todos os compromissos agendados
        Console.WriteLine("Compromissos agendados:");
        foreach (var compromisso in compromissos)
        {
            Console.WriteLine(compromisso); // Chama o método ToString() da classe Compromisso
        }
    }
}
