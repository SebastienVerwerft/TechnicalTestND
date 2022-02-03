using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    public GameObject _DeathGo;

    private void Update()
    {
        if (_DeathGo.activeSelf && Input.touchCount > 0)
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
            // Game over
            _DeathGo.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
