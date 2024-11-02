using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class TimeManagerScript : MonoBehaviour
{
    private string myurl = "https://script.google.com/macros/s/AKfycbzwEZjq6ft1Z0CMXSLVSe73FosimuQdgA4eJPaiV2S_Zz5wAElsG_htJ1s3mJ_2AgYTfA/exec";
    public static Dictionary<string, float> timeDict = new Dictionary<string, float>();
    private static float startTime;
    private static float endTime;
    private static bool isTimerRunning = false;
    public string sceneName;
    private int numLevel = 5;

    void Start()
    {
        // StartCoroutine(Upload());
        sceneName = gameObject.scene.name;
        Debug.Log(sceneName);
        StartTimer();
    }

    public void StartTimer()
    {
        startTime = Time.time;
        isTimerRunning = true;
    }

    public void StopTimer()
    {
        if (isTimerRunning)
        {
            endTime = Time.time;
            isTimerRunning = false;
            float totalTime = endTime - startTime;
            timeDict[sceneName.ToLower()] = totalTime;
            Debug.Log($"Level Completion Time: {totalTime:F4} s");
        }
    }

    IEnumerator Upload(Dictionary<string, float> timeData)
    {
        WWWForm form = new WWWForm();
        form.AddField("method", "Write");
        for (int i = 1; i <= numLevel; i++)
        {
            if (!timeData.ContainsKey($"level{i}"))
            {
                timeData[$"level{i}"] = 0f;
            }
            form.AddField($"level{i}", timeData[$"level{i}"].ToString("F4"));
        }

        using UnityWebRequest www = UnityWebRequest.Post(myurl, form);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(www.error);
        }
        else
        {
            Debug.Log("Time upload complete!");
        }
    }

    public void ExternalUpload(Dictionary<string, float> timeData)
    {
        StartCoroutine(Upload(timeData));
    }
}
