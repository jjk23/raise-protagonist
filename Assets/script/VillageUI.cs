using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;
using DG.Tweening;
using Michsky.MUIP;//��� ui���� �������
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
    #region ����ui
    public void clickrest()
    {
        GameObject.Find("gamemanager").GetComponent<UiManager>().clickrest();
    }
    #endregion
    #region �Ͻ��� ui
    public void clickblack()
    {
        GameManager.Instance.dindex = 0;
        GameObject.Find("gamemanager").GetComponent<TextManager>().dialogue();
    }
    #endregion
    #region ���� ui
    public void clickdungeon()
    {
        active(dungeonui);
    }
    #endregion
    #region ���Ǽ� �Լ�
    public void active(GameObject gm)
    {
        oksound.Play();
        gm.SetActive(true);
        gm.transform.localScale = new Vector3(0, 0, 0);
        gm.transform.DOScale(new Vector3(1, 1, 1), 0.5f).SetEase(Ease.OutQuad);
    }
    public void cancel(GameObject gm)//�ش� ���ӿ�����Ʈ�� ��Ȱ��ȭ
    {
        nosound.Play();
        gm.SetActive(false);
    }
    #endregion
}
