using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger3to4 : MonoBehaviour
{
    public GameObject gate;

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
            gate.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
