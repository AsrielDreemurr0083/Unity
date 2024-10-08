using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] GameObject prefab;

    [SerializeField] List<GameObject> obstacles;

    [SerializeField] int createCount = 5;
    [SerializeField] int random;
    void Start()
    {
        obstacles.Capacity = 10;

        Create();

        StartCoroutine(ActiveObstacle());
    }

    public void Create()
    {
        for (int i = 0; i < createCount; i++)
        {
            prefab = ResourcesManager.Instance.Instantiate("Cone",gameObject.transform);

            prefab.SetActive(false);

            obstacles.Add(prefab);
        }
    }

    public bool ExamineActive()
    {
        for(int i = 0; i < obstacles.Count; i++)
        {
            if (obstacles[i].activeSelf == false)
            {
                return false;
            }
        }
        return true;
    }

    public IEnumerator ActiveObstacle()
    {
        int count = 0;

        while (true)
        {
            yield return CoroutineCache.WaitForSecond(2.5f);

            random = Random.Range(0, obstacles.Count);

            while (obstacles[random].activeSelf == true)
            {
                if (ExamineActive())
                {
                    GameObject clone = ResourcesManager.Instance.Instantiate("Cone", gameObject.transform);

                    clone.SetActive(false);

                    obstacles.Add(clone);
                }

                random = (random + 1) % obstacles.Count;
            }

            obstacles[random].SetActive(true);
        }
    }
}
