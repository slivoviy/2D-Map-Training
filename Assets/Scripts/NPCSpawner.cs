using System;
using Pathfinding;
using UnityEngine;
using Random = UnityEngine.Random;

public class NPCSpawner : MonoBehaviour {
    [SerializeField] private int radius;

    public Vector3 GenerateDestination () {
        var startNode = AstarPath.active.GetNearest(transform.position).node;
        var nodes = PathUtilities.BFS(startNode, radius);
        var singleRandomPoint = PathUtilities.GetPointsOnNodes(nodes, 1)[0];
    
        return singleRandomPoint;
    }
}