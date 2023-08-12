using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : MonoBehaviour
{
    public static BuffManager instance;
    private void Awake() {
        instance = this;
    }
    public GameObject buffPrefab;
    public bool onATK, onDEF = false;
    public void CreateBuff(string type, float per, float dur, Sprite icon)
    {
        GameObject go = Instantiate(buffPrefab, transform);
        go.GetComponent<BaseBuff>().Init(type, per, dur);
        go.GetComponent<UnityEngine.UI.Image>().sprite = icon;
    }
}
