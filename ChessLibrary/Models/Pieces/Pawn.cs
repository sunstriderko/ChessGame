namespace ChessLibrary.Models.Pieces
{
    using ChessLibrary.Enums;
    using ChessLibrary.Interfaces;

    public class Pawn : Piece
    {
        public Pawn(PieceType type, PieceColor color) : base(type, color)
        {
        }

        public override bool Move(IPiece previousModel, int previousColumn, int previousRow, int nextColumn, int nextRow, IPiece modelNext, bool validBool)
        {
            if (previousModel.PieceColor == PieceColor.White)
            {
                if ((modelNext.PieceColor == PieceColor.Black) && (previousColumn == nextColumn))
                {
                    validBool = false;
                }
                else if ((modelNext.PieceColor == PieceColor.Black) && (previousRow == nextRow + 1) && (previousColumn == nextColumn + 1 || previousColumn == nextColumn - 1))
                {
                    validBool = true;
                }
                else if ((previousColumn == nextColumn) && (previousRow == nextRow + 2) && previousRow == 6)
                {
                    validBool = true;
                }
                else if ((previousColumn == nextColumn) && (previousRow == nextRow + 1))
                {
                    validBool = true;
                }
                else if ((previousColumn == nextColumn + 1 || previousColumn == nextColumn - 1) && nextRow == 2)
                {
                    validBool = true;
                }
                else
                {
                    validBool = false;
                }
            }

            else if (previousModel.PieceColor == PieceColor.Black)
            {
                if ((modelNext.PieceColor == PieceColor.White) && (previousColumn == nextColumn))
                {
                    validBool = false;
                }
                else if ((modelNext.PieceColor == PieceColor.White) && (previousRow == nextRow - 1) && (previousColumn == nextColumn + 1 || previousColumn == nextColumn - 1))
                {
                    validBool = true;
                }
                else if ((previousColumn == nextColumn) && (previousRow == nextRow - 2) && previousRow == 1)
                {
                    validBool = true;
                }
                else if ((previousColumn == nextColumn) && (previousRow == nextRow - 1))
                {
                    validBool = true;
                }
                else if ((previousColumn == nextColumn + 1 || previousColumn == nextColumn - 1) && nextRow == 5)
                {
                    validBool = true;
                }
                else
                {
                    validBool = false;
                }
            }

            return validBool;
        }
    }
}
