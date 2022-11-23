using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
				if (value >= 100 && value <= -100)
                {
					throw new NeuronException("Неккоректное значение параметра", value);
                }
                else
                {
					a = value;
				}
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
				if (value >= 100 && value <= -100)
				{
					throw new NeuronException("Неккоректное значение параметра", value);
				}
				else
				{
					b = value;
				}
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
				if (value >= 100 && value <= -100)
				{
					throw new NeuronException("Неккоректное значение параметра", value);
				}
				else
				{
					c = value;
				}
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
}
