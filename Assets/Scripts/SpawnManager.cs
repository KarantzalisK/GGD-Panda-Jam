using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class waypointList 
{
    public List<GameObject> waypoints;
}

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    public List<waypointList> enemyPaths;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
