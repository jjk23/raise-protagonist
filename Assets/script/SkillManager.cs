using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public TextMeshProUGUI[] skillname = new TextMeshProUGUI[4];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        skillname[0].text = GameManager.Instance.skill1;
        skillname[1].text = GameManager.Instance.skill2;
        skillname[2].text = GameManager.Instance.skill3;
        skillname[3].text = GameManager.Instance.skill4;
    }
}
