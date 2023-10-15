using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    public Vector3 GetPosition() { return transform.position; }
    private const float playerDistanceSpawnLevelPart = 200;
    
    [SerializeField] private Transform levelPartStart;
    [SerializeField] private List<Transform> levelPartList;
    [SerializeField] private PlayerMovement player; //tror han ah�nvisar till script p� player, hans heter Player


    private Vector3 lastEndPosition;
    
    private void Awake()
    {
        lastEndPosition = levelPartStart.Find("EndPosition").position;
        SpawnLevelPart();

        int startingSpawnLevelParts = 5;
        for (int i = 0; i < startingSpawnLevelParts; i++)
        {
            SpawnLevelPart();
        }
      //det spawnas mer och mer bana n�r spelaren n�rmar sig endpoint p� varje block
    }
    private void Update()
    {
        //testa h�r och se om plattform dyker upp n�r spelaren kommer n�ra 
        if (Vector3.Distance(player.GetPosition(), lastEndPosition)< playerDistanceSpawnLevelPart) //vet inte riktigt var den h�mtar GetPosition
        {
            SpawnLevelPart();
        }
    }

    private void SpawnLevelPart()
    {
        Transform chosenLevelPart = levelPartList[Random.Range(0, levelPartList.Count)];
        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }


    private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }
}
