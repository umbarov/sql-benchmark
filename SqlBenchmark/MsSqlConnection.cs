using System;
using System.Data.SqlClient;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Microsoft.Extensions.Configuration;

namespace SqlBenchmark
{
	[SimpleJob(RuntimeMoniker.Net472, baseline: true)]
	[SimpleJob(RuntimeMoniker.NetCoreApp31)]
	public class MsSqlConnection
	{
		private string _connectionString = "";

		[GlobalSetup]
		public void Setup()
		{
			var config = new ConfigurationBuilder()
				.AddJsonFile("./appsettings.json")
				.Build();

			_connectionString = config["MsSqlConnectionStrings:DefaultConnection"];
		}

		[Benchmark]
		public void Connect()
		{
			using (var con = new SqlConnection(_connectionString))
			{
				con.Open();
			}
		}
	}
}
