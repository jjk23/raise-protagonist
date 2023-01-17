using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkillExplain : MonoBehaviour
{
    public GameObject explain;
    public TextMeshProUGUI skillname;
    public TextMeshProUGUI skillexplain;
    public bool isclick;
    void Update()
    {
        if(isclick)
        {
            explain.SetActive(true);
        }
        else
        {
            explain.SetActive(false);
        }
    }
    public void pointerdown()
    {
        isclick = true;
    }
    public void pointerup()
    {
        isclick = false;
    }
    void set(string name, string ex)
    {
        skillname.text = name;
        skillexplain.text = ex;
    }
    public void critical()
    {
        set("급소찌르기", "적의 급소를 찔러 데미지를 줍니다.\n인간에겐 2배의 피해를 줍니다.\ntp:20/데미지:10");
    }
    public void breakteeth()
    {
        set("엄니부수기", "야수의 엄니를 부수는듯한 공격으로 피해를 줍니다.\n야수에겐 2배의 피해를 줍니다.\ntp:20/데미지:10");
    }
    public void firesword()
    {
        set("화염의 검", "검에 화염의 힘을 부여하여 적을 공격합니다.\n벌레에겐 2배의 피해를 줍니다.\ntp:20/데미지:10");
    }
}
