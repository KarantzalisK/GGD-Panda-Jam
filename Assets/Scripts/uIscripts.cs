using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class uIscripts : MonoBehaviour
{
    public string sceneName;
    public GameObject pauseMenu, controllPanelBeforeStart,deadPanel,mainMenu;
    private int wallhealthInt,maxwallhealthINT;
    private GameObject wallHealthOBJ;

    // Start is called before the first frame update
    void Start()
    {
        wallHealthOBJ = GameObject.FindGameObjectWithTag("wall");
        wallhealthInt = wallHealthOBJ.GetComponent<WallScript>().wallHealth;
        maxwallhealthINT = wallHealthOBJ.GetComponent<WallScript>().maxWallHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1 )
        {
            pauseMenu.SetActive(true);

        }
        if (pauseMenu.activeSelf || mainMenu.activeSelf)
        {
            Time.timeScale = 0;

        }
        else if (pauseMenu.activeSelf== false || mainMenu.activeSelf) {
            Time.timeScale = 1;

        }
        if (wallhealthInt == maxwallhealthINT)
        {
            deadPanel.SetActive(true);   
        }
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
    

    
}
