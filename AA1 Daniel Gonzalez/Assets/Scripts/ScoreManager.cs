using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager scoreManager { get; private set; }

    [SerializeField] private TMP_Text score_text;
    private int score;
    // Start is called before the first frame update
    void Awake()
    {
        if (scoreManager == null)
            scoreManager = this;
        else
            Destroy(this.gameObject);
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        score_text.text = "Score: " + score;
    }
}
