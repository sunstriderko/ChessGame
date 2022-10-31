namespace ChessLibrary.Interfaces
{
    public interface IMoves
    {
        bool PawnMove(IPiece modelPrevious, IPiece modelNext, int previousColumnModel, int previousRowMOdel, int nextColumnModel, int nextRowModel, bool validBool);

        bool RookMove(IPiece model, int previousColumnModel, int previousRowMOdel, int nextColumnModel, int nextRowModel, bool validBool);

        bool BishopMove(IPiece model, int previousColumnModel, int previousRowMOdel, int nextColumnModel, int nextRowModel, bool validBool);

        bool KnightMove(IPiece model, int previousColumnModel, int previousRowMOdel, int nextColumnModel, int nextRowModel, bool validBool);

        bool QueenMove(IPiece model, int previousColumnModel, int previousRowMOdel, int nextColumnModel, int nextRowModel, bool validBool);

        bool KingMove(IPiece model, int previousColumnModel, int previousRowMOdel, int nextColumnModel, int nextRowModel, bool validBool);
    }
}
