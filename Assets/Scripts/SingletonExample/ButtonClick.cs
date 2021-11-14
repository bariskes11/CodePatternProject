using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    [SerializeField]
    Text buttonText;
    public void LoadNextScene()
    {
        GameManager.instance.LoadnextLevel();
    }

    public void IncreaseLevelText()
    {
        buttonText.text = GameManager.instance.NextLevelIndex().ToString();
    }
}
