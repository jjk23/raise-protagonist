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
    public void skillfind(string s)
    {
        switch (s)
        {
            case "잠금":
                set("스킬이 존재하지 않습니다!", "상점이나 레벨업을 통해 스킬을 추가하세요!");
                break;
            case "참격":
                slash();
                break;
            case "단전호흡":
                break;
            case "힘줄끊기":
                break;
            case "암습":
                break;
            case "튕겨내기":
                break;
            case "천사의치유":
                break;
            case "일점찌르기":
                break;
            case "버서커":
                break;
            case "어쎄신무브":
                break;
            case "여정의 검":
                break;
            case "급소찌르기":
                critical();
                break;
            case "엄니부수기":
                breakteeth();
                break;
            case "화염의검":
                firesword();
                break;
            case "분노":
                rage();
                break;
            case "진압":
                shutdown();
                break;
            case "제비반환":
                swallowslash();
                break;
            case "글라디우스":
                gladius();
                break;
            case "약육강식":
                sotf();
                break;
            case "인페르노":
                inferno();
                break;
        }

    }
    public void skill1ex()
    {
        skillfind(GameManager.Instance.skill1);
    }
    public void skill2ex()
    {
        skillfind(GameManager.Instance.skill2);
    }
    public void skill3ex()
    {
        skillfind(GameManager.Instance.skill3);
    }
    public void skill4ex()
    {
        skillfind(GameManager.Instance.skill4);
    }
    #region 스킬설명
    public void critical()
    {
        set("급소찌르기(C랭크)", "적의 급소를 찔러 데미지를 줍니다.\ntp:20/데미지:10\n인간에겐 2배의 피해를 줍니다.");
    }
    public void breakteeth()
    {
        set("엄니부수기(C랭크)", "야수의 엄니를 부수는듯한 공격으로 \n피해를 줍니다.\ntp:20/데미지:10\n야수에겐 2배의 피해를 줍니다.");
    }
    public void firesword()
    {
        set("화염의 검(C랭크)", "검에 화염의 힘을 부여하여 적을 공격합니다.\ntp:20/데미지:10\n벌레에겐 2배의 피해를 줍니다.");
    }
    public void rage()
    {
        set("분노(B랭크)", "분노를 끌어올려 \n일시적으로 공격력을 크게 향상시킵니다.\ntp:10\n다음 한 턴 동안 힘+40%");
    }
    public void shutdown()
    {
        set("진압(B랭크)", "적에게 태클을 걸어 넉아웃 시킵니다.\ntp:20/데미지:10\n적과 자신의 방어력 차이에 비례하여 \n데미지 증가(최대 100)");
    }
    public void swallowslash()
    {
        set("제비반환(B랭크)", "제비를 베는 듯한 움직임으로 빠르게 공격합니다.\ntp:20/데미지:30\n치명타가 뜬다면 기본데미지+30");
    }
    public void gladius()
    {
        set("글라디우스(A랭크)", "로마시대 검투사의 검술로 공격합니다.\ntp:20/데미지:60\n인간에겐 2배의 피해를 줍니다.");
    }
    public void sotf()
    {
        set("약육강식(A랭크)", "사냥감을 사냥하는듯한 몸놀림으로 \n적을 잔혹하게 공격합니다.\ntp:20/데미지:60\n야수에겐 2배의 피해를 줍니다.");
    }
    public void inferno()
    {
        set("인페르노(A랭크)", "지옥불과 같은 화염으로 \n적을 흔적도 없이 태워버립니다.\ntp:20/데미지:60\n벌레에겐 2배의 피해를 줍니다.");
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
        set("참격(D랭크)", "적을 단칼에 베어버립니다.\ntp:10/데미지:20");
    }
    public void key()
    {
        set("열쇠", "적을 처치했을때 얻는 골드량이 20%증가합니다.");
    }
    #endregion
}
