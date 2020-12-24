using System;
using System.Windows;
using System.Drawing;


namespace ChessLibrary.Models
{
    public class Piece
    {
        public Piece(PieceTypes aType, PieceColors aColor)
        {
            PieceType = aType;
            PieceColor = aColor;
        }

        public PieceTypes PieceType { get; set; }

        public PieceColors PieceColor { get; set; }

    }

    public enum PieceTypes
    {
        Free,
        Pawn,
        Rook,
        Bishop,
        Knight,
        Queen,
        King,
    }

    public enum PieceColors
    {
        White,
        Black,
        None,
    }
}
