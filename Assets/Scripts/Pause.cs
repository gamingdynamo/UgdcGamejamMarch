using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    private bool Paused;
    public GameObject PausePanel;
    public GameObject controlspanel;


    private void Start()
    {
        Paused = false;
    }

    // Update is called once per frame
    void Update()
    {


    }


    public void PauseGame()
    {
       

        if (Paused == false)
        {
            PausePanel.SetActive(true);
            Time.timeScale = 0f;
            Paused = true;
        }

       else if (Paused == true)
        {
            PausePanel.gameObject.SetActive(false);
            Time.timeScale = 1f;
            Paused = false;
        }
    }

   public void Resume()
    {
        PausePanel.gameObject.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ControlsPanel()
    {
        controlspanel.gameObject.SetActive(true);
    }

    public void ExitControlsPanel()
    {
        controlspanel.SetActive(false);
    }
}
