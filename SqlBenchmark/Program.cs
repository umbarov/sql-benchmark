using System;
using BenchmarkDotNet.Running;

namespace SqlBenchmark
{
	class Program
	{
		static void Main(string[] args)
		{
			var summary = BenchmarkRunner.Run<MsSqlConnection>();
		}
	}
}
