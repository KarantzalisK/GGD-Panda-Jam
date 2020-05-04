using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage;
    public float health,maxhealth;
    public float healthPercentage,healthspriteXWIDTH;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
     if (health >= maxhealth)
        {
            gameObject.SetActive(false);
        }
        EnemyHealthBarMANAGER();
    }

    
    private void EnemyHealthBarMANAGER()
    {
        healthPercentage = healthspriteXWIDTH - (health/maxhealth)*healthspriteXWIDTH;
        Debug.Log(healthPercentage + "healthpercentageEnemy");
        
    }

}
