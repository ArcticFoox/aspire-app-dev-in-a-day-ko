var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var apiapp = builder.AddProject<Projects.AspireYouTubeSummariser_ApiApp>("apiapp");

builder.AddProject<Projects.AspireYouTubeSummariser_WebApp>("webapp")
       // 추가 👇
       .WithExternalHttpEndpoints()
       // 추가 👆
       .WithReference(cache)
       .WithReference(apiapp);


builder.Build().Run();
