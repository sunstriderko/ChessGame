using System;
using System.Collections.Generic;
using System.Text;

namespace ChessLibrary.Interfaces
{
    public interface IMoves
    {
        public string Name { get; set; }

        void PawnMove();

        void TowerMove();

        void ArcherMove();

        void KnightMove();

        void QueenMove();

        void KingMove();

    }
}
