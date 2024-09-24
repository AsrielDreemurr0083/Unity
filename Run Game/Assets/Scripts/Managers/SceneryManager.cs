using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneryManager : Singleton<SceneryManager> 
{
    [SerializeField] Image screenImage;


    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        SceneManager.LoadScene(1); //������ ���̵�
    //    }
    //}

    public IEnumerator AsyncLoad(int index)
    {
        screenImage.gameObject.SetActive(true);

        // <asyncOperation.allowSceneActivation>
        //����� �غ�� ��� ����� Ȱ��ȭ�Ǵ� ���� ����ϴ� ����
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(index); //�񵿱��� ���̵�

        asyncOperation.allowSceneActivation = false;

        Color color = screenImage.color;

        color.a = 0f;

        while (asyncOperation.isDone == false)
        {
            color.a += Time.deltaTime;

            screenImage.color = color;

            // <asyncOperation.isDone>
            // �ش� ������ �Ϸ�Ǿ����� ��Ÿ���� ���� (�б� ����)

            if (asyncOperation.progress >= 0.9f)
            {
                color.a = Mathf.Lerp(color.a, 1f, Time.deltaTime);

                screenImage.color = color;

                if (color.a >= 1.0f)
                {
                    asyncOperation.allowSceneActivation = true;

                    yield break;
                }
            }
            yield return null;
        }


        //<asyncOperation.progress>
        // �۾��� ���� ���¸� ��Ÿ���� ���� (�б� ����)
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    //public IEnumerator FadeIn(int index)
    //{
    //    AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(index);
    //    // Color ���� ����
    //
    //    // Color ������ ScreenImage color�� ����
    //
    //    Color color = screenImage.color;
    //    // Color�� Alpha ���� 1�� ����
    //
    //    color.a = 1f;
    //    // ScreenImage�� Ȱ��ȭ �Ѵ�.
    //
    //    screenImage.gameObject.SetActive(true);
    //    // �ݺ������� color�� Alpha���� 0���� ũ�ų� ���ٸ�
    //    // �ݺ��� ����
    //    
    //    while(asyncOperation.isDone == false)
    //    {
    //        color.a -= Time.deltaTime;
    //        screenImage.color = color;
    //
    //        if(asyncOperation.progress >= 0.9f)
    //        {
    //            color.a = Mathf.Lerp(color.a, 0f, Time.deltaTime);
    //        }
    //        if (color.a >= 1.0f)
    //        {
    //            asyncOperation.allowSceneActivation = true;
    //
    //            yield break;
    //        }
    //        yield return null;
    //    }
    //    // color�� Alpha ���� ��� ����߷��� ����
    //    // screenImage�� color ���� ����
    //
    //    // ScreenImage�� ��Ȱ��ȭ
    //    screenImage.gameObject.SetActive(false);
    //
    //}

    //����

    public IEnumerator FadeIn()
    {
        Color color = screenImage.color;

        color.a = 1;

        screenImage.gameObject.SetActive (true);

        while(color.a >= 0.0f)
        {
            color.a -= Time.deltaTime;

            screenImage.color = color;

            yield return null;
        }

        screenImage.gameObject.SetActive(false);
    }





    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Fade In ȣ��
        Debug.Log("Fade In");
        StartCoroutine(FadeIn());
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
