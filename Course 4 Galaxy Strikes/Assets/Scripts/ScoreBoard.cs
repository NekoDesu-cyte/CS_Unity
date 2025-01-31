using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    int score = 0;

    public void IncreaseScore(int amount)
    {
        score += amount;
        Debug.Log(score);
    }
}
