using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneration : MonoBehaviour
{
    [SerializeField] int width, height;
    [SerializeField] int minHeight, maxHeight;
    [SerializeField] int repeatNum;
    [SerializeField] GameObject dirt, grass;
    void Start()
    {
        Generation();
    }

    void Generation()
    {
        int repeatValue = 0;
        for (int i = 2; i < width; i++)
        {
            if (repeatValue == 0)
            {
                height = Random.Range(minHeight, maxHeight);
                GenerateFlatPlatform(i);
                repeatValue = repeatNum;
            }      
            else
            {
                GenerateFlatPlatform(i);
                repeatValue--;
            }
        }
    }

    void GenerateFlatPlatform(int i)
    {
        for (int j = 0; j < height; j++)
        {
            spawnObject(dirt, i, j);
        }
        spawnObject(grass, i, height);
    }
    void spawnObject(GameObject obj, int width, int height)
    {
        obj = Instantiate(obj, new Vector2(width, height), Quaternion.identity);
        obj.transform.parent = this.transform;
    }
}
