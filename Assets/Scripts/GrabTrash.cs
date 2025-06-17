using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabTrash : MonoBehaviour
{
    public StickTip leftTip;
    public StickTip rightTip;

    private GameObject currentGrabTrash = null;

    void Update()
    {
        if (leftTip.detectedTrash != null && leftTip.detectedTrash == rightTip.detectedTrash)
        {
            currentGrabTrash = leftTip.detectedTrash;
            GrabTrash1(currentGrabTrash);
        }
    }
    void GrabTrash1(GameObject trash)
    {
        // 중앙 위치 계산
        Vector3 midPoint = (leftTip.transform.position + rightTip.transform.position) / 2f;
        trash.transform.position = midPoint;

        // 붙이기
        trash.transform.SetParent(this.transform); // 이 오브젝트는 XR Origin에 붙어 있음

        // Rigidbody 제어
        var rb = trash.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }
    }

    public void ReleaseTrash()
    {
        if (currentGrabTrash != null)
        {
            currentGrabTrash.transform.SetParent(null);
            var rb = currentGrabTrash.GetComponent<Rigidbody>();
            if (rb != null) rb.isKinematic = false;
            currentGrabTrash = null;
        }
    }
}
