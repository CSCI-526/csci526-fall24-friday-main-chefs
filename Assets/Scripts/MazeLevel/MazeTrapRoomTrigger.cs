using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeTrapRoomTrigger : MonoBehaviour
{
    public GameObject door1;
    public GameObject door2;
    public GameObject enemy1;
    public GameObject enemy2;
    public MazeTrapRoomEnemy mazeTrapRoomEnemy;
    public GameObject trigger;
    private bool isTriggered = false;
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
            isTriggered = true;
            mazeTrapRoomEnemy.enter = true;
            door1.SetActive(true);
            door2.SetActive(true);
            enemy1.SetActive(true);
            enemy2.SetActive(true);
            trigger.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}
