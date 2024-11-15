using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRespawn : MonoBehaviour
{
    public GameObject mentos;
    public GameObject coke;
    public Vector3 mentosPosition;
    public Vector3 cokePosition;
    private float mentosRespawnTime = 0f;
    private float cokeRespawnTime = 0f;
    private GameObject mentosBullet;
    private GameObject cokeBullet;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(mentosBullet == null && mentosRespawnTime > 5.0f)
        {
            mentosBullet = Instantiate(mentos, mentosPosition, Quaternion.identity);
            mentosRespawnTime = 0f;
        }
        if(cokeBullet == null && cokeRespawnTime > 5.0f)
        {
            cokeBullet = Instantiate(coke, cokePosition, Quaternion.identity);
            cokeRespawnTime = 0f;
        }
        mentosRespawnTime += Time.deltaTime;
        cokeRespawnTime += Time.deltaTime;
        if(mentosRespawnTime > 5.0f)
        {
            mentosRespawnTime = 6.0f;
        }
        if(cokeRespawnTime > 5.0f)
        {
            cokeRespawnTime = 6.0f;
        }
    }
}
