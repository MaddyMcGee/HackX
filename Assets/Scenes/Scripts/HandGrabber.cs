using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGrabber : MonoBehaviour
{
    [SerializeField]
    private bool isRight;
    Coroutine carry;
    Collider thing;

    // Start is called before the first frame update
    void Start()
    {
        thing = null;
        carry = null;
        XRInput xrInput = new XRInput();
        if (isRight)
        {
            xrInput.Hands.RightGrip.Enable();
            xrInput.Hands.RightGrip.started += m => Grab();
            xrInput.Hands.RightGrip.canceled += m => Release();
        }
        else
        {
            xrInput.Hands.LeftGrip.Enable();
            xrInput.Hands.LeftGrip.started += m => Grab();
            xrInput.Hands.LeftGrip.canceled += m => Release();
        }
    }

    private void Grab()
    {
        if (thing != null)
        {
            carry = StartCoroutine(CarryThing(thing.gameObject));
            thing = null;
        }
    }

    private void Release()
    {
        if (carry != null)
        {
            StopCoroutine(carry);
            carry = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Grabable"))
        {
            thing = other;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.Equals(thing))
        {
            thing = null;
        }
    }

    private IEnumerator CarryThing(GameObject obj)
    {
        while (true)
        {
            yield return new WaitForFixedUpdate();
            obj.transform.position = transform.position;
            //obj.GetComponent<Rigidbody>().constraints;
            //RigidbodyConstraints.
        }
    }

}
