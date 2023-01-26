using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemManager : MonoBehaviour
{
    public Image[] itemicon = new Image[3];
    public Sprite[] iconsprites = new Sprite[50];
    public TextMeshProUGUI[] itemname = new TextMeshProUGUI[3];
    public TextMeshProUGUI[] itemexplain = new TextMeshProUGUI[3];
    public TextMeshProUGUI pcnttext;//���� ���ǰ��� �ؽ�Ʈ
    public TextMeshProUGUI ccnttext;//���� ������ġ�� ���� �ؽ�Ʈ
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
                break;
            case "������":
                GameManager.Instance.weapon = itemname;
                str = 5;
                break;
            case "��������":
                GameManager.Instance.armer = itemname;
                def = 10;
                break;
            case "ö��":
                GameManager.Instance.weapon = itemname;
                str = 10;
                break;
            case "ö����":
                GameManager.Instance.armer = itemname;
                def = 15;
                break;
            case "�ٽ�Ÿ��ҵ�":
                GameManager.Instance.weapon = itemname;
                str = 15;
                break;
            case "Ȳ�ð���":
                GameManager.Instance.armer = itemname;
                def = 20;
                break;
            case "���̾Ƽҵ�":
                GameManager.Instance.weapon = itemname;
                str = 20;
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
        }
        else
        {
            GameManager.Instance.str -= str;
            GameManager.Instance.def -= def;
            GameManager.Instance.spd -= spd;
        }
    }
}
