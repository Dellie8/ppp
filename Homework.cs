using System.Linq.Expressions;

namespace ConsoleApp2;
//expr.1
class Program
{
    int a = 6, b = 7;
    int temvar = a;
    a = b;
    b = temvar;
    //second method (но так делать не стоит, так как возникнет риск переполнения памяти (если превысит значение типа int)) 
    a = a + b;
    b = a - b;
    a = a - b;
}

//expr.2
class Program
{
    static void Main()
    {
    int n = 666;
    int reversed = (n % 10) * 100 + (n / 10 % 10) * 10 + (n / 100);
    Console.WriteLine(reversed);
}

//expr.3
class Program
{
    static void Main()
    {
    int H = 18;
    int angR = 30 * (H % 12);
    int ang = Math.Min(angR, 360 - angR);
    Console.WriteLine(ang);
    }
}
