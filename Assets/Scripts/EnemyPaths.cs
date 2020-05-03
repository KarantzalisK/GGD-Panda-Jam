using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class waypointList
{
    public List<GameObject> waypoints;
}

[CreateAssetMenu(fileName = "New Enemy Paths", menuName = "Enemy Paths")]
public class EnemyPaths : ScriptableObject
{
    public List<waypointList> enemyPaths;

}
