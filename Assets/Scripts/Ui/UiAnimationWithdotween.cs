using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class UiAnimationWithdotween : MonoBehaviour
{
    [HideInInspector]
    public bool restartUiAnimations=true;
    private bool jump;
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
        uiObj.GetComponents<RectTransform>();
        uiObj.transform.DOLocalJump(new Vector3(0, 0, 0),4f, 10, 2f);


    }
}
