namespace ConsoleApp2;
//expr.1
int a = 5, b = 10;
int temp = a;
a = b;
b = temp;
a = a + b;
b = a - b;
a = a - b;
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
