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
        // �߾� ��ġ ���
        Vector3 midPoint = (leftTip.transform.position + rightTip.transform.position) / 2f;
        trash.transform.position = midPoint;

        // ���̱�
        trash.transform.SetParent(this.transform); // �� ������Ʈ�� XR Origin�� �پ� ����

        // Rigidbody ����
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
