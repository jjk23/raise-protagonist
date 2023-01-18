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
        set("급소찌르기", "적의 급소를 찔러 데미지를 줍니다.\ntp:20/데미지:10\n인간에겐 2배의 피해를 줍니다.");
    }
    public void breakteeth()
    {
        set("엄니부수기", "야수의 엄니를 부수는듯한 공격으로 \n피해를 줍니다.\ntp:20/데미지:10\n야수에겐 2배의 피해를 줍니다.");
    }
    public void firesword()
    {
        set("화염의 검", "검에 화염의 힘을 부여하여 적을 공격합니다.\ntp:20/데미지:10\n벌레에겐 2배의 피해를 줍니다.");
    }
    public void rage()
    {
        set("분노", "분노를 끌어올려 \n일시적으로 공격력을 크게 향상시킵니다.\ntp:10\n다음 한 턴 동안 힘+40%");
    }
    public void shutdown()
    {
        set("진압", "적에게 태클을 걸어 넉아웃 시킵니다.\ntp:20/데미지:10\n적과 자신의 방어력 차이에 비례하여 \n데미지 증가(최대 100)");
    }
    public void swallowslash()
    {
        set("제비반환", "제비를 베는 듯한 움직임으로 빠르게 공격합니다.\ntp:20/데미지:30\n치명타가 뜬다면 기본데미지+30");
    }
    public void gladius()
    {
        set("글라디우스", "로마시대 검투사의 검술로 공격합니다.\ntp:20/데미지:60\n인간에겐 2배의 피해를 줍니다.");
    }
    public void sotf()
    {
        set("약육강식", "사냥감을 사냥하는듯한 몸놀림으로 \n적을 잔혹하게 공격합니다.\ntp:20/데미지:60\n야수에겐 2배의 피해를 줍니다.");
    }
    public void inferno()
    {
        set("인페르노", "지옥불과 같은 화염으로 \n적을 흔적도 없이 태워버립니다.\ntp:20/데미지:60\n벌레에겐 2배의 피해를 줍니다.");
    }
    public void potion()
    {
        set("포션", "최대체력의 50%만큼 체력을 회복합니다.\n(최대 수량 5개)");
    }
    public void cureall()
    {
        set("만병통치약", "저주를 제외한 모든 상태이상을 치유합니다.\n(최대 수량 5개)");
    }
    public void slash()
    {
        set("참격", "적을 단칼에 베어버립니다.\ntp:10/데미지:20");
    }
}
