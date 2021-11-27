using System;
using System.Collections.Generic;

namespace grafika
{
    public class App
    {
        private readonly int Size = 64;
        private readonly int Rows = 8;
        private readonly int Cols = 8;
        private int[] startTable = 
        {
            0, 1, 1, 0, 0, 1, 1, 0,
            1, 0, 0, 0, 0, 0, 0, 1,
            0, 1, 1, 1, 1, 0, 0, 1,
            1, 0, 0, 1, 1, 0, 0, 0,
            1, 0, 0, 0, 1, 0, 0, 1,
            0, 0, 0, 1, 1, 0, 0, 1,
            1, 0, 0, 1, 0, 0, 1, 0,
            1, 1, 0, 1, 1, 0, 0, 1,
        };


        public void mainLoop()
        {
            Console.WriteLine("Data: ");
            int[,] codedMatrix = codeMatrix(startTable);
            printFormattedMatrix(startTable);
            printOptions(codedMatrix);
        }

        public void printOptions(int[,] codedMatrix)
        {
            while(true)
            {
                Console.WriteLine("1 - Decode");
                Console.WriteLine("2 - End");
                String option = Console.ReadLine();

                switch(option)
                {
                    case "1":
                        getData(codedMatrix);
                        break;
                    case "2":
                        Console.WriteLine("END");
                        Environment.Exit(exitCode: 0);
                        break;
                }
            }
        }

        public void getData(int[,] codedMatrix)
        {
            List<String> matrixList = new List<string>();
            int[] inputMatrix = new int[Size];
            
            for (int i = 0; i < Rows; i++)
            {
                Console.WriteLine("Row Data: " + ( i + 1) + " separated with whitespace");
                string line = Console.ReadLine();
                string[] splittedLine = line.Split(" ");
                //matrixList.Add(splittedLine.ToString());
                matrixList.AddRange(splittedLine);
            }

            Console.WriteLine("Given numbers: ");

            int iterator = 0;

            for (int i = 0; i < Rows; i++)
            {
                for ( int j = 0; j < Cols; j++)
                {
                    Console.Write(matrixList[iterator] + " ");
                    inputMatrix[iterator] = Convert.ToInt32(matrixList[iterator++]);
                }
                Console.WriteLine();
            }

            decodeMatrix(codedMatrix, inputMatrix);

        }

    public void decodeMatrix(int[,] codedMatrix, int[] inputMatrix)
    {
        int[] decodedMatrix = new int[Size];

        for (int i = 0; i < Size; i++)
        {
            int suma = 0;
            for (int j = 0; j < Size; j++)
            {
                suma += inputMatrix[j] * codedMatrix[i,j];
            }
            if (suma == 0)
            {
                decodedMatrix[i] = inputMatrix[i];
            }
            else if (suma < 0)
            {
                decodedMatrix[i] = 0;
            }
            else
            {
                decodedMatrix[i] = 1;
            }
        }

        Console.WriteLine();
        Console.WriteLine("Score:");
        Console.WriteLine();

        int iterator = 1;

        for (int i = 0; i < Size; i++)
        {
            Console.Write(decodedMatrix[i] + " ");
            if (iterator % 8 == 0)
            {
                Console.WriteLine();
            }

            iterator++;
        }
    }

    public int[,] codeMatrix(int[] matrix)
    {
        int[,] codedMatrix = new int[Size, Size];
        
        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                if (i == j)
                {
                    codedMatrix[i, j] = 0;
                }
                else
                {
                    codedMatrix[i, j] = ((2 * matrix[i] - 1) * (2 * matrix[j] - 1));
                }
            }
        }
        return codedMatrix;
    }

    public void printFormattedMatrix(int[] matrix)
    {
        int iterator = 1;
        
        for (int i = 0; i < Size; i++)
        {
            Console.Write(matrix[i] + " ");
            if (iterator % 8 == 0)
            {
                Console.WriteLine();
            }
            iterator++;
        }
    }










        
    }
}
