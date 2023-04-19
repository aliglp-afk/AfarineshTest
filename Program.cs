using System;
using System.Data;
using System.Text;

namespace AfarineshTest
{
    internal class Program
    {

        public static string InfixToPostfix(string infix)
        {
            string postfix = "";
            Stack<char> stack = new Stack<char>();
            Dictionary<char, int> precedence = new Dictionary<char, int>()
    {
        { '+', 1 },
        { '-', 1 },
        { '*', 2 },
        { '/', 2 }
    };

            foreach (char c in infix)
            {
                if (char.IsDigit(c))
                {
                    postfix += c;
                }
                else if (c == '(')
                {
                    stack.Push(c);
                }
                else if (c == ')')
                {
                    while (stack.Peek() != '(')
                    {
                        postfix += stack.Pop();
                    }
                    stack.Pop();
                }
                else
                {
                    while (stack.Count > 0 && stack.Peek() != '(' && precedence[stack.Peek()] >= precedence[c])
                    {
                        postfix += stack.Pop();
                    }
                    stack.Push(c);
                }
            }

            while (stack.Count > 0)
            {
                postfix += stack.Pop();
            }

            return postfix;
        }

        public static int EvaluatePostfix(string postfix)
        {
            Stack<int> stack = new Stack<int>();

            foreach (char c in postfix)
            {
                if (char.IsDigit(c))
                {
                    stack.Push(c - '0');
                }
                else
                {
                    int operand2 = stack.Pop();
                    int operand1 = stack.Pop();
                    int result = 0;

                    switch (c)
                    {
                        case '+':
                            result = operand1 + operand2;
                            break;
                        case '-':
                            result = operand1 - operand2;
                            break;
                        case '*':
                            result = operand1 * operand2;
                            break;
                        case '/':
                            result = operand1 / operand2;
                            break;
                    }

                    stack.Push(result);
                }
            }

            return stack.Pop();
        }


        public static string TestThree(int[] numbers, int target){
            string result="";
            foreach(var x in TestThreeAnswer(numbers,target)){
                result+=x+"\n";
            }
            return result;
        }
        
        public static Dictionary<int, int> TestThreeAnswer(int[] numbers, int target)
        {

            Dictionary<int, int> result = new Dictionary<int, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i; j < numbers.Length; j++)
                {
                    if (i != j)
                    {
                        if (numbers[i] + numbers[j] == target)
                        {
                            result.Add(i, j);
                        }
                    }
                }
            }

            return result;

        }
        public static string TestTwo(string[] words)
        {
            if (words.Length == 1)
                return "";

            string result = "";
            bool flag = true;
            for (int i = 0; i < words[0].Length; i++)
            {
                try
                {
                    for (int j = 0; j + 1 <= words.Length != null; j++)
                    {
                        try
                        {
                            flag = flag & words[j][i] == words[j + 1][i];
                        }
                        catch (IndexOutOfRangeException ex)
                        {
                            break;
                        }
                    }
                    if (flag)
                    {
                        result += words[0][i];
                    }
                }
                catch (IndexOutOfRangeException ex)
                {
                    break;
                }
            }
            return result;
        }

        public static int TestOne(string expression)
        {
            string postfix = InfixToPostfix(expression);
            return EvaluatePostfix(postfix);
        }
        static void Main(string[] args)
        {
            // Answer of Test number 1

            // string expression = "(6/2*(1+2))";
            // Console.WriteLine($"{TestOne(expression)}");

            // Answer of test number 2

            // string[] words = {"school"};
            // string[] words = {"school","shadow","sheep"};
            // string[] words = {"world","wall","whale"};
            // string[] words = { "bird", "bird", "bird" };
            // Console.WriteLine($"{TestTwo(words)}");

            // Answer of Test number 3

            // int[]numbers=new int[]{12,2,3,9,5};
            // int target=14;
            // int target=11;
            // int target=5;
            // Console.WriteLine($"{TestThree(numbers,target)}");
            
            
            
        }
    }
}