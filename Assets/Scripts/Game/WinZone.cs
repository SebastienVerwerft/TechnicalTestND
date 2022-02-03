using UnityEngine;
using UnityEngine.SceneManagement;

public class WinZone : MonoBehaviour
{
    public GameObject _winGo;

    private void Update()
    {
        if(_winGo.activeSelf && Input.touchCount > 0)
        {
            // Get the first input only
            Touch touch = Input.GetTouch(0);

            // Reload the scene
            if (touch.phase == TouchPhase.Began)
            {
                SceneManager.LoadScene(0);
                Time.timeScale = 1;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            // You win
            _winGo.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
