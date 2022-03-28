using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    private bool reload = false;
    private bool playerDead = false;
    private bool isPaused = false;
    public GameObject reloadText;
    public GameObject pausePanel;
    

    public Text healthText;
    public Text ammoText;
    
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(reload)
        {
            Debug.Log("Active Text");
            reloadText.SetActive(true);
        }
        else
        {
            reloadText.SetActive(false);
        }


        PausePanel();

       
    }
    public void PausePanel()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            Debug.Log("paused");
            pausePanel.SetActive(true);
            isPaused = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            Debug.Log("unPaused");
            pausePanel.SetActive(false);
            isPaused = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    public void SetPlayerDead(bool playerDead)
    {
        this.playerDead = playerDead;
    }
    public bool GetPlayerDead()
    {
        return playerDead;
    }
    public void SetReload(bool reload)
    {
        this.reload = reload;
    }
    public bool GetReload()
    {
        return reload;
    }

}
