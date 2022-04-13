using System;
using System.Collections;
using Pathfinding;
using UnityEngine;

public abstract class NonPlayerCharacter : MonoBehaviour {
    [SerializeField] private NPCSpawner spawnLocation;
    protected AIPath PathfindingAI;
    

    private void Start() {
        PathfindingAI = GetComponent<AIPath>();

        StartCoroutine(MoveAround());
    }

    IEnumerator MoveAround() {
        while (true) {
            if (!PathfindingAI.pathPending && (PathfindingAI.reachedDestination || !PathfindingAI.hasPath)) {
                PathfindingAI.destination = spawnLocation.GenerateDestination();
                PathfindingAI.SearchPath();
            }
             
            yield return new WaitUntil(() => PathfindingAI.reachedDestination);
            
            yield return new WaitForSeconds(2f);
        }
    }
}