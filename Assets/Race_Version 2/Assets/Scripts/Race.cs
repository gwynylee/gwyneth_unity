using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;

public class Race : MonoBehaviour
{
    public List<CourseTile> tilePrefabs;
    public RacePlayer playerPrefab;

    
    public Transform courseParent;

    public float heightScale = 0.3f;
    public float percentageScale = 0.05f;

    public int courseLength = 10;
    public int playerCount = 2;

    public float turnDuration = 0.5f;

    private List<CourseTile> tiles = new List<CourseTile>();
    private List<RacePlayer> players = new List<RacePlayer>();

    private void Start()
    {
        GenerateCourse();

        GeneratePlayers();

        StartCoroutine(Loop());
    }

    private void GenerateCourse()
    {
        int height = 0;

        // Generate a new tile until you reach the course length,
        // and place them at an appropriate position.
        for (int i = 0; i < courseLength; i++)
        {
            int heightDelta = Random.Range(-1, 2);
            height += heightDelta;

           float chanceToMoveModifier = percentageScale * heightDelta * -1;

            CourseTile chosenPrefab = tilePrefabs[Random.Range(0, tilePrefabs.Count)];

            CourseTile spawnedTile = Instantiate(chosenPrefab, courseParent);
            spawnedTile.ChanceToMove += chanceToMoveModifier;

            spawnedTile.transform.localPosition = new Vector3(0, height * heightScale, i);

            tiles.Add(spawnedTile);
        }
    }

    private void GeneratePlayers()
    {
        for (int i = 0; i < playerCount; i++)
        {
            RacePlayer spawnedPlayer = Instantiate(playerPrefab);
            players.Add(spawnedPlayer);
        }
    }

    private IEnumerator Loop()
    {
        while (true)
        {
            // Perform logic to attempt to move players forward,
            // and check if the race is complete.
            for (int i = 0; i < playerCount; i++)
            {
                RacePlayer player = players[i];

                if (Random.value > tiles[player.CurrentTile].ChanceToMove)
                {
                    player.CurrentTile++;
                }

                player.transform.position = tiles[player.CurrentTile].transform.position;

                // Check if the game is over.
                if (player.CurrentTile == tiles.Count - 1)
                {

                   
          
                    Debug.Log($"Player {i} won!");

                    yield break;
                }
            }

            yield return new WaitForSeconds(turnDuration);
        }
    }
}
