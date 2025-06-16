using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBagTrigger : MonoBehaviour
{
    public int trashCount = 0;
    public int trashCountClear = 3;
    public GameObject winMassage; // UI �޼���

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trash"))
        {
            if(other.gameObject.GetComponent<TrashAlreadyCount>() == null)
            {
                trashCount++;

                other.gameObject.AddComponent<TrashAlreadyCount>();

                Debug.Log($"������� ������ ������ {trashCount}��");

                if( trashCount >= trashCountClear)
                {
                    GameClear();
                }
            }
        }
    }

    void GameClear()
    {
        Debug.Log("���� Ŭ����! ����� �ְ��� ȯ�� ��ȭ���Դϴ�!");

        if(winMassage != null)
        {
            winMassage.SetActive(true);
        }

        Time.timeScale = 0f;
    }

    // �ߺ� ���� ������ �±� ��ũ��Ʈ
    public class TrashAlreadyCount : MonoBehaviour { }
}
