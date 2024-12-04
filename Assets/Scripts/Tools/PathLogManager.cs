using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

public class PathLogManager : MonoBehaviour
{
    private string myurl = "https://script.google.com/macros/s/AKfycbx0nRHzfD5VcHAWa9sZWu0yQYek3Hu6KNk3_I-TithQ6J8ddY4S4ZxHaNdF3hRNfivLeg/exec";
    public List<string> triggerNames = new List<string>();

    void Start()
    {
        // StartCoroutine(Upload());
        triggerNames = PathTrigger.GetAllTriggerNames();
        PathTrigger.pathDict.Clear();
        foreach (string name in triggerNames)
        {
            PathTrigger.pathDict[name] = 0;
        }
    }

    IEnumerator Upload(Dictionary<string, int> pathDict)
    {
        WWWForm form = new WWWForm();
        form.AddField("method", "Write");
        foreach (string key in pathDict.Keys)
        {
            form.AddField(key, pathDict[key].ToString());
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

    public void ExternalUpload(Dictionary<string, int> pathDict)
    {
        StartCoroutine(Upload(pathDict));
    }
}
