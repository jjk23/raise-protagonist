using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClodiaUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("dungeonmanager").GetComponent<DungeonManager>().market.SetActive(true);
        SceneManager.LoadScene("village");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
