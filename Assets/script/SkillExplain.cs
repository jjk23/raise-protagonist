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
        set("�޼����", "���� �޼Ҹ� �� �������� �ݴϴ�.\ntp:20/������:10\n�ΰ����� 2���� ���ظ� �ݴϴ�.");
    }
    public void breakteeth()
    {
        set("���Ϻμ���", "�߼��� ���ϸ� �μ��µ��� �������� \n���ظ� �ݴϴ�.\ntp:20/������:10\n�߼����� 2���� ���ظ� �ݴϴ�.");
    }
    public void firesword()
    {
        set("ȭ���� ��", "�˿� ȭ���� ���� �ο��Ͽ� ���� �����մϴ�.\ntp:20/������:10\n�������� 2���� ���ظ� �ݴϴ�.");
    }
    public void rage()
    {
        set("�г�", "�г븦 ����÷� \n�Ͻ������� ���ݷ��� ũ�� ����ŵ�ϴ�.\ntp:10\n���� �� �� ���� ��+40%");
    }
    public void shutdown()
    {
        set("����", "������ ��Ŭ�� �ɾ� �˾ƿ� ��ŵ�ϴ�.\ntp:20/������:10\n���� �ڽ��� ���� ���̿� ����Ͽ� \n������ ����(�ִ� 100)");
    }
    public void swallowslash()
    {
        set("�����ȯ", "���� ���� ���� ���������� ������ �����մϴ�.\ntp:20/������:30\nġ��Ÿ�� ��ٸ� �⺻������+30");
    }
    public void gladius()
    {
        set("�۶��콺", "�θ��ô� �������� �˼��� �����մϴ�.\ntp:20/������:60\n�ΰ����� 2���� ���ظ� �ݴϴ�.");
    }
    public void sotf()
    {
        set("��������", "��ɰ��� ����ϴµ��� ������� \n���� ��Ȥ�ϰ� �����մϴ�.\ntp:20/������:60\n�߼����� 2���� ���ظ� �ݴϴ�.");
    }
    public void inferno()
    {
        set("���丣��", "�����Ұ� ���� ȭ������ \n���� ������ ���� �¿������ϴ�.\ntp:20/������:60\n�������� 2���� ���ظ� �ݴϴ�.");
    }
    public void potion()
    {
        set("����", "�ִ�ü���� 50%��ŭ ü���� ȸ���մϴ�.\n(�ִ� ���� 5��)");
    }
    public void cureall()
    {
        set("������ġ��", "���ָ� ������ ��� �����̻��� ġ���մϴ�.\n(�ִ� ���� 5��)");
    }
    public void slash()
    {
        set("����", "���� ��Į�� ��������ϴ�.\ntp:10/������:20");
    }
}
