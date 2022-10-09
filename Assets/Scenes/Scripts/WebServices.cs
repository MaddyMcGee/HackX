using System.Collections;
using System.Collections.Generic;
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
        StartCoroutine(Post());
    }

    public void ResolveHelp()
    {
        contents.needsHelp = false;
        StartCoroutine(Post());
    }

    public void CompleteShot()
    {
        contents.didShot = true;
        StartCoroutine(Post());
    }

    public void CompleteSlice()
    {
        contents.didScalpel = true;
        StartCoroutine(Post());
    }

    private IEnumerator Post()
    {
        using (UnityWebRequest webRequest = 
            UnityWebRequest.Put("https://lf50cu4aj3.execute-api.us-east-1.amazonaws.com/staging/students", 
            JsonUtility.ToJson(contents)))
        {
            yield return webRequest.SendWebRequest();
        }
    }

}
public class Contents
{
    public string name;
    public bool didShot;
    public bool didScalpel;
    public bool needsHelp;
}
