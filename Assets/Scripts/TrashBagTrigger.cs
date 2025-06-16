using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBagTrigger : MonoBehaviour
{
    public int trashCount = 0;
    public int trashCountClear = 3;
    public GameObject winMassage; // UI 메세지

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trash"))
        {
            if(other.gameObject.GetComponent<TrashAlreadyCount>() == null)
            {
                trashCount++;

                other.gameObject.AddComponent<TrashAlreadyCount>();

                Debug.Log($"현재까지 수집한 쓰레기 {trashCount}개");

                if( trashCount >= trashCountClear)
                {
                    GameClear();
                }
            }
        }
    }

    void GameClear()
    {
        Debug.Log("게임 클리어! 당신은 최고의 환경 미화원입니다!");

        if(winMassage != null)
        {
            winMassage.SetActive(true);
        }

        Time.timeScale = 0f;
    }

    // 중복 감지 방지용 태그 스크립트
    public class TrashAlreadyCount : MonoBehaviour { }
}
