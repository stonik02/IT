using System;

namespace SquareProgram
{
    class Point // Точка, определяющая середину квадрата
    {
        public int x, y;

        public Point(int x, int y) 
        {
            this.x = x;
            this.y = y;
        }

        public void Move(int dx, int dy)
        {
            x += dx;
            y += dy;
        }
    }

    class Segment   // Линия или сорона квадраа, соединящая две точки
    {
        public Point p1, p2;

        public Segment(Point p1, Point p2)
        {
            this.p1 = p1;
            this.p2 = p2;
        }

        public void Resize(int length)
        {
            double dx = p2.x - p1.x;
            double dy = p2.y - p1.y;
            double factor = length / Math.Sqrt(dx * dx + dy * dy);
            dx *= factor;
            dy *= factor;
            p2.x = (int)(p1.x + dx);
            p2.y = (int)(p1.y + dy);
        }
    }

    class Square  // Квадрат создается по точке в середине и размеру стороны (size)
    {
        private Segment[] sides;
        private int size;

        public Square(Point origin, int size)
        {
            sides = new Segment[4];
            Point p1 = new Point(origin.x, origin.y); // Ставим точки по origin и size
            Point p2 = new Point(origin.x + size, origin.y);
            Point p3 = new Point(origin.x + size, origin.y + size);  
            Point p4 = new Point(origin.x, origin.y + size);
            sides[0] = new Segment(p1, p2); // Строим линии по точкам
            sides[1] = new Segment(p2, p3);
            sides[2] = new Segment(p3, p4);
            sides[3] = new Segment(p4, p1);
            this.size = size;
        }

        public void Sizing(int newSize) // Изменение размера квадрата по новому size
        {
            Point origin = sides[0].p1; // Средняя точка
            Point p1 = new Point(origin.x, origin.y); // Ставим точки по origin и size
            Point p2 = new Point(origin.x + newSize, origin.y);
            Point p3 = new Point(origin.x + newSize, origin.y + newSize);
            Point p4 = new Point(origin.x, origin.y + newSize);
            sides[0] = new Segment(p1, p2); // Строим линии по точкам
            sides[1] = new Segment(p2, p3);
            sides[2] = new Segment(p3, p4);
            sides[3] = new Segment(p4, p1);
            size = newSize;
        }

        public void Rotating(double angle) // Поворот квадрата : поворачивает каждую точку квадрата на угол
        {
            Point origin = sides[0].p1;
            double centerX = origin.x + size / 2.0;
            double centerY = origin.y + size / 2.0;
            foreach (Segment side in sides)
            {
                double dx1 = side.p1.x - centerX;
                double dy1 = side.p1.y - centerY;
                double dx2 = side.p2.x - centerX;
                double dy2 = side.p2.y - centerY;
                side.p1.x = (int)(centerX + dx1 * Math.Cos(angle) - dy1 * Math.Sin(angle));
                side.p1.y = (int)(centerY + dx1 * Math.Sin(angle) + dy1 * Math.Cos(angle));
                side.p2.x = (int)(centerX + dx2 * Math.Cos(angle) - dy2 * Math.Sin(angle));
                side.p2.y = (int)(centerY + dx2 * Math.Sin(angle) + dy2 * Math.Cos(angle));
            }
        }

        public void ChangeColor(string color) // Просто изменение цвета
        {
            Console.WriteLine("Изменение цвета на " + color + "...");
        }

        public override string ToString()
        {
            string result = "Размер квадрата " + size + ":\n";
            foreach (Segment side in sides)
            {
                result += "  " + side.p1.x + "," + side.p1.y + " - " + side.p2.x + "," + side.p2.y + "\n";
            }
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Point origin = new Point(0, 0);
            Square square = new Square(origin, 50);
            Console.WriteLine(square);
            square.Sizing(100);
            Console.WriteLine(square);
            square.Rotating(90);
            Console.WriteLine(square);
            square.ChangeColor("red");
        }
    }
}