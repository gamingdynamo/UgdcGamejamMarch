using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    private bool Paused = false;
    public GameObject PausePanel;

    // Update is called once per frame
    void Update()
    {


        if(Input.GetKeyDown(KeyCode.Escape) && Paused == false)
        {
            PausePanel.gameObject.SetActive(true);
            Time.timeScale = 0f;
            Paused = true;
        }

        if(Input.GetKeyDown(KeyCode.Escape) && Paused == true)
        {
            PausePanel.gameObject.SetActive(false);
            Time.timeScale = 1f;
            Paused = false;
        }
    }
}
