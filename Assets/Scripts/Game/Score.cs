using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public float _totalScore = 0;
    public GameObject _textMesh;

    public void AddScore()
    {
        // Count the score and write it
        _totalScore += 1;
        _textMesh.GetComponent<TextMeshProUGUI>().text = _totalScore.ToString();
    }
    
}
