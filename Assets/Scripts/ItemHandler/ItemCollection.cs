using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollection : MonoBehaviour
{
    public TextMeshProUGUI itemCountText;
    public StatusControllerCombEffect statusController;

    private Vector3 textOffset = new Vector3(-4.0f, 4.2f, 0.0f);
    private Dictionary<BulletBase.FoodType, int> backpack = new Dictionary<BulletBase.FoodType, int>
    {
            { BulletBase.FoodType.Mentos, 0 },
            { BulletBase.FoodType.Soda, 0 }
    };

    // Start is called before the first frame update
    void Start()
    {
        itemCountText.transform.position = transform.position + textOffset;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateBackpack();
        UpdateText();
    }

    private void UpdateBackpack()
    {
        List<BulletBase.FoodType> foods = new List<BulletBase.FoodType>(backpack.Keys);
        foreach (BulletBase.FoodType food in foods)
        {
            float status = statusController.GetStatusCount(food);
            if (status > 0)
            {
                backpack[food] = 1;
            }
            else
            {
                backpack[food] = 0;
            }
        }
    }

    private void UpdateText()
    {
        int idx = 0;
        itemCountText.text = "";
        List<BulletBase.FoodType> foods = new List<BulletBase.FoodType>(backpack.Keys);

        foreach (BulletBase.FoodType food in foods)
        {
            int cnt = backpack[food];
            if (cnt > 0)
            {
                if (idx == 0)
                {
                    itemCountText.text = food.ToString() + ": " + cnt;
                }
                else
                {
                    itemCountText.text += ", " + food.ToString() + ": " + cnt;
                }
                idx++;
            }
        }

        UpdateTextPosition();
    }

    private void UpdateTextPosition()
    {
        itemCountText.transform.position = transform.position + textOffset;
    }
}
