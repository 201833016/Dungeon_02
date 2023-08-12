using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnClick : MonoBehaviour
{
    public string type;
    public float per;
    public float duration;
    public Sprite icon;

    public void TestClick() // 버튼을 클릭하면, GameObje에 붙인 수치를 가져옴
    {
        BuffManager.instance.CreateBuff(type, per, duration, icon);
    }
}
