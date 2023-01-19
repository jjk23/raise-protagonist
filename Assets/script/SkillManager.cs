using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{
    public string skillname;
    public TextMeshProUGUI[] skilltext = new TextMeshProUGUI[4];    
    public Image[] skillicon = new Image[4];
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
                       
    }
    public void Clickskill(int index)
    {
        if(skillname!=null)
        {
            switch (index)
            {
                case 0:
                    GameManager.Instance.skill1 = skillname;
                    skilltext[0].text = GameManager.Instance.skill1;                    
                    break;
                case 1:
                    GameManager.Instance.skill2 = skillname;
                    skilltext[1].text = GameManager.Instance.skill2;
                    break;
                case 2:
                    GameManager.Instance.skill3 = skillname;
                    skilltext[2].text = GameManager.Instance.skill3;
                    break;
                case 3:
                    GameManager.Instance.skill4 = skillname;
                    skilltext[3].text = GameManager.Instance.skill4;
                    break;
            }           
            skillname = null;
        }       
    }
}
