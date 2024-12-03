using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject crosshair;
    public LogManagerScript logManager;
    public PathLogManager pathLogManager;
    public bool needLog = false;
    private bool isLog = false;
    private bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //get input from keyboard esc
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                gameContinue();
            }
            else
            {
                gamePause();
            }
        }
    }

    public void gameOver(string text, bool win = true)
    {
        string result;
        if (!isLog && needLog)
        {
            Debug.Log("Start to upload log data");
            Debug.Log(text);
            if(win)
            {
                result = "Win";
            }
            else
            {
                result = "Lose";
            }
            logManager.ExternalUpload(BulletBase.counter, result);
            pathLogManager.ExternalUpload(PathTrigger.pathList);
            isLog = true;
        }
        //find child in gameoverUI by name
        crosshair.SetActive(false);
        Cursor.visible = true;
        gameOverUI.transform.Find("Information").GetComponent<TextMeshProUGUI>().text = text;
        gameOverUI.transform.Find("WinOrLose").GetComponent<TextMeshProUGUI>().text = win ? "You Win!" : "You Lose!";        
        gameOverUI.SetActive(true);
        gameOverUI.transform.Find("NextButton").gameObject.SetActive(win);
        gameOverUI.transform.Find("Continue").gameObject.SetActive(false);
        Time.timeScale = 0;
    }

    public void restart()
    {
        // Get the current scene name
        // Debug.Log(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //Debug.Log("Restart");
    }

    public void nextLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
        //Debug.Log("NextLevel");
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        //Debug.Log("MainMenu");
    }

    public void gamePause()
    {
        crosshair.SetActive(false);
        Cursor.visible = true;
        gameOverUI.SetActive(true);
        gameOverUI.transform.Find("WinOrLose").GetComponent<TextMeshProUGUI>().text = "Pause";
        gameOverUI.transform.Find("Information").GetComponent<TextMeshProUGUI>().text = "Take a rest?";
        gameOverUI.transform.Find("NextButton").gameObject.SetActive(false);
        Time.timeScale = 0;
    }

    public void gameContinue()
    {
        crosshair.SetActive(true);
        Cursor.visible = false;
        gameOverUI.SetActive(false);
        Time.timeScale = 1;
    }

    //public void quit()
    //{
    //    Debug.Log("Quit");
    //    Application.Quit();
    //}
}
