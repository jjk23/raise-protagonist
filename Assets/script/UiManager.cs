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
    public RadialSlider mastervol;
    public RadialSlider bgmvol;
    public RadialSlider sevol;
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
        strt.text = "힘: " + GameManager.Instance.str;
        deft.text = "인내: " + GameManager.Instance.def;
        spdt.text = "민첩" + GameManager.Instance.spd;
        goldt.text = "소지금: " + GameManager.Instance.gold;
    }
    public void clickinn()
    {
        oksound.Play();
        restui.SetActive(true);
        restui.transform.localScale = new Vector3(0, 0, 0);
        restui.transform.DOScale(new Vector3(1, 1, 1), 0.5f).SetEase(Ease.OutQuad);
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
    public void cancel(GameObject gm)//해당 게임오브젝트를 비활성화
    {
        nosound.Play();
        gm.SetActive(false);
    }
}
