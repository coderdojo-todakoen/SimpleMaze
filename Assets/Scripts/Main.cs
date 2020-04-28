using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    // 操作対象の球
    GameObject sphere;
    // ゴール
    GameObject goal;
    // 「スタート」の文字
    GameObject start;
    // 「ゴール」の文字
    GameObject end;
    // 「スタート」「ゴール」の文字を表示する位置のオフセット
    Vector3 offset = new Vector3(0, 0, 1.5F);
    // 経過時間
    float time;

    // Start is called before the first frame update
    void Start()
    {
        // GameObjectを取得します
        sphere = GameObject.Find("Sphere");
        goal = GameObject.Find("Goal");
        start = GameObject.Find("Start");
        end = GameObject.Find("End");
    }

    // Update is called once per frame
    void Update()
    {
        if (time < 5F)
        {
            // ゲーム開始から5秒間、「スタート」「ゴール」の場所に文字を表示します
            start.transform.position = RectTransformUtility.WorldToScreenPoint(Camera.main, sphere.transform.position - offset);
            end.transform.position = RectTransformUtility.WorldToScreenPoint(Camera.main, goal.transform.position + offset);

            time += Time.deltaTime;

            if (time > 5F)
            {
                // 5秒以上経過したら、文字を削除します
                GameObject.Destroy(start);
                GameObject.Destroy(end);
            }
        }
    }
}
