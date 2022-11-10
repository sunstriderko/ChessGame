namespace ChessLibrary.Models.Pieces
{
    using System;
    using ChessLibrary.Enums;
    using ChessLibrary.Interfaces;

    public class Bishop : Piece
    {
        public Bishop(PieceType type, PieceColor color) : base(type, color)
        {
        }

        public override bool Move(IPiece previousModel, int previousColumn, int previousRow, int nextColumn, int nextRow, IPiece nextModel, bool validBool)
        {
            if (Math.Abs(previousColumn - nextColumn) == Math.Abs(previousRow - nextRow))
            {
                validBool = true;
            }
            else
            {
                validBool = false;
            }

            return validBool;
        }
    }
}
