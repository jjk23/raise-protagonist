using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemManager : MonoBehaviour
{
    public Image[] itemicon = new Image[3];
    public Sprite[] iconsprites = new Sprite[50];
    public TextMeshProUGUI[] itemnames = new TextMeshProUGUI[3];
    public TextMeshProUGUI[] itemexplain = new TextMeshProUGUI[3];
    public TextMeshProUGUI pcnttext;//가방 포션개수 텍스트
    public TextMeshProUGUI ccnttext;//가방 만병통치약 개수 텍스트
    public string color;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        pcnttext.text = GameManager.Instance.potioncnt + "개";
        ccnttext.text = GameManager.Instance.curecnt + "개";
    }
    public void setitem(string itemname,bool getitem)
    {
        int str=0, def=0, spd=0;
        switch (itemname)
        {
            case "천갑옷":
                GameManager.Instance.armer = itemname;
                def = 5;
                itemicon[1].sprite = iconsprites[0];
                itemnames[1].text = color+"천갑옷(D등급)"+"</color>";
                itemexplain[1].text = "천으로 만든 갑옷입니다.\n찰과상 정도는\n방어할 수 있습니다.";
                break;
            case "낡은검":
                GameManager.Instance.weapon = itemname;
                str = 5;
                itemicon[0].sprite = iconsprites[1];
                itemnames[0].text = color + "낡은검(D등급)" + "</color>";
                itemexplain[0].text = "조금만 세게 내리쳐도\n부러질것 같은\n낡은 검입니다.\n맨손보다는 낫습니다.";
                break;
            case "목제갑옷":
                GameManager.Instance.armer = itemname;
                def = 10;
                itemicon[1].sprite = iconsprites[2];
                itemnames[1].text = color + "목제갑옷(C등급)" + "</color>";
                itemexplain[1].text = "나무로 만든 갑옷입니다.\n썩지 않게 조심하세요.";
                break;
            case "철검":
                GameManager.Instance.weapon = itemname;
                str = 10;
                itemicon[0].sprite = iconsprites[3];
                itemnames[0].text = color + "철검(C등급)" + "</color>";
                itemexplain[0].text = "철로 만든 대중적인 검입니다.\n가볍게 공격하기 용이합니다.";
                break;
            case "철갑옷":
                GameManager.Instance.armer = itemname;
                def = 15;
                itemicon[1].sprite = iconsprites[4];
                itemnames[1].text = color + "철갑옷(B등급)" + "</color>";
                itemexplain[1].text = "철로 만든 단단한 갑옷입니다.\n고블린 정도의 공격은\n가볍게 막을수 있습니다.";
                break;
            case "바스타드소드":
                GameManager.Instance.weapon = itemname;
                str = 15;
                itemicon[0].sprite = iconsprites[5];
                itemnames[0].text = color + "바스타드소드(B등급)" + "</color>";
                itemexplain[0].text = "철검을 전투에 걸맞게 \n개량한 검입니다.\n도신이 더욱 길어져\n공격 사거리가\n크게 증가했습니다.";
                break;
            case "황궁갑옷":
                GameManager.Instance.armer = itemname;
                def = 20;
                itemicon[1].sprite = iconsprites[6];
                itemnames[1].text = color + "황궁갑옷(A등급)" + "</color>";
                itemexplain[1].text = "황실의 귀족들만이\n 입을 수 있는 갑옷입니다.\n기존의 철갑옷과는 \n차원이 다른 방어력을 자랑하며\n무엇보다 반짝입니다.";
                break;
            case "다이아소드":
                GameManager.Instance.weapon = itemname;
                str = 2;
                itemicon[0].sprite = iconsprites[7];
                itemnames[0].text = color + "다이아소드(A등급)" + "</color>";
                itemexplain[0].text = "다이아몬드로 만든\n귀하디 귀한 검입니다.\n전투로 쓰기 아까울 정도로요..";
                break;
            case "목걸이":
                GameManager.Instance.accessory = itemname;
                str = 5;
                itemicon[2].sprite = iconsprites[8];
                itemnames[2].text = color + "목걸이(C등급)" + "</color>";
                itemexplain[2].text = "빨간 마석이 박혀있는\n아름다운 목걸이입니다.\n광기를 부추기는\n선혈색이군요.";
                break;
            case "팬던트":
                GameManager.Instance.accessory = itemname;
                def = 5;
                itemicon[2].sprite = iconsprites[9];
                itemnames[2].text = color + "팬던트(C등급)" + "</color>";
                itemexplain[2].text = "푸른 마석이 박혀있는\n예쁜 팬던트입니다.\n가만히 바라보면 \n마음이 안정되는 기분입니다.";
                break;
            case "반지":
                GameManager.Instance.accessory = itemname;
                spd = 5;
                itemicon[2].sprite = iconsprites[10];
                itemnames[2].text = color + "반지(C등급)" + "</color>";
                itemexplain[2].text = "드래곤의 뼈로 제작한\n은빛 반지입니다.\n고룡을 잡는데 \n수많은 희생이 필요했겠죠.";
                break;
            case "열쇠":
                GameManager.Instance.accessory = itemname;
                str = 20;
                itemicon[2].sprite = iconsprites[11];
                itemnames[2].text = color + "열쇠(B등급)" + "</color>";
                itemexplain[2].text = "어떤 상자라도 열 수 있는\n마법의 열쇠입니다.\n'어떤'상자라도요.";
                break;
            case "미스릴갑옷":
                GameManager.Instance.armer = itemname;
                def = 30;
                break;
            case "무라마사":
                GameManager.Instance.weapon = itemname;
                str = 25;
                spd = 25;
                break;
            case "미카엘의방패":
                GameManager.Instance.armer = itemname;
                def = 40;
                break;
            case "우리엘의심판검":
                GameManager.Instance.weapon = itemname;
                str = 40;
                break;
        }
        if(getitem)
        {
            GameManager.Instance.str += str;
            GameManager.Instance.def += def;
            GameManager.Instance.spd += spd;
            if(itemname=="열쇠")
            {
                GameManager.Instance.key = true;
            }
        }
        else
        {
            GameManager.Instance.str -= str;
            GameManager.Instance.def -= def;
            GameManager.Instance.spd -= spd;
            if (itemname == "열쇠")
            {
                GameManager.Instance.key = false;
            }
        }
    }
}
