using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HalamanManager : MonoBehaviour
{
    [SerializeField] bool isEscapeToExit;
    GameObject panelInfo;
    bool isShowed;

    // Use this for initialization
    void Start()
    {
        isShowed = false;
        panelInfo = GameObject.Find("PanelInfo");
        panelInfo.SetActive(isShowed);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isEscapeToExit)
            {
                Application.Quit();
            }
            else
            {
                BackToMenu();
            }
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void ShowInfo()
    {
        isShowed = !isShowed;
        panelInfo.SetActive(isShowed);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
