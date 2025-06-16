using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickTip : MonoBehaviour
{
    public GameObject detectedTrash = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trash"))
        {
            detectedTrash = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Trash"))
        {
            if (detectedTrash == other.gameObject)
                detectedTrash = null;
        }
    }
}