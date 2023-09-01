using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using CameraFading;
public class SceneMove : MonoBehaviour
{
    float fadeTime = 0.5f;

    public void MoveTestScene()
    {
        SceneManager.LoadScene("TestScene");
    }

    public void MoveSampleScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void MoveReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 씬 새로고침
    }

    public void GameStartScene()
    {
        CameraFade.Out(fadeTime);
        StartFade();
        StartCoroutine(GameStart());
    }
    public void GameOut()
    {
        // 게임 프로그램 나가기
        Application.Quit();
    }

    IEnumerator GameStart()
    {
        yield return new WaitForSeconds(fadeTime + 0.1f);
        SceneManager.LoadScene("SampleScene");
    }

    public void StartFade()
    {
        for (int i = 1; i < this.gameObject.transform.parent.childCount; i++)
        {
            GameObject aaa = this.gameObject.transform.parent.GetChild(i).gameObject;
            aaa.SetActive(false);
        }
    }
}
