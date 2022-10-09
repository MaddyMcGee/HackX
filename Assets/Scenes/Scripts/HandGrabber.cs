using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGrabber : MonoBehaviour
{
    Coroutine carry;
    Collider thing;
    bool isCarrying;
    // Start is called before the first frame update
    void Start()
    {
        isCarrying = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isCarrying && other.CompareTag("Grabable"))
        {
            thing = other;
            carry = StartCoroutine(CarryThing(other.gameObject));
            isCarrying = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isCarrying && other.Equals(thing))
        {
            isCarrying = false;
            StopCoroutine(carry);
        }
    }

    private IEnumerator CarryThing(GameObject obj)
    {
        while (true)
        {
            yield return new WaitForFixedUpdate();
            obj.transform.position = transform.position;
        }
    }

}
