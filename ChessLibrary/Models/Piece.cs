namespace ChessLibrary.Models
{
    using ChessLibrary.Enums;
    using ChessLibrary.Interfaces;

    public class Piece : IPiece
    {
        public Piece(PieceType aType, PieceColor aColor)
        {
            PieceType = aType;
            PieceColor = aColor;
        }

        public PieceType PieceType { get; set; }

        public PieceColor PieceColor { get; set; }

        public int PieceMoveCounter { get; set; } = 0;

    }
}
