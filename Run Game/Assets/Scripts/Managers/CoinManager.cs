using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinManager : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] List<GameObject> coins;

    [SerializeField] float positionX = 4.0f;

    [SerializeField] int createCount = 16;    
    [SerializeField] float offsetZ = 2.5f;

    
    void Awake()
    {
        coins.Capacity = 20;
        Create();
    }

    

    private void Create()
    {
        for(int i = 0; i < createCount; i++) 
        {
            GameObject clone = Instantiate(prefab);

            clone.transform.SetParent(gameObject.transform);

            clone.transform.localPosition = new Vector3(0, 0, offsetZ * i);

            int index = clone.name.IndexOf("(Clone)");

            if(index > 0)
            {
                clone.name = clone.name.Substring(0, index);
            }

            clone.GetComponent<MeshRenderer>().enabled = false;
            clone.GetComponent<BoxCollider>().enabled = false;

            coins.Add(clone);
        }
    }

    /*private void InitializePosition()
    {
        for (int i = 0; i < createCount; i++)
        {
            prefab = Instantiate(prefab);
            prefab.transform.SetParent(gameObject.transform);

            // x축 위치를 -4, 0, 4 중에서 랜덤 선택
            float randomX = Random.Range(0f, 4f);
            if (randomX < 1f)
            {
                randomX = -4f;
            }
            else if (randomX < 2f)
            {
                randomX = 0f;
            }
            else
            {
                randomX = 4f;
            }

            prefab.transform.localPosition = new Vector3(randomX, 0, offsetZ * i);
        }
    }*/

    public void InitializePosition()
    {
        transform.localPosition = new Vector3(positionX * Random.Range(-1, 2), 0, 0);

<<<<<<< HEAD
        for(int i = 0; i < coins.Count; i++)
        {
            coins[i].GetComponent<MeshRenderer>().enabled = true;
            coins[i].GetComponent<BoxCollider>().enabled = true;
=======
        for(int i = 0; i<coins.Count; i++)
        {
            if (coins[i].GetComponent<MeshRenderer>().enabled == false)
            {
                coins[i].GetComponent<MeshRenderer>().enabled = true;
                coins[i].GetComponent<BoxCollider>().enabled = true;
            }
>>>>>>> b0999e6c45e4fbd6c3d8a4021f6e30fa0884492a
        }
    }



}
