using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeBullet : MonoBehaviour
{
    public string[] bulletName = {"Regular", "Mentos", "Soda" };
    public GameObject[] bullets;
    public TextMeshProUGUI bulletInfoText;
    private ShootController shootController;

    // Start is called before the first frame update
    void Start()
    {
        shootController = GetComponent<ShootController>();
        shootController.bullet = bullets[0];
        bulletInfoText.text = "Using " + bulletName[0] + " bullet";
        shootController.SetShootSpeed(3);
    }

    // Update is called once per frame
    void Update()
    {
        // Get input from keyboard to change the bullet
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            shootController.bullet = bullets[0];
            bulletInfoText.text = "Using " + bulletName[0] + " bullet";
            shootController.SetShootSpeed(15);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            shootController.bullet = bullets[1];
            bulletInfoText.text = "Using " + bulletName[1] + " bullet";
            shootController.SetShootSpeed(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            shootController.bullet = bullets[2];
            bulletInfoText.text = "Using " + bulletName[2] + " bullet";
            shootController.SetShootSpeed(10);
        }
    }
}
