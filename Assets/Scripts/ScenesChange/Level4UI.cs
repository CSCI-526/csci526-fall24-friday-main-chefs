using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Level4UI : MonoBehaviour
{
    public GameObject level4UI;
    public TextMeshProUGUI level4Text;
    public float countdown = 8f;
    public GameObject enemy1;
    public GameObject enemy2;
    public HealthController healthController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        level4Text.text = Mathf.Round(countdown).ToString();
        if (countdown <= 0)
        {
            level4UI.SetActive(false);
            enemy1.SetActive(true);
            enemy2.SetActive(true);
            healthController.healthDecreaseRate = 3f;
        }
    }
}
