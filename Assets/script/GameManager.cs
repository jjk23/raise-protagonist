using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int level = 1;
    public int exp = 0;
    public int maxexp = 10;//10,20,30,40...90
    public int str = 5;
    public int def = 5;
    public int spd = 5;
    public int hp = 50;
    public int tp = 0;
    public int gold = 10000;
    public int day = 1;
    public int enstr;//��� ���ȵ�
    public int endef;
    public int enspd;
    public int enhp;
    public int potioncnt = 0;
    public int curecnt = 0;
    public int dindex;//��ȭâ �ε���
    #region �ε��� ����
    /*
     * 0:vip���� �Ͻ��� ���� ��ȭ
     */
    #endregion
    public int dungeonindex;//���� ������ ���� �ε���
    public int[] dungeonhard = new int[20];//���� ���̵�
    public int infoindex;//���� �������� �� ���� �ر� ����
    public int damage = 0;//�����Ҷ� ���� �ִ� ������
    public int endamage = 0;//�����Ҷ� �޴� ������
    public bool poison=false;
    public bool paralyze=false;
    public bool tired=false;
    public bool blind = false;
    public bool blood = false;
    public bool silence = false;
    public bool curse = false;
    public bool key = false;
    public bool isbattle=false;
    public bool dispell = false;
    public bool myturn;
    #region �нú� ����
    public bool pberserk = false;
    public bool pshielder = false;
    public bool passassin = false;
    public bool pbughunter = false;
    public bool pbeasthunter = false;
    public bool pdevilhunter = false;
    public bool pvip = false;
    public bool pnaturalheal = false;
    public bool padrenalin = false;
    public bool plegend = false;
    public bool psageeye = false;
    public bool pgrideye = false;
    public bool praphael = false;
    #endregion
    public string skill1;
    public string skill2;
    public string skill3;  
    public string skill4;
    public string weapon;
    public string armer;
    public string accessory;
    public string enname;//�� �̸�
    public Slider enhpslider;
    public TextMeshProUGUI enhpt;

    #region �̱��� ����
    //���ӸŴ����� �ν��Ͻ��� ��� ��������(static ���������� �����ϱ� ���� ����������� �ϰڴ�).
    //�� ���� ������ ���ӸŴ��� �ν��Ͻ��� �� instance�� ��� �༮�� �����ϰ� �� ���̴�.
    //������ ���� private����.
    private static GameManager instance = null;

    void Awake()
    {
        if (null == instance)
        {
            //�� Ŭ���� �ν��Ͻ��� ź������ �� �������� instance�� ���ӸŴ��� �ν��Ͻ��� ������� �ʴٸ�, �ڽ��� �־��ش�.
            instance = this;

            //�� ��ȯ�� �Ǵ��� �ı����� �ʰ� �Ѵ�.
            //gameObject�����ε� �� ��ũ��Ʈ�� ������Ʈ�μ� �پ��ִ� Hierarchy���� ���ӿ�����Ʈ��� ��������, 
            //���� �򰥸� ������ ���� this�� �ٿ��ֱ⵵ �Ѵ�.
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //���� �� �̵��� �Ǿ��µ� �� ������ Hierarchy�� GameMgr�� ������ ���� �ִ�.
            //�׷� ��쿣 ���� ������ ����ϴ� �ν��Ͻ��� ��� ������ִ� ��찡 ���� �� ����.
            //�׷��� �̹� ���������� instance�� �ν��Ͻ��� �����Ѵٸ� �ڽ�(���ο� ���� GameMgr)�� �������ش�.
            Destroy(gameObject);
        }
    }

    //���� �Ŵ��� �ν��Ͻ��� ������ �� �ִ� ������Ƽ. static�̹Ƿ� �ٸ� Ŭ�������� ���� ȣ���� �� �ִ�.
    public static GameManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }
    #endregion
    public void cure()//��� �����̻� ġ��
    {
        poison = false;
        paralyze= false;
        blind= false;
        curse=false;
        tired=false;
        blood= false;
        silence= false; 
    }
    public void getdamage(int dmg)//������ ����
    {
        if (!myturn)//�� ���� �ƴϸ�
        {
            endamage = enstr + dmg - def;//����� ������
            if (endamage < 0)
            {
                endamage = 0;
            }
            hp -= endamage;
        }
        else if (myturn)
        {
            damage = str + dmg - endef;
            if (damage < 0)
            {
                damage = 0;
            }
            enhp-= damage;
        }
    }
    public void enhpset()//�� hp ui����
    {                
        enhpslider.value = enhp;
        enhpt = GameObject.Find("enhpnum").GetComponent<TextMeshProUGUI>();
        enhpt.text = "" + enhp;
    }
}
