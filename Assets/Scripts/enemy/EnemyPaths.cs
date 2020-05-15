using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class waypointList
{
    public List<GameObject> waypoints;
}

public class EnemyPaths : MonoBehaviour
{
    public List<waypointList> enemyPaths;
     
}