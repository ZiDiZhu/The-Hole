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
}
