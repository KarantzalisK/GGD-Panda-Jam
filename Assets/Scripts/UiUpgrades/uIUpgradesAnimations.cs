using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class uIUpgradesAnimations : MonoBehaviour
{   [HideInInspector]
    public bool CanAnimate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CanAnimate)
        {
            gameObject.GetComponent<Transform>().DOScaleY(1,1f);
        }
        else {
            gameObject.GetComponent<Transform>().DOScaleY(0, 0.5f);
        }
    }
}
