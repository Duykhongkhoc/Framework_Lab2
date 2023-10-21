using System.Text;
class Generic
{
    public static double GetAvergare<T>(List<T> list)
    {
        double avg = 0;
        foreach (T item in list)
        {
            avg += double.Parse(item.ToString());
        }
        return avg / list.Count();
    }
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        List<int> listInt = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 }; ;
        List<float> listFloat = new List<float> { 1.2f, 3.6f, 4.7f };
        Console.Write(GetAvergare(listInt) + "\n");
        Console.WriteLine(GetAvergare(listFloat));
    }
}