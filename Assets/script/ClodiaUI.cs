using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClodiaUI : MonoBehaviour// 클로디아의 숲은 인덱스 0.
{
    public Sprite[] signsprite = new Sprite[3];//0은 물음표. 1은 몬스터. 2는 강적
    public Image[] signs= new Image[3];
    public int[] signindex= new int[3];
    public int stage;//0부터 4스테이지까지 있음.4스테이지 이후엔 귀환.
    public GameObject honet;
    
    void Start()
    {
        stage = 0;
        GameObject.Find("gamemanager").GetComponent<UiManager>().market.SetActive(false);
        switch(GameManager.Instance.dungeonhard[0])//클로디아 숲의 난이도 확인
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
    #region 편의성 함수
    public void setmonster(GameObject enermy,int enhp,int enstr,int endef,int enspd)
    {
        enermy.SetActive(true);
        GameManager.Instance.enhp= enhp;
        GameManager.Instance.enstr= enstr;
        GameManager.Instance.endef= endef;
        GameManager.Instance.enspd= enspd;
        for(int i=1;i<10;i++)
        {
            if(GameObject.Find("info"+i).transform.GetChild(0).gameObject.activeSelf==false)
            {
                break;
            }
            else
            {
                GameManager.Instance.infoindex += 1;
            }
        }
        GameObject.Find("eninfo").SetActive(false);
        Debug.Log(GameManager.Instance.infoindex);
        GameManager.Instance.isbattle= true;
    }
    #endregion
}
