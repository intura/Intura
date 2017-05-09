using System;
using Intura.Collections;

namespace Intura
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var stack = new Stack<int>(5);
            DisplayStack(stack);

            // Add some data
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

            DisplayStack(stack);

            stack.Push(6);

            DisplayStack(stack);

            Console.WriteLine(stack.Pop());

            DisplayStack(stack);

            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());

            DisplayStack(stack);

            Console.WriteLine(stack.Pop());

            if (!stack.IsEmpty)
                Console.WriteLine(stack.Pop());
            else
                Console.WriteLine("Stack is empty");

            DisplayStack(stack);

            Console.WriteLine("Press <Return> to quit");
            Console.ReadLine();
        }

        static void DisplayStack(Stack<int> stack)
        {
            Console.WriteLine($"Capacity : {stack.Capacity}");
            Console.WriteLine($"Size     : {stack.Size}");
            Console.WriteLine("---");
        }
    }
}