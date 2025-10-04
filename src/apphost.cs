#:sdk Aspire.AppHost.Sdk@9.5.1
#:project Chatbot
#:package Aspire.Hosting.Qdrant@9.5.1
#:package CommunityToolkit.Aspire.Hosting.Ollama@9.8.0

var builder = DistributedApplication.CreateBuilder(args);

var db = builder.AddQdrant("db");
var ai = builder.AddOllama("ai")
    .AddModel("nomic-embed-text");

var chatbot = builder.AddProject<Projects.Chatbot>("chatbot")
    .WithReference(db)
    .WithReference(ai);

builder.Build().Run();
