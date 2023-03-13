

class TechChallenge {



    public static void Main(String[] args) {

        List<(double x, double y)> dots = GetDots();

        double ab = CalcDistance(dots[0], dots[1]);
        Console.WriteLine("\nLength of AB is: " + "'" +ab+"'");

        double bc = CalcDistance(dots[1], dots[2]);
        Console.WriteLine("Length of BC is: " + "'" + bc + "'");

        double ac = CalcDistance(dots[0], dots[2]);
        Console.WriteLine("Length of AC is: " + "'" + ac + "'\n");

        
        DisplayTriangleInfo(ab, bc, ac);
        PerimeterNumbers(ab, bc, ac);



    }


    public static List<(double x, double)> GetDots() {
        var dots = new List<(double x, double y)>();
        double x, y;
        int i = 0;
        while (i < 3) {
            try {
                Console.WriteLine("Enter Coordinate x of dot " + (char)(65 + i));
                x = double.Parse(Console.In.ReadLine());

                Console.WriteLine("Enter Coordinate y of dot " + (char)(65 + i));
                y = double.Parse(Console.In.ReadLine());
            }
            catch (FormatException){
                Console.WriteLine("----Please enter numeric values----");
                continue;
            }
           



            i++;
            dots.Add((x, y));
        }
        
       
        return dots;
    }

    public static double CalcDistance((double, double) dotA, (double, double) dotB)
    {
        double powXdiff = Math.Pow(dotA.Item1 - dotB.Item1,2);
        double powYdiff = Math.Pow(dotA.Item2 - dotB.Item2, 2);

        double distance = Math.Round(Math.Sqrt(powXdiff+powYdiff),4);

        return distance;
    }

    public static void DisplayTriangleInfo(double ab, double bc, double ac) {

        Boolean checkEquilateral = ab == bc && ab == ac;
        Console.WriteLine("Triangle IS" + ( checkEquilateral ? "":" NOT" ) + " 'Equilateral'");

        Boolean checkIsoceles = (ab == bc && ab != ac) || (ab != bc && ab == ac) || (bc == ac && bc != ac);
        Console.WriteLine("Triangle IS" + ( checkIsoceles ? "" : " NOT") + " 'Isoceles'");

        Boolean checkRight = (Math.Pow(bc,2) - (Math.Pow(ab, 2) + Math.Pow(ac, 2))) <= 0.001;
        Console.WriteLine("Triangle IS" + (checkRight ? "" : " NOT") + " 'Right'\n");

    }


    public static void PerimeterNumbers(double ab, double bc, double ac) { 
    
        double perimeter = ab+bc+ac;
        Console.WriteLine("Perimeter: " + "'"+ perimeter +"'");

        for (int i = 0; i <=perimeter; i++) {
            if (i % 2 == 0) Console.WriteLine(i);
        }


    
    }






}

