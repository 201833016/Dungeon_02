using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
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
}
