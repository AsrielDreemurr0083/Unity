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
    //        SceneManager.LoadScene(1); //동기방식 씬이동
    //    }
    //}

    public IEnumerator AsyncLoad(int index)
    {
        screenImage.gameObject.SetActive(true);

        // <asyncOperation.allowSceneActivation>
        //장면이 준비된 즉시 장면이 활성화되는 것을 허용하는 변수
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(index); //비동기방식 씬이동

        asyncOperation.allowSceneActivation = false;

        Color color = screenImage.color;

        color.a = 0f;

        while (asyncOperation.isDone == false)
        {
            color.a += Time.deltaTime;

            screenImage.color = color;

            // <asyncOperation.isDone>
            // 해당 동작이 완료되었는지 나타내는 변수 (읽기 전용)

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
        // 작업의 진행 상태를 나타내는 변수 (읽기 전용)
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    //public IEnumerator FadeIn(int index)
    //{
    //    AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(index);
    //    // Color 변수 선언
    //
    //    // Color 변수에 ScreenImage color를 저장
    //
    //    Color color = screenImage.color;
    //    // Color의 Alpha 값을 1로 설정
    //
    //    color.a = 1f;
    //    // ScreenImage를 활성화 한다.
    //
    //    screenImage.gameObject.SetActive(true);
    //    // 반복문으로 color의 Alpha값이 0보다 크거나 같다면
    //    // 반복을 수행
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
    //    // color의 Alpha 값을 계속 떨어뜨려준 다음
    //    // screenImage의 color 값에 저장
    //
    //    // ScreenImage를 비활성화
    //    screenImage.gameObject.SetActive(false);
    //
    //}

    //정답

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


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(AsyncLoad(1));
        }
    }



    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Fade In 호출
        Debug.Log("Fade In");
        StartCoroutine(FadeIn());
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
