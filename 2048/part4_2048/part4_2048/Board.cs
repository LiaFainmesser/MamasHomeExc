using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part4_2048
{
    public class Board
    {
        public int[,] Data { get; protected set; }
        public int[] DataIndexer { get; protected set; }
        public int BoardSize { get; protected set; }
        public Board(int boardSize)
        {
            Data = new int[boardSize, boardSize];
            DataIndexer = new int[boardSize * boardSize];
            BoardSize = boardSize;
        }
        public void InitialBoard()
        {
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    Data[i, j] = 0;
                    DataIndexer[j + (BoardSize * i)] = 0;
                }
            }
            FillRandomSquare();
            FillRandomSquare();

        }
        public void FillRandomSquare()
        {
            Random rnd = new Random();
            int boardIndexerLocation = rnd.Next(0, DataIndexer.Length);

            if (DataIndexer[boardIndexerLocation] != 0)
            {
                FillRandomSquare();
            }
            else
            {
                int randomBoardValue = rnd.Next(1, 3) * 2;
                Data[boardIndexerLocation / BoardSize, boardIndexerLocation % BoardSize] = randomBoardValue;
                DataIndexer[boardIndexerLocation] = randomBoardValue;
            }
        }

        public int Move(Direction direction)
        {

            switch(direction)
            {
                case Direction.Up:
                    return moveUp();
                case Direction.Down:
                    return moveDown();
                case Direction.Left:
                    return moveLeft();
                default:
                    return moveRight();
            }

        }
        private int moveDown()
        {
            for (int i = 0; i < BoardSize - 2; i++)
                pushDown();
            int points = 0;
            for (int i = DataIndexer.Length - 1; i > BoardSize - 1; i--)
            {
                if (DataIndexer[i - 4] == DataIndexer[i])
                {
                    DataIndexer[i] = DataIndexer[i] * 2;
                    points += DataIndexer[i];
                    DataIndexer[i - 4] = 0;
                }
            }
            for (int i = 0; i < BoardSize - 2; i++)
                pushDown();
            datatIndexerToData();
            return points;
        }
        private int moveUp()
        {
            for (int i = 0; i < BoardSize - 2; i++)
                pushUp();

            int points = 0;
            for (int i = 0; i < DataIndexer.Length - BoardSize; i++)
            {
                if (DataIndexer[i + 4] == DataIndexer[i])
                {
                    DataIndexer[i] = DataIndexer[i] * 2;
                    points += DataIndexer[i] * 2;
                    DataIndexer[i + 4] = 0;
                }
            }
            for (int i = 0; i < BoardSize - 2; i++)
                pushUp();
            datatIndexerToData();
            return points;
        }
        private int moveLeft()
        {
            for (int i = 0; i < BoardSize - 2; i++)
                pushLeft();
            int points = 0;
            for (int i = 0; i < DataIndexer.Length; i++)
            {
                if(i % BoardSize != BoardSize - 1)
                {
                    if (DataIndexer[i] == DataIndexer[i + 1])
                    {
                        points += DataIndexer[i] * 2;
                        DataIndexer[i] = DataIndexer[i] * 2;
                        DataIndexer[i + 1] = 0;
                    }
                }                
            }
            for (int i = 0; i < BoardSize - 2; i++)
                pushLeft();
            datatIndexerToData();
            return points;
        }
        private int moveRight()
        {
            for (int i = 0; i < BoardSize - 2; i++)
                pushRight();    
            int points = 0;
            for (int i = DataIndexer.Length -1; i > 0; i--)
            {
                if (i % BoardSize != 0)
                {
                    if (DataIndexer[i] == DataIndexer[i - 1])
                    {
                        points += DataIndexer[i] * 2;
                        DataIndexer[i] = DataIndexer[i] * 2;
                        DataIndexer[i - 1] = 0;
                    }
                }
            }
            for (int i = 0; i < BoardSize - 2; i++)
                pushRight();
            datatIndexerToData();
            return points;
        }

        
        private void pushDown()
        {
            for (int i = 0; i < DataIndexer.Length - BoardSize; i++)
            {
                if (DataIndexer[i + 4] == 0)
                {
                    DataIndexer[i + 4] = DataIndexer[i];
                    DataIndexer[i] = 0;
                }
            }
            datatIndexerToData();
        }
        private void pushUp()
        {
            for (int i = DataIndexer.Length - 1; i > BoardSize - 1; i--)
            {
                if (DataIndexer[i - 4] == 0)
                {
                    DataIndexer[i - 4] = DataIndexer[i];
                    DataIndexer[i] = 0;
                }
            }
            datatIndexerToData();
        }
        private void pushLeft()
        {
            for (int i = 0; i < DataIndexer.Length - 1; i++)
            {
                if (i % BoardSize != BoardSize - 1)
                {
                    if (DataIndexer[i] == 0)
                    {
                        DataIndexer[i] = DataIndexer[i + 1];
                        DataIndexer[i + 1] = 0;
                    }                   
                }
            }
            datatIndexerToData();
        }
        private void pushRight()
        {
            for (int i = DataIndexer.Length - 1; i > 0; i--)
            {
                if (i % BoardSize != 0)
                {
                    if (DataIndexer[i] == 0)
                    {
                        DataIndexer[i] = DataIndexer[i - 1];
                        DataIndexer[i - 1] = 0;
                    }
                }
            }
            datatIndexerToData();
        }

        private void datatIndexerToData()
        {
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    Data[i, j] = DataIndexer[j + (BoardSize * i)];                  
                }
            }
        }
        public override string ToString()
        {
            string output = "";
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    output += $"{Data[i, j]} ,";
                }
                output += $"\n";
            }
            return output;
        }
    }
}
