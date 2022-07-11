using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TextMeshProUGUI _score;
    [SerializeField] private int _scorePerSecond;

    public int CurrentScore { get; private set; }

    private void Start()
    {
        CurrentScore = 0;

        StartCoroutine(AddScore());
    }

    private void Update()
    {
        _score.text = CurrentScore.ToString();
    }

    private IEnumerator AddScore()
    {
        while (true)
        {
            CurrentScore += _scorePerSecond;
            yield return new WaitForSeconds(1);
        }
    }
}