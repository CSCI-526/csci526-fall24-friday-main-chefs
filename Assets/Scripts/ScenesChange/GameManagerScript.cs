using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameManagerScript : MonoBehaviour
{
    public EnemiesManager enemiesManager;
    public GameObject gameOverUI;
    public GameObject crosshair;
    public GameObject player;
    public GameObject[] enemies;
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
        //player.GetComponent<MovementController>().enabled = false;
        //player.GetComponent<ShootController>().enabled = false;
        //player.GetComponent<HealthController>().enabled = false;
        //foreach (GameObject enemy in enemies)
        //{
        //    Destroy(enemy);
        //}
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //Debug.Log("Restart");
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        //Debug.Log("MainMenu");
    }

    public void quit()
    {
        Debug.Log("Quit");
        //Application.Quit();
    }
}
