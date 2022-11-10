namespace ChessLibrary.Models.Pieces
{
    using ChessLibrary.Enums;
    using ChessLibrary.Interfaces;

    public class Rook : Piece
    {
        public Rook(PieceType type, PieceColor color) : base(type, color)
        {
        }

        public override bool Move(IPiece previousModel, int previousColumn, int previousRow, int nextColumn, int nextRow, IPiece nextModel, bool validBool)
        {
            if (previousColumn == nextColumn || previousRow == nextRow)
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
