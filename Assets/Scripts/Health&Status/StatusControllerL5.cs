using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusControllerL5 : MonoBehaviour
{
    public StatusBar statusBar;
    public HealthController healthController;
    public L5PuzzleGate l5PuzzleGate;

    private Dictionary<BulletBase.FoodType, float> statusCount = new Dictionary<BulletBase.FoodType, float>
     {
            { BulletBase.FoodType.Mentos, 0 },
            { BulletBase.FoodType.Soda, 0 }
     };

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (statusCount[BulletBase.FoodType.Mentos] > 0 && statusCount[BulletBase.FoodType.Soda] > 0)
        {
            l5PuzzleGate.openGate();
            // Boom (^ ; w ; ^)
            statusCount[BulletBase.FoodType.Mentos] = 0;
            statusCount[BulletBase.FoodType.Soda] = 0;
            statusBar.SetCount(0);
            healthController.maxSize += 3;
        }
        UpdateStatusCounter();
    }

    public void SetStatusCounter(BulletBase.FoodType foodType, float CountDownTime)
    {
        if (foodType == BulletBase.FoodType.Regular)
        {
            return;
        }
        statusCount[foodType] = CountDownTime;
        statusBar.SetMaxCount(CountDownTime);
        if(foodType == BulletBase.FoodType.Mentos)
        {
            statusBar.SetFillColor(new Color(144 / 255f, 196 / 255f, 236 / 255f, 1f));
        }
        else if(foodType == BulletBase.FoodType.Soda)
        {
            statusBar.SetFillColor(new Color(112 / 255f, 44 / 255f, 0f, 1f));
        }

    }

    public void UpdateStatusCounter()
    {
        List<BulletBase.FoodType> keys = new List<BulletBase.FoodType>(statusCount.Keys);

        foreach (BulletBase.FoodType key in keys)
        {
            statusCount[key] -= Time.deltaTime;
            if (statusCount[key] < 0)
            {
                statusCount[key] = 0;
            }
            else if (statusCount[key] > 0)
            {
                statusBar.SetCount(statusCount[key]);
            }
        }
    }
}
