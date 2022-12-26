using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiManager : MonoBehaviour
{
    public TextMeshProUGUI strt;
    public TextMeshProUGUI deft;
    public TextMeshProUGUI spdt;
    public TextMeshProUGUI goldt;
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
    
}
