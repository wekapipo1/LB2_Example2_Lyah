using System;

public class Ar
{
    //поля
    int n; //кількість чисел в масиві
    int[] a; //одновимірний масив
    int ko; //кількість від'ємних чисел в масиві
    public Ar(int n, int x)
    {
        //конструктор 1
        //створюємо пустий масив n з елементів
        this.n = n;
        a = new int[n];
        //заповнюємо масив випадковипи числами
        Random o = new Random();
        for (int i = 0; i < n; i++)
            a[i] = o.Next(-x, x);
    }
    public Ar(string s)
    {
        //конструктор 2
        //заповнюємо масив числами з тектового файлу
        //по одному числу на кожен рядок
        StreamReader f = new StreamReader(s);
        string str = "";
        int k = 0;
        //рахуємо кількість чисел в файлі
        while (f.EndOfStream != true)
        {
            str = f.ReadLine(); k++;
        }
        //створюємо пустий масив n з елементів
        n = k; a= new int[n];
        f.Close();
        //читаємо файл спочатку і заповнюємо масив
        StreamReader f1 = new StreamReader(s);
        for (int i = 0;i < k; i++)
        {
            str = f1.ReadLine();
            a[i] = Convert.ToInt32(str);
        }
        f1.Close();
    }
    public int N
    {
        //властивість для читання поля n
        get { return n; }
    }
    public int Ko
    {
        //властивість для обчислення кількості від'ємних
        get
        {
            ko = 0;
            for (int i = 0; i < n; i++)
                if (a[i] < 0) ko++;
            return ko;
        }
    }
    public void Print()
    {
        //метод виведення масиву на екран
        Console.WriteLine();
        for (int i = 0; i < n;i++)
            Console.Write(" {0} ", a[i]);
        Console.WriteLine();
    }
    public int Max()
    {
        //метод знаходження індексу максимального числа
        int t = 0; int m = a[0];
        for (int i = 1; i < n; i++)
            if (a[i] > m)
            { m = a[i]; t = i; }
        return t;
    }
    public int Pr(int i1, int i2)
    {
        //обчислення добутку елементів масиву
        //з індексами від і1 до і2 включно
        int p = 1;
        for (int i = i1; i <= i2; i++)
            p = p * a[i];
        return p;
    }
}
class Program
{
    static void Main(string[] args)
    {
        //опис об'єкту
        Ar mas;
        //вибір конструктору
        Console.Write("Конструктор 1/2 -->  ");
        int r = Convert.ToInt32(Console.ReadLine());
        if (r == 1)
        {
            //конструктор 1
            //заповнення випадковими числами
            Console.Write("Кiлькiсть чисел -->  ");
            int k = Convert.ToInt32(Console.ReadLine());
            mas = new Ar(k, 10);
        }
        else
        {
            //конструктор 2
            //числа з текстового файлу
            mas = new Ar("C:\\Users\\Анастасія\\OneDrive\\Рабочий стол\\1.txt");
        }

        //виведення масиву
        mas.Print();

        //знаходимо кількість від'ємних
        int t = mas.Ko;
        Console.WriteLine("Кiлькiсть вiд'ємних = {0} ", t);

        //знаходимо індекс максимального
        int nmx = mas.Max();
        Console.WriteLine("Iндекс максимального {0} ", nmx);

        //якщо максимальний не останній
        if (nmx != mas.N - 1)
        {
            //знаходимо добуток чисел правіше максимального
            //використовуючи властивість mas.N для визначення кількості елемемнтів
            //mas.N - 1 індекс останнього елементу масиву
            int p = mas.Pr(nmx+1, mas.N -1);
            Console.WriteLine("Pr={0}", p);
        }
        else
            Console.WriteLine("Максимальний останнiй. Добуток не обчислюється");

        Console.ReadKey();
    }
}