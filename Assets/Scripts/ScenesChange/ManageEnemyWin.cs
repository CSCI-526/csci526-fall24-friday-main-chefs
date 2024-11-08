using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ManageEnemyWin : MonoBehaviour
{
    public int surviveTime = 10;
    public TextMeshProUGUI countDownText;
    public GameManagerScript gameManager;
    public GameObject targetObject;
    HealthController hpScript;
    private float timeLeft;
    // Start is called before the first frame update
    void Start()
    {
        timeLeft = surviveTime;
        hpScript = targetObject.GetComponent<HealthController>();
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        countDownText.text = Mathf.Round(timeLeft).ToString();
        if (timeLeft < 0)
        {
            gameManager.gameOver("See, you don¡¯t always need to take down the enemy.");
        } else if (hpScript.currentHealth >= hpScript.maxHealth)
        {
            gameManager.gameOver("Feed you too much... \n Oh you are bursting!", false);
        } else if (hpScript.currentHealth <= 0)
        {
            gameManager.gameOver("Looking slimmer makes you prettier... \nWait, why are you starving to death?", false);
        }
    }
}
