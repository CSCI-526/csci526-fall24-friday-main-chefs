using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionControllerIceSlime : MonoBehaviour
{
    private HealthController healthController ;
    private StatusController statusController;

    void Awake()
    {
        healthController = GetComponent<HealthController>();
        statusController = GetComponent<StatusController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet" && !healthController.isPlayer)
        { 
            if(collision.gameObject.GetComponent<BulletBase>().foodType == BulletBase.FoodType.Fire)
            {
                healthController.EatBullets(collision.gameObject.GetComponent<BulletBase>().calories);
                //statusController.SetStatusCounter(collision.gameObject.GetComponent<BulletBase>().foodType, 5);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
