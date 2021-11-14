using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField]
    Text scoreText;
    int currentScore = 0;
    private void OnEnable()
    {
        // setting up observetions
        // subscriped methods
        BlueCubeEvent.cubeReached += AddScore;
        RedCubeEvent.redCubeReached += SubstractScore;
        GoldCubeEvent.goldUnlocked += GoldEvent;
    }

    private void GoldEvent()
    {
        currentScore += 100;
        Debug.Log($"This function is fired from gold Cube");
        scoreText.text = $"Score:{currentScore}";
    }

    private void SubstractScore()
    {
        Debug.Log($"This function is fired by RedcubeReached Event  The RedCube");
        currentScore--;
        currentScore = Mathf.Clamp(currentScore, 0, int.MaxValue);
        scoreText.text = $"Score:{currentScore}";


    }

    private void AddScore()
    {

        Debug.Log($"This function is fired by cubeReached Event The BlueCube ");
        currentScore++;
        scoreText.text = $"Score:{currentScore}";   
    }
    private void OnDisable()
    {
        // unsubscribe on disable  to prevent errors
        BlueCubeEvent.cubeReached -= AddScore;
        RedCubeEvent.redCubeReached -= SubstractScore;
    }
}
