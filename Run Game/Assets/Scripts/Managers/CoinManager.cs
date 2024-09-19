using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinManager : MonoBehaviour
{
    public GameObject prefab;
    [SerializeField] int createCount = 16;    
    [SerializeField] float offsetZ = 2.5f;
    // Start is called before the first frame update
    void Awake()
    {
        Create();
    }

    private void Create()
    {
        for(int i = 0; i < createCount; i++) 
        {
            prefab = Instantiate(prefab);
            prefab.transform.SetParent(gameObject.transform);
            prefab.transform.localPosition = new Vector3(0,0,offsetZ * i);           
        }


    }
}
