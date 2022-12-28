using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class UiManager : MonoBehaviour
{
    public AudioSource oksound;
    public AudioSource nosound;
    public TextMeshProUGUI strt;
    public TextMeshProUGUI deft;
    public TextMeshProUGUI spdt;
    public TextMeshProUGUI goldt;
    public GameObject restui;
    public GameObject dialogue;
    public Image black;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        strt.text = "»˚: " + GameManager.Instance.str;
        deft.text = "¿Œ≥ª: " + GameManager.Instance.def;
        spdt.text = "πŒ√∏" + GameManager.Instance.spd;
        goldt.text = "º“¡ˆ±›: " + GameManager.Instance.gold;
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

    }
    public void clickrest()
    {
        black.gameObject.SetActive(true);
        black.material.DOFade(1, 0.5f);
        GameManager.Instance.gold -= 50;
        GameManager.Instance.hp = 300;
        GameManager.Instance.cure();
        crest();
    }
    public void crest()//cancel rest
    {
        nosound.Play();
        restui.SetActive(false);
    }
}
