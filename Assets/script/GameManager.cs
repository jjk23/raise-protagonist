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
    public int enstr;//상대 스탯들
    public int endef;
    public int enspd;
    public int enhp;
    public int potioncnt = 0;
    public int curecnt = 0;
    public int dindex;//대화창 인덱스
    #region 인덱스 설명
    /*
     * 0:vip없이 암시장 출입 대화
     */
    #endregion
    public int dungeonindex;//현재 선택한 던전 인덱스
    public int[] dungeonhard = new int[20];//던전 난이도
    public int infoindex;//현재 전투중인 적 정보 해금 개수
    public int damage = 0;//전투할때 내가 주는 데미지
    public int endamage = 0;//전투할때 받는 데미지
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
    #region 패시브 모음
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
    public string enname;//적 이름
    public Slider enhpslider;
    public TextMeshProUGUI enhpt;

    #region 싱글톤 설정
    //게임매니저의 인스턴스를 담는 전역변수(static 변수이지만 이해하기 쉽게 전역변수라고 하겠다).
    //이 게임 내에서 게임매니저 인스턴스는 이 instance에 담긴 녀석만 존재하게 할 것이다.
    //보안을 위해 private으로.
    private static GameManager instance = null;

    void Awake()
    {
        if (null == instance)
        {
            //이 클래스 인스턴스가 탄생했을 때 전역변수 instance에 게임매니저 인스턴스가 담겨있지 않다면, 자신을 넣어준다.
            instance = this;

            //씬 전환이 되더라도 파괴되지 않게 한다.
            //gameObject만으로도 이 스크립트가 컴포넌트로서 붙어있는 Hierarchy상의 게임오브젝트라는 뜻이지만, 
            //나는 헷갈림 방지를 위해 this를 붙여주기도 한다.
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //만약 씬 이동이 되었는데 그 씬에도 Hierarchy에 GameMgr이 존재할 수도 있다.
            //그럴 경우엔 이전 씬에서 사용하던 인스턴스를 계속 사용해주는 경우가 많은 것 같다.
            //그래서 이미 전역변수인 instance에 인스턴스가 존재한다면 자신(새로운 씬의 GameMgr)을 삭제해준다.
            Destroy(gameObject);
        }
    }

    //게임 매니저 인스턴스에 접근할 수 있는 프로퍼티. static이므로 다른 클래스에서 맘껏 호출할 수 있다.
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
    public void cure()//모든 상태이상 치유
    {
        poison = false;
        paralyze= false;
        blind= false;
        curse=false;
        tired=false;
        blood= false;
        silence= false; 
    }
    public void getdamage(int dmg)//데미지 계산식
    {
        if (!myturn)//내 턴이 아니면
        {
            endamage = enstr + dmg - def;//상대의 데미지
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
    public void enhpset()//적 hp ui적용
    {                
        enhpslider.value = enhp;
        enhpt = GameObject.Find("enhpnum").GetComponent<TextMeshProUGUI>();
        enhpt.text = "" + enhp;
    }
}
