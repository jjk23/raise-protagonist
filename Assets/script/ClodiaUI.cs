using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.Audio;
using TMPro;

public class ClodiaUI : MonoBehaviour// 클로디아의 숲은 인덱스 0.
{
    public Sprite[] signsprite = new Sprite[3];//0은 물음표. 1은 몬스터. 2는 강적
    public Image[] signs= new Image[3];
    public int[] signindex= new int[3];
    public int stage;//0부터 4스테이지까지 있음.4스테이지 이후엔 귀환.
    public GameObject honet;
    public GameObject battlestart;
    public GameObject enskill;
    public AudioSource battlebgm;
    public AudioSource forestbgm;
    public AudioSource skillsound;
    public TextMeshProUGUI skillname;
    public bool isco = false;
    
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
                        StartCoroutine("battle","honetco");//코루틴은 이렇게 쉼표로 구분해서 매개변수를 넣음
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
    #region 클로디아 몬스터 배틀 코루틴
    IEnumerator battle(string name)//모든 몬스터에게 공통으로 적용되는 battle 밑작업. battle 한번 시작하면 몬스터체력 0될때까지 무한루프
    {
        GameManager.Instance.enhpset();
        yield return new WaitForSeconds(4);
        GameManager.Instance.enname = name.Substring(0,name.Length - 2);//뒤에 있는 co를 잘라서 몬스터 이름을 파악
        whofirst();
        while (GameManager.Instance.enhp > 0)
        {
            if (GameManager.Instance.myturn == false && !SkillManager.Instance.isco)//isco는 코루틴이 진행중인지 확인하고 진행 안하면 시행한다는 뜻.
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
                    SkillManager.Instance.isco = true;
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(0);
    }
    IEnumerator honetco()
    {
        int rand = Random.Range(0, 2);
        Debug.Log("honetco");
        switch (rand)
        {
            case 0:
                enskill.SetActive(true);
                skillname.text = "일반공격";
                yield return new WaitForSeconds(0.5f);
                enskill.SetActive(false);
                SkillManager.Instance.StartCoroutine("Slash");
                break;
            case 1:
                enskill.SetActive(true);
                skillname.text = "날갯짓";
                yield return new WaitForSeconds(0.5f);
                enskill.SetActive(false);
                SkillManager.Instance.StartCoroutine("Wind");
                break;
        }
    }
    #endregion
    #region 편의성 함수
    public void setmonster(GameObject enermy,int enhp,int enstr,int endef,int enspd)//몬스터 소환 함수
    {
        forestbgm.Pause();
        battlebgm.Play();
        StartCoroutine("battlestartco");
        enermy.SetActive(true);
        GameManager.Instance.enhpslider = GameObject.Find("enermyhp").GetComponent<Slider>();
        GameManager.Instance.enhpslider.maxValue = enhp;
        GameManager.Instance.enhp= enhp;
        GameManager.Instance.enstr= enstr;
        GameManager.Instance.endef= endef;
        GameManager.Instance.enspd= enspd;
        for (int i = 1; i < 10; i++)
        {
            if (GameObject.Find("info" + i).transform.GetChild(0).gameObject.activeSelf == false)//해당 몬스터의 정보가 얼마나 열람되었는지 확인
            {
                break;
            }
            else
            {
                GameManager.Instance.infoindex += 1;
            }
            if (i > 10)
            {
                Debug.Log("a");
                break;
            }
        }
        GameObject.Find("eninfo").SetActive(false);//처음에 eninfo가 활성화 되어있어야 FIND를 수행할수 있음
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
            int rand = Random.Range(0, 2);//0,1중 하나 출력
            if (rand == 0)
            {
                GameManager.Instance.myturn = true;
            }
            else
            {
                GameManager.Instance.myturn = false;
            }
        }
    }//누가 선턴 잡는지
    IEnumerator battlestartco()//전투개시 ui 보이게
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
