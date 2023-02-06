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
        set("급소찌르기(C랭크)", "적의 급소를 찔러 데미지를 줍니다.\ntp:20/데미지:10(대인)");
    }
    public void breakteeth()
    {
        set("엄니부수기(C랭크)", "야수의 엄니를 부수는듯한 공격으로 \n피해를 줍니다.\ntp:20/데미지:10(도축)");
    }
    public void firesword()
    {
        set("화염의 검(C랭크)", "검에 화염의 힘을 부여하여 적을 공격합니다.\ntp:20/데미지:10(화염)");
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
        set("글라디우스(A랭크)", "로마시대 검투사의 검술로 공격합니다.\ntp:20/데미지:60(대인)");
    }
    public void sotf()
    {
        set("약육강식(A랭크)", "사냥감을 사냥하는듯한 몸놀림으로 \n적을 잔혹하게 공격합니다.\ntp:20/데미지:60(도축)");
    }
    public void inferno()
    {
        set("인페르노(A랭크)", "지옥불과 같은 화염으로 \n적을 흔적도 없이 태워버립니다.\ntp:20/데미지:60(화염)");
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
    public void berserk()
    {
        set("광전사", "체력이 50 낮아질때마다 힘이 10 상승합니다.");
    }
    public void shielder()
    {
        set("방패병", "상대의 공격을 완벽히 방어하면\n(상대의 공격보다 내 인내가 더 높으면)\n상대에게 그 공격의 10%만큼 피해를 줍니다.");
    }
    public void assassin()
    {
        set("어쎄신", "민첩에 비례해서 회피확률과 치명타확률이 상승합니다.\n(회피는 10당 5%. 치명타는 10당 10%)");
    }
    public void champion()
    {
        set("챔피언", "모든 스탯이 5 상승합니다.");
    }
    public void bughunter()
    {
        set("벌레 학살자", "독,마비,실명에 대해 면역이 됩니다.");
    }
    public void beasthunter()
    {
        set("도살자", "체력이 50%이하인 적에게 20%추가 피해를 줍니다.");
    }
    public void devilhunter()
    {
        set("악마 사냥꾼", "<마계>에서의 모든 스탯이 7 상승합니다.");
    }
    public void vip()
    {
        set("V.I.P", "<암시장>을 이용할 수 있습니다.");
    }
    public void natrualheal()
    {
        set("자연치유", "매 전투가 끝날때마다 체력을 50회복합니다.");
    }
    public void adrenalin()
    {
        set("아드레날린", "죽음에 이르는 피해를 받으면 1회 체력을 50회복합니다.\n<미사용>");
    }
    public void legend()
    {
        set("전설", "적의 공격으로 받는 모든 피해가 20%감소합니다.\n이후 받는 5이하의 피해는 무시합니다.");
    }
    public void sageeye()
    {
        set("현자의 눈", "상대의 숨겨진 정보들을 꿰뚫어봅니다.");
    }
    public void grideye()
    {
        set("탐식의 눈", "상대를 처치하면 적의 레벨에 따라 무작위 스탯이 상승합니다.\n(1~4레벨은 1. 5~7레벨은 2. 8~10레벨은 3.)");
    }
    public void raphael()
    {
        set("라파엘의 가호", "모든 상태이상에 대해 면역이 됩니다.");
    }
    public void dispel()
    {
        set("디스펠", "(한 전투당 한번 사용 가능.아이콘 클릭으로 사용.)\n상대의 다음 행동을 무효로 합니다.");
    }
    #endregion
}
