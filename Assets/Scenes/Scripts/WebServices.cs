using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WebServices : MonoBehaviour
{
    [SerializeField]
    private string name = "Brutus";
    private bool didShot;
    private bool didScalpel;
    private bool needsHelp;

    public void Start()
    {
        needsHelp = false;
        didShot = false;
        didScalpel = false;
    }

    public void CallForHelp()
    {
        needsHelp = true;
        StartCoroutine(Post(BuildForm()));
    }

    public void ResolveHelp()
    {
        needsHelp = false;
        StartCoroutine(Post(BuildForm()));
    }

    public void CompleteShot()
    {
        didShot = true;
        StartCoroutine(Post(BuildForm()));
    }

    public void CompleteSlice()
    {
        didScalpel = true;
        StartCoroutine(Post(BuildForm()));
    }

    private WWWForm BuildForm()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", name);
        form.AddField("didShot", didShot ? "true" : "false");
        form.AddField("didScalpel", didScalpel ? "true" : "false");
        form.AddField("needsHelp", needsHelp ? "true" : "false");
        return form;
    }

    private IEnumerator Post(WWWForm form)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Post("https://lf50cu4aj3.execute-api.us-east-1.amazonaws.com/staging/students", form))
        {
            yield return webRequest.SendWebRequest();
        }
    }
}
