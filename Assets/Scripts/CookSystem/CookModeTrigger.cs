using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CookModeTrigger : MonoBehaviour
{
    public GameObject player;
    public GameObject replacedBullet;
    public GameObject pressEText;
    public GameObject info;
    public GameObject inputSequence;
    public GameObject arrowTextPrefab;
    public KeyCode[] recipe;
    public TextMeshProUGUI BulletUse;
    public TextMeshProUGUI ItemCollected;

    private bool isInRange = false;
    private bool isCookMode = false;
    private int recipeIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isInRange && Input.GetKeyDown(KeyCode.E))
        {
            if(isCookMode)
            {
                ExitCookMode();
            }
            else
            {
                EnterCookMode();
            }
        }

        if(isCookMode)
        {
            // Listen input of a series of arrow keys and see if the player is cooking the right recipe
            if(Input.GetKeyDown(recipe[recipeIndex]))
            {
                recipeIndex++;
                if(recipeIndex == recipe.Length)
                {
                    // Player has cooked the right recipe
                    Debug.Log("Cooked the right recipe");
                    player.gameObject.GetComponent<ShootController>().bullet = replacedBullet;
                    BulletUse.text = "Fire Ball !";
                    BulletUse.color = new Color(255, 103, 0);
                    BulletUse.outlineColor = new Color(255, 0, 0);
                    BulletUse.outlineWidth = 0.27f;
                    ExitCookMode();
                }
                if(isCookMode)
                {
                    inputSequence.transform.GetChild(recipeIndex - 1).gameObject.GetComponent<TextMeshProUGUI>().color = Color.green;
                    foreach (Transform child in inputSequence.transform)
                    {
                        child.GetComponent<RectTransform>().localPosition = new Vector2(child.GetComponent<RectTransform>().localPosition.x - 1.5f, 1.5f);
                    }
                }               
            }
        }
    }

    private void GenerateRecipe()
    {
        for(int i = 0; i < recipe.Length; i++)
        {
            Vector2 position = new Vector2(1.5f * i, 1.5f);
            GameObject newText = Instantiate(arrowTextPrefab, position, Quaternion.identity);
            newText.GetComponent<TextMeshProUGUI>().text = GetArrowKey(recipe[i]).ToString();
            newText.transform.SetParent(inputSequence.transform);
            newText.GetComponent<RectTransform>().localPosition = position;
            newText.SetActive(true);
        }
    }

    private char GetArrowKey(KeyCode input)
    {
        if(input == KeyCode.UpArrow)
        {
            return '¡ü';
        }

        if(input == KeyCode.DownArrow)
        {
            return '¡ý';
        }

        if(input == KeyCode.LeftArrow)
        {
            return '¡û';
        }

        if(input == KeyCode.RightArrow)
        {
            return '¡ú';
        }

        return ' ';
    }

    private void EnterCookMode()
    {
        Debug.Log("Cook Mode");
        pressEText.SetActive(false);
        info.SetActive(false);
        isCookMode = true;
        GenerateRecipe();
    }

    private void ExitCookMode()
    {
        Debug.Log("Exit Cook Mode");
        pressEText.SetActive(true);
        player.GetComponent<ShootController>().enabled = true;
        player.GetComponent<HealthController>().healthDecreaseRate = 2;
        player.GetComponent<CollisionController>().enabled = true;
        isCookMode = false;
        foreach(Transform child in inputSequence.transform)
        {
            Destroy(child.gameObject);
        }
        recipeIndex = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<ItemCollection>().items[IngredientBase.IngredientType.Chili])
            {
                pressEText.SetActive(true);
                isInRange = true;
                player.GetComponent<ShootController>().enabled = false;
                player.GetComponent<HealthController>().healthDecreaseRate = 0;
                player.GetComponent<CollisionController>().enabled = false;
            }
            else
            {
                info.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            ExitCookMode();
            isInRange = false;
            pressEText.SetActive(false);
            info.SetActive(false);
        }
    }
}
