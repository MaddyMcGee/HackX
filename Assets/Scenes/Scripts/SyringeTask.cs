using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyringeTask : MonoBehaviour
{
    [SerializeField]
    private WebServices webServices;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Syringe"))
        {
            webServices.CompleteShot();
        }
    }
}
