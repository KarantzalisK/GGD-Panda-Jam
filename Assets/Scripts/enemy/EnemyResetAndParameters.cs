﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyResetAndParameters : MonoBehaviour
{
    public int damage;
    public float health,maxhealth;
    public float initialHealth;
    public float speed;
    private Vector2 startinPosition;
    // Start is called before the first frame update
    void Start()
    {
       
        startinPosition = transform.position;
        initialHealth = health;
        
    }

    // Update is called once per frame
    void Update()
    {
     if (health >= maxhealth)
        {
            Destroy(this.gameObject);            

        }
    }

    
  
  

   


}
