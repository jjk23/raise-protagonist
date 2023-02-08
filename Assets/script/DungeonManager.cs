using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonManager : MonoBehaviour
{
    public GameObject[] dungeon = new GameObject[20];
    public GameObject market;
    int index = 0;//현재 선택한 던전 인덱스
    public AudioSource oksound;
    public int[] dungeonhard = new int[20];
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
        dungeon[index].SetActive(false);
        dungeon[num].SetActive(true);
        index = num;
    }
    public void enterdungeon()
    {
        market.SetActive(false);
        switch(index)
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
