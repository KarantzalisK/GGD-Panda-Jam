using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealthBarManager : MonoBehaviour
{
    public float healthbarScale;
    public Vector3 localScaleATruntime;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponentInParent<Enemy>().healthspriteXWIDTH = this.gameObject.transform.localScale.x;

    }

    // Update is called once per frame
    void Update()
    {
        HealthBarChangeScale();
        
    }
    void HealthBarChangeScale()
    {
        localScaleATruntime = transform.localScale;
        localScaleATruntime.x = gameObject.GetComponentInParent<Enemy>().healthPercentage;
        transform.localScale= localScaleATruntime;
    }
}
