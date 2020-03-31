using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace SqlBenchmark
{
	[SimpleJob(RuntimeMoniker.Net472, baseline: true)]
	[SimpleJob(RuntimeMoniker.NetCoreApp31)]
	public class PostgreSqlConnection
	{
		private string _connectionString = "";

		[GlobalSetup]
		public void Setup()
		{
			var config = new ConfigurationBuilder()
				.AddJsonFile("./appsettings.json")
				.Build();

			_connectionString = config["PostgreSqlConnectionStrings:DefaultConnection"];
		}

		[Benchmark]
		public void Connect()
		{
			using (var con = new NpgsqlConnection(_connectionString))
			{
				con.Open();
			}
		}
	}
}
