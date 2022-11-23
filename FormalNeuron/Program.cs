using System;
using System.Linq;

namespace FormalNeuron
{
	class Program
    {
        static void Main(string[] args)
        {
			Neuron neuron = new Neuron(TrainingData.X, TrainingData.Y);
			Console.WriteLine("[{0}] {1}",
				string.Join(", ", neuron.ParameterW),
				neuron.ParameterC
				);

			foreach (int[] test in TrainingData.Test)
			{
				Console.WriteLine("[{0}] {1} {2}",
					string.Join(", ", test),
					test[3],
					neuron.calculate(test)
				);
			}
		}
    }
}
