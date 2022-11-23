using System;
using System.Collections.Generic;
using System.Text;

namespace FormalNeuron
{
	// Структура для обучения модели
	// не ссылочный, а значимый тип, который позволяет упростить
	// обработку и хранение информации.
	// Модификатор internal даст доступ к полям структуры из всей программы, но
	// эту структуру нельзя будет использовать в других программах/сборках
	struct TrainingData
	{
		internal static int[][] X = {
				new int [] {0, 0, 0, 0},
				new int [] {0, 0, 0, 1},
				new int [] {1, 1, 1, 0},
				new int [] {1, 1, 1, 0},
				new int [] {1, 1, 1, 1}
		};
		
		internal static int[] Y = { 0, 1, 1, 0, 1 };

		internal static int[][] Test = {
				new int [] {0, 0, 0, 0},
				new int [] {0, 0, 0, 1},
				new int [] {0, 1, 0, 1},
				new int [] {0, 1, 1, 0},
				new int [] {1, 1, 1, 0},
				new int [] {1, 1, 1, 1}
		};
	}
}
