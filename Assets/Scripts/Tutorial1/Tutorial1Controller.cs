using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Tutorial1Controller : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;

    public TextMeshProUGUI section2Text1;
    public GameObject section2Text2;
    public GameObject section2Text3;
    public TextMeshProUGUI section2Text4;
    public GameObject gate2t3;

    private Vector2 respawnPoint;
    private GameObject enemyInScene = null;
    private bool inSection2 = false;
    private float enemyRespawnTime = 0f;
    private float section2Counter = 25f;

    private bool inSection3 = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(inSection2)
        {
            if(enemyInScene == null)
            {
                if(enemyRespawnTime > 3f)
                {
                    enemyInScene = Instantiate(enemy, new Vector2(26, 1), Quaternion.identity);
                    enemyInScene.SetActive(true);
                    enemyRespawnTime = 0f;
                    section2Text1.enabled = false;
                }
                else
                {
                    enemyRespawnTime += Time.deltaTime;
                }
            }

            if(section2Counter < 0f)
            {
                section2Text2.SetActive(false);
                section2Text3.SetActive(false);
                gate2t3.SetActive(false);
            }
            section2Counter -= Time.deltaTime;
            section2Text4.text = "in " + Mathf.Round(section2Counter).ToString() + "s";
        }
    }

    public void section2Start()
    {
        Debug.Log("Section 2 Start");
        player.GetComponent<HealthController>().enabled = true;
        player.GetComponent<StatusController>().enabled = true; 
        player.GetComponent<CollisionController>().enabled = true;
        player.GetComponent<ShootController>().enabled = true; 
        player.transform.Find("StatusCanvas").gameObject.SetActive(true);
        player.transform.Find("HealthCanvas").gameObject.SetActive(true);
        inSection2 = true;
    }

    public void section3Start()
    {
        gate2t3.SetActive(true);
        Destroy(enemyInScene);
        inSection2 = false;
        inSection3 = true;
        player.GetComponent<HealthController>().healthDecreaseRate = 2.5f;
    }
}
