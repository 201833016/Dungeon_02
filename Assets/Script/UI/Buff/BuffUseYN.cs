using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuffUseYN : MonoBehaviour
{
    public static BuffUseYN instance;
    private void Awake()
    {
        instance = this;
    }
    public Image timePrefab;
    public TextMeshProUGUI ATK_Text;
    public TextMeshProUGUI DEF_Text;


    private void Start()
    {
        
        ATKEnabled(false);
        DEFEnabled(false);
    }

    public void ATKEnabled(bool yesno)
    {
        timePrefab.enabled = yesno;
        ATK_Text.enabled = yesno;
    }

    public void DEFEnabled(bool yesno)
    {
        timePrefab.enabled = yesno;
        DEF_Text.enabled = yesno;
    }

}
