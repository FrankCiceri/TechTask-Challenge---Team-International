

class TechChallenge {



    public static void Main(String[] args) {

        List<(double x, double y)> dots = GetDots();

        double ab = CalcDistance(dots[0], dots[1]);
        Console.WriteLine($"\nLength of AB is: '{ab}'");

        double bc = CalcDistance(dots[1], dots[2]);
        Console.WriteLine($"Length of BC is: '{bc}'");

        double ac = CalcDistance(dots[0], dots[2]);
        Console.WriteLine($"Length of AC is: '{ac}'\n");


        DisplayTriangleInfo(ab, bc, ac);
        PerimeterNumbers(ab, bc, ac);



    }


    public static List<(double, double)> GetDots() {
        var dots = new List<(double x, double y)>();
        double x, y;
        int i = 0;
        while (i < 3) {
            try {
                Console.WriteLine($"Enter Coordinate x of dot {(char)(65 + i)}" );
                x = double.Parse(Console.In.ReadLine());

                Console.WriteLine($"Enter Coordinate y of dot {(char)(65 + i)}");
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

        Boolean isEquilateral = ab == bc && ab == ac;
        Console.WriteLine($"Triangle IS{ (isEquilateral ? "" : " NOT") } 'Equilateral'");

        Boolean isIsoceles = (ab == bc && ab != ac) || (ab != bc && ab == ac) || (bc == ac && bc != ab);
        Console.WriteLine($"Triangle IS{ ( isIsoceles ? "" : " NOT") } 'Isosceles'");

        
        Boolean isRight = CheckRightTriangle(ab, bc, ac);
        Console.WriteLine($"Triangle IS{(isRight ? "" : " NOT")} 'Right'\n");

    }

    public static Boolean CheckRightTriangle(double ab, double bc, double ac) {

        return RightFormula(sideA: ab, sideB: ac, hypothenuse: bc) || RightFormula(sideA: ab, sideB: bc, hypothenuse: ac) || RightFormula(sideA: ac, sideB: bc, hypothenuse: ab);
                          
    }

    public static Boolean RightFormula(double sideA, double sideB, double hypothenuse) {

        Boolean checkRight = Math.Abs((Math.Pow(hypothenuse, 2) - (Math.Pow(sideA, 2) + Math.Pow(sideB, 2)))) <= 0.001;
        return checkRight;

    }
    



    public static void PerimeterNumbers(double ab, double bc, double ac) { 
    
        double perimeter = ab+bc+ac;
        Console.WriteLine($"Perimeter: '{perimeter}'");

        for (int i = 0; i <=perimeter; i++) {
            if (i % 2 == 0) Console.WriteLine(i);
        }


    
    }


}

