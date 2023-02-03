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
    #region ��������Ʈ �ε��� ����
    /*0:�Ͻ��� ������
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
    void black1()//vip�нú� ���� ���·� �Ͻ��� ���� ��ȭ
    {
        switch (n)
        {
            case 0:
                dimage.sprite = sprites[0];
                dtext.DOText("���� �ʰ��� �ּ��̰� �� ���� �ƴϴ�.\n<b><color=yellow>VIP</color><b>���Ե��� ���� ���̶��.", 0.5f);
                break;
            case 1:
                dtext.text="";
                dtext.DOText("�˾Ƶ������ �� ����.", 0.5f);
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
