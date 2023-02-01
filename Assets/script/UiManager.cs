using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;
using DG.Tweening;
using Michsky.MUIP;//��� ui���� �������
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
    public TextMeshProUGUI potiont;//���� ���ǰ��� �ؽ�Ʈ
    public TextMeshProUGUI potiongold;
    public TextMeshProUGUI curet;//���� ������ġ�� ���� �ؽ�Ʈ
    public TextMeshProUGUI curegold;
    public TextMeshProUGUI newskilltext;
    public TextMeshProUGUI dayt;//��¥ �ؽ�Ʈ
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
        strt.text = "��: " + GameManager.Instance.str;
        deft.text = "�γ�: " + GameManager.Instance.def;
        spdt.text = "��ø: " + GameManager.Instance.spd;
        goldt.text = "������: " + GameManager.Instance.gold;
        hpt.text = ""+GameManager.Instance.hp;
        levelt.text = "LV: " + GameManager.Instance.level;
        dayt.text = "DAY: " + GameManager.Instance.day;
        #region ��������
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
    #region �Ͻ��� ui
    public void clickblack()
    {    
        GameManager.Instance.dindex = 0;
    }
    #endregion
    #region ���� ui
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
    #region ���� ui
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
            case "�޼����":
                setnewskill(100, name);               
                break;
            case "���Ϻμ���":
                setnewskill(100, name);
                break;
            case "ȭ���ǰ�":
                setnewskill(100, name);
                break;
            case "�г�":
                setnewskill(500, name);
                break;
            case "����":
                setnewskill(500, name);
                break;
            case "�����ȯ":
                setnewskill(500, name);
                break;
            case "�۶��콺":
                setnewskill(700, name);
                break;
            case "��������":
                setnewskill(700, name);
                break;
            case "���丣��":
                setnewskill(700, name);
                break;
        }
    }
    public void buyitem(string name)
    {
        switch (name)
        {
            case "õ����":
                setnewitem(100, name, 1);
                break;
            case "��������":
                setnewitem(200, name, 1);
                break;
            case "ö����":
                setnewitem(500, name, 1);
                break;
            case "Ȳ�ð���":
                setnewitem(1000, name, 1);
                break;
            case "������":
                setnewitem(100, name, 0);
                break;
            case "ö��":
                setnewitem(200, name, 0);
                break;
            case "�ٽ�Ÿ��ҵ�":
                setnewitem(500, name, 0);
                break;
            case "���̾Ƽҵ�":
                setnewitem(1000, name, 0);
                break;
            case "�����":
                setnewitem(300, name, 2);
                break;
            case "�Ҵ�Ʈ":
                setnewitem(300, name, 2);
                break;
            case "����":
                setnewitem(300, name, 2);
                break;
            case "����":
                setnewitem(500, name, 2);
                break;
        }
    }
    #endregion
    #region ��ų ui
    
    public void clickskill()
    {
        skillui.SetActive(true);
        for(int i=0;i<4;i++)
        {
            skills[i].transform.localPosition = new Vector3(-206.6f, -300, 0);
        }
        StartCoroutine("skillmove");
    }
    IEnumerator skillmove()//��ų ��ư Ŭ�������� ��ų ���ٴٴ��ϰ� �ö���°�
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
    #region ���� ui
    public void clickbag()
    {
        StartCoroutine("bagco");
    }
    IEnumerator bagco()//���� ���� �ڷ�ƾ
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
    IEnumerator cbagco()//���� ������ �ڷ�ƾ
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
    #region �нú� ui
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
    #region ���Ǽ� �Լ�
    public void active(GameObject gm)
    {
        setui.transform.localPosition = new Vector3(0, 0, 0);//setui�� ó���� active���·� �־�� �Ҹ� ��� ���� �� active���·� �� �ָ� ���ٰ� ���� ��ġ�� �ǵ����� �۾�
        setui.SetActive(false);
        oksound.Play();
        gm.SetActive(true);
        gm.transform.localScale = new Vector3(0,0,0);
        gm.transform.DOScale(new Vector3(1, 1, 1), 0.5f).SetEase(Ease.OutQuad);
    }
    public void cancel(GameObject gm)//�ش� ���ӿ�����Ʈ�� ��Ȱ��ȭ
    {
        nosound.Play();
        gm.SetActive(false);
    }
    public void getskillcancel(GameObject gm)//get skillui ��ų �ȹ�ﶧ ���
    {
        shopui.SetActive(true);
        nosound.Play();
        gm.SetActive(false);
    }
    void setnewskill(int gold, string skillname)//���Ǽ� �Լ�
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
            newskilltext.text = "����� ���ο� ��ų " + skillname + "��(��) \n�����Ͽ����ϴ�!";
            clickskill();
        }
    }
    void setnewitem(int gold,string Itemname,int index)//index�� �������� ������ �Ǽ��縮���� ����
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
            if(index==0)//������ �ִ� ������ �����ϴ� ����
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
