using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger2t3 : MonoBehaviour
{
    public Tutorial1Controller tutorial1Controller;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            tutorial1Controller.section3Start();
            this.gameObject.SetActive(false);
        }
    }
}
