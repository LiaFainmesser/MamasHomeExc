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
        public int[,] Data {  get;}
        public int[] DataIndexer { get;}
        public int BoardSize { get; }

        public enum Direction 
        {
            Up = 'w',
            Down = 's',
            Left = 'a',
            Right = 'd'
        }
        public enum GameStatus
        {
            Win, //0
            Lose, //1      
            Idle //2
        }
        public Board(int boardSize) 
        {
            Data = new int[boardSize, boardSize];
            DataIndexer = new int[boardSize * boardSize];
            BoardSize = boardSize;  
        }  
        public void InitialBoard()
        {
            for(int i = 0; i < BoardSize; i++) 
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
                int randomBoardValue = rnd.Next(1, 2) * 2;
                Data[boardIndexerLocation / 4, boardIndexerLocation % 4] = randomBoardValue;
                DataIndexer[boardIndexerLocation] = randomBoardValue;
            }
        }

        public int Move(Direction direction)
        {

            return Data[1, 1];
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
