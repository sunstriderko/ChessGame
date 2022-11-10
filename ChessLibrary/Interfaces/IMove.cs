namespace ChessLibrary.Interfaces
{
    public interface IMove
    {
        bool Move(IPiece previousModel, int previousColumn, int previousRow, int nextColumn, int nextRow, IPiece nextModel, bool validBool);
    }
}
