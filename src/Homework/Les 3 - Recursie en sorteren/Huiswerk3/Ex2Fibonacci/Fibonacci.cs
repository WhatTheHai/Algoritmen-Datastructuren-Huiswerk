namespace AD
{
    public class Opgave2
    {
        static long calls = 0;

        private static long FibonacciRecursiveInternal(int n) {
            calls++;
            if (n < 2) {
                return n;
            }
            return FibonacciRecursiveInternal(n - 1) + FibonacciRecursive(n - 2);
        }

        public static long FibonacciRecursive(int n)
        {
            calls = 0;
            return FibonacciRecursiveInternal(n);
        }

        private static long FibonacciIterativeInternal(int n) {
            int temp, firstNumber = 0, secondNumber = 1;
            //i = 1 want stap 1 en niet 0
            for (int i = 1; i < n; i++) {
                calls++;
                temp = firstNumber;
                firstNumber = secondNumber;
                secondNumber = temp + firstNumber;
            }
            return secondNumber;
        }

        public static long FibonacciIterative(int n)
        {
            calls = 0;
            return FibonacciIterativeInternal(n);
        }

        public static void Run()
        {
            int MAX = 35;

            System.Console.WriteLine("Recursief:");
            for (int n = 1; n <= MAX; n++)
            {
                System.Console.WriteLine("          Fibonacci({0,2}) = {1,8} ({2,9} calls)", n, FibonacciRecursive(n), calls);
            }
            System.Console.WriteLine("Iteratief:");
            for (int n = 1; n <= MAX; n++)
            {
                System.Console.WriteLine("          Fibonacci({0,2}) = {1,8} ({2,9} loops)", n, FibonacciIterative(n), calls);
            }
        }
    }
}
