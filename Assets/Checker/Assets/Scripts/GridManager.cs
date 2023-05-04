using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField]
    private int _width, _height;

    [SerializeField]
    private Tile _tilePrefab;

    [SerializeField]
    private Transform _cam;

    [SerializeField]
    private Piece _whitePawm;

    [SerializeField]
    private Piece _whiteKing;

    [SerializeField]
    private Piece _whiteKnight;

    [SerializeField]
    private Piece _whiteQueen;

    [SerializeField]
    private Piece _whiteBishop;

    [SerializeField]
    private Piece _whiteRook;

    [SerializeField]
    private Piece _blackPawm;

    [SerializeField]
    private Piece _blackKing;

    [SerializeField]
    private Piece _blackKnight;

    [SerializeField]
    private Piece _blackQueen;

    [SerializeField]
    private Piece _blackBishop;

    [SerializeField]
    private Piece _blackRook;

    [SerializeField]
    private Dictionary<Vector2, Tile> _tiles;

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        _tiles = new Dictionary<Vector2, Tile>();

        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                var spawnedTile = Instantiate(_tilePrefab, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";

                var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                spawnedTile.Init(isOffset);

                _tiles[new Vector2(x, y)] = spawnedTile;

                if (y == 0 || y == 1 || y == 6 || y == 7)
                {
                    ChessPosition(new Vector2(x, y), spawnedTile);
                }
            }
        }
        _cam.transform.position = new Vector3((float)_width / 2 - 0.5f, (float)_height / 2 - 0.5f, -10);
    }

    public Tile GetTileAtPosition(Vector2 pos)
    {
        if (_tiles.TryGetValue(pos, out var tile))
        {
            return tile;
        }
        return null;
    }

    public void DesselectAllTiles()
    {
        foreach (var tile in _tiles.Values)
        {
            tile.DisableMovementToTile();
        }
    }

    public void ChessPosition(Vector2 tilePosition, Tile spawnedTile)
    {
        Piece newSpawnPiece;

        if (tilePosition.y == 0)
        {

            switch (tilePosition.x)
            {

                case 0: case 7:
                    newSpawnPiece = Instantiate(_whiteRook, tilePosition, Quaternion.identity);

                    spawnedTile.PositionPiece(newSpawnPiece);
                    break;
                case 1:
                case 6:
                    newSpawnPiece = Instantiate(_whiteKnight, tilePosition, Quaternion.identity);
                    spawnedTile.PositionPiece(newSpawnPiece);
                    break;
                case 2:
                case 5:
                    newSpawnPiece = Instantiate(_whiteBishop, tilePosition, Quaternion.identity);
                    spawnedTile.PositionPiece(newSpawnPiece);
                    break;
                case 3:
                    newSpawnPiece = Instantiate(_whiteQueen, tilePosition, Quaternion.identity);
                    spawnedTile.PositionPiece(newSpawnPiece);
                    break;
                case 4:
                    newSpawnPiece = Instantiate(_whiteKing, tilePosition, Quaternion.identity);
                    spawnedTile.PositionPiece(newSpawnPiece);
                    break;
            }
        }

        if (tilePosition.y == 7)
        {
            switch (tilePosition.x)
            {
                case 0:
                case 7:
                    newSpawnPiece = Instantiate(_blackRook, tilePosition, Quaternion.identity);
                    spawnedTile.PositionPiece(newSpawnPiece);
                    break;
                case 1:
                case 6:
                    newSpawnPiece = Instantiate(_blackKnight, tilePosition, Quaternion.identity);
                    spawnedTile.PositionPiece(newSpawnPiece);
                    break;
                case 2:
                case 5:
                    newSpawnPiece = Instantiate(_blackBishop, tilePosition, Quaternion.identity);
                    spawnedTile.PositionPiece(newSpawnPiece);
                    break;
                case 3:
                    newSpawnPiece = Instantiate(_blackQueen, tilePosition, Quaternion.identity);
                    spawnedTile.PositionPiece(newSpawnPiece);
                    break;
                case 4:
                    newSpawnPiece = Instantiate(_blackKing, tilePosition, Quaternion.identity);
                    spawnedTile.PositionPiece(newSpawnPiece);
                    break;
            }
        }

        if (tilePosition.y == 1)
        {
            newSpawnPiece = Instantiate(_whitePawm, tilePosition, Quaternion.identity);
            spawnedTile.PositionPiece(newSpawnPiece);
        }

        if (tilePosition.y == 6)
        {
            newSpawnPiece = Instantiate(_blackPawm, tilePosition, Quaternion.identity);
            spawnedTile.PositionPiece(newSpawnPiece);
        }
    }
}