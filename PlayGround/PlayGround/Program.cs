using PlayGround;
//var arr1 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
//var arr2 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
//var arr3 = UniqueElements(arr1, arr2);
//Console.WriteLine(String.Join(", ",arr3));


//var input = Console.ReadLine();
//Console.WriteLine(isP(input));

//Shape shape = new Shape();
//Ellipse ellipse = new Ellipse();
//Rectangle rectangle = new Rectangle();
//Circle circle = new Circle();
//Console.WriteLine(rectangle is Shape);
//Console.WriteLine(rectangle is Ellipse);
//var idk = ellipse as Shape;
//if (idk == null)
//{
//    Console.WriteLine("NULL");
//}
//else
//    Console.WriteLine("Not NULL");
//Console.WriteLine();


//int i = 0;
//do
//{
//    Console.WriteLine(i++);
//} while (i < 10);
//i = 0;
//Console.WriteLine("------------------------------");
//do
//{
//    Console.WriteLine(++i);
//} while (i<10);


//try
//{
//    Console.WriteLine("1");
//    Abc();
//    Console.WriteLine("2");
//}
//catch (Exception)
//{
//    Console.WriteLine("E");
//}
//finally
//{
//    Console.WriteLine("after all");
//}


void Abc()
{
    try
    {
        Console.WriteLine("A");
        throw new Exception();
        Console.WriteLine("B");
    }
    finally
    {
        Console.WriteLine("C");
    }
}
int[] UniqueElements(int[] arr1, int[] arr2)
{
    var unique = new List<int>();
    for (int i = 0; i < arr1.Length; i++)
    {
        if (!arr2.Contains(arr1[i]))
        {
            unique.Add(arr1[i]);
        }
    }
    return unique.ToArray();
}

bool isP(string input)
{
    bool isP = true;
    for (int i = 0; i < input.Length; i++)
    {
        var y = input.Length - 1 - i;

        if (y >= 0)
            if (input[y] != input[i])
            {
                isP = false;
            }
    }

    return isP;

}
