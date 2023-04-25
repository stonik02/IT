int n = 3; // размер матрицы
int[,] A = new int[3, 3] { { 1, -2, 3 }, { 4, 0, -5 }, { -6, 7, 8 } };
int[,] B = new int[3, 3] { { 1, -2, 3 }, { 4, 0, -5 }, { -6, 7, 8 } };

// найдем минимум сумм абсолютных значений элементов по столбцам
int minSum = int.MaxValue;
for (int j = 0; j < n; j++) // перебираем столбцы
{
    int sum = SumAbsColumn(A, j);
    if (sum < minSum)
        minSum = sum;
}

Console.WriteLine("Минимум всех сумм абсолютных величин элементов матрицы по столбцам: {0}", minSum);
Console.ReadKey();



static int SumAbsColumn(int[,] matrix, int column) // функция для нахождения суммы абсолютных значений элементов столбца
{
    int sum = 0;
    for (int i = 0; i < matrix.GetLength(0); i++) // перебираем строки
        sum += Math.Abs(matrix[i, column]); // добавляем абсолютное значение элемента в сумму
    return sum;
}
