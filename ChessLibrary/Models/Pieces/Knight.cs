namespace ChessLibrary.Models.Pieces
{
    using ChessLibrary.Enums;
    using ChessLibrary.Interfaces;

    public class Knight : Piece
    {
        public Knight(PieceType type, PieceColor color) : base(type, color)
        {
        }

        public override bool Move(IPiece previousModel, int previousColumn, int previousRow, int nextColumn, int nextRow, IPiece nextModel, bool validBool)
        {
            if ((previousColumn == nextColumn + 1 || previousColumn == nextColumn - 1) && (previousRow == nextRow + 2 || previousRow == nextRow - 2))
            {
                validBool = true;
            }
            else if ((previousRow == nextRow + 1 || previousRow == nextRow - 1) && (previousColumn == nextColumn + 2 || previousColumn == nextColumn - 2))
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
