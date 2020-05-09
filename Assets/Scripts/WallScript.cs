using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WallScript : MonoBehaviour
{
    public int wallHealth, maxWallHealth;
    private GameObject enemy;
    public Slider healthslider;
    // Start is called before the first frame update
    void Start()
    {
        healthslider.maxValue = maxWallHealth;
        wallHealth = 0;
    }

    // Update is called once per frame
    void Update()
    {
    
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            wallHealth = wallHealth + collision.gameObject.GetComponent<EnemyResetAndParameters>().damage;
            healthslider.value = wallHealth;
            Debug.Log(healthslider.maxValue);
        }
       
    }
}
