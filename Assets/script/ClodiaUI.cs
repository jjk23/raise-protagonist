using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.Audio;
using TMPro;

public class ClodiaUI : MonoBehaviour// Ŭ�ε���� ���� �ε��� 0.
{
    public Sprite[] signsprite = new Sprite[3];//0�� ����ǥ. 1�� ����. 2�� ����
    public Image[] signs= new Image[3];
    public int[] signindex= new int[3];
    public int stage;//0���� 4������������ ����.4�������� ���Ŀ� ��ȯ.
    public GameObject honet;
    public GameObject battlestart;
    public GameObject enskill;
    public AudioSource battlebgm;
    public AudioSource forestbgm;
    public AudioSource skillsound;
    public TextMeshProUGUI skillname;
    
    void Start()
    {
        stage = 0;
        GameObject.Find("gamemanager").GetComponent<UiManager>().market.SetActive(false);
        switch(GameManager.Instance.dungeonhard[0])//Ŭ�ε�� ���� ���̵� Ȯ��
        {
            case 0:
                signs[0].sprite = signsprite[1];
                signindex[0] = 1;
                signs[1].sprite = signsprite[0];
                signindex[1] = 0;
                signs[2].sprite = signsprite[0];
                signindex[2] = 0;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void click1()
    {
        switch (GameManager.Instance.dungeonhard[0])
        {
            case 0:
                switch (stage)
                {
                    case 0:
                        setmonster(honet, 50, 2, 2, 8);
                        StartCoroutine("battle","honetco");
                        break; 
                    case 1:
                        break; 
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                }
                break;
            case 1:
                switch (stage)
                {
                    case 0:
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                }
                break;
            case 2:
                switch (stage)
                {
                    case 0:
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                }
                break;
            case 3:
                switch (stage)
                {
                    case 0:
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                }
                break;
            case 4:
                switch (stage)
                {
                    case 0:
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                }
                break;
        }
    }
    public void click2()
    {
        switch (GameManager.Instance.dungeonhard[0])
        {
            case 0:
                switch (stage)
                {
                    case 0:
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                }
                break;
            case 1:
                switch (stage)
                {
                    case 0:
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                }
                break;
            case 2:
                switch (stage)
                {
                    case 0:
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                }
                break;
            case 3:
                switch (stage)
                {
                    case 0:
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                }
                break;
            case 4:
                switch (stage)
                {
                    case 0:
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                }
                break;
        }
    }
    public void click3()
    {
        switch (GameManager.Instance.dungeonhard[0])
        {
            case 0:
                switch (stage)
                {
                    case 0:
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                }
                break;
            case 1:
                switch (stage)
                {
                    case 0:
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                }
                break;
            case 2:
                switch (stage)
                {
                    case 0:
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                }
                break;
            case 3:
                switch (stage)
                {
                    case 0:
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                }
                break;
            case 4:
                switch (stage)
                {
                    case 0:
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                }
                break;
        }
    }
    #region Ŭ�ε�� ���� ��Ʋ �ڷ�ƾ
    IEnumerator battle(string name)//��� ���Ϳ��� �������� ����Ǵ� battle ���۾�
    {
        whofirst();
        while(GameManager.Instance.enhp>0)
        {
            if(GameManager.Instance.myturn==false)
            {
                if (GameManager.Instance.dispell)
                {
                    GameManager.Instance.myturn = true;
                    GameManager.Instance.dispell = false;
                }
                else
                {
                    enskill.SetActive(true);
                    skillsound.Play();
                    StartCoroutine(name);
                }               
            }
        }
        yield return new WaitForSeconds(0);
    }
    IEnumerator honetco()
    {
        int rand = Random.Range(0, 2);
        switch (rand)
        {
            case 0:
                skillname.text = "�Ϲݰ���";
                yield return new WaitForSeconds(1);
                break;
            case 1:
                break;
        }
    }
    #endregion
    #region ���Ǽ� �Լ�
    public void setmonster(GameObject enermy,int enhp,int enstr,int endef,int enspd)//���� ��ȯ �Լ�
    {
        forestbgm.Pause();
        battlebgm.Play();
        StartCoroutine("battlestartco");
        enermy.SetActive(true);
        GameManager.Instance.enhp= enhp;
        GameManager.Instance.enstr= enstr;
        GameManager.Instance.endef= endef;
        GameManager.Instance.enspd= enspd;
        for(int i=1;i<10;i++)
        {
            if(GameObject.Find("info"+i).transform.GetChild(0).gameObject.activeSelf==false)//�ش� ������ ������ �󸶳� �����Ǿ����� Ȯ��
            {
                break;
            }
            else
            {
                GameManager.Instance.infoindex += 1;
            }
        }
        GameObject.Find("eninfo").SetActive(false);//ó���� eninfo�� Ȱ��ȭ �Ǿ��־�� FIND�� �����Ҽ� ����
        GameManager.Instance.isbattle= true;
    }
    public void whofirst()
    {
        if (GameManager.Instance.spd > GameManager.Instance.enspd)
        {
            GameManager.Instance.myturn = true;
        }
        else if (GameManager.Instance.spd < GameManager.Instance.enspd)
        {
            GameManager.Instance.myturn = false;
        }
        else
        {
            int rand = Random.Range(0, 2);//0,1�� �ϳ� ���
            if (rand == 0)
            {
                GameManager.Instance.myturn = true;
            }
            else
            {
                GameManager.Instance.myturn = false;
            }
        }
    }//���� ���� �����
    IEnumerator battlestartco()//�������� ui ���̰�
    {
        battlestart.transform.localPosition = new Vector3(-2000, 0, 0);
        battlestart.transform.DOLocalMoveX(-300, 0.5f);
        yield return new WaitForSeconds(0.5f);
        battlestart.transform.DOLocalMoveX(300, 3);
        yield return new WaitForSeconds(3);
        battlestart.transform.DOLocalMoveX(2000, 0.5f);
    }
    #endregion
}
