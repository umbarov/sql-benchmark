using BenchmarkDotNet.Running;

namespace SqlBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            var msSqlSummary = BenchmarkRunner.Run<MsSqlConnection>();
            var postgreSqlSummary = BenchmarkRunner.Run<PostgreSqlConnection>();
        }
    }
}
