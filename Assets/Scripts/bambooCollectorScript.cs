using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class bambooCollectorScript : MonoBehaviour
{
    public GameObject bambooTextobj;
    public int bambooscore=0,bambootoupgrade=0;
    public Transform objectATMaxEdge;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag =="bamboo")
        {
            bambooscore++;
            bambooTextobj.GetComponent<TMPro.TextMeshProUGUI>().text = bambooscore.ToString() +  "/" + bambootoupgrade.ToString();
            collision.gameObject.transform.position =new Vector2(Random.Range(-objectATMaxEdge.position.x, objectATMaxEdge.position.x),Random.Range(-objectATMaxEdge.position.y, objectATMaxEdge.position.y));
        }
        Debug.Log("KOLAI");
    }

}
