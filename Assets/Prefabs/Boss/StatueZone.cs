using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using CameraFading;
public class StatueZone : MonoBehaviour
{
    TestLevel testLevel;
    float fadeTime = 1.2f;
    private void Awake()
    {
        testLevel = GameObject.Find("TestLevel").GetComponent<TestLevel>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            testLevel.level++;
            CameraFade.Out(fadeTime);
            GameObject.Find("Canvas").transform.Find("BuffPanel").gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.Find("PlayerHPBar").gameObject.SetActive(false);
            StartCoroutine(SceneReload());
        }
    }

    private IEnumerator SceneReload()
    {
        yield return new WaitForSeconds(fadeTime + 0.3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 씬 새로고침
    }

}
