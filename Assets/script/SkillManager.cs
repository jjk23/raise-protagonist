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
    public AudioSource nosound;
    public GameObject[] passives = new GameObject[15];
    public GameObject[] passivelock = new GameObject[15];
    public GameObject skillui;
    public GameObject slash;
    public GameObject circle;
    public GameObject search;
    public GameObject miss;
    public GameObject crit;
    public bool isco = false;//이게 false여야지 적이 스킬 사용
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
            skillui.SetActive(false);
        }       
        else if(GameManager.Instance.myturn && !isco&&GameManager.Instance.isbattle)
        {
            switch (index)
            {
                case 0:
                    if(GameManager.Instance.skill1!="잠금"&&GameManager.Instance.tp>=returntp(GameManager.Instance.skill1))//스킬이 잠금이거나 tp소비량 이상이어야 가능
                    {
                        GameManager.Instance.tp -= returntp(GameManager.Instance.skill1);
                        isco = true;
                        StartCoroutine(convert(GameManager.Instance.skill1));
                    }                    
                    break;
                case 1:
                    if (GameManager.Instance.skill2 != "잠금" && GameManager.Instance.tp >= returntp(GameManager.Instance.skill2))
                    {
                        GameManager.Instance.tp -= returntp(GameManager.Instance.skill2);
                        isco = true;
                        StartCoroutine(convert(GameManager.Instance.skill2));
                    }
                    break;
                case 2:
                    if (GameManager.Instance.skill3 != "잠금" && GameManager.Instance.tp >= returntp(GameManager.Instance.skill3))
                    {
                        GameManager.Instance.tp -= returntp(GameManager.Instance.skill3);
                        isco = true;
                        StartCoroutine(convert(GameManager.Instance.skill3));
                    }
                    break;
                case 3:
                    if (GameManager.Instance.skill4 != "잠금" && GameManager.Instance.tp >= returntp(GameManager.Instance.skill4))
                    {
                        GameManager.Instance.tp -= returntp(GameManager.Instance.skill4);
                        isco = true;
                        StartCoroutine(convert(GameManager.Instance.skill4));
                    }
                    break;
            }
        }
    }
    public void Clicksearch()
    {
        skillui.SetActive(false);
        if (GameManager.Instance.isbattle)
        {
            StartCoroutine("Search");
        }
        else
        {
            nosound.Play();
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
    #region 스킬 코루틴 모음
    IEnumerator Slash()//기본공격
    {
        var clone = Instantiate(slash, transform);
        Destroy(clone, 3f);
        yield return new WaitForSeconds(0.5f);
        if (GameManager.Instance.myturn)
        {
            int rand = Random.Range(0, 2);
            if (GameManager.Instance.enname=="honet"&& rand == 0)//호넷 패시브:50%로 기본공격 회피
            {
                var clone2 = Instantiate(miss, transform);
                Destroy(clone2, 1f);
                yield return new WaitForSeconds(1f);
            }
            else
            {
                GameManager.Instance.getdamage(0);
                StartCoroutine("damageco");
                yield return new WaitForSeconds(0.35f);               
            }
            GameManager.Instance.myturn = false;
        }
        else
        {
            GameManager.Instance.getdamage(0);
            StartCoroutine("damageco");
            yield return new WaitForSeconds(3);
            GameManager.Instance.myturn = true;
        }
        isco = false;
    }
    IEnumerator Wind()
    {
        var clone = Instantiate(circle, transform);
        Destroy(clone, 3f);
        yield return new WaitForSeconds(0.5f);        
        if (GameManager.Instance.myturn)
        {
            GameManager.Instance.getdamage(20);
            StartCoroutine("damageco");
            yield return new WaitForSeconds(0.35f);
            GameManager.Instance.myturn = false;
        }
        else
        {
            GameManager.Instance.getdamage(20);
            StartCoroutine("damageco");
            yield return new WaitForSeconds(3);
            GameManager.Instance.myturn = true;
        }
        isco = false;
    }
    IEnumerator Critical()
    {
        var clone = Instantiate(crit, transform);
        Destroy(clone, 3f);
        yield return new WaitForSeconds(0.5f);
        if (GameManager.Instance.myturn)
        {
            GameManager.Instance.getdamage(10);
            StartCoroutine("damageco");
            yield return new WaitForSeconds(0.35f);
            GameManager.Instance.myturn = false;
        }
        else
        {
            GameManager.Instance.getdamage(10);
            StartCoroutine("damageco");
            yield return new WaitForSeconds(3);
            GameManager.Instance.myturn = true;
        }
        isco = false;
    }
    IEnumerator Search()
    {
        var clone = Instantiate(search, transform);
        Destroy(clone, 3f);
        yield return new WaitForSeconds(0.5f);
        GameObject.Find("search").transform.GetChild(0).gameObject.SetActive(true);
        GameObject.Find("info" + (GameManager.Instance.infoindex+1)).transform.GetChild(0).gameObject.SetActive(true);
        GameManager.Instance.infoindex += 1;
        GameManager.Instance.myturn = false;
        isco = false;
    }
    #endregion
    #region 편의성 함수
    public void seticon(string skillname, Image icon)//아이콘 설정해주는 편의성 함수
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
    IEnumerator damageco()//피격 이펙트 실행. 이 이전에 얼마나 데미지를 받는지 설정할것.
    {
        pucksound.Play();
        if (GameManager.Instance.myturn)
        {
            GameManager.Instance.enhpset();
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
    public string convert(string skillname)//GameManager에 한글로 저장되는 스킬이름을 코루틴 함수 호출을 위해 영어로 변환
    {
        switch (skillname)
        {
            case "급소찌르기":
                return "Critical";
            case "엄니부수기":
                return "Breakteeth";
            case "화염의검":
                return "Firesword";
            case "분노":
                return "Rage";
            case "진압":
                return "Shutdown";
            case "제비반환":
                return "Swallowslash";
            case "글라디우스":
                return "Gladius";
            case "약육강식":
                return "Yakyukgansick";
            case "인페르노":
                return "Inferno";
            case "참격":
                return "Slash2";
        }
        return "오류";
    }
    public int returntp(string skillname)//스킬이름 넣으면 얼마나 써야하는지 보여줌
    {
        switch (skillname)
        {
            case "급소찌르기":
                return 20;
            case "엄니부수기":
                return 20;
            case "화염의검":
                return 20;
            case "분노":
                return 10;
            case "진압":
                return 20;
            case "제비반환":
                return 20;
            case "글라디우스":
                return 20;
            case "약육강식":
                return 20;
            case "인페르노":
                return 20;
            case "참격":
                return 10;
        }
        return 99999;
    }
    #endregion
}
