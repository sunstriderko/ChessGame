namespace ChessGame
{
    using ChessLibrary.Enums;
    using ChessLibrary.Interfaces;

    public static class Movement
    {
        public static bool ValidMoveChecker(bool validation, IPiece previousPiece, IPiece nextPiece, int previousColumn, int previousRow, int nextColumn, int nextRow)
        {
            if (previousPiece.PieceColor != nextPiece.PieceColor  && previousPiece.PieceType != PieceType.Free)
            {
                if (previousPiece.PieceType == PieceType.Pawn)
                {
                    validation = previousPiece.Move(previousPiece, previousColumn, previousRow, nextColumn, nextRow, nextPiece, validation);
                }
                else if (previousPiece.PieceType == PieceType.Rook)
                {
                    validation = previousPiece.Move(previousPiece, previousColumn, previousRow, nextColumn, nextRow, nextPiece, validation);
                }
                else if (previousPiece.PieceType == PieceType.Bishop)
                {
                    validation = previousPiece.Move(previousPiece, previousColumn, previousRow, nextColumn, nextRow, nextPiece, validation);
                }
                else if (previousPiece.PieceType == PieceType.King)
                {
                    validation = previousPiece.Move(previousPiece, previousColumn, previousRow, nextColumn, nextRow, nextPiece, validation);
                }
                else if (previousPiece.PieceType == PieceType.Queen)
                {
                    validation = previousPiece.Move(previousPiece, previousColumn, previousRow, nextColumn, nextRow, nextPiece, validation);
                }
                else if (previousPiece.PieceType == PieceType.Knight)
                {
                    validation = previousPiece.Move(previousPiece, previousColumn, previousRow, nextColumn, nextRow, nextPiece, validation);
                }
            }
            else
            {
                validation = false;
            }

            return validation;
        }
    }
}
