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
    public AudioSource oksound;
    public AudioSource nosound;
    public AudioSource restsound;
    public AudioSource villagebgm;
    public AudioMixer mixer;
    public TextMeshProUGUI strt;
    public TextMeshProUGUI deft;
    public TextMeshProUGUI spdt;
    public TextMeshProUGUI goldt;
    public TextMeshProUGUI hpt;
    public RadialSlider mastervol;
    public RadialSlider bgmvol;
    public RadialSlider sevol;
    public Slider hpslider;
    public GameObject restui;
    public GameObject setui;
    public Image black;    
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
        Debug.Log("hp:"+GameManager.Instance.hp);
        Debug.Log("gd:" + GameManager.Instance.gold);
    }
    public void clickblack()
    {    
        GameManager.Instance.dindex = 0;
    }
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
    public void active(GameObject gm)
    {
        setui.transform.localPosition = new Vector3(0, 0, 0);//setui�� ó���� active���·� �־�� �Ҹ� ��� ���� �� active���·� �� �ָ� ���ٰ� ���� ��ġ�� �ǵ����� �۾�
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
}
