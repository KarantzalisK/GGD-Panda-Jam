using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class uIscripts : MonoBehaviour
{
    public string sceneName;
    public GameObject pauseMenu, controllPanelBeforeStart,deadPanel,mainMenu;
    private int wallhealthInt,maxwallhealthINT;
    private GameObject wallHealthOBJ,waveIndexObj;
    public GameObject waveIndexTXTobj;


    // Start is called before the first frame update
    void Start()
    {
        wallHealthOBJ = GameObject.FindGameObjectWithTag("wall");
        maxwallhealthINT = wallHealthOBJ.GetComponent<WallScript>().maxWallHealth;
        waveIndexObj = GameObject.FindGameObjectWithTag("spawnpoint");
    }

    // Update is called once per frame
    void Update()
    {
        wallhealthInt = wallHealthOBJ.GetComponent<WallScript>().wallHealth;
        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1)
        {
            pauseMenu.SetActive(true);
            GetComponent<UiAnimationWithdotween>().UiScaleAnimation(pauseMenu);

        }
        if (pauseMenu.activeSelf || mainMenu.activeSelf)
        {
            Time.timeScale = 0;

        }
        else if (pauseMenu.activeSelf== false || mainMenu.activeSelf) {
            Time.timeScale = 1;

        }
        if (wallhealthInt >= maxwallhealthINT)
        {
            deadPanel.SetActive(true);   
        }
        if (deadPanel.activeSelf)
        {
            Time.timeScale = 0;

        }
        WaveIndicateVoid();
    }
    public void LoadingScenes(string sceneName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
       // Destroy(GameObject.Find("Game"));
       // Instantiate(gamePrefab);
        //pauseMenu = GameObject.Find("PauseMenu");

    }
    public void SceneQuiting()
    {
        Application.Quit();
    }
    public void WaveIndicateVoid()
    {
        waveIndexTXTobj.GetComponent<TMPro.TextMeshProUGUI>().text = "Wave " + (waveIndexObj.GetComponent<SpawnManager>().waveNumber+1).ToString();
    }
    

    
}
