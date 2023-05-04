using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum typeOfMovement
{
    pawnstraight, diagonally, horizontally, allDirections, knight
}

public enum piecesEating
{
    pawn, others
}

public class Piece : MonoBehaviour
{
    [SerializeField] private bool _whitePiece;
    [SerializeField] private bool _blackPiece;
    [SerializeField] private bool _king;
    [SerializeField] private float _pieceMoveAhead;
    [SerializeField] private typeOfMovement _piecesMovement;
    [SerializeField] private piecesEating _piecesEating;

    public bool WhitePiece { get => _whitePiece; }
    public bool BlackPiece { get => _blackPiece; }
    public bool King { get => _king; }
    public float PieceMoveAhead { get => _pieceMoveAhead; }
    public typeOfMovement MovementType { get => _piecesMovement; }
}
