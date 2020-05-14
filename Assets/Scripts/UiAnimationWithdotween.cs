using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class UiAnimationWithdotween : MonoBehaviour
{
    [HideInInspector]
    public bool restartUiAnimations=true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UiScaleAnimation(GameObject uiObj)
    {
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    uiObj.GetComponent<RectTransform>().DOBlendableScaleBy(new Vector3(1, 1, 0), 0.5f);
        //}
        //else if (Input.GetKeyUp(KeyCode.Escape))
        //{ uiObj.GetComponent<RectTransform>().DOPlayBackwards(); }


    }
}
