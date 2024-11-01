using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EatBulletEnd : MonoBehaviour
{
    public int surviveTime = 10;
    public TextMeshProUGUI countDownText;
    public GameManagerScript gameManager;
    private float timeLeft;
    // Start is called before the first frame update
    void Start()
    {
        timeLeft = surviveTime;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        countDownText.text = Mathf.Round(timeLeft).ToString();
        if (timeLeft < 0)
        {
            gameManager.gameOver("Fitness master!\n Perfectly control your energy!");
        }
    }
}
