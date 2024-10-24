using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject crosshair;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gameOver(string text)
    {
        //find child in gameoverUI by name
        crosshair.SetActive(false);
        Cursor.visible = true;
        gameOverUI.transform.Find("Information").GetComponent<TextMeshProUGUI>().text = text;
        gameOverUI.SetActive(true);
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

    public void quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
