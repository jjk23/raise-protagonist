using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;
using DG.Tweening;
using Michsky.MUIP;//모던 ui에셋 헤더파일
using UnityEngine.EventSystems;

public class VillageUI : MonoBehaviour
{
    public AudioSource oksound;
    public AudioSource nosound;
    public AudioSource restsound;
    public AudioSource villagebgm;
    public GameObject restui;
    public GameObject dungeonui;
    public Image black;
    // Start is called before the first frame update
    void Start()
    {
        villagebgm.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #region 여관 ui
    public void clickrest()
    {
        if (GameManager.Instance.gold >= 100)
        {
            StartCoroutine("restco");
        }
        else
        {
            nosound.Play();
        }
    }
    IEnumerator restco()
    {
        villagebgm.Pause();
        GameObject.Find("gamemanager").GetComponent<UiManager>().black.gameObject.SetActive(true);
        black = GameObject.Find("black").GetComponent<Image>();
        restsound.Play();
        cancel(restui);
        black.DOFade(1, 4f);
        yield return new WaitForSeconds(5);
        black.DOFade(0, 3f);
        yield return new WaitForSeconds(3);
        black.gameObject.SetActive(false);
        GameManager.Instance.gold -= 100;
        GameManager.Instance.hp = 300;
        GameManager.Instance.cure();
        villagebgm.Play();
    }
    #endregion
    #region 암시장 ui
    public void clickblack()
    {
        GameManager.Instance.dindex = 0;
        GameObject.Find("gamemanager").GetComponent<TextManager>().dialogue();
    }
    #endregion
    #region 던전 ui
    public void clickdungeon()
    {
        active(dungeonui);
    }
    #endregion
    #region 편의성 함수
    public void active(GameObject gm)
    {
        oksound.Play();
        gm.SetActive(true);
        gm.transform.localScale = new Vector3(0, 0, 0);
        gm.transform.DOScale(new Vector3(1, 1, 1), 0.5f).SetEase(Ease.OutQuad);
    }
    public void cancel(GameObject gm)//해당 게임오브젝트를 비활성화
    {
        nosound.Play();
        gm.SetActive(false);
    }
    #endregion
}
