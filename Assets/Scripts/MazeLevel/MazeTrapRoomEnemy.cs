using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeTrapRoomEnemy : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject door1;
    public GameObject door2;
    public bool enter = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy1 == null && enemy2 == null && enter == true)
        {
            door1.SetActive(false);
            door2.SetActive(false);
        }
    }
}
