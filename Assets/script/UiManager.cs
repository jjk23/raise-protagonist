using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;
using DG.Tweening;
using Michsky.MUIP;//모던 ui에셋 헤더파일
using UnityEngine.EventSystems;

public class UiManager : MonoBehaviour
{
    public int dinex = 0;
    public int pcnt = 0;
    public int ccnt = 0;
    public AudioSource oksound;
    public AudioSource nosound;
    public AudioSource restsound;
    public AudioSource ticksound;
    public AudioSource villagebgm;
    public AudioSource shopin;
    public AudioSource shopout;
    public AudioMixer mixer;
    public TextMeshProUGUI strt;
    public TextMeshProUGUI deft;
    public TextMeshProUGUI spdt;
    public TextMeshProUGUI goldt;
    public TextMeshProUGUI hpt;
    public TextMeshProUGUI levelt;
    public TextMeshProUGUI potiont;//상점 포션개수 텍스트
    public TextMeshProUGUI potiongold;
    public TextMeshProUGUI curet;//상점 만병통치약 개수 텍스트
    public TextMeshProUGUI curegold;
    public TextMeshProUGUI newskilltext;
    public TextMeshProUGUI dayt;//날짜 텍스트
    public RadialSlider mastervol;
    public RadialSlider bgmvol;
    public RadialSlider sevol;
    public Slider hpslider;
    public GameObject restui;
    public GameObject setui;
    public GameObject shopui;
    public GameObject skillui;
    public GameObject getskillui;
    public GameObject passiveui;
    public GameObject[] skills = new GameObject[4];
    public GameObject[] bags = new GameObject[6];
    public Image black;
    public Sprite bansprite;
    // Start is called before the first frame update
    void Start()
    {
        villagebgm.Play();       
    }

    // Update is called once per frame
    void Update()
    {
        strt.text = "힘: " + GameManager.Instance.str;
        deft.text = "인내: " + GameManager.Instance.def;
        spdt.text = "민첩: " + GameManager.Instance.spd;
        goldt.text = "소지금: " + GameManager.Instance.gold;
        hpt.text = ""+GameManager.Instance.hp;
        levelt.text = "LV: " + GameManager.Instance.level;
        dayt.text = "DAY: " + GameManager.Instance.day;
        #region 볼륨조절
        if (mastervol.SliderValue==0)
        {
            mixer.SetFloat("Master", -80);
        }
        else
        {
            mixer.SetFloat("Master", -25 + (mastervol.SliderValue / 4));
        }
        if (bgmvol.SliderValue == 0)
        {
            mixer.SetFloat("BGM", -80);
        }
        else
        {
            mixer.SetFloat("BGM", -25 + (mastervol.SliderValue / 4));
        }
        if (sevol.SliderValue == 0)
        {
            mixer.SetFloat("SE", -80);
        }
        else
        {
            mixer.SetFloat("SE", -25 + (mastervol.SliderValue / 4));
        }
        #endregion
        hpslider.value = GameManager.Instance.hp;
    }
    #region 암시장 ui
    public void clickblack()
    {    
        GameManager.Instance.dindex = 0;
    }
    #endregion
    #region 여관 ui
    public void clickrest()
    {
        StartCoroutine("restco");
    }
    IEnumerator restco()
    {
        villagebgm.Pause();
        black.gameObject.SetActive(true);
        restsound.Play();
        cancel(restui);
        black.DOFade(1, 4f);
        yield return new WaitForSeconds(5);
        black.DOFade(0, 3f);
        yield return new WaitForSeconds(3);
        black.gameObject.SetActive(false);
        GameManager.Instance.gold -= 50;
        GameManager.Instance.hp = 300;
        GameManager.Instance.cure();
        villagebgm.Play();
    }
    #endregion
    #region 상점 ui
    public void clickshop()
    {
        pcnt = 0;
        potiont.text = "0";
        ccnt = 0;
        curet.text= "0";
        shopin.Play();
        shopui.GetComponent<RectTransform>().DOAnchorPosY(0, 2).SetEase(Ease.OutElastic);
    }
    public void shopexit()
    {
        shopout.Play();
        shopui.transform.DOLocalMove(new Vector3(0, 1500, 0), 1);
    }
    public void potionup()
    {
        if(5> GameManager.Instance.potioncnt+pcnt && GameManager.Instance.gold >= (pcnt+1) * 100)
        {
            pcnt += 1;
            potiont.text = "" + pcnt;
            potiongold.text = "" + pcnt * 100;
            oksound.Play();
        }
        else
        {
            nosound.Play();
        }
    }
    public void potiondown()
    {
        if(pcnt>0)
        {
            pcnt -= 1;
            potiont.text = "" + pcnt;
            potiongold.text = "" + pcnt * 100;
            oksound.Play();
        }
        else
        {
            nosound.Play();
        }
    }
    public void buypotion()
    {
        ccnt = 0;
        curet.text = "" + ccnt;
        curegold.text = "" + ccnt * 100;
        shopin.Play();
        GameManager.Instance.potioncnt = pcnt;
        GameManager.Instance.gold -= pcnt * 100;
        pcnt = 0;
        potiont.text = "" + pcnt;
        potiongold.text = "" + pcnt * 100;
    }
    public void cureup()
    {
        if (5 > GameManager.Instance.curecnt + ccnt&&GameManager.Instance.gold>=(ccnt+1)*100)
        {
            ccnt += 1;
            curet.text = "" + ccnt;
            curegold.text = "" + ccnt * 100;
            oksound.Play();
        }
        else
        {
            nosound.Play();
        }
    }
    public void curedown()
    {
        if (ccnt > 0)
        {
            ccnt -= 1;
            curet.text = "" + ccnt;
            curegold.text = "" + ccnt * 100;
            oksound.Play();
        }
        else
        {
            nosound.Play();
        }
    }
    public void buycure()
    {
        pcnt = 0;
        potiont.text = "" + pcnt;
        potiongold.text = "" + pcnt * 100;
        shopin.Play();
        GameManager.Instance.curecnt= ccnt;
        GameManager.Instance.gold -= ccnt * 100;
        ccnt = 0;
        curet.text = "" + ccnt;
        curegold.text = "" + ccnt * 100;
    }
    public void buyskill(string name)
    {
        switch (name)
        {
            case "급소찌르기":
                setnewskill(100, name);               
                break;
            case "엄니부수기":
                setnewskill(100, name);
                break;
            case "화염의검":
                setnewskill(100, name);
                break;
            case "분노":
                setnewskill(500, name);
                break;
            case "진압":
                setnewskill(500, name);
                break;
            case "제비반환":
                setnewskill(500, name);
                break;
            case "글라디우스":
                setnewskill(700, name);
                break;
            case "약육강식":
                setnewskill(700, name);
                break;
            case "인페르노":
                setnewskill(700, name);
                break;
        }
    }
    public void buyitem(string name)
    {
        switch (name)
        {
            case "천갑옷":
                setnewitem(100, name, 1);
                break;
            case "목제갑옷":
                setnewitem(200, name, 1);
                break;
            case "철갑옷":
                setnewitem(500, name, 1);
                break;
            case "황궁갑옷":
                setnewitem(1000, name, 1);
                break;
            case "낡은검":
                setnewitem(100, name, 0);
                break;
            case "철검":
                setnewitem(200, name, 0);
                break;
            case "바스타드소드":
                setnewitem(500, name, 0);
                break;
            case "다이아소드":
                setnewitem(1000, name, 0);
                break;
            case "목걸이":
                setnewitem(300, name, 2);
                break;
            case "팬던트":
                setnewitem(300, name, 2);
                break;
            case "반지":
                setnewitem(300, name, 2);
                break;
            case "열쇠":
                setnewitem(500, name, 2);
                break;
        }
    }
    #endregion
    #region 스킬 ui
    
    public void clickskill()
    {
        skillui.SetActive(true);
        for(int i=0;i<4;i++)
        {
            skills[i].transform.localPosition = new Vector3(-206.6f, -300, 0);
        }
        StartCoroutine("skillmove");
    }
    IEnumerator skillmove()//스킬 버튼 클릭했을때 스킬 따다다닥하고 올라오는거
    {
        ticksound.Play();
        skills[0].transform.DOLocalMove(new Vector3(-206.6f, 70, 0),0.5f);        
        yield return new WaitForSeconds(0.2f);
        ticksound.Play();
        skills[1].transform.DOLocalMove(new Vector3(-206.6f,-20, 0), 0.5f);
        yield return new WaitForSeconds(0.2f);
        ticksound.Play();
        skills[2].transform.DOLocalMove(new Vector3(-206.6f, -110, 0), 0.5f);
        yield return new WaitForSeconds(0.2f);
        ticksound.Play();
        skills[3].transform.DOLocalMove(new Vector3(-206.6f, -200, 0), 0.5f);
    }
    #endregion
    #region 가방 ui
    public void clickbag()
    {
        StartCoroutine("bagco");
    }
    IEnumerator bagco()//가방 열때 코루틴
    {
        for(int i=0;i<3;i++)
        {
            bags[i].transform.DOMoveY(0, 0.5f);
            ticksound.Play();
            yield return new WaitForSeconds(0.2f);
        }
        bags[3].transform.DOMoveY(1.5f, 0.5f);
        ticksound.Play();
        yield return new WaitForSeconds(0.2f);
        bags[4].transform.DOMoveY(-1f, 0.5f);
        ticksound.Play();
        bags[5].transform.DOMoveY(0, 0.5f);
    }
    public void cancelbag()
    {
        StartCoroutine("cbagco");
    }
    IEnumerator cbagco()//가방 닫을때 코루틴
    {
        for (int i = 0; i < 3; i++)
        {
            bags[i].transform.DOMoveY(-12, 0.5f);
            ticksound.Play();
            yield return new WaitForSeconds(0.2f);
        }
        bags[4].transform.DOMoveY(-10, 0.5f);
        ticksound.Play();
        yield return new WaitForSeconds(0.2f);
        bags[3].transform.DOMoveY(-13, 0.5f);
        ticksound.Play();
        bags[5].transform.DOMoveY(-16, 0.5f);
    }
    #endregion
    #region 패시브 ui
    public void clickpassive()
    {
        if(passiveui.transform.localRotation.z==1)
        {
            ticksound.Play();
            passiveui.transform.DORotate(new Vector3(0, 0, 0), 0.2f);
        }
        else if(passiveui.transform.localRotation.z == 0)
        {
            shopout.Play();
            passiveui.transform.DORotate(new Vector3(0, 0, 180), 2f);
        }
    }
    #endregion
    #region 편의성 함수
    public void active(GameObject gm)
    {
        setui.transform.localPosition = new Vector3(0, 0, 0);//setui는 처음에 active상태로 있어야 소리 재생 가능 즉 active상태로 저 멀리 놨다가 원래 위치로 되돌리는 작업
        setui.SetActive(false);
        oksound.Play();
        gm.SetActive(true);
        gm.transform.localScale = new Vector3(0,0,0);
        gm.transform.DOScale(new Vector3(1, 1, 1), 0.5f).SetEase(Ease.OutQuad);
    }
    public void cancel(GameObject gm)//해당 게임오브젝트를 비활성화
    {
        nosound.Play();
        gm.SetActive(false);
    }
    public void getskillcancel(GameObject gm)//get skillui 스킬 안배울때 사용
    {
        shopui.SetActive(true);
        nosound.Play();
        gm.SetActive(false);
    }
    void setnewskill(int gold, string skillname)//편의성 함수
    {
        if (GameManager.Instance.gold < gold||EventSystem.current.currentSelectedGameObject.tag=="ban")
        {
            nosound.Play();
        }
        else
        {
            EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite = bansprite;
            EventSystem.current.currentSelectedGameObject.tag = "ban";
            if (gold == 100)
            {
                GameObject.Find("skillmanager").GetComponent<SkillManager>().color = "<color=#95FF00>";
            }
            else if (gold == 500)
            {
                GameObject.Find("skillmanager").GetComponent<SkillManager>().color = "<color=#0077FF>";
            }
            else if (gold == 700)
            {
                GameObject.Find("skillmanager").GetComponent<SkillManager>().color = "<color=#BC00FF>";
            }
            shopin.Play();
            shopui.SetActive(false);
            GameManager.Instance.gold -= gold;
            GameObject.Find("skillmanager").GetComponent<SkillManager>().skillname = skillname;
            active(getskillui);
            newskilltext.text = "당신은 새로운 스킬 " + skillname + "을(를) \n습득하였습니다!";
            clickskill();
        }
    }
    void setnewitem(int gold,string Itemname,int index)//index로 무기인지 방어구인지 악세사리인지 구분
    {
        if (GameManager.Instance.gold < gold)
        {
            nosound.Play();
        }
        else
        {
            if(gold==100)
            {
                GameObject.Find("itemmanager").GetComponent<ItemManager>().color = "<color=#FFFFFF>";
            }
            else if (gold == 200||gold==300)
            {
                GameObject.Find("itemmanager").GetComponent<ItemManager>().color = "<color=#95FF00>";
            }
            else if (gold == 500)
            {
                GameObject.Find("itemmanager").GetComponent<ItemManager>().color = "<color=#0077FF>";
            }
            else if (gold == 1000)
            {
                GameObject.Find("itemmanager").GetComponent<ItemManager>().color = "<color=#BC00FF>";
            }
            shopin.Play();
            GameManager.Instance.gold -= gold;
            if(index==0)//기존에 있던 아이템 제거하는 과정
            {
                GameObject.Find("itemmanager").GetComponent<ItemManager>().setitem(GameManager.Instance.weapon, false);
            }
            if(index==1)
            {
                GameObject.Find("itemmanager").GetComponent<ItemManager>().setitem(GameManager.Instance.armer, false);
            }
            if(index==2)
            {
                GameObject.Find("itemmanager").GetComponent<ItemManager>().setitem(GameManager.Instance.accessory, false);
            }            
            GameObject.Find("itemmanager").GetComponent<ItemManager>().setitem(Itemname, true);
        }
    }
    #endregion
}
