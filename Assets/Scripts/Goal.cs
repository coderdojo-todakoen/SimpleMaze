using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public GameObject goalText;

    void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Sphere") && !goalText.activeSelf)
        {
            // 「GOAL」の文字を表示します
            goalText.SetActive(true);

            // ゲームを再開します
            StartCoroutine(Restart());
        }
    }

    IEnumerator Restart()
    {
        // 5秒経ったらシーンを再読み込みして、ゲームを再開します
        yield return new WaitForSeconds(5F);
        SceneManager.LoadScene("SampleScene");
    }
}
