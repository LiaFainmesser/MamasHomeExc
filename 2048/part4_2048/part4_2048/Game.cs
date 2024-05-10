using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static part4_2048.Board;

namespace part4_2048
{
    public class Game
    {
        public Board board { get; }      
        public Board.GameStatus gameStatus { get; }
        public int Points { get;}  
        public Game() 
        {
            board = new Board(4);
            gameStatus = Board.GameStatus.Idle;
            Points = 0; 
        }  
         
        public void GameRun()
        {
            board.InitialBoard();
            while (gameStatus == Board.GameStatus.Idle) 
            {
                ConsoleGame.ShowBoard(board.Data);
                Move(ConsoleGame.GetDirectionInput());
                ConsoleGame.ShowPoints(Points);
                Board.GameStatus gameStatus = CheckGameStatus();
            }
            ConsoleGame.GameOverOutput(gameStatus,Points);
        }
        public void Move(Board.Direction direction)
        {

        }

        public Board.GameStatus CheckGameStatus()
        {
            bool idle = false;
            for (int i = 0; i < board.DataIndexer.Length; i++)
            {
                if (board.DataIndexer[i] == 2048)
                    return Board.GameStatus.Win;
                else if (board.DataIndexer[i] == 0)
                    idle = true;    
            }
            if (idle)
                return Board.GameStatus.Idle;
            return Board.GameStatus.Lose;

        }
    }
}
