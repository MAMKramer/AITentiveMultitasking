using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Pawn : ChessFigure
{
    public override bool[,] PossibleMove(bool assingBeatingMovements = false)
    {
        bool[,] possibleMoves = new bool[8, 8];

        if (IsWhite)
        {
            // Diagonal Left
            AssignPawnMove(CurrentX - 1, CurrentY + 1, ref possibleMoves, assingBeatingMovements);

            // Diagonal Right
            AssignPawnMove(CurrentX + 1, CurrentY + 1, ref possibleMoves, assingBeatingMovements);

            // Forward
            AssignPawnMove(CurrentX, CurrentY + 1, ref possibleMoves, assingBeatingMovements);

            // Two Steps Forward
            if (CurrentY == 1)
            {
                AssignPawnMove(CurrentX, CurrentY + 1, ref possibleMoves, assingBeatingMovements);
                AssignPawnMove(CurrentX, CurrentY + 2, ref possibleMoves, assingBeatingMovements);
            }
        }
        else
        {
            // Diagonal Left
            AssignPawnMove(CurrentX - 1, CurrentY - 1, ref possibleMoves, assingBeatingMovements);

            // Diagonal Right
            AssignPawnMove(CurrentX + 1, CurrentY - 1, ref possibleMoves, assingBeatingMovements);

            // Forward
            AssignPawnMove(CurrentX, CurrentY - 1, ref possibleMoves, assingBeatingMovements);

            // Two Steps Forward
            if (CurrentY == 6)
            {
                AssignPawnMove(CurrentX, CurrentY - 1, ref possibleMoves, assingBeatingMovements);
                AssignPawnMove(CurrentX, CurrentY - 2, ref possibleMoves, assingBeatingMovements);
            }
        }

        return possibleMoves;
    }


    private void AssignPawnMove(int x, int y, ref bool[,] possibleMoves, bool assingBeatingMovements)
    {
        ChessFigure FigureOnTargetPosition = null;
        if (x >= 0 && x < 8 && y >= 0 && y < 8)
        {
            FigureOnTargetPosition = BoardManager.ChessFigurePositions[x, y];
        }

        bool isForwardMove = CurrentX == x;

        if (isForwardMove && assingBeatingMovements) return;

        if (assingBeatingMovements || (FigureOnTargetPosition != null && FigureOnTargetPosition.IsWhite != IsWhite && !isForwardMove) || (isForwardMove && FigureOnTargetPosition == null))
        {
            AssignMove(x, y, ref possibleMoves, assingBeatingMovements);
        }
    }
}
