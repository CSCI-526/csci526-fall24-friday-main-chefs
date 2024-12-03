using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

public class PathLogManager : MonoBehaviour
{
    private string myurl = "https://script.google.com/macros/s/AKfycbzlbR5negPAIbyNmkUnpcmY_89dyRVltgtB99dnEc55OopDHmskfWfA-TqYqiDrtwovkg/exec";

    void Start()
    {
        // StartCoroutine(Upload());
        PathTrigger.pathList.Clear();
    }

    IEnumerator Upload(List<string> pathList)
    {
        string jsonData = JsonConvert.SerializeObject(pathList);
        
        WWWForm form = new WWWForm();
        form.AddField("data", jsonData);

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

    public void ExternalUpload(List<string> pathList)
    {
        StartCoroutine(Upload(pathList));
    }
}
