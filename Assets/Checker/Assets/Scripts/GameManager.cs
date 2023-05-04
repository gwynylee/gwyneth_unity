using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private GridManager _gridManager;
    [SerializeField] private TextMeshProUGUI _colorTurnText;

    public enum GameFases
    {
        selectingPiece,
        pieceSelected
    }

    private Piece _selectedPiece;
    private Tile _selectedTile;
    private bool _whitesTurn = true;
    private bool _gameOver = false;

    public GameFases currentGameFase = GameFases.selectingPiece;
    public bool GameOver { get => _gameOver; }
    public bool WhitesTurn { get => _whitesTurn; }

    void Start()
    {
        Instance = this;
        UpdateText();
    }

    public void PieceSelected(Piece SelectedPiece, Tile SelectedTile)
    {
        _gridManager.DesselectAllTiles();
        currentGameFase = GameFases.pieceSelected;
        _selectedPiece = SelectedPiece;
        _selectedTile = SelectedTile;
    }

    public void MoveTo(Tile tileSelected)
    {
        _whitesTurn = !_whitesTurn;
        UpdateText();
        _gridManager.DesselectAllTiles();
        currentGameFase = GameFases.selectingPiece;
        _selectedTile.RemovePiece();
        _selectedPiece.transform.position = tileSelected.transform.position;
        tileSelected.PositionPiece(_selectedPiece);
    }

    private void UpdateText()
    {
        _colorTurnText.text = _whitesTurn ? "White's Turn" : "Black's Turn";
        _colorTurnText.color = _whitesTurn ? Color.white : Color.black;
    }

    public void EndGame(bool whitesWon)
    {
        _colorTurnText.text = whitesWon ? "White's Won" : "Black's Won";
        _colorTurnText.color = whitesWon ? Color.white : Color.black;
        _gameOver = true;
    }
}
