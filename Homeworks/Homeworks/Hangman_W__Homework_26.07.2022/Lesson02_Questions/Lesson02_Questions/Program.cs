using System;

namespace Lesson01_Questions // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Questions q = new Questions();
            //q.Fibonacci();
            //q.FibonacciUcgen();
            q.W();
        }
    }

    class Questions
    {
        public void Fibonacci()
        {

            Console.Write("Num = ");
            decimal length = Convert.ToInt32(Console.ReadLine());
            decimal a = 0, oncekiResult = 1, result = 0;
            Console.Write("{0} {1}", a, oncekiResult);
            for (decimal i = 2; i < length; i++)
            {
                try
                {
                    result = a + oncekiResult;
                    a = oncekiResult;
                    oncekiResult = result;
                }
                catch (Exception)
                {

                    throw;
                }
                Console.Write(" {0}", result);
            }
        }
        public void FibonacciUcgen()
        {
            int a = 0, b = 1, result = 0;
            Console.Write("Col and len = ");
            int col = int.Parse(Console.ReadLine());
            for (int i = 1; i <= col; i++)
            {
                a = 0;
                b = 1;
                Console.Write(b + " ");
                for (int j = 1; j < i; j++)
                {
                    result = a + b;
                    a = b;
                    b = result;
                    Console.Write(result + " ");
                }
                Console.WriteLine();
            }

        }

        public void W()
        {

            for (int i = 21; i > 0; i--) //21 kere dönücek bu for içini
            {
                for (int j = 1; j <= 20; j++) //1den başla ve 20 dahil 20 ye kadar ** yaz tek satırda ama.
                {
                    Console.Write("*");
                }
                for (int j = 1; j < i; j++) //i şuan 21 diye düşünelim, 1 den başla ve 20'ye kadar _ yaz ama tek satırda
                {
                    Console.Write("_");
                }
                for (int j = 1; j <= 20; j++) //1den başla ve 20 dahil 20 ye kadar * tek satırda.
                {
                    Console.Write("*");
                }
                for (int j = 1; j < i; j++)//aynı mantık
                {
                    Console.Write("_");
                }
                for (int j = 1; j <= 20; j++) //aynı mantık
                {
                    Console.Write("*");
                }
                Console.WriteLine();//bir set yani en üstteki for'un 1 tane i si bittiğinde yani döngü 1 kere tamamlandığonda enterla
                //böylece "_" giderek azalır. ve azaldıkça yanına gelen yıldızlarla eğik bir görüntü almaya başlar 2. ve 3. yerdeki yıldızlar. Böylece dolaylı yoldan W harfi
                //elde etmiş oluruz biraz yamuğumsu olsada.
            }
        }
    }
}//  1 2 3 5 8

/*
 0 1 0

result = 1
a = 1
b = 1

result = 2
a = 1
b = 2

result = 3
a = 2
b = 3

result = 5
a = 3
b = 5


 */