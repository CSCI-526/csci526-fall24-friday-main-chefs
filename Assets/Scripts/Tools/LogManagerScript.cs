using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class LogManagerScript : MonoBehaviour
{
    private string myurl = "https://script.google.com/macros/s/AKfycbx-F59N2rcfGAmJ5Woo7S7BCCbBFs5gLwovchk-UDnu7fvcyXS1xePo4ZRUR7hm4YVb/exec";

    void Start()
    {
        // StartCoroutine(Upload());
        BulletBase.counter.Clear();
    }

    IEnumerator Upload(Dictionary<string, int> bulletData, string result)
    {
        // Ensure all bullet types exist in the dictionary
        if (!bulletData.ContainsKey("regular")) bulletData["regular"] = 0;
        if (!bulletData.ContainsKey("mentos")) bulletData["mentos"] = 0;
        if (!bulletData.ContainsKey("soda")) bulletData["soda"] = 0;


        WWWForm form = new WWWForm();
        form.AddField("method", "Write");
        form.AddField("result", result);
        form.AddField("regular", bulletData["regular"].ToString());
        form.AddField("mentos", bulletData["mentos"].ToString());
        form.AddField("soda", bulletData["soda"].ToString());

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

    public void ExternalUpload(Dictionary<string, int> bulletData, string result)
    {
        StartCoroutine(Upload(bulletData, result));
    }
}
