using System;
using Microsoft.AspNet.SignalR.Client.Hubs;

namespace SignalR.Chat.Client
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Instancia a conexão com servidor
            var connection = new HubConnection("http://127.0.0.1:8088/");

            //Faz o proxy para o hub com base no nome do hub no servidor
            var myHub = connection.CreateHubProxy("CustomHub");

            //Inicia Conexão
            connection.Start().ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    Console.WriteLine("Ocorreu um erro ao abrir a conexão:{0}",
                    task.Exception.GetBaseException());
                }
                else
                {
                    Console.WriteLine("Conectado");
                }

            }).Wait();


            Console.WriteLine("Por favor digite seu Nome:");
            String name = Console.ReadLine();
            Console.WriteLine("Obrigado! Comece seu chat!");
            String msg = "";

            myHub.On<string, string>("addMessage", (nome, param) =>
            {
                if (nome != name)
                {
                    Console.WriteLine($"{nome} diz: {param}");
                }
            });

            while (msg != "Exit")
            {
                msg = Console.ReadLine();
                myHub.Invoke<string>("DoSomething", name, msg).Wait();
            }

            connection.Stop();
        }
    }
}