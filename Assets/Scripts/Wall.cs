using UnityEngine;

public class Wall : MonoBehaviour
{
    void Start()
    {
        // 壁を生成するためのプレハブを読み込みます
        GameObject cube = Resources.Load<GameObject>("Prefabs/Cube");

        // 迷路の外周の壁を生成します
        Vector3 position = cube.transform.position;
        position.x = -10.5F;
        position.z = 8;
        for (int i = 0; i != 22; ++i, position.x += 1F)
        {
            GameObject obj = Instantiate(cube, position, Quaternion.identity, transform);
            obj.transform.localScale = new Vector3(1F, 1F, 0.1F);
        }
        position.x = 11F;
        position.z = 7.5F;
        for (int i = 0; i != 16; ++i, position.z -= 1F)
        {
            GameObject obj = Instantiate(cube, position, Quaternion.identity, transform);
            obj.transform.localScale = new Vector3(0.1F, 1F, 1F);
        }
        position.x = 10.5F;
        position.z = -8;
        for (int i = 0; i != 22; ++i, position.x -= 1F)
        {
            GameObject obj = Instantiate(cube, position, Quaternion.identity, transform);
            obj.transform.localScale = new Vector3(1F, 1F, 0.1F);
        }
        position.x = -11F;
        position.z = -7.5F;
        for (int i = 0; i != 16; ++i, position.z += 1F)
        {
            GameObject obj = Instantiate(cube, position, Quaternion.identity, transform);
            obj.transform.localScale = new Vector3(0.1F, 1F, 1F);
        }

        // 迷路の内側の壁を生成します
        position.x = -9F;
        position.z = 6F;
        for (int i = 0; i != 7; ++i)
        {
            // +x方向へ壁を作ったかどうか
            bool sumi = false;
            for (int j = 0; j != 10; ++j)
            {
                // 壁を生成する座標
                Vector3 p = position;
                Vector3 scale = new Vector3(0.1F, 1F, 0.1F);
                // 壁を生成する方向
                // i == 0 のときのみ+z方向へも壁を生成できます
                // 1つ前の壁を+x方向へ作った場合は、-x方向へは生成できません
                int direction = Random.Range(i == 0 ? 1 : 2, sumi ? 4 : 5);
                sumi = false;
                switch (direction)
                {
                    case 1:
                        // +z方向へ壁を作ります
                        p.z += 1F;
                        scale.x = 0.1F;
                        scale.z = 2F;
                        break;
                    case 2:
                        // +x方向へ壁を作ります
                        p.x += 1F;
                        scale.x = 2F;
                        scale.z = 0.1F;
                        // +x方向へ壁を作ったことを記録します
                        sumi = true;
                        break;
                    case 3:
                        // -z方向へ壁を作ります
                        p.z -= 1F;
                        scale.x = 0.1F;
                        scale.z = 2F;
                        break;
                    case 4:
                        // -x方向へ壁を作ります
                        p.x -= 1F;
                        scale.x = 2F;
                        scale.z = 0.1F;
                        break;
                }

                GameObject obj = Instantiate(cube, p, Quaternion.identity, transform);
                obj.transform.localScale = scale;

                position.x += 2;
            }
            position.x = -9F;
            position.z -= 2;
        }
    }
}
