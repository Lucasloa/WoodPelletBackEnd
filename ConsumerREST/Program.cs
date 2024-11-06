// See https://aka.ms/new-console-template for more information
using ConsumerREST;
Console.WriteLine("Hello, World!");
Worker worker = new Worker();
await worker.DoWork();