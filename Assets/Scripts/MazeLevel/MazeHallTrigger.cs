using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeHallTrigger : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            foreach(GameObject enemy in enemies)
            {
                enemy.SetActive(true);
            }
            Player.GetComponent<ShootController>().shootSpeed += 1;
            Destroy(this);
        }
    }
}
