using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonCreator<GameManager>
{
    public int LevelIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("object created");
        
    }



    public void LoadnextLevel()
    {
        LevelIndex += 1;
        SceneManager.LoadScene(LevelIndex);
    }

    public int NextLevelIndex()
    {
        Debug.Log($"LevelIndex Current Value : {LevelIndex}");
        LevelIndex++;
        return LevelIndex;
    }

    
}
