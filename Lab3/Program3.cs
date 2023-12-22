Console.Write("Желаемый результат d1: ");
float d1 = Convert.ToSingle(Console.ReadLine());
Console.Write("Желаемый результат d2: ");
float d2 = Convert.ToSingle(Console.ReadLine());
Console.Write("Коэффициент поляризации: ");
float pol = Convert.ToSingle(Console.ReadLine());

// входные сигналы
List<int> x1 = new List<int>();
List<int> x2 = new List<int>();

// весовые коэффициенты
List<float> w1 = new List<float>();
List<float> w2 = new List<float>();

float u1 = 0;
float u2 = 0;

float y1, y2;

int I = 0;

// добавление значений входных сигналов
for (int i = 0; i < 5; i++)
{
    Random rnd = new Random();
    int a = rnd.Next(-10, 10);
    int b = rnd.Next(-10, 10);
    x1.Add(a);
    x2.Add(b);
}

// добавление весовых коэффициентов
for (int i = 0; i < 5; i++)
{
    w1.Add(0);
    w2.Add(0);
}

while (true)
{
    // Вычисление u
    for (int i = 0; i < 5; i++)
    {
        u1 += x1[i] * w1[i];
        u2 += x2[i] * w2[i];
    }

    if (u1 < pol)
    {
        y1 = 0;
    }
    else
    {
        y1 = 1;
    }

    if (u2 < pol)
    {
        y2 = 0;
    }
    else
    {
        y2 = 1;
    }

    if (y1 == d1 & y2 == d2)
    {
        break;
    }
    else
    {
        I++;

        for (int i = 0; i < 5; i++)
        {
            w1[i] = (float)(w1[i] + 0.1 * d1 * (x1[i] - w1[i]));
            w2[i] = (float)(w2[i] + 0.1 * d2 * (x2[i] - w2[i]));
        }
    }
}

Console.Write("w1: ");
foreach (float k in w1)
{
    Console.Write(k + "\t");
}

Console.WriteLine();
Console.Write("w2: ");
foreach (float l in w2)
{
    Console.Write(l + "\t");
}

Console.WriteLine();
Console.WriteLine(I);
Console.ReadLine();