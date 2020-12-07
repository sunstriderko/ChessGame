using System;
using System.Collections.Generic;
using System.Text;
using ChessLibrary.Models;

namespace ChessLibrary.Interfaces
{
    public interface IMoves
    {
        bool PawnMove(Piece model, int previousColumnModel, int previousRowMOdel, int nextColumnModel, int nextRowModel, bool validBool);

        bool RookMove(Piece model, int previousColumnModel, int previousRowMOdel, int nextColumnModel, int nextRowModel, bool validBool);

        bool BishopMove(Piece model, int previousColumnModel, int previousRowMOdel, int nextColumnModel, int nextRowModel, bool validBool);

        bool KnightMove(Piece model, int previousColumnModel, int previousRowMOdel, int nextColumnModel, int nextRowModel, bool validBool);

        bool QueenMove(Piece model, int previousColumnModel, int previousRowMOdel, int nextColumnModel, int nextRowModel, bool validBool);

        bool KingMove(Piece model, int previousColumnModel, int previousRowMOdel, int nextColumnModel, int nextRowModel, bool validBool);

    }
}
