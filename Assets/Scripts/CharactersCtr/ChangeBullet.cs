using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeBullet : MonoBehaviour
{
    public string[] bulletName = {"Regular", "Mentos", "Soda" };
    public float[] shootSpeed;
    public GameObject[] bullets;
    public TextMeshProUGUI bulletInfoText;
    private ShootController shootController;
    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        shootController = GetComponent<ShootController>();
        shootController.bullet = bullets[index];
        bulletInfoText.text = "Using " + bulletName[index] + " bullet";
        shootController.SetShootSpeed(5);
    }

    // Update is called once per frame
    void Update()
    {
        // Get input from mouse right click to change the bullet
        if (Input.GetMouseButtonDown(1))
        {
            index++;
            if (index >= bullets.Length)
            {
                index = 0;
            }
            shootController.bullet = bullets[index];
            bulletInfoText.text = "Using " + bulletName[index] + " bullet";
            shootController.SetShootSpeed(shootSpeed[index]);
        }
    }
}
