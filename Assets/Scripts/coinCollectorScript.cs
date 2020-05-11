using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class coinCollectorScript : MonoBehaviour
{
    public GameObject coinsGatheredTextobj;
    public int coinsToUpgrade=0,coinMultiplier;
    private int coinsGathered = 0;
    public Transform objectATMaxEdge;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinsGatheredTextobj.GetComponent<TMPro.TextMeshProUGUI>().text = coinsGathered.ToString() + "/" + coinsToUpgrade.ToString();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag =="collectible")
        {
            CollectibleRectanglePosition(collision.gameObject);
            if (coinsGathered < coinsToUpgrade && coinsGathered<coinsToUpgrade- coinMultiplier)
            {
                coinsGathered = coinsGathered + coinMultiplier;
                
            }
            else coinsGathered = coinsToUpgrade;
        }
        Debug.Log("KOLAI");
    }
    private void CollectibleRectanglePosition(GameObject collectible) //respawns object to different position based to an imaginary rectanble by gettin an object at the edge of it
    {
        collectible.transform.position = new Vector2(Random.Range(-objectATMaxEdge.position.x, objectATMaxEdge.position.x), Random.Range(-objectATMaxEdge.position.y, objectATMaxEdge.position.y));

    }


}
