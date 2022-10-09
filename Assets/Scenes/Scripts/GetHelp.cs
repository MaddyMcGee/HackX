using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GetHelp : MonoBehaviour
{
    public void CallForHelp()
    {
        StartCoroutine(Post());
    }

    private IEnumerator Post()
    {
        WWWForm form = new WWWForm();
        form.AddField("studentName", "Brutus");
        form.AddField("needsHelp", "true");

        using (UnityWebRequest webRequest = UnityWebRequest.Post("https://ptsv2.com/t/w3tw1-1665292876/post", form))
        {
            yield return webRequest.SendWebRequest();
        }
    }
}
