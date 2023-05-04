using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField]
    private Piece _currentPiece;


    [SerializeField]
    private Color _baseColor, _offsetColor;

    [SerializeField]
    protected SpriteRenderer _renderer;

    [SerializeField]
    private GameObject _highlight;

    [SerializeField]
    private GameObject _canMove;

    private Vector3 _tilePosition;

    private void Awake()
    {
        _tilePosition = transform.position;
    }

    public bool CanMoveTo { get => _canMove.activeSelf ? true : false; }

    public void Init(bool isOffset)
    {
        _renderer.color = isOffset ? _offsetColor : _baseColor;
    }

    public void PositionPiece(Piece piece)
    {
        if(_currentPiece != null)
        {
            if (_currentPiece.King)
            {
                GameManager.Instance.EndGame(_currentPiece.BlackPiece);
            }

            Destroy(_currentPiece.gameObject);
        }

        _currentPiece = piece;
    }

    public void RemovePiece()
    {
        _currentPiece = null;
    }

    void OnMouseEnter()
    {
        _highlight.SetActive(true);
    }

    void OnMouseExit()
    {
        _highlight.SetActive(false);
    }

    void EnableMovementToTile()
    {
        _canMove.SetActive(true);
    }

    public void DisableMovementToTile()
    {
        _canMove.SetActive(false);
    }

    void OnMouseDown()
    {
        if (GameManager.Instance.GameOver) return;

        if(GameManager.Instance.currentGameFase == GameManager.GameFases.selectingPiece && _currentPiece != null)
        {
            if (GameManager.Instance.WhitesTurn == _currentPiece.BlackPiece || !GameManager.Instance.WhitesTurn == _currentPiece.WhitePiece) return;

            GameManager.Instance.PieceSelected(_currentPiece, this);
            HighlightPosibleMoves();
            return;
        }

        if(CanMoveTo)
        {
            GameManager.Instance.MoveTo(gameObject.GetComponent<Tile>());
        }
        else
        {
            if(_currentPiece != null)
            {
                GameManager.Instance.PieceSelected(_currentPiece, this);
                HighlightPosibleMoves();
            }
        }
    }

    void HighlightPosibleMoves()
    {
        if (_currentPiece == null) return;

        switch (_currentPiece.MovementType)
        {
            case typeOfMovement.pawnstraight:

                if(_currentPiece.BlackPiece)
                {
                    PawnRaycast(Vector2.down, _currentPiece.PieceMoveAhead, transform.position);
                    PawnRaycast(new Vector2(1, -1), _currentPiece.PieceMoveAhead, transform.position);
                    PawnRaycast(new Vector2(-1, -1), _currentPiece.PieceMoveAhead, transform.position);
                }
                else
                {
                    PawnRaycast(Vector2.up, _currentPiece.PieceMoveAhead, transform.position);
                    PawnRaycast(new Vector2(1, 1), _currentPiece.PieceMoveAhead, transform.position);
                    PawnRaycast(new Vector2(-1, 1), _currentPiece.PieceMoveAhead, transform.position);
                }

                break;
            case typeOfMovement.diagonally:
                FireRaycastInDirection(new Vector2(-1, 1), _currentPiece.PieceMoveAhead, transform.position);
                FireRaycastInDirection(new Vector2(-1, -1), _currentPiece.PieceMoveAhead, transform.position);
                FireRaycastInDirection(new Vector2(1, 1), _currentPiece.PieceMoveAhead, transform.position);
                FireRaycastInDirection(new Vector2(1, -1), _currentPiece.PieceMoveAhead, transform.position);
                break;
            case typeOfMovement.horizontally:
                FireRaycastInDirection(new Vector2(-1, 0), _currentPiece.PieceMoveAhead, transform.position);
                FireRaycastInDirection(new Vector2(1, 0), _currentPiece.PieceMoveAhead, transform.position);
                FireRaycastInDirection(new Vector2(0, 1), _currentPiece.PieceMoveAhead, transform.position);
                FireRaycastInDirection(new Vector2(0, -1), _currentPiece.PieceMoveAhead, transform.position);
                break;
            case typeOfMovement.allDirections:
                FireRaycastInDirection(new Vector2(-1, 1), _currentPiece.PieceMoveAhead, transform.position);
                FireRaycastInDirection(new Vector2(-1, -1), _currentPiece.PieceMoveAhead, transform.position);
                FireRaycastInDirection(new Vector2(1, 1), _currentPiece.PieceMoveAhead, transform.position);
                FireRaycastInDirection(new Vector2(1, -1), _currentPiece.PieceMoveAhead, transform.position);
                FireRaycastInDirection(new Vector2(-1, 0), _currentPiece.PieceMoveAhead, transform.position);
                FireRaycastInDirection(new Vector2(1, 0), _currentPiece.PieceMoveAhead, transform.position);
                FireRaycastInDirection(new Vector2(0, 1), _currentPiece.PieceMoveAhead, transform.position);
                FireRaycastInDirection(new Vector2(0, -1), _currentPiece.PieceMoveAhead, transform.position);
                break;
            case typeOfMovement.knight:
                FireRaycastInDirection(new Vector2(0,0), _currentPiece.PieceMoveAhead, transform.position + new Vector3(1, 2));
                FireRaycastInDirection(new Vector2(0,0), _currentPiece.PieceMoveAhead, transform.position + new Vector3(2, 1));
                FireRaycastInDirection(new Vector2(0, 0), _currentPiece.PieceMoveAhead, transform.position + new Vector3(1, -2));
                FireRaycastInDirection(new Vector2(0, 0), _currentPiece.PieceMoveAhead, transform.position + new Vector3(2, -1));
                FireRaycastInDirection(new Vector2(0, 0), _currentPiece.PieceMoveAhead, transform.position + new Vector3(-1, 2));
                FireRaycastInDirection(new Vector2(0, 0), _currentPiece.PieceMoveAhead, transform.position + new Vector3(-2, 1));
                FireRaycastInDirection(new Vector2(0, 0), _currentPiece.PieceMoveAhead, transform.position + new Vector3(-1, -2));
                FireRaycastInDirection(new Vector2(0, 0), _currentPiece.PieceMoveAhead, transform.position + new Vector3(-2, -1));
                break;
        }
    }

    private void FireRaycastInDirection(Vector2 direaction, float distace, Vector3 position)
    {
        RaycastHit2D[] hits;

        // Gets all tiles touched by the raycast
        hits = Physics2D.RaycastAll(position, direaction, distace);

        // Go through all tiles the raycast touched
        foreach (var hit in hits)
        {
            // If the raycast touch the current tile go for the next one
            if (hit.collider.gameObject == gameObject) continue;

            // If to block any other object other than tiles
            if (hit.collider.gameObject.TryGetComponent(out Tile tile))
            {
                // Checking if tile has piece
                if (tile._currentPiece != null)
                {
                    // pieces with SAME colors
                    if (_currentPiece.WhitePiece == tile._currentPiece.WhitePiece)
                    {
                        break;
                    }
                    else // pieces with DIFFERENT colors
                    {
                        tile.EnableMovementToTile();
                        break;
                    }
                }

                tile.EnableMovementToTile();
            }
        }
    }
    private void PawnRaycast(Vector2 direaction, float distace, Vector3 position)
    {
        RaycastHit2D[] hits;

        // Gets all tiles touched by the raycast
        hits = Physics2D.RaycastAll(position, direaction, distace);

        // Go through all tiles the raycast touched
        foreach (var hit in hits)
        {
            // If the raycast touch the current tile go for the next one
            if (hit.collider.gameObject == gameObject) continue;

            if(direaction == Vector2.up || direaction == Vector2.down)
            {
                // If to block any other object other than tiles
                if (hit.collider.gameObject.TryGetComponent(out Tile tile))
                {
                    // Checking if tile has piece
                    if (tile._currentPiece != null) break;

                    tile.EnableMovementToTile();
                }
            }
            else
            {
                if (hit.collider.gameObject.TryGetComponent(out Tile tile))
                {
                    // Checking if tile has piece
                    if (tile._currentPiece != null && _currentPiece.WhitePiece != tile._currentPiece.WhitePiece)
                    {
                        tile.EnableMovementToTile();
                        break;
                    }
                }
            }


        }
    }
}
