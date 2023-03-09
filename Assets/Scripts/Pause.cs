using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    private bool Paused;
    public GameObject PausePanel;


    private void Start()
    {
        Paused = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) && Paused == false)
        {
            if (Paused == false)
            {
                PausePanel.SetActive(true);
                Time.timeScale = 0f;
                Paused = true;
            }

             if (Paused == true)
            {
                PausePanel.gameObject.SetActive(false);
                Time.timeScale = 1f;
                Paused = false;
            }
        }


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
}
