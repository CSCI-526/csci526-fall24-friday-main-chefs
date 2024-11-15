using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1SceneController : MonoBehaviour
{
    public L5PuzzleGate l5PuzzleGate;
    public GameObject player;
    public GameObject mentosEnemy;
    public GameObject cokeEnemy;
    public Vector2 mentosEnemyPos;
    public Vector2 cokeEnemyPos;

    private bool inSection2 = false;
    private GameObject mentosEnemyInScene;
    private GameObject cokeEnemyInScene;
    private float mentosEnemyRespawnTime = 3f;
    private float cokeEnemyRespawnTime = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inSection2)
        {
            if (mentosEnemyInScene == null)
            {
                if (mentosEnemyRespawnTime <= 0)
                {
                    mentosEnemyInScene = Instantiate(mentosEnemy, mentosEnemyPos, Quaternion.identity);
                    mentosEnemyRespawnTime = 3f;
                    mentosEnemyInScene.gameObject.SetActive(true);
                }
                else
                {
                    mentosEnemyRespawnTime -= Time.deltaTime;
                }
            }
        }

        if (inSection2)
        {
            if (cokeEnemyInScene == null)
            {
                if (cokeEnemyRespawnTime <= 0)
                {
                    cokeEnemyInScene = Instantiate(cokeEnemy, cokeEnemyPos, Quaternion.identity);
                    cokeEnemyRespawnTime = 3f;
                    cokeEnemyInScene.gameObject.SetActive(true);
                }
                else
                {
                    cokeEnemyRespawnTime -= Time.deltaTime;
                }
            }
        }
    }

    public void section2Start()
    {
        inSection2 = true;
        player.GetComponent<HealthController>().healthDecreaseRate = 1f;
    }

    public void openGate()
    {
        if (inSection2) 
        {
            l5PuzzleGate.openGate();
        }
    }
}
