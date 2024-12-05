using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemCollection : MonoBehaviour
{
    public TextMeshProUGUI ItemText;
    public Dictionary<IngredientBase.IngredientType, bool> items = new Dictionary<IngredientBase.IngredientType, bool>();


    // Start is called before the first frame update
    void Start()
    {
        // Initialize the dictionary, traverse all the ingredient types and set them to false
        foreach (IngredientBase.IngredientType type in Enum.GetValues(typeof(IngredientBase.IngredientType)))
        {
            items.Add(type, false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddNewItem(IngredientBase.IngredientType type)
    {
        ItemText.text = "Bag: " + type.ToString();
        if (items.ContainsKey(type))
        {
            items[type] = true;
        }
    }
}
