using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        Debug.Log("Start Game");
        SceneManager.LoadScene("Tutorial1");
    }

    public void Instruction()
    {
        Debug.Log("Instruction");
        SceneManager.LoadScene("Instruction");
    }

    public void Levels()
    {
        SceneManager.LoadScene("LevelChoose");
    }

    public void ChooseLevel(string level)
    {
        Debug.Log("Choose Level");
        SceneManager.LoadScene(level);
    }
}
