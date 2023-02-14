using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{
    private static SkillManager instance = null;
    public string skillname;
    public string color;
    public TextMeshProUGUI[] skilltext = new TextMeshProUGUI[4];    
    public Image[] skillicon = new Image[4];
    public Image red;
    public Sprite[] iconsprites = new Sprite[50];
    public AudioSource pucksound;
    public GameObject[] passives = new GameObject[15];
    public GameObject[] passivelock = new GameObject[15];
    public GameObject slash;
    // Start is called before the first frame update
    public static SkillManager Instance
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
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {        
        skillname = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Clickskill(int index)
    {
        if(skillname!=null)//skillname은 uimanager에서 설정. 스킬 습득가능한지 확인하는과정
        {
            switch (index)
            {
                case 0:
                    GameManager.Instance.skill1 = skillname;
                    skilltext[0].text = color+GameManager.Instance.skill1+"</color>";//color는 uimanager에서 상점 구매할때 설정
                    seticon(skillname, skillicon[0]);
                    break;
                case 1:
                    GameManager.Instance.skill2 = skillname;
                    skilltext[1].text = color + GameManager.Instance.skill2 + "</color>";
                    seticon(skillname, skillicon[1]);
                    break;
                case 2:
                    GameManager.Instance.skill3 = skillname;
                    skilltext[2].text = color + GameManager.Instance.skill3 + "</color>";
                    seticon(skillname, skillicon[2]);
                    break;
                case 3:
                    GameManager.Instance.skill4 = skillname;
                    skilltext[3].text = color + GameManager.Instance.skill4 + "</color>";
                    seticon(skillname, skillicon[3]);
                    break;
            }           
            skillname = null;
            GameObject.Find("gamemanager").GetComponent<UiManager>().shopui.SetActive(true);
            GameObject.Find("gamemanager").GetComponent<UiManager>().getskillui.SetActive(false);
            GameObject.Find("gamemanager").GetComponent<UiManager>().skillui.SetActive(false);
        }       
    }
    public void getpassive(string passivename)
    {
        switch (passivename)
        {
            case "광전사":
                passives[0].SetActive(true);
                passivelock[0].SetActive(false);
                GameManager.Instance.pberserk = true;
                break;
            case "방패병":
                passives[1].SetActive(true);
                passivelock[1].SetActive(false);
                GameManager.Instance.pshielder = true;
                break;
            case "어쎄신":
                passives[2].SetActive(true);
                passivelock[2].SetActive(false);
                GameManager.Instance.passassin = true;
                break;
            case "챔피언":
                passives[3].SetActive(true);
                passivelock[3].SetActive(false);
                break;
            case "벌레학살자":
                passives[4].SetActive(true);
                passivelock[4].SetActive(false);
                GameManager.Instance.pbughunter = true;
                break;
            case "도살자":
                passives[5].SetActive(true);
                passivelock[5].SetActive(false);
                GameManager.Instance.pbeasthunter = true;
                break;
            case "악마사냥꾼":
                passives[6].SetActive(true);
                passivelock[6].SetActive(false);
                GameManager.Instance.pdevilhunter = true;
                break;
            case "VIP":
                passives[7].SetActive(true);
                passivelock[7].SetActive(false);
                GameManager.Instance.pvip = true;
                break;
            case "자연치유":
                passives[8].SetActive(true);
                passivelock[8].SetActive(false);
                GameManager.Instance.pnaturalheal = true;
                break;
            case "아드레날린":
                passives[9].SetActive(true);
                passivelock[9].SetActive(false);
                GameManager.Instance.padrenalin = true;
                break;
            case "전설":
                passives[10].SetActive(true);
                passivelock[10].SetActive(false);
                GameManager.Instance.plegend = true;              
                break;
            case "현자의눈":
                passives[11].SetActive(true);
                passivelock[11].SetActive(false);
                GameManager.Instance.psageeye = true;
                break;
            case "탐식의눈":
                passives[12].SetActive(true);
                passivelock[12].SetActive(false);
                GameManager.Instance.pgrideye = true;
                break;
            case "라파엘의가호":
                passives[13].SetActive(true);
                passivelock[13].SetActive(false);
                GameManager.Instance.praphael = true;
                break;
            case "디스펠":
                passives[14].SetActive(true);
                passivelock[14].SetActive(false);
                break;
        }

    }
    public void seticon(string skillname,Image icon)//아이콘 설정해주는 편의성 함수
    {
        switch (skillname)
        {
            case "급소찌르기":
                icon.sprite = iconsprites[0];
                break;
            case "엄니부수기":
                icon.sprite = iconsprites[1];
                break;
            case "화염의검":
                icon.sprite = iconsprites[2];
                break;
            case "분노":
                icon.sprite = iconsprites[3];
                break;
            case "진압":
                icon.sprite = iconsprites[4];
                break;
            case "제비반환":
                icon.sprite = iconsprites[5];
                break;
            case "글라디우스":
                icon.sprite = iconsprites[6];
                break;
            case "약육강식":
                icon.sprite = iconsprites[7];
                break;
            case "인페르노":
                icon.sprite = iconsprites[8];
                break;
        }
    }
    IEnumerator Slash()
    {
        var clone = Instantiate(slash, transform);
        Destroy(clone, 3f);
        yield return new WaitForSeconds(1);
        StartCoroutine("damageco");
        if(GameManager.Instance.myturn)
        {
            yield return new WaitForSeconds(0.35f);
            GameManager.Instance.myturn=false;
        }
        else
        {
            yield return new WaitForSeconds(3);
            GameManager.Instance.myturn=true;
        }
    }
    IEnumerator damageco()
    {
        pucksound.Play();
        if (GameManager.Instance.myturn)
        {
            GameObject.Find("enemy").GetComponent<Image>().color = new Color32(255, 255, 255, 0);
            yield return new WaitForSeconds(0.2f);
            GameObject.Find("enemy").GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            yield return new WaitForSeconds(0.1f);
            GameObject.Find("enemy").GetComponent<Image>().color = new Color32(255, 255, 255, 0);
            yield return new WaitForSeconds(0.05f);
            GameObject.Find("enemy").GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
        else
        {
            red.gameObject.SetActive(true);
            red.color = new Color32(255, 0, 0, 255);
            red.DOFade(0, 3);
            yield return new WaitForSeconds(3);
            red.gameObject.SetActive(false);
        }
    }
    public void adsdasdasdsa()
    {
        StartCoroutine("Slash");
    }
}
