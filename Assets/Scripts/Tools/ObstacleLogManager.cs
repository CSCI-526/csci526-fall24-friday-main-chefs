using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class ObstacleLogManager : MonoBehaviour
{
    private string myurl = "https://script.google.com/macros/s/AKfycbwd0OwlutL8RX8wcDnlH2e0HpClAhOpdqfkMJaG2o2i-jl4YT8qTw_11W0zgVh49xiI/exec";

    void Start()
    {
        // StartCoroutine(Upload());
        PoisonNeedle.touchTimes = 0;
        Fork.touchTimes = 0;
    }

    IEnumerator Upload(int needle_touchTimes, int fork_touchTimes)
    {
        WWWForm form = new WWWForm();
        form.AddField("method", "Write");
        form.AddField("needle", needle_touchTimes.ToString());
        form.AddField("fork", fork_touchTimes.ToString());

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
