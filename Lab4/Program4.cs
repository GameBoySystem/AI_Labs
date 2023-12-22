List<float> listX = new List<float>();
List<float> listW = new List<float>();
int itemX;

float pol = 0.5f;
float n = 0.5f;
int SumX = 0;

Console.WriteLine("Введите значения x1 - x15");
for (int i = 0; i < 15; i++)
{
    Console.Write("x" + (i + 1) + ":\t");
    itemX = Convert.ToInt32(Console.ReadLine());
    listX.Add(itemX);
    SumX += itemX;
    listW.Add(0);
}

// нормализация данных
float normalizeX = (float)Math.Sqrt(SumX);
for (int i = 0; i < listX.Count; i++)
{
    listX[i] = listX[i] / normalizeX;
}


Console.ReadKey();