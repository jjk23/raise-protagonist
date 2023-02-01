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
            case "���":
                set("��ų�� �������� �ʽ��ϴ�!", "�����̳� �������� ���� ��ų�� �߰��ϼ���!");
                break;
            case "����":
                slash();
                break;
            case "����ȣ��":
                break;
            case "���ٲ���":
                break;
            case "�Ͻ�":
                break;
            case "ƨ�ܳ���":
                break;
            case "õ����ġ��":
                break;
            case "�������":
                break;
            case "����Ŀ":
                break;
            case "���Ź���":
                break;
            case "������ ��":
                break;
            case "�޼����":
                critical();
                break;
            case "���Ϻμ���":
                breakteeth();
                break;
            case "ȭ���ǰ�":
                firesword();
                break;
            case "�г�":
                rage();
                break;
            case "����":
                shutdown();
                break;
            case "�����ȯ":
                swallowslash();
                break;
            case "�۶��콺":
                gladius();
                break;
            case "��������":
                sotf();
                break;
            case "���丣��":
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
    #region ��ų����
    public void critical()
    {
        set("�޼����(C��ũ)", "���� �޼Ҹ� �� �������� �ݴϴ�.\ntp:20/������:10\n�ΰ����� 2���� ���ظ� �ݴϴ�.");
    }
    public void breakteeth()
    {
        set("���Ϻμ���(C��ũ)", "�߼��� ���ϸ� �μ��µ��� �������� \n���ظ� �ݴϴ�.\ntp:20/������:10\n�߼����� 2���� ���ظ� �ݴϴ�.");
    }
    public void firesword()
    {
        set("ȭ���� ��(C��ũ)", "�˿� ȭ���� ���� �ο��Ͽ� ���� �����մϴ�.\ntp:20/������:10\n�������� 2���� ���ظ� �ݴϴ�.");
    }
    public void rage()
    {
        set("�г�(B��ũ)", "�г븦 ����÷� \n�Ͻ������� ���ݷ��� ũ�� ����ŵ�ϴ�.\ntp:10\n���� �� �� ���� ��+40%");
    }
    public void shutdown()
    {
        set("����(B��ũ)", "������ ��Ŭ�� �ɾ� �˾ƿ� ��ŵ�ϴ�.\ntp:20/������:10\n���� �ڽ��� ���� ���̿� ����Ͽ� \n������ ����(�ִ� 100)");
    }
    public void swallowslash()
    {
        set("�����ȯ(B��ũ)", "���� ���� ���� ���������� ������ �����մϴ�.\ntp:20/������:30\nġ��Ÿ�� ��ٸ� �⺻������+30");
    }
    public void gladius()
    {
        set("�۶��콺(A��ũ)", "�θ��ô� �������� �˼��� �����մϴ�.\ntp:20/������:60\n�ΰ����� 2���� ���ظ� �ݴϴ�.");
    }
    public void sotf()
    {
        set("��������(A��ũ)", "��ɰ��� ����ϴµ��� ������� \n���� ��Ȥ�ϰ� �����մϴ�.\ntp:20/������:60\n�߼����� 2���� ���ظ� �ݴϴ�.");
    }
    public void inferno()
    {
        set("���丣��(A��ũ)", "�����Ұ� ���� ȭ������ \n���� ������ ���� �¿������ϴ�.\ntp:20/������:60\n�������� 2���� ���ظ� �ݴϴ�.");
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
        set("����(D��ũ)", "���� ��Į�� ��������ϴ�.\ntp:10/������:20");
    }
    public void key()
    {
        set("����", "���� óġ������ ��� ��差�� 20%�����մϴ�.");
    }
    #endregion
}
