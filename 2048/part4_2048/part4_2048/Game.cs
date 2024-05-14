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
        private GameStatus _gameStatus;
        private int _points;
        private int _highScore;
        public Game() 
        {
            board = new Board(4);
            _gameStatus = GameStatus.Idle;
            _points = 0;
            _highScore = 0;
        }  
        public void GameRun()
        {
            board.InitialBoard();
            while (_gameStatus == GameStatus.Idle) 
            {
                ConsoleGame.ShowBoard(board.Data);
                Move(ConsoleGame.GetDirectionInput());           
            }

            if (_gameStatus == GameStatus.Idle && _points > _highScore)
            {
                _highScore = _points;
            }

            if(ConsoleGame.GameOverOutput(_gameStatus, _points, _highScore))
            {
                _gameStatus = GameStatus.Idle;
                GameRun();
            }
        }
        public void Move(Direction direction)
        {
            _points += board.Move(direction);
            ConsoleGame.ShowPoints(_points);
            _gameStatus = CheckGameStatus();

            if(_gameStatus == GameStatus.Idle)    
                board.FillRandomSquare();
        }

        public GameStatus CheckGameStatus()
        {
            bool idle = false;
            for (int i = 0; i < board.DataIndexer.Length; i++)
            {
                if (board.DataIndexer[i] == 2048)
                    return GameStatus.Win;

                else if (board.DataIndexer[i] == 0)
                    idle = true;    
            }

            if (idle)
                return GameStatus.Idle;
            
            return GameStatus.Lose;

        }
    }
}
