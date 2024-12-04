using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class ObstacleLogManager : MonoBehaviour
{
    private string myurl = "https://script.google.com/macros/s/AKfycbyzMv41fnP1kLZAEqQTxsXSFM6WSS-Uft5cwBT6vxzTVCs9AWe8t-56Xj_7JzKsQ57DUg/exec";
    public static Dictionary<string, int> levelDict = new Dictionary<string, int>();

    void Start()
    {
        // StartCoroutine(Upload());
        levelDict.Clear();
    }

    IEnumerator Upload(int needle_touchTimes, int fork_touchTimes)
    {
        WWWForm form = new WWWForm();
        form.AddField("method", "Write");
        foreach (string name in levelDict.Keys)
        {
            form.AddField(name, levelDict[name].ToString());
        }

        using UnityWebRequest www = UnityWebRequest.Post(myurl, form);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }
    }

    public void ExternalUpload(int needle_touchTimes, int fork_touchTimes)
    {
        StartCoroutine(Upload(needle_touchTimes, fork_touchTimes));
    }
}
