using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger1t2 : MonoBehaviour
{
    public GameObject gate1t2;
    public Tutorial1Controller tutorial1Controller;
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
        if (collision.gameObject.tag == "Player")
        {
            gate1t2.SetActive(true);
            tutorial1Controller.section2Start();
            this.gameObject.SetActive(false);
        }
    }
}
