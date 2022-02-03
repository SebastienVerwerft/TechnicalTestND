using UnityEngine;

public class Collectible : MonoBehaviour
{
    public AudioSource _audioSource;

    private void OnTriggerEnter(Collider other)
    {
        // Detect the player
        if(other.gameObject.name == "Player")
        {
            // Play the sound then delete the coin
            _audioSource.Play();
            transform.parent.gameObject.GetComponent<Score>().AddScore();
            Destroy(gameObject);
        }
    }
}
