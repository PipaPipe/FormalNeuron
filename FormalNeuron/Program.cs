using System;
using System.Linq;

namespace FormalNeuron
{


	class Neuron
	{
		// Поля класса приватные, потому что должны быть видны только для
		// Методов внутри самого класса, нам не нужно изменять значение
		// Если мы хотим обратиться к этим полям напрямую, то необходимо создать
		// Геттеры и сеттеры, в которых мы будем задавать/забирать значения
		private double a = 0.02;
		private double b = -0.4;
		readonly double[] w = { 0, 0, 0, 0 };
		private int c = 0;

		// т.к Данный параметр является основным, то мы его не сможем изменять
		// сделаем для него модификатор readonly
		public double[] ParameterW
        {
            get
            {
				return w;
            }
        }
		public double ParameterA
        {
            get
            {
				// Возвращаем значение того или иногт параметра
				return a;
            }
            set
            {
				// Для установления нового значения в поле мы можем реализовать 
				// В сеттере ветвления, для проверки валидности входного значения
				a = value;
            }
        }

		public double ParameterB
        {
            get
            {
				return b;
            }
            set
            {
				b = value;
            }
        }

		public int ParameterC
        {
            get
            {
				return c;
            }
            set
            {
				c = value;
            }
        }

		public Neuron(int[][] X, int[] Y)
		{
			while (learn(X, Y))
			{
				if (c++ > 10000) break;
			}
		}

		public double calculate(int[] x)
		{
			double s = b;
			for (int i = 0; i < w.Length; i++) s += w[i] * x[i];
			return (s > 0) ? 1 : 0;
		}

		bool learn(int[][] X, int[] Y)
		{
			double[] w_ = new double[w.Length];

			Array.Copy(w, w_, w.Length);

			int i = 0;
			foreach (int[] x in X)
			{
				int y = Y[i++];
				for (int j = 0; j < x.Length; j++)
				{
					w[j] += a * (y - calculate(x)) * x[j];
				}
			}
			return !Enumerable.SequenceEqual(w_, w);
		}

	}

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
