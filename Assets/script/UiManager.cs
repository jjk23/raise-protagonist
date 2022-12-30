using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class UiManager : MonoBehaviour
{
    public int dinex = 0;
    public AudioSource oksound;
    public AudioSource nosound;
    public AudioSource restsound;
    public TextMeshProUGUI strt;
    public TextMeshProUGUI deft;
    public TextMeshProUGUI spdt;
    public TextMeshProUGUI goldt;
    public TextMeshProUGUI dtext;
    public GameObject restui;
    public GameObject dialogue;
    public Image black;
    public Image dimage;
    public Sprite[] sprites=new Sprite[100];
    #region 스프라이트 인덱스 정리
    /*0:암시장 문지기
     */
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
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
        dialogue.SetActive(true);
        dimage.sprite = sprites[0];
        GameManager.Instance.dindex = 0;
    }
    public void clickrest()
    {
        StartCoroutine("restco");
    }
    IEnumerator restco()
    {
        black.gameObject.SetActive(true);
        restsound.Play();
        crest();
        black.DOFade(1, 4f);
        yield return new WaitForSeconds(5);
        black.DOFade(0, 3f);
        yield return new WaitForSeconds(3);
        black.gameObject.SetActive(false);
        GameManager.Instance.gold -= 50;
        GameManager.Instance.hp = 300;
        GameManager.Instance.cure();        
    }
    public void crest()//cancel rest
    {
        nosound.Play();
        restui.SetActive(false);
    }
}
