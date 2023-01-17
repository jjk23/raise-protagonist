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
        set("�޼����", "���� �޼Ҹ� �� �������� �ݴϴ�.\n�ΰ����� 2���� ���ظ� �ݴϴ�.\ntp:20/������:10");
    }
    public void breakteeth()
    {
        set("���Ϻμ���", "�߼��� ���ϸ� �μ��µ��� �������� ���ظ� �ݴϴ�.\n�߼����� 2���� ���ظ� �ݴϴ�.\ntp:20/������:10");
    }
    public void firesword()
    {
        set("ȭ���� ��", "�˿� ȭ���� ���� �ο��Ͽ� ���� �����մϴ�.\n�������� 2���� ���ظ� �ݴϴ�.\ntp:20/������:10");
    }
}
