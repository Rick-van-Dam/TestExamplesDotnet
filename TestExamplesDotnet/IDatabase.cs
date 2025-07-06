using Microsoft.Extensions.Hosting;

namespace TestExamplesDotnet;

public interface IDatabase
{
    string ConnectionString { get; }

    void EnsureInitialized(IHost host);
    Task Clean();
}
