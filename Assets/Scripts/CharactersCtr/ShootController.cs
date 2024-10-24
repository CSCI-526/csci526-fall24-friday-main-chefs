using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    public bool isPlayer;
    public GameObject target;
    public GameObject bullet;
    public float bulletSpawnDistance = 0.05f;
    public float shootSpeed = 3;
    private float shootTime = 0;
    private float timeCount = 0;
    private float bulletSpawnRadius;
    // Start is called before the first frame update
    void Start()
    {
        shootTime = 1 / shootSpeed;
        bulletSpawnRadius = bulletSpawnDistance + transform.localScale.x / 2 + bullet.transform.localScale.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        bulletSpawnRadius = bulletSpawnDistance + transform.localScale.x / 2 + bullet.transform.localScale.x / 2;
        if(isPlayer && Input.GetMouseButton(0) && timeCount > shootTime)
        {            
            float angle = Mathf.Atan2(Input.mousePosition.y - Screen.height / 2, Input.mousePosition.x - Screen.width / 2);
            Vector2 bulletSpawn = new Vector2(transform.position.x, transform.position.y);
            bulletSpawn.x += Mathf.Cos(angle) * bulletSpawnRadius;
            bulletSpawn.y += Mathf.Sin(angle) * bulletSpawnRadius;
            GameObject newBullet = Instantiate(bullet, bulletSpawn, Quaternion.identity);
            newBullet.GetComponent<BulletBase>().SetTrajectory(new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)));
            newBullet.GetComponent<BulletBase>().SetCounter(newBullet.GetComponent<BulletBase>().foodType);
            timeCount = 0;
        }
        else if(!isPlayer && timeCount > shootTime)
        {
            float angle = Mathf.Atan2(target.transform.position.y - transform.position.y, target.transform.position.x - transform.position.x);
            Vector2 bulletSpawn = new Vector2(transform.position.x, transform.position.y);
            bulletSpawn.x += Mathf.Cos(angle) * bulletSpawnRadius;
            bulletSpawn.y += Mathf.Sin(angle) * bulletSpawnRadius;
            GameObject newBullet = Instantiate(bullet, bulletSpawn, Quaternion.identity);
            newBullet.GetComponent<BulletBase>().SetTrajectory(new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)));
            timeCount = 0;
        }

        // Prevent timeCount from going over 2 * shootTime
        if (timeCount > shootTime * 2)
        {
            timeCount = shootTime * 2;
        }
        else
        {
            timeCount += Time.deltaTime;
        }
    }

    public void SetShootSpeed(float speed)
    {
        shootSpeed = speed;
        shootTime = 1 / shootSpeed;
    }
}
