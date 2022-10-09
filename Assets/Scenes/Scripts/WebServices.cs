using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class WebServices : MonoBehaviour
{
    [SerializeField]
    private string userName = "Brutus";
    private Contents contents;

    public void Start()
    {
        contents = new Contents();
        contents.needsHelp = false;
        contents.didShot = false;
        contents.didScalpel = false;
        contents.name = userName;
    }

    public void CallForHelp()
    {
        contents.needsHelp = true;
        StartCoroutine(Post(contents));
    }

    public void ResolveHelp()
    {
        contents.needsHelp = false;
        StartCoroutine(Post(contents));
    }

    public void CompleteShot()
    {
        contents.didShot = true;
        StartCoroutine(Post(contents));
    }

    public void CompleteSlice()
    {
        contents.didScalpel = true;
        StartCoroutine(Post(contents));
    }

    private IEnumerator Post(Contents c)
    {
        yield return Post("https://lf50cu4aj3.execute-api.us-east-1.amazonaws.com/staging/students", JsonUtility.ToJson(c));
    }

    private IEnumerator Post(string url, string bodyJsonString)
    {
        var request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(bodyJsonString);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();
        Debug.Log("Status Code: " + request.responseCode);
    }


}
public class Contents
{
    public string name;
    public bool didShot;
    public bool didScalpel;
    public bool needsHelp;
}
