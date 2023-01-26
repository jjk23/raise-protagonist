using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemManager : MonoBehaviour
{
    public Image[] itemicon = new Image[3];
    public Sprite[] iconsprites = new Sprite[50];
    public TextMeshProUGUI[] itemname = new TextMeshProUGUI[3];
    public TextMeshProUGUI[] itemexplain = new TextMeshProUGUI[3];
    public TextMeshProUGUI pcnttext;//°¡¹æ Æ÷¼Ç°³¼ö ÅØ½ºÆ®
    public TextMeshProUGUI ccnttext;//°¡¹æ ¸¸º´ÅëÄ¡¾à °³¼ö ÅØ½ºÆ®
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        pcnttext.text = GameManager.Instance.potioncnt + "°³";
        ccnttext.text = GameManager.Instance.curecnt + "°³";
    }
    public void setitem(string itemname,bool getitem)
    {
        int str=0, def=0, spd=0;
        switch (itemname)
        {
            case "Ãµ°©¿Ê":
                GameManager.Instance.armer = itemname;
                def = 5;
                break;
            case "³°Àº°Ë":
                GameManager.Instance.weapon = itemname;
                str = 5;
                break;
            case "¸ñÁ¦°©¿Ê":
                GameManager.Instance.armer = itemname;
                def = 10;
                break;
            case "Ã¶°Ë":
                GameManager.Instance.weapon = itemname;
                str = 10;
                break;
            case "Ã¶°©¿Ê":
                GameManager.Instance.armer = itemname;
                def = 15;
                break;
            case "¹Ù½ºÅ¸µå¼Òµå":
                GameManager.Instance.weapon = itemname;
                str = 15;
                break;
            case "È²±Ã°©¿Ê":
                GameManager.Instance.armer = itemname;
                def = 20;
                break;
            case "´ÙÀÌ¾Æ¼Òµå":
                GameManager.Instance.weapon = itemname;
                str = 20;
                break;
            case "¹Ì½º¸±°©¿Ê":
                GameManager.Instance.armer = itemname;
                def = 30;
                break;
            case "¹«¶ó¸¶»ç":
                GameManager.Instance.weapon = itemname;
                str = 25;
                spd = 25;
                break;
            case "¹ÌÄ«¿¤ÀÇ¹æÆÐ":
                GameManager.Instance.armer = itemname;
                def = 40;
                break;
            case "¿ì¸®¿¤ÀÇ½ÉÆÇ°Ë":
                GameManager.Instance.weapon = itemname;
                str = 40;
                break;
        }
        if(getitem)
        {
            GameManager.Instance.str += str;
            GameManager.Instance.def += def;
            GameManager.Instance.spd += spd;
        }
        else
        {
            GameManager.Instance.str -= str;
            GameManager.Instance.def -= def;
            GameManager.Instance.spd -= spd;
        }
    }
}
