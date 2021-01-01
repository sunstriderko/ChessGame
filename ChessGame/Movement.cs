using System;
using ChessLibrary.Models;
using ChessLibrary.Interfaces;
using ChessGame;
using System.Windows;
using System.Windows.Controls;

namespace ChessGame
{
    public class Movement : IMoves
    {
        public bool BishopMove(Piece model, int previousColumn, int previousRow, int nextColumn, int nextRow, bool validBool)
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

        public bool KingMove(Piece model, int previousColumn, int previousRow, int nextColumn, int nextRow, bool validBool)
        {
            if ((previousColumn == nextColumn + 1 || previousColumn == nextColumn - 1) && (previousRow == nextRow + 1 || previousRow == nextRow - 1))
            {
                validBool = true;
            }

            else if ((previousColumn == nextColumn) && (previousRow == nextRow + 1 || previousRow == nextRow - 1))
            {
                validBool = true;
            }

            else if ((previousRow == nextRow) && (previousColumn == nextColumn + 1 || previousColumn == nextColumn - 1))
            {
                validBool = true;
            }

            else if (model.PieceMoveCounter == 0 && previousRow == nextRow && (previousColumn == nextColumn + 2 || previousColumn == nextColumn - 2))
            {
                validBool = true;
            }

            else
            {
                validBool = false;
            }
            return validBool;
        }

        public bool KnightMove(Piece model, int previousColumn, int previousRow, int nextColumn, int nextRow, bool validBool)
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

        public bool PawnMove(Piece modelPrevious, Piece modelNext, int previousColumn, int previousRow, int nextColumn, int nextRow, bool validBool) 
        {
            if (modelPrevious.PieceColor == PieceColors.White)
            {
                if ((modelNext.PieceColor == PieceColors.Black) && (previousColumn == nextColumn))
                {
                    validBool = false;
                }

                else if ((modelNext.PieceColor == PieceColors.Black) && (previousRow == nextRow + 1) && (previousColumn == nextColumn + 1 || previousColumn == nextColumn - 1))
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

            else if (modelPrevious.PieceColor == PieceColors.Black)
            {
                if ((modelNext.PieceColor == PieceColors.White) && (previousColumn == nextColumn))
                {
                    validBool = false;
                }

                else if ((modelNext.PieceColor == PieceColors.White) && (previousRow == nextRow - 1) && (previousColumn == nextColumn + 1 || previousColumn == nextColumn - 1))
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

        public bool QueenMove(Piece model, int previousColumn, int previousRow, int nextColumn, int nextRow, bool validBool)
        {
            if (previousColumn == nextColumn || previousRow == nextRow)
            {
                validBool = true;
            }

            else if (Math.Abs(previousColumn - nextColumn) == Math.Abs(previousRow - nextRow))
            {
                validBool = true;
            }

            else
            {
                validBool = false;
            }

            return validBool;
        }

        public bool RookMove(Piece model, int previousColumn, int previousRow, int nextColumn, int nextRow, bool validBool)
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

        public bool ValidMoveChecker(bool validation, Piece previousPiece, Piece nextPiece, int previousColumn, int previousRow, int nextColumn, int nextRow)
        {
            if (previousPiece.PieceColor != nextPiece.PieceColor  && previousPiece.PieceType != PieceTypes.Free)
            {
                if (previousPiece.PieceType == PieceTypes.Pawn)
                {
                    validation = PawnMove(previousPiece, nextPiece, previousColumn, previousRow, nextColumn, nextRow, validation);
                }

                else if (previousPiece.PieceType == PieceTypes.Rook)
                {
                    validation = RookMove(previousPiece, previousColumn, previousRow, nextColumn, nextRow, validation);
                }

                else if (previousPiece.PieceType == PieceTypes.Bishop)
                {
                    validation = BishopMove(previousPiece, previousColumn, previousRow, nextColumn, nextRow, validation);
                }

                else if (previousPiece.PieceType == PieceTypes.King)
                {
                    validation = KingMove(previousPiece, previousColumn, previousRow, nextColumn, nextRow, validation);
                }

                else if (previousPiece.PieceType == PieceTypes.Queen)
                {
                    validation = QueenMove(previousPiece, previousColumn, previousRow, nextColumn, nextRow, validation);
                }

                else if (previousPiece.PieceType == PieceTypes.Knight)
                {
                    validation = KnightMove(previousPiece, previousColumn, previousRow, nextColumn, nextRow, validation);
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
