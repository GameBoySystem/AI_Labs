internal class Program2
{
    private static void Main(string[] args)
    {
        Console.Write("Разрядность входного сигнала: ");
        int n = Convert.ToInt32(Console.ReadLine());
        Console.Write("Желаемый результат: ");
        float d = Convert.ToSingle(Console.ReadLine());
        Console.Write("Погрешность: ");
        float pogr = Convert.ToSingle(Console.ReadLine());
        Console.Write("Значение коэффициента обучения: ");
        float eta = Convert.ToSingle(Console.ReadLine());
        Console.Write("Значение коэффициента b: ");
        float beta = Convert.ToSingle(Console.ReadLine());

        // Число итераций
        int I;
        // Сумма произведений значений входных сигналов X и их весовых коэффициентов W
        float u;
        float diff;

        // Список значений входных сигналов X
        List<float> InitialListX = new List<float>();
        //Список весовых коэффициентов W
        List<float> InitialListW = new List<float>();

        // Заполнение списков listX и listW
        for (int i = 0; i < n; i++)
        {
            Random rnd = new Random();
            float x = Convert.ToSingle(rnd.Next(-100, 100) / 100f);
            float w = Convert.ToSingle(rnd.Next(-100, 100) / 100f);
            InitialListX.Add(x);
            InitialListW.Add(w);
        }


        for (int mode = 1; mode < 3; mode++)
        {
            I = 0;
            u = 0;
            diff = 0;
            List<float> listX = InitialListX;
            List<float> listW = InitialListW;
            switch (mode)
            {
                case 1:
                    Console.WriteLine("Униполярный нейрон");
                    break;
                case 2:
                    Console.WriteLine("Биполярный нейрон");
                    break;
                default:
                    break;
            }

            while (true)
            {
                I++;

                // Вычисление u
                for (int i = 0; i < n; i++)
                {
                    u += listX[i] * listW[i];
                }
                //Console.WriteLine("u " + u);
                //Console.ReadKey();

                // Вычисление f(u)
                float y = 0;
                switch (mode)
                {
                    case 1:
                        // униполярная функция
                        y = 1 / Convert.ToSingle(1 + Math.Pow(Math.E, -1 * beta * u));
                        break;
                    case 2:
                        // биполярная функция
                        y = (float)Math.Tanh(beta * u);
                        break;
                    default:
                        break;
                }
                //Console.WriteLine("y " + y);
                //Console.ReadKey();
                //Console.WriteLine("y-d " + (y - d));
                //Console.ReadKey();

                if (Math.Abs(y - d) > pogr)
                {
                    // вычисление дифференциала
                    switch (mode)
                    {
                        case 1:
                            // дифференциал униполярной функции
                            diff = beta * y * (1 - y);
                            break;
                        case 2:
                            // дифференциал биполярной функции
                            diff = (float)(beta * (1 - Math.Pow(y, 2)));
                            break;
                        default:
                            break;
                    }
                    for (int j = 0; j < n; j++)
                    {
                        listW[j] = listW[j] - eta * (y - d) * listX[j] * diff;
                    }
                }
                else
                {
                    break;
                }
            }

            foreach (float w in listW)
            {
                Console.Write(" " + w);
            }
            Console.WriteLine("");
            Console.WriteLine("Количество итераций: " + I);
            Console.WriteLine("");
        }
        Console.ReadKey();
    }
}