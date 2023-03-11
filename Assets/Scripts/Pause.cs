using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Pause : MonoBehaviour
{

    private bool Paused;
    public GameObject PausePanel;
    public GameObject controlspanel;
    public Slider slider;
    public AudioSource bgmusic;
    public TextMeshProUGUI volumetext;
    private void Start()
    {
        Paused = false;
        bgmusic.volume = .5f;
        
    }

    // Update is called once per frame
    void Update()
    {
        bgmusic.volume = slider.value;
        volumetext.text = bgmusic.volume.ToString();
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

    public GameObject ObjectivePanelp;

    public void ObjectivePanel()
    {
        Time.timeScale = 0f;
        ObjectivePanelp.gameObject.SetActive(true);
       
    }

    public void ExitObjectPanel()
    {
        Time.timeScale = 1f;
        ObjectivePanelp.gameObject.SetActive(false);
        
    }
}
