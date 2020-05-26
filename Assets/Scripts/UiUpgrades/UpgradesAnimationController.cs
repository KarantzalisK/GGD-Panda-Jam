using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UpgradesAnimationController : MonoBehaviour
{
    private uIUpgradesAnimations animationControlls;
    // Start is called before the first frame update
    void Start()
    {
        animationControlls = GetComponent<uIUpgradesAnimations>();
    }

    // Update is called once per frame
    void Update()
    {
        ActivatePanel();
    }

    private void ActivatePanel()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&!animationControlls.CanAnimate)
        {
            animationControlls.CanAnimate = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space)&& animationControlls.CanAnimate)
        { 
            animationControlls.CanAnimate = false; }
    }
}
