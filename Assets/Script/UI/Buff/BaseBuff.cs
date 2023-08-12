using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BaseBuff : MonoBehaviour
{
    public string type;
    public float percentage;
    public float duration;
    public float current_Time;
    public Image icon;
    [SerializeField] private TextMeshProUGUI coolTime_Text;
    public BuffUseYN buffyn;
    public TextMeshProUGUI tempText;

    bool endATK, endDEF = false;
    private void Awake()
    {
        tempText = GameObject.Find("ABCDEFG").GetComponent<TextMeshProUGUI>();
        buffyn.ATK_Text = GameObject.Find("ATKCheckText").GetComponent<TextMeshProUGUI>();
        buffyn.DEF_Text = GameObject.Find("DEFCheckText").GetComponent<TextMeshProUGUI>();
    }


    public void Init(string type, float per, float dur)
    {
        this.type = type;
        percentage = per;
        duration = dur;
        current_Time = duration;
        icon.fillAmount = 1;
        coolTime_Text = GetComponentInChildren<TextMeshProUGUI>();

        Excute();
    }
    WaitForSeconds seconds = new WaitForSeconds(0.1f);
    public void Excute()
    {
        PlayerBuffData.instance.onBuff.Add(this);
        PlayerBuffData.instance.ChooseBuff(type);
        StartCoroutine(Activation());
    }

    IEnumerator Activation()
    {
        while (current_Time > 0)
        {
            current_Time -= 0.1f;
            icon.fillAmount = current_Time / duration;
            coolTime_Text.text = current_Time.ToString("F0");
            if (type == "ATK")
            {
                BuffManager.instance.onATK = true;
                buffyn.ATK_Text.text = current_Time.ToString("F1") + "초";
                if (buffyn.ATK_Text.text == "0.0초")
                {
                    endATK = true;
                }
                
            }
            if (type == "DEF")
            {
                BuffManager.instance.onDEF = true;
                buffyn.DEF_Text.text = current_Time.ToString("F1") + "초";
                tempText.text = current_Time.ToString("F1") + "초";
                if (buffyn.DEF_Text.text == "0.0초")
                {
                    endDEF = true;
                }
                
            }
            yield return seconds;
        }
        if (BuffManager.instance.onATK && endATK == true)
        {
            endATK = false;
            BuffManager.instance.onATK = false;
            BuffUseYN.instance.ATKEnabled(false);
        }
        if (BuffManager.instance.onDEF && endDEF == true)
        {
            endDEF = false;
            BuffManager.instance.onDEF = false;
            BuffUseYN.instance.DEFEnabled(false);
        }
        icon.fillAmount = 0;
        current_Time = 0;
        coolTime_Text.enabled = false;
        

        DeActivation();
    }

    public void DeActivation()
    {
        PlayerBuffData.instance.onBuff.Remove(this);
        PlayerBuffData.instance.ChooseBuff(type);
        Destroy(gameObject);
    }


}
