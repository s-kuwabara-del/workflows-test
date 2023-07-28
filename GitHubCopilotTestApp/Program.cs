using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

// 同期用オブジェクト
object lockObject = new object();

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Console.WriteLine("入力した数までの素数を表示します。");
Console.WriteLine("数値を入力してください。");
Console.Write("> ");

var input = Console.ReadLine();
if (string.IsNullOrEmpty(input))
{
    Console.WriteLine("数値を入力してください。");
    return;
}
var number = int.Parse(input);
Console.WriteLine("1から" + number + "までの素数を表示します。");

var primes = new HashSet<int>(number);
var sw = new Stopwatch();
var sb = new StringBuilder();

sw.Start();

Parallel.For(1, number, i =>
{
    if (IsPrime(i))
    {
        lock (lockObject)
        {
            primes.Add(i);
        }
    }
});

sw.Stop();
Console.WriteLine("処理時間: " + sw.ElapsedMilliseconds + "ms");
Console.WriteLine(string.Join(" ", new SortedSet<int>(primes)));

static bool IsPrime(int number)
{
    // number が素数かどうかを判定する
    if (number < 2)
    {
        return false;
    }
    for (int i = 2; i * i <= number; i++)
        {
            if (number % i == 0)
        {
            return false;
        }
    }
    return true;
}
