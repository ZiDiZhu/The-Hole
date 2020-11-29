using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public GameObject agreementPanel;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        agreementPanel.SetActive(true);
    }

   
    void Update()
    {
        
    }

    public void HideAgreementPanel()
    {
        agreementPanel.SetActive(false);
    }

    public void StartGameScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void restart()
    {
        SceneManager.LoadScene("Intro");
    }

    public void end1_starved()
    {
        SceneManager.LoadScene("End1_starvation");
    }

    public void end2_killed()
    {
        SceneManager.LoadScene("End2_killed");
    }

    public void end3_suicide()
    {
        SceneManager.LoadScene("End3_suicide");
    }


    public void end4_survive()
    {
        SceneManager.LoadScene("End4_survived");
    }
}
