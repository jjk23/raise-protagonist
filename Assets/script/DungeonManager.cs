using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonManager : MonoBehaviour
{
    public GameObject[] dungeon = new GameObject[20];
    public AudioSource oksound;    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setdungeon(int num)
    {
        oksound.Play();
        dungeon[GameManager.Instance.dungeonindex].SetActive(false);
        dungeon[num].SetActive(true);
        GameManager.Instance.dungeonindex = num;
    }
    public void enterdungeon()
    {
        switch(GameManager.Instance.dungeonindex)
        {
            case 0:
                SceneManager.LoadScene("clodia forest");               
                break;
            case 1:
                SceneManager.LoadScene("cold mountain");
                break;
        }
    }
}
