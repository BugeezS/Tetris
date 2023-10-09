using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class GameState
    {
        private Block currentBlock;

        public Block Block
        {
            get => currentBlock;
            private set
            {
                currentBlock = value;
                currentBlock.Reset();
            }
        }
        public GameGrid GameGrid { get; }
        public BlockQueue BlockQueue { get; }
        public bool GameOver { get; private set; }

        public GameState()
        {
            GameGrid = new GameGrid(22,10);
            BlockQueue = new BlockQueue();
            currentBlock = BlockQueue.GetAnUpdate();
        }

        private bool BlockFits()
        {
            foreach ( Position p in currentBlock.TilePositions())
            {
                if (!GameGrid.IsEmpty(p.Row, p.Column))
                {
                    return false;
                }
                return true;
            }
            
        }
    }
}
