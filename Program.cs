// See https://aka.ms/new-console-template for more information
using System.ComponentModel.Design;
using System.Data;
using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
// вариант 6 (на рандом взял)
// Колосов Максим 3265

namespace Epic{
    class Program
    {
        public static void Main(string[] args)
        {
          
        int[,] inputMatrix = new int[8, 8] {
                    {9, 3, -1, 0, 1, 0, 0, -1},
                    {3, 9, 3, 3, 1, 3, 3, 3},
                    {0, 3, 9, 0, 1, 0, 0, 0},
                    {0, 3, 0, 9, 1, 0, 0, 0},
                    {1, 1, 1, 1, 1, 1, 1, 1},
                    {0, 3, 0, 0, 1, 9, 6, 0},
                    {6, 3, 0, 0, 1, 6, 9, 0},
                    {-1, 3, 0, 0, 1, 0, 6, 9},
                };

        Console.WriteLine("Task 1");

        Console.WriteLine("Input N - the one-dimentional array size");


        int[] inputArray =  CreateOneDimensionalArray(int.Parse(Console.ReadLine()));
        PrintArray(inputArray);
        MaxElementIndex(inputArray);
        WeirdProduct(inputArray);

        Console.WriteLine("Task 2");

        Greet(inputMatrix);
        
        

        Console.WriteLine("Press any key to finish.");
        Console.ReadLine();
        }
        static void Greet(int[,] inputMatrix)
        {
            Console.WriteLine("Enter 1 to fill matrix 1-64, 2 to fill yourself, 3 to see how I filled");
            ProcessInput(inputMatrix);
        }

        static void ProcessInput(int[,] inputMatrix)
        {
            bool validInput = Int16.TryParse(Console.ReadLine(), out Int16 parsedInput);
            // bool validInput = true;
            // int parsedInput = 3;
            if (validInput)
            {
                switch (parsedInput)
                {
                    case 1:
                        FillMatrixOneThrough64(inputMatrix);
                        PrintMatrix(inputMatrix);
                        PrintList(GetKList(inputMatrix));
                        PrintSumInNegativeRows(inputMatrix);
                        break;

                    case 2:
                        FillMatrixManually(inputMatrix);
                        PrintMatrix(inputMatrix);
                        PrintList(GetKList(inputMatrix));
                        PrintSumInNegativeRows(inputMatrix);
                        break;

                    case 3:
                        // FillMatrixMe();
                        PrintMatrix(inputMatrix);
                        PrintList(GetKList(inputMatrix));
                        PrintSumInNegativeRows(inputMatrix);
                        break;

                    default:
                        Console.WriteLine("That is not an option!");
                        break;
                }
                return;
            }
            Console.WriteLine("That is not an option!");
        }

        // void FillMatrixMe()
        // {
            
        // }

        static void FillMatrixManually(int[,] inputMatrix)
        {
            int counter = 1;
            for (int column = 0; column < inputMatrix.GetLength(0); column++)
            {
                for (int row = 0; row < inputMatrix.GetLength(1); row++)
                {
                    Console.WriteLine("Enter the " + counter + " number: ");
                    if(int.TryParse(Console.ReadLine(), out int userInput))
                        inputMatrix[column, row] = userInput;
                    counter++;
                }
            }
        }

        static void FillMatrixOneThrough64(int[,] inputMatrix)
        {
            int matrixValue = 1;
            for (int column = 0; column < inputMatrix.GetLength(0); column++)
            {
                for (int row = 0; row < inputMatrix.GetLength(1); row++)
                {
                    inputMatrix[column, row] = matrixValue;
                    matrixValue++;
                }
            }
        }

        static void PrintMatrix(int[,] inputMatrix)
        {
            for (int column = 0; column < inputMatrix.GetLength(0); column++)
            {
                for (int row = 0; row < inputMatrix.GetLength(1); row++)
                {
                    Console.Write(inputMatrix[column,row] + " ");
                }
                Console.WriteLine();
            }
        }

        static bool CompareRowAndColumn(int[,] inputMatrix, int index)
        {
            int topBoundry = inputMatrix.GetLength(1);
            for (int i = 0; i < topBoundry; i++)
            {
                if (inputMatrix[index, i] != inputMatrix[i, index])
                    return false;
            }
            return true;
        }
        static List<int> GetKList(int[,] inputMatrix)
        {
            int topBoundry = inputMatrix.GetLength(1);
            List<int> kValues = new List<int>();

            for (int kCandidate = 0; kCandidate < topBoundry; kCandidate++)
            {
                if(CompareRowAndColumn(inputMatrix, kCandidate)) 
                    {
                        kValues.Add(kCandidate);
                    }
            }

            return kValues;
        }
        
        static void PrintList(List<int> ints)
        {
            Console.WriteLine("List of K values: ");
            foreach(var element in ints)
            {
                Console.WriteLine(element);
            }
        }

        static void PrintSumInNegativeRows (int[,] inputMatrix)
        {
            int topBoundry = inputMatrix.GetLength(0);
            int sum = 0;
            for (int column = 0; column < topBoundry; column++)
            {
                for (int row = 0; row < topBoundry; row++)
                {
                    if (inputMatrix[column, row] < 0)
                    {
                        sum += SumRow(inputMatrix, row);
                        break;
                    }
                }
            }
            Console.WriteLine("Sum in negative rows is: " + sum);
        }

        static int SumRow(int[,] inputMatrix, int row)
        {
            int sum = 0;
            int topBoundry = inputMatrix.GetLength(0);
            for (int i = 0; i < topBoundry; i++)
            {
                sum += inputMatrix[i, row];
            }
            
            return sum;
        }

        // TASK 1

        static int[] CreateOneDimensionalArray(int arrayLength)
        {
            int[] inputArray = new int[arrayLength];
            for (int i = 0; i < arrayLength; i++)
            {
                Console.WriteLine("Enter the " + i + " element: ");
                inputArray[i] = int.Parse(Console.ReadLine());
            }
            return inputArray;
        }

        static void PrintArray(int[] inputArray)
        {
            for(int i = 0; i < inputArray.Length; i++)
                Console.Write(inputArray[i] + " ");
            Console.WriteLine();
        }

        static void MaxElementIndex(int[] inputArray)
        {
            int max = inputArray.Max();
            for (int i = 0; i < inputArray.Length; i++)
                if (inputArray[i] == max)
                {
                    Console.WriteLine("Index of max element is: " + i);
                    Console.WriteLine();
                    return;
                }
        }
        static void WeirdProduct(int[] inputArray)
        {
            int firstBoundry = -2;
            int secondBoundry = -2;
            float product = 1;

            for (int i = 0; i < inputArray.Length; i++)
            {
                if (inputArray[i] == 0)
                {
                    if (firstBoundry == -2)
                    {
                        firstBoundry = i;
                        continue;
                    }  
                    secondBoundry = i;    
                    break;
                }

            }
            if (firstBoundry == secondBoundry + 1 || firstBoundry == -2 || secondBoundry == -2)
                product = 0;
            if (firstBoundry != -2 && secondBoundry != -2)
            {
                for (int i = firstBoundry + 1; i < secondBoundry; i++)
                {
                    product *= inputArray[i];
                }
            }
            Console.WriteLine("The product between 0s is: " + product);

        }
    }
}
