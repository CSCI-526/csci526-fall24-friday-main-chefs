using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    [SerializeField] GameObject Player ;  
    public bool isPickedUp ; 
    private Vector2 vel ; 
    public float smoothTime; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPickedUp)
        {
            Vector3 offset = new Vector3(0, 1.7f, 0);
            transform.position = Vector2.SmoothDamp(transform.position, Player.transform.position + offset, ref vel, smoothTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("player") && !isPickedUp)
        {
            isPickedUp = true; 
        }
    }
}
