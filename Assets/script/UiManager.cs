using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;
using DG.Tweening;
using Michsky.MUIP;

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
    public TextMeshProUGUI potiont;
    public TextMeshProUGUI potiongold;
    public TextMeshProUGUI curet;
    public TextMeshProUGUI curegold;
    public TextMeshProUGUI newskilltext;
    public RadialSlider mastervol;
    public RadialSlider bgmvol;
    public RadialSlider sevol;
    public Slider hpslider;
    public GameObject restui;
    public GameObject setui;
    public GameObject shopui;
    public GameObject skillui;
    public GameObject getskillui;
    public GameObject[] skills = new GameObject[4];
    public Image black;    
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
    public void clickblack()
    {    
        GameManager.Instance.dindex = 0;
    }
    public void clickrest()
    {
        StartCoroutine("restco");
    }
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
        if(5> GameManager.Instance.potioncnt+pcnt)
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
    public void cureup()
    {
        if (5 > GameManager.Instance.curecnt + ccnt)
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
    #endregion
    void setnewskill(int gold,string skillname)//편의성 함수
    {
        if (GameManager.Instance.gold < gold)
        {
            nosound.Play();
        }
        else
        {
            if(gold == 100)
            {
                GameObject.Find("skillmanager").GetComponent<SkillManager>().color = "<color=#374B5F>";
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
}
