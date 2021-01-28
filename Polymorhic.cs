using System;
using System.Collections.Generic;

namespace Polymorhic
{
	internal abstract class Shape
	{
		public int x, y;

		public Shape(int x, int y)
		{
			this.x = x;
			this.y = y;
			Console.WriteLine("Shape class constructor");
		}

		public override string ToString()
		{
			return $"({x};{y})";
		}

		public abstract double GetSquare();
	}

	internal class Rect : Shape
	{
		int width, height;

		public int Width { get; set; }
		public int Height { get; set; }

		public Rect(int x, int y, int w, int h) : base(x, y)
		{
			this.width = w;
			this.height = h;

			Console.WriteLine("Rect class constructor");
		}

		public override string ToString()
		{
			return "Rectangle: " + base.ToString() + $" width: {width}, heigth: {height}";
		}

		public override bool Equals(object obj)
		{
			var another = (Rect)obj;

			return base.Equals(obj) && 
				((this.width == another.width) && (this.height == another.height));
		}

		public override double GetSquare()
		{
			return (double)(width * height);
		}
	}

	internal class Circle : Shape
	{
		double radius;

		public Circle(int x, int y, double radius) : base(x, y)
		{
			this.radius = radius;
			Console.WriteLine("Circle class constructor");
		}

		public override bool Equals(object obj)
		{
			return base.Equals(obj) &&
				(this.radius == ((Circle)obj).radius);
		}

		public override double GetSquare()
		{
			return 2 * Math.PI * radius;
		}

		public override string ToString()
		{
			return "Circle: " + base.ToString() + $" radius: {radius}";
		}
	}

	sealed class App
	{
		static void Main(string[] args)
		{
			// random generator
			Random rand = new Random();

			// polymorphic object list
			List<Shape> shapes = new List<Shape>();

			for(int i = 0; i < 10; i++)
			{
				// randomly choose what class object to add
				// if 1, add Rects
				if(rand.Next(2) == 1)
				{
					shapes.Add(new Rect(rand.Next(100), rand.Next(100),
						rand.Next(100), rand.Next(100)));
				}
				// if 0, add Circle
				else
				{
					shapes.Add(new Circle(rand.Next(100),
						rand.Next(100), rand.Next(100)));
				}
			}

			// display objects
			foreach(var shape in shapes)
			{
				Console.WriteLine(shape + " square = " + shape.GetSquare());
			}

			Console.ReadKey();
		}
	}
}


/*
	Output:

	Rect class constructor
	Shape class constructor
	Circle class constructor
	Shape class constructor
	Circle class constructor
	Shape class constructor
	Circle class constructor
	Shape class constructor
	Rect class constructor
	Shape class constructor
	Circle class constructor
	Shape class constructor
	Circle class constructor
	Shape class constructor
	Rect class constructor
	Shape class constructor
	Rect class constructor
	Shape class constructor
	Rect class constructor

	Rectangle: (41;43) width: 60, heigth: 38 square = 2280
	Circle: (35;65) radius: 15 square = 94,24777960769379
	Circle: (1;70) radius: 34 square = 213,62830044410595
	Circle: (79;37) radius: 70 square = 439,822971502571
	Rectangle: (68;11) width: 13, heigth: 50 square = 650
	Circle: (93;11) radius: 23 square = 144,51326206513048
	Circle: (78;56) radius: 13 square = 81,68140899333463
	Rectangle: (27;73) width: 82, heigth: 71 square = 5822
	Rectangle: (10;29) width: 25, heigth: 7 square = 175
	Rectangle: (22;66) width: 4, heigth: 6 square = 24

*/