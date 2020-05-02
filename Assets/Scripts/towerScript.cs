using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerScript : MonoBehaviour
{ public GameObject arrow;
    private Transform closesPosition;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(arrow);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
