using Microsoft.Extensions.DependencyInjection;

int ReadNumber() {
    string? line = Console.ReadLine();
    bool ret = int.TryParse(line, out int result);
    if (ret)
        return result;
    return 0;
}

Console.Write("Select a scope of \"MyService\": [1] Transient [2] Scoped [default] Singleton\n> ");
int index1 = ReadNumber();
Console.Write("Select a scope of \"MyMessage\": [1] Transient [2] Scoped [default] Singleton\n> ");
int index2 = ReadNumber();
Console.Write("Create Scope in Demo? [1] Yes [default] No\n> ");
int index3 = ReadNumber();

var serviceCollection = new ServiceCollection();
switch (index1) {
    case 1:
        serviceCollection.AddTransient<MyService>();
        break;
    case 2:
        serviceCollection.AddScoped<MyService>();
        break;
    default:
        serviceCollection.AddSingleton<MyService>();
        break;
}

switch (index2) {
    case 1:
        serviceCollection.AddTransient<IMessage, MyMessage>();
        break;
    case 2:
        serviceCollection.AddScoped<IMessage, MyMessage>();
        break;
    default:
        serviceCollection.AddSingleton<IMessage, MyMessage>();
        break;
}

var serviceProvider = serviceCollection.BuildServiceProvider();
switch (index3) {
    case 1:
        Console.WriteLine("=== Run Scope 1 ===");
        var scope1 = serviceProvider.CreateScope();
        scope1.ServiceProvider.GetRequiredService<MyService>().WriteMessage();
        scope1.ServiceProvider.GetRequiredService<MyService>().WriteMessage();
        Console.WriteLine("=== RUn Scope 2 ===");
        var scope2 = serviceProvider.CreateScope();
        scope2.ServiceProvider.GetRequiredService<MyService>().WriteMessage();
        scope2.ServiceProvider.GetRequiredService<MyService>().WriteMessage();
        break;
    default:
        serviceProvider.GetRequiredService<MyService>().WriteMessage();
        serviceProvider.GetRequiredService<MyService>().WriteMessage();
        break;
}