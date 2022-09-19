using System;


namespace ShapesLiblary
{
    public class Shape
    {
        public static double [] Side { get; set; }
        public static double Radius{ get; set; }

        public static double FindAreaCircle(double Radius)
        {
            return Math.PI * Radius; 
        }

        public static double FindAreaSquare(double [] Side)
        {
            return Math.Sqrt(Side[0]);
        }

        public static double FindAreaRectangle(double [] Side)
        {
            return Side[0] * Side[1];
        }

        public static double Triangle(double A)
        {
            return ((A * Math.Sqrt(3) / 4));
        }

        private static double Triangle(double A, double B)
        {
            return 0.5 * A * B;
        }

        private static double Triangle(double A, double B, double C)
        {
            double P = (A + B + C) / 2;
            return Math.Sqrt(P * (P - A) * (P - B) * (P - C));
        }

        public static double FindAreaTriangle(double A, double B, double C)
        {
            if (TriangleRightAngle(A, B, C))
            {
                var triagle = SortTriangleSide(A, B, C);
                return Triangle(triagle[0], triagle[1]);
            }
            return Triangle(A, B, C); 
        }

        public static bool TriangleRightAngle(double A, double B, double C) //проверка треугольника на прямой угол
        {
            var triagle = SortTriangleSide(A, B, C);
            if ((Math.Pow(triagle[0], 2) + Math.Pow(triagle[1], 2)) == Math.Pow(triagle[2], 2))
            {
                return true;
            }
            return false;
        }

        private static double [] SortTriangleSide(double A, double B, double C)
        {
            double[] side = new double[3];
            side[0] = A; side[1] = B; side[2] = C;
            Array.Sort(side);
            return side;   
        }

        public static (string, object/*, int*/) FindFigura(double [] Side)
        {
            (string, object/*, int*/) result=("",0/*,0*/);
            switch (Side.Length)
            {
                case 1:
                    result=("Круг", FindAreaCircle(Side[0])/*, 1*/);
                    break;
                case 2:
                    result = ("Прямоугольник", FindAreaRectangle(Side)/*, 2*/);
                    break;
                case 3:
                    if(TriangleRightAngle(Side[0], Side[1], Side[2]))
                    {
                        result = ("Треугольник с прямым углом", Triangle(Side[0], Side[1])/*, 3*/);
                        break;
                    }
                    result = ("Треугольник", Triangle(Side[0], Side[1], Side[2])/*, 4*/);
                    break;
                case 4:
                    if (Side[0] == Side[1] && Side[2] == Side[3] && Side[0]==Side[3])
                    {
                        result = ("Квадрат", FindAreaSquare(Side)/*, 5*/);
                        break;
                    }
                    result = ("Фигура не найдена, проверьте правильность внесенных данных", 0/*,0*/);
                    break;
                default:
                    Console.WriteLine("Такой фигуры пока нет. Мы работаем над этим!");
                    result = ("Фигура не найдена, проверьте правильность внесенных данных", 0/*,0*/);
                    break;
            }
            return result;
        }

        public static void PrintResult(object Method)
        {
            Console.WriteLine($"Результат: {Method}");
        }
    }
}
