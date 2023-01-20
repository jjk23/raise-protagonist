using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{
    public string skillname;
    public string color;
    public TextMeshProUGUI[] skilltext = new TextMeshProUGUI[4];    
    public Image[] skillicon = new Image[4];
    public Sprite[] iconsprites = new Sprite[50];
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
                       
    }
    public void Clickskill(int index)
    {
        if(skillname!=null)//skillname�� uimanager���� ����
        {
            switch (index)
            {
                case 0:
                    GameManager.Instance.skill1 = skillname;
                    skilltext[0].text = color+GameManager.Instance.skill1+"</color>";//color�� uimanager���� ���� �����Ҷ� ����
                    seticon(skillname, skillicon[0]);
                    break;
                case 1:
                    GameManager.Instance.skill2 = skillname;
                    skilltext[1].text = color + GameManager.Instance.skill2 + "</color>";
                    seticon(skillname, skillicon[1]);
                    break;
                case 2:
                    GameManager.Instance.skill3 = skillname;
                    skilltext[2].text = color + GameManager.Instance.skill3 + "</color>";
                    seticon(skillname, skillicon[2]);
                    break;
                case 3:
                    GameManager.Instance.skill4 = skillname;
                    skilltext[3].text = color + GameManager.Instance.skill4 + "</color>";
                    seticon(skillname, skillicon[3]);
                    break;
            }           
            skillname = null;
            GameObject.Find("gamemanager").GetComponent<UiManager>().shopui.SetActive(true);
            GameObject.Find("gamemanager").GetComponent<UiManager>().getskillui.SetActive(false);
            GameObject.Find("gamemanager").GetComponent<UiManager>().skillui.SetActive(false);
        }       
    }
    public void seticon(string skillname,Image icon)//������ �������ִ� ���Ǽ� �Լ�
    {
        switch (skillname)
        {
            case "�޼����":
                icon.sprite = iconsprites[0];
                break;
            case "���Ϻμ���":
                icon.sprite = iconsprites[1];
                break;
            case "ȭ���ǰ�":
                icon.sprite = iconsprites[2];
                break;
            case "�г�":
                icon.sprite = iconsprites[3];
                break;
            case "����":
                icon.sprite = iconsprites[4];
                break;
            case "�����ȯ":
                icon.sprite = iconsprites[5];
                break;
            case "�۶��콺":
                icon.sprite = iconsprites[6];
                break;
            case "��������":
                icon.sprite = iconsprites[7];
                break;
            case "���丣��":
                icon.sprite = iconsprites[8];
                break;
        }
    }
}
