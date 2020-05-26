using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UiButtonSystems : MonoBehaviour
{
    private GameObject playerObj;
    private coinCollectorScript coinColectScript;
    private WallScript wall;
    private PlayerParameters playerPM;
    private towerParameters turret;
    private UIupgradePARAMETERS uiUpgParam;
    private bool heal, addMaxHealth, playerSpeed, turretShootinSpeed, turretRespawnMin;
    private GameObject[] upgButtons;
    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        playerPM = playerObj.GetComponent<PlayerParameters>();
        turret = GameObject.FindGameObjectWithTag("turret").GetComponent<towerParameters>();
        coinColectScript =playerObj.GetComponent<coinCollectorScript>();
        wall = GameObject.FindGameObjectWithTag("wall").GetComponent<WallScript>();
        uiUpgParam = GetComponent<UIupgradePARAMETERS>();
        upgButtons=uiUpgParam.upgButtons;
    }

    // Update is called once per frame
    void Update()
    {
        if (coinColectScript.coinsGathered == coinColectScript.coinsToUpgrade)
        {
            disableEnableInteractivityAtButtons(true);

        }
        else disableEnableInteractivityAtButtons(false);

    }
    private void OnClickResetCoins()
    {
        coinColectScript.coinsToUpgrade *= uiUpgParam.multiplier;
        coinColectScript.coinsGathered = 0;
    }
    public void Upgrades()//it change the parameters according to the upgrade and sets the selectors string to selected object
    {
            //it uses an eventsystem component event trigger on mouse down
            UpgradeSelector(EventSystem.current.currentSelectedGameObject.name);
            if (heal)
            {
                wall.wallHealth -= uiUpgParam.healWall;
            }
            if (addMaxHealth)
            {
                wall.maxWallHealth += coinColectScript.coinsGathered;
            }
            if (playerSpeed)
            {
                playerPM.speed += uiUpgParam.playerSpeedADD;
            }
            if (turretShootinSpeed)
            {
                turret.reloadDelay -= uiUpgParam.turretReloadingMIN;
            }
            if (turretRespawnMin)
            {
                turret.turretRespawnDelay -= uiUpgParam.turretRespawnDelayMin;
            }
            OnClickResetCoins();

       
    }
     //select upgrade by searching if the objects name maches the given if string
    public void UpgradeSelector(string nameOfUpgrade)
    {
        if (nameOfUpgrade.ToLower().Contains("heal"))
        {
            heal = true;
        }
        else heal = false;
        if (nameOfUpgrade.ToLower().Contains("addmaxhp"))
        {
            addMaxHealth = true;
        }
        else addMaxHealth = false; 
        if (nameOfUpgrade.ToLower().Contains("playerspeed"))
        {
            playerSpeed = true;
        }
        else playerSpeed = false;
        if (nameOfUpgrade.ToLower().Contains("turretshootinspeed"))
        {
            turretShootinSpeed = true;
        }
        else turretShootinSpeed = false; 
        if (nameOfUpgrade.ToLower().Contains("turretrespawnmin"))
        {
            turretRespawnMin = true;
        }
        else turretRespawnMin = false;
    }
    //makes upg button clickable when certain parameters are met
    public void disableEnableInteractivityAtButtons(bool interactable)
    {
        Debug.LogWarning(interactable);
        if (interactable)
        {
            foreach (GameObject upgBTN in upgButtons)
            {
                upgBTN.GetComponent<UnityEngine.UI.Button>().interactable = true;
            }
        }
        else foreach (GameObject upgBTN in upgButtons)
            {
            upgBTN.GetComponent<UnityEngine.UI.Button>().interactable = false;
            }
    }
}
