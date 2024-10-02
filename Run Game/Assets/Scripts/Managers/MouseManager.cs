using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseManager : MonoBehaviour
{
    [SerializeField] Texture2D texture2D;

    // Start is called before the first frame update
    void Start()
    {
        texture2D = ResourcesManager.Instance.Load<Texture2D>("Default");

        Cursor.SetCursor(texture2D, Vector2.zero, CursorMode.Auto);
    }

    void OnSceneLoaded(SceneryManager scene, LoadSceneMode mode)
    {

    }
}
