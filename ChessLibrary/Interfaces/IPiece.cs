namespace ChessLibrary.Interfaces
{
    using ChessLibrary.Enums;

    public interface IPiece
    {
        public PieceType PieceType { get; set; }

        public PieceColor PieceColor { get; set; }

        public int PieceMoveCounter { get; set; }
    }
}
