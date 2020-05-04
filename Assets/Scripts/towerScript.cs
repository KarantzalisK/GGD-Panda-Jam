using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerScript : MonoBehaviour
{ public GameObject arrow;
    private Transform closesPosition;
    public int towerDMG;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(arrow);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemy")
        {
            collision.gameObject.GetComponent<Enemy>().health= collision.gameObject.GetComponent<Enemy>().health+towerDMG;
        }
    }
   
}
