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
    public GameObject cut;
    public GameObject crit;
    public GameObject breakteeth;
    public GameObject fsword;
    public GameObject fire;
    public GameObject smoke;
    public bool isco = false;//�̰� false������ ���� ��ų ���
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
        if(skillname!=null)//skillname�� uimanager���� ����. ��ų ���氡������ Ȯ���ϴ°���
        {
            switch (index)
            {
                case 0:
                    GameManager.Instance.skill1 = skillname;
                    skilltext[0].text = color+GameManager.Instance.skill1+"</color>";//color�� uimanager���� ���� �����Ҷ� ����
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
            skillui.SetActive(false);
            switch (index)
            {
                case 0:
                    if(GameManager.Instance.skill1!="���"&&GameManager.Instance.tp>=returntp(GameManager.Instance.skill1))//��ų�� ����̰ų� tp�Һ� �̻��̾�� ����
                    {
                        GameManager.Instance.tp -= returntp(GameManager.Instance.skill1);
                        isco = true;
                        StartCoroutine(convert(GameManager.Instance.skill1));
                    }                    
                    break;
                case 1:
                    if (GameManager.Instance.skill2 != "���" && GameManager.Instance.tp >= returntp(GameManager.Instance.skill2))
                    {
                        GameManager.Instance.tp -= returntp(GameManager.Instance.skill2);
                        isco = true;
                        StartCoroutine(convert(GameManager.Instance.skill2));
                    }
                    break;
                case 2:
                    if (GameManager.Instance.skill3 != "���" && GameManager.Instance.tp >= returntp(GameManager.Instance.skill3))
                    {
                        GameManager.Instance.tp -= returntp(GameManager.Instance.skill3);
                        isco = true;
                        StartCoroutine(convert(GameManager.Instance.skill3));
                    }
                    break;
                case 3:
                    if (GameManager.Instance.skill4 != "���" && GameManager.Instance.tp >= returntp(GameManager.Instance.skill4))
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
            case "������":
                passives[0].SetActive(true);
                passivelock[0].SetActive(false);
                GameManager.Instance.pberserk = true;
                break;
            case "���к�":
                passives[1].SetActive(true);
                passivelock[1].SetActive(false);
                GameManager.Instance.pshielder = true;
                break;
            case "����":
                passives[2].SetActive(true);
                passivelock[2].SetActive(false);
                GameManager.Instance.passassin = true;
                break;
            case "è�Ǿ�":
                passives[3].SetActive(true);
                passivelock[3].SetActive(false);
                break;
            case "�����л���":
                passives[4].SetActive(true);
                passivelock[4].SetActive(false);
                GameManager.Instance.pbughunter = true;
                break;
            case "������":
                passives[5].SetActive(true);
                passivelock[5].SetActive(false);
                GameManager.Instance.pbeasthunter = true;
                break;
            case "�Ǹ���ɲ�":
                passives[6].SetActive(true);
                passivelock[6].SetActive(false);
                GameManager.Instance.pdevilhunter = true;
                break;
            case "VIP":
                passives[7].SetActive(true);
                passivelock[7].SetActive(false);
                GameManager.Instance.pvip = true;
                break;
            case "�ڿ�ġ��":
                passives[8].SetActive(true);
                passivelock[8].SetActive(false);
                GameManager.Instance.pnaturalheal = true;
                break;
            case "�Ƶ巹����":
                passives[9].SetActive(true);
                passivelock[9].SetActive(false);
                GameManager.Instance.padrenalin = true;
                break;
            case "����":
                passives[10].SetActive(true);
                passivelock[10].SetActive(false);
                GameManager.Instance.plegend = true;              
                break;
            case "�����Ǵ�":
                passives[11].SetActive(true);
                passivelock[11].SetActive(false);
                GameManager.Instance.psageeye = true;
                break;
            case "Ž���Ǵ�":
                passives[12].SetActive(true);
                passivelock[12].SetActive(false);
                GameManager.Instance.pgrideye = true;
                break;
            case "���Ŀ��ǰ�ȣ":
                passives[13].SetActive(true);
                passivelock[13].SetActive(false);
                GameManager.Instance.praphael = true;
                break;
            case "����":
                passives[14].SetActive(true);
                passivelock[14].SetActive(false);
                break;
        }

    }
    #region ��ų �ڷ�ƾ ����
    IEnumerator Slash()//�⺻����
    {
        var clone = Instantiate(slash, transform);
        Destroy(clone, 3f);
        yield return new WaitForSeconds(0.5f);      
        int rand = Random.Range(0, 2);
        if (GameManager.Instance.enname == "honet" && rand == 0&&GameManager.Instance.myturn)//ȣ�� �нú�:50%�� �⺻���� ȸ��
        {
            var clone2 = Instantiate(miss, transform);
            Destroy(clone2, 1f);
            yield return new WaitForSeconds(1f);
            GameManager.Instance.myturn = false;
            isco = false;
        }
        else
        {
            StartCoroutine("damageco", 0);
        }
    }
    IEnumerator Wind()
    {
        var clone = Instantiate(circle, transform);
        Destroy(clone, 3f);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine("damageco",20);
    }
    IEnumerator Critical()
    {
        GameManager.Instance.person = true;
        var clone = Instantiate(crit, transform);
        Destroy(clone, 3f);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine("damageco", 10);
    }
    IEnumerator Cut()
    {
        var clone = Instantiate(cut, transform);
        Destroy(clone, 3f);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine("damageco", 20);
    }
    IEnumerator Firesword()
    {
        GameManager.Instance.fire= true;
        var clone = Instantiate(fire, transform);
        clone.transform.localPosition = new Vector3(700,400,10);
        Destroy(clone, 0.8f);//destroy�� ���� �ʰ��ؾ� dotween�� �����ϴµ��� destroy�� �߻�����
        clone.transform.DOLocalMove(new Vector3(-700, -400, 0),0.7f);
        yield return new WaitForSeconds(0.5f);
        clone = Instantiate(fire, transform);
        clone.transform.localPosition = new Vector3(-700, 400, 10);
        Destroy(clone, 0.8f);
        clone.transform.DOLocalMove(new Vector3(700, -400, 0), 0.7f);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine("damageco", 10);
    }
    IEnumerator Breakteeth()
    {
        GameManager.Instance.beast = true;
        var clone = Instantiate(breakteeth, transform);
        Destroy(clone, 3f);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine("damageco", 10);
    }
    IEnumerator Shutdown()
    {
        GameManager.Instance.fire = true;
        var clone = Instantiate(smoke, transform);
        clone.transform.localPosition = new Vector3(700, 400, 10);
        Destroy(clone, 0.4f);//destroy�� ���� �ʰ��ؾ� dotween�� �����ϴµ��� destroy�� �߻�����
        clone.transform.DOLocalMove(new Vector3(-700, -400, 0), 0.3f);
        yield return new WaitForSeconds(0.1f);
        for(int i=0;i<30;i++)
        {
            clone = Instantiate(smoke, transform);
            clone.transform.localPosition = new Vector3(Random.Range(-700,700), 200, 10);
            Destroy(clone, 2);
            clone.transform.DOLocalMove(new Vector3(Random.Range(-700, 700), -600, 0), 0.2f);
            yield return new WaitForSeconds(0.1f);
        }       
        StartCoroutine("damageco", 10);
    }
    IEnumerator Search()//���� ��ų
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
    #region ���Ǽ� �Լ�
    public void seticon(string skillname, Image icon)//������ �������ִ� ���Ǽ� �Լ�
    {
        switch (skillname)
        {
            case "�޼����":
                icon.sprite = iconsprites[0];
                break;
            case "���Ϻμ���":
                icon.sprite = iconsprites[1];
                break;
            case "ȭ���ǰ�":
                icon.sprite = iconsprites[2];
                break;
            case "�г�":
                icon.sprite = iconsprites[3];
                break;
            case "����":
                icon.sprite = iconsprites[4];
                break;
            case "�����ȯ":
                icon.sprite = iconsprites[5];
                break;
            case "�۶��콺":
                icon.sprite = iconsprites[6];
                break;
            case "��������":
                icon.sprite = iconsprites[7];
                break;
            case "���丣��":
                icon.sprite = iconsprites[8];
                break;
        }
    }
    IEnumerator damageco(int dmg)//�󸶳� ���ظ� �޴��� �����ϰ� �ǰ� ����Ʈ ����
    {
        GameManager.Instance.getdamage(dmg);
        pucksound.Play();
        if (GameManager.Instance.myturn)
        {
            GameManager.Instance.enhpset();
            GameObject.Find("enemy").GetComponent<Image>().color = new Color32(255, 255, 255, 0);//���ڱ��� ����Ʈ
            yield return new WaitForSeconds(0.2f);
            GameObject.Find("enemy").GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            yield return new WaitForSeconds(0.1f);
            GameObject.Find("enemy").GetComponent<Image>().color = new Color32(255, 255, 255, 0);
            yield return new WaitForSeconds(0.05f);
            GameObject.Find("enemy").GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            GameManager.Instance.myturn = false;
        }
        else
        {
            red.gameObject.SetActive(true);//ȭ�� ������ ����Ʈ
            red.color = new Color32(255, 0, 0, 255);
            red.DOFade(0, 3);
            yield return new WaitForSeconds(3);
            red.gameObject.SetActive(false);
            GameManager.Instance.myturn = true;
        }
        isco = false;
    }
    public string convert(string skillname)//GameManager�� �ѱ۷� ����Ǵ� ��ų�̸��� �ڷ�ƾ �Լ� ȣ���� ���� ����� ��ȯ
    {
        switch (skillname)
        {
            case "�޼����":
                return "Critical";
            case "���Ϻμ���":
                return "Breakteeth";
            case "ȭ���ǰ�":
                return "Firesword";
            case "�г�":
                return "Rage";
            case "����":
                return "Shutdown";
            case "�����ȯ":
                return "Swallowslash";
            case "�۶��콺":
                return "Gladius";
            case "��������":
                return "Yakyukgansick";
            case "���丣��":
                return "Inferno";
            case "����":
                return "Cut";
        }
        return "����";
    }
    public int returntp(string skillname)//��ų�̸� ������ �󸶳� tp�� ����ϴ��� ������
    {
        switch (skillname)
        {
            case "�޼����":
                return 20;
            case "���Ϻμ���":
                return 20;
            case "ȭ���ǰ�":
                return 20;
            case "�г�":
                return 10;
            case "����":
                return 20;
            case "�����ȯ":
                return 20;
            case "�۶��콺":
                return 20;
            case "��������":
                return 20;
            case "���丣��":
                return 20;
            case "����":
                return 10;
        }
        return 99999;
    }
    #endregion
}
