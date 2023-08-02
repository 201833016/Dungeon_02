using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleAAA : MonoBehaviour
{
    [SerializeField] private TempCardSelectPageSO aaa; // 사용될 카드 덱
    [SerializeField] private TempCardSelectPageSO bbb; // 사용되지 않을 덱

    public void SampleEEE()  // 선택한 카드를 덱 리스트에서 제거
    {
        Debug.Log($"{aaa.cardSelects.Count}");

        aaa.cardSelects = bbb.cardSelects;  // 저장된 덱에서 초기화후 집어 넣기
        // 근데 이러면 저장 데이터와 연동되서 기존 덱을 지우면 저장 덱도 지워짐.
        
    } 
}
