using GeradorTxt;
using System;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Se o primeiro argumento for "test", executa a suíte de testes
            if (args.Length > 0 && args[0].ToLower() == "test")
            {
                RodarTestes();
                return; // Finaliza o programa após rodar os testes
            }

            // Caso contrário, executa a aplicação normalmente
            MainConsole.Run();
        }

        static void RodarTestes()
        {
            Console.WriteLine("--------- Iniciando Testes Unitários --------");        
            var test = new TesteGerador();
            
            try 
            {
                // Chamamos cada caso de teste manualmente para cobrir os cenários
                test.Deve_Validar_Soma_Dos_Itens(100.00m, 50.00m, 50.00m, true);
                test.Deve_Validar_Soma_Dos_Itens(100.00m, 50.005m, 50.005m, true);
                test.Deve_Validar_Soma_Dos_Itens(100.00m, 50.01m, 50.01m, false);
                
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("Todos os testes passaram com sucesso!");
            } 
            catch (Exception ex) 
            {
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("TESTE FALHOU: " + ex.Message);            
                Console.WriteLine(ex.StackTrace);                
            }
        }
    }
}