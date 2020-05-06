using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WallScript : MonoBehaviour
{
    public int wallHealth, maxWallHealth;
    private GameObject enemy;
    public Slider healthslider;
    public Image darkenSpriterSlider;
    // Start is called before the first frame update
    void Start()
    {
        healthslider.maxValue = maxWallHealth;
        wallHealth = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (wallHealth != 0)
        {
            darkenSpriterSlider.enabled = true;
        }
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            wallHealth = wallHealth + collision.gameObject.GetComponent<Enemy>().damage;
            healthslider.value = wallHealth;
            Debug.Log(healthslider.maxValue);
        }
       
    }
}
