using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1Trigger1t2 : MonoBehaviour
{
    public GameObject gate;
    public L1SceneController sceneController;
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
            gate.SetActive(true);
            sceneController.section2Start();
            this.gameObject.SetActive(false);
        }
    }
}
