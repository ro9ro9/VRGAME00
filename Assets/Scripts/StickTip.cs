using UnityEngine;

public class StickTip : MonoBehaviour
{
    public GameObject detectedTrash = null;
    private FixedJoint joint;
    private GameObject currentTrash;
    private Rigidbody rb;
    private float shakeOut = 2.0f;

    void Start()
    {
        rb = GetComponentInParent<Rigidbody>();
    }

    void OnTriggerStay(Collider other)
    {
        if (GameManager.Instance.currentMode != GameManager.GrabMode.Easy) return;
        if (currentTrash != null) return;
        if (joint != null) return;

        if (other.CompareTag("Trash"))
        {
            float dist = Vector3.Distance(transform.position, other.transform.position);
            if (dist < 0.2f)
            {
                Rigidbody otherRb = other.attachedRigidbody;
                if (otherRb == null)
                {
                    Debug.LogWarning("Trash 오브젝트에 Rigidbody 없음: " + other.name);
                    return;
                }

                joint = gameObject.AddComponent<FixedJoint>();
                joint.connectedBody = otherRb;
                currentTrash = other.gameObject;

                Debug.Log("붙임 성공: " + currentTrash.name);
            }
        }
    }
}