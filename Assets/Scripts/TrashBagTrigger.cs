using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TrashBagTrigger : MonoBehaviour
{
    public int trashCount = 0;
    public int trashCountClear = 3;
    public TMP_Text clearText;

    private bool isCleared = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isCleared) return;

        if (other.CompareTag("Trash"))
        {
            if (other.gameObject.GetComponent<TrashAlreadyCount>() == null)
            {
                trashCount++;

                other.gameObject.AddComponent<TrashAlreadyCount>();

                Debug.Log($"������� ������ ������ {trashCount}��");

                if (trashCount >= trashCountClear)
                {
                    StartCoroutine(ShowClearUI());
                }
            }
        }
    }

    private IEnumerator ShowClearUI()
    {
        isCleared = true;

        if (clearText != null)
        {
            clearText.text = "���� Ŭ����! ����� �ְ��� ȯ�� ��ȭ���Դϴ�!";
            clearText.gameObject.SetActive(true);
        }

        Time.timeScale = 0f;

        yield return null;
    }

    // �ߺ� ���� ������ �±� ��ũ��Ʈ
    public class TrashAlreadyCount : MonoBehaviour { }
}
