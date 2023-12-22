int n = 10;
for (int l = 0; l < 5; l++)
{
    Console.WriteLine($"Разрядность равна {n}");
    int resultD = 2;
    int u = 0;
    int iteration = 0;
    double averageIterations = 0.0;

    for (int k = 0; k < 11; k++)
    {
        Random random = new Random();

        int[] listX = new int[n];
        int[] listW = new int[n];

        for (int i = 0; i < n; i++)
        {
            int x = random.Next(-10, 10);
            int w = random.Next(-100, 100);
            listX[i] = x;
            listW[i] = w;
        }

        int d = random.Next(0, 2);

        if (resultD == d)
        {
            Console.WriteLine($"Среднее количество итераций: {averageIterations / 11.0}");
            break;
        }

        while (resultD != d)
        {
            foreach (int x in listX)
            {
                u += x * listW[Array.IndexOf(listX, x)];
            }

            if (u >= 0)
                resultD = 1;
            else
                resultD = 0;

            iteration++;
            averageIterations += iteration;
            u = 0;

            for (int j = 0; j < n; j++)
            {
                if (resultD > d)
                    listW[j] = listW[j] - listX[j];
                else
                    listW[j] = listW[j] + listX[j];
            }
        }

        Array.Clear(listX, 0, n);
        Array.Clear(listW, 0, n);
        resultD = 2;
        u = 0;
        iteration = 0;
    }

    n += 20;
    Console.WriteLine($"Среднее количество итераций: {averageIterations / 11.0}");
}
    Console.ReadKey();