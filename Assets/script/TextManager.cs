using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TextManager : MonoBehaviour
{
    int n = 0;
    bool isend=false;
    public AudioSource cancelsound;
    public AudioSource textsound;
    public TextMeshProUGUI dtext;
    public Image dimage;
    public GameObject dialoguegm;
    public Sprite[] sprites = new Sprite[100];
    #region 스프라이트 인덱스 정리
    /*0:암시장 문지기
     */
    #endregion
    // Update is called once per frame
    void Update()
    {
        
    }
    public void dialogue()
    {
        dialoguegm.SetActive(true);
        switch (GameManager.Instance.dindex)
        {
            case 0:
                black1();
                break;
        } 
        if(isend)
        {
            cancelsound.Play();
            isend= false;
        }
        else
        {
            textsound.Play();
            n++;
        }
    }
    void black1()//vip패시브 없는 상태로 암시장 입장 대화
    {
        switch (n)
        {
            case 0:
                dimage.sprite = sprites[0];
                dtext.DOText("여긴 너같은 애송이가 올 곳이 아니다.\n<b><color=yellow>VIP</color><b>고객님들을 위한 곳이라고.", 0.5f);
                break;
            case 1:
                dtext.text="";
                dtext.DOText("알아들었으면 썩 꺼져.", 0.5f);
                break;
            case 2:
                end();
                break;
        }
    }
    void end()
    {
        dialoguegm.SetActive(false);
        n = 0;
        isend = true;
    }
}
