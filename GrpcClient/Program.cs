using System;
using System.Net.Http;
using System.Threading.Tasks;
using Grpc.Net.Client;

namespace GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            bool useHttps = true; // when running under MAC TLS with HTTP/2 is not supported so we need to send to http 

            string uri = "https://localhost:5001";
            if (useHttps == false) {
                uri = "http://127.0.0.1:5000";
            }

            // Return "true" to allow certificates that are untrusted/invalid
            var httpHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback =
                    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };            

            using var channel = GrpcChannel.ForAddress(uri, new GrpcChannelOptions { HttpHandler = httpHandler });

            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(
                              new HelloRequest { Name = "GreeterClient A, uri:" + uri });
            Console.WriteLine("Greeting: " + reply.Message);
            channel.ShutdownAsync().Wait();
        }
    }
}