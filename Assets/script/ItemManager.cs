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
    public TextMeshProUGUI pcnttext;//���� ���ǰ��� �ؽ�Ʈ
    public TextMeshProUGUI ccnttext;//���� ������ġ�� ���� �ؽ�Ʈ
    public string color;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        pcnttext.text = GameManager.Instance.potioncnt + "��";
        ccnttext.text = GameManager.Instance.curecnt + "��";
    }
    public void setitem(string itemname,bool getitem)
    {
        int str=0, def=0, spd=0;
        switch (itemname)
        {
            case "õ����":
                GameManager.Instance.armer = itemname;
                def = 5;
                itemicon[1].sprite = iconsprites[0];
                itemnames[1].text = color+"õ����(D���)"+"</color>";
                itemexplain[1].text = "õ���� ���� �����Դϴ�.\n������ ������\n����� �� �ֽ��ϴ�.";
                break;
            case "������":
                GameManager.Instance.weapon = itemname;
                str = 5;
                itemicon[0].sprite = iconsprites[1];
                itemnames[0].text = color + "������(D���)" + "</color>";
                itemexplain[0].text = "���ݸ� ���� �����ĵ�\n�η����� ����\n���� ���Դϴ�.\n�Ǽպ��ٴ� �����ϴ�.";
                break;
            case "��������":
                GameManager.Instance.armer = itemname;
                def = 10;
                itemicon[1].sprite = iconsprites[2];
                itemnames[1].text = color + "��������(C���)" + "</color>";
                itemexplain[1].text = "������ ���� �����Դϴ�.\n���� �ʰ� �����ϼ���.";
                break;
            case "ö��":
                GameManager.Instance.weapon = itemname;
                str = 10;
                itemicon[0].sprite = iconsprites[3];
                itemnames[0].text = color + "ö��(C���)" + "</color>";
                itemexplain[0].text = "ö�� ���� �������� ���Դϴ�.\n������ �����ϱ� �����մϴ�.";
                break;
            case "ö����":
                GameManager.Instance.armer = itemname;
                def = 15;
                itemicon[1].sprite = iconsprites[4];
                itemnames[1].text = color + "ö����(B���)" + "</color>";
                itemexplain[1].text = "ö�� ���� �ܴ��� �����Դϴ�.\n��� ������ ������\n������ ������ �ֽ��ϴ�.";
                break;
            case "�ٽ�Ÿ��ҵ�":
                GameManager.Instance.weapon = itemname;
                str = 15;
                itemicon[0].sprite = iconsprites[5];
                itemnames[0].text = color + "�ٽ�Ÿ��ҵ�(B���)" + "</color>";
                itemexplain[0].text = "ö���� ������ �ɸ°� \n������ ���Դϴ�.\n������ ���� �����\n���� ��Ÿ���\nũ�� �����߽��ϴ�.";
                break;
            case "Ȳ�ð���":
                GameManager.Instance.armer = itemname;
                def = 20;
                itemicon[1].sprite = iconsprites[6];
                itemnames[1].text = color + "Ȳ�ð���(A���)" + "</color>";
                itemexplain[1].text = "Ȳ���� �����鸸��\n ���� �� �ִ� �����Դϴ�.\n������ ö���ʰ��� \n������ �ٸ� ������ �ڶ��ϸ�\n�������� ��¦�Դϴ�.";
                break;
            case "���̾Ƽҵ�":
                GameManager.Instance.weapon = itemname;
                str = 2;
                itemicon[0].sprite = iconsprites[7];
                itemnames[0].text = color + "���̾Ƽҵ�(A���)" + "</color>";
                itemexplain[0].text = "���̾Ƹ��� ����\n���ϵ� ���� ���Դϴ�.\n������ ���� �Ʊ�� �����ο�..";
                break;
            case "�����":
                GameManager.Instance.accessory = itemname;
                str = 5;
                itemicon[2].sprite = iconsprites[8];
                itemnames[2].text = color + "�����(C���)" + "</color>";
                itemexplain[2].text = "���� ������ �����ִ�\n�Ƹ��ٿ� ������Դϴ�.\n���⸦ ���߱��\n�������̱���.";
                break;
            case "�Ҵ�Ʈ":
                GameManager.Instance.accessory = itemname;
                def = 5;
                itemicon[2].sprite = iconsprites[9];
                itemnames[2].text = color + "�Ҵ�Ʈ(C���)" + "</color>";
                itemexplain[2].text = "Ǫ�� ������ �����ִ�\n���� �Ҵ�Ʈ�Դϴ�.\n������ �ٶ󺸸� \n������ �����Ǵ� ����Դϴ�.";
                break;
            case "����":
                GameManager.Instance.accessory = itemname;
                spd = 5;
                itemicon[2].sprite = iconsprites[10];
                itemnames[2].text = color + "����(C���)" + "</color>";
                itemexplain[2].text = "�巡���� ���� ������\n���� �����Դϴ�.\n����� ��µ� \n������ ����� �ʿ��߰���.";
                break;
            case "����":
                GameManager.Instance.accessory = itemname;
                str = 20;
                itemicon[2].sprite = iconsprites[11];
                itemnames[2].text = color + "����(B���)" + "</color>";
                itemexplain[2].text = "� ���ڶ� �� �� �ִ�\n������ �����Դϴ�.\n'�'���ڶ󵵿�.";
                break;
            case "�̽�������":
                GameManager.Instance.armer = itemname;
                def = 30;
                break;
            case "���󸶻�":
                GameManager.Instance.weapon = itemname;
                str = 25;
                spd = 25;
                break;
            case "��ī���ǹ���":
                GameManager.Instance.armer = itemname;
                def = 40;
                break;
            case "�츮���ǽ��ǰ�":
                GameManager.Instance.weapon = itemname;
                str = 40;
                break;
        }
        if(getitem)
        {
            GameManager.Instance.str += str;
            GameManager.Instance.def += def;
            GameManager.Instance.spd += spd;
            if(itemname=="����")
            {
                GameManager.Instance.key = true;
            }
        }
        else
        {
            GameManager.Instance.str -= str;
            GameManager.Instance.def -= def;
            GameManager.Instance.spd -= spd;
            if (itemname == "����")
            {
                GameManager.Instance.key = false;
            }
        }
    }
}
