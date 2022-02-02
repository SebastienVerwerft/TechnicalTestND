using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField] private GameObject _tileGo;

    private Transform _tilesParent;

    private void Awake()
    {
        // Init
        _tilesParent = transform.parent.transform.parent;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Detect the player
        if(other.gameObject.name == "Player")
        {
            // Create the next+1 tile
            Instantiate(_tileGo, transform.parent.position + new Vector3(0, 0, 20f), transform.rotation, _tilesParent);

            // Delete the previous-2 tile
            if(_tilesParent.childCount > 4)
            {
                Destroy(_tilesParent.GetChild(0).gameObject);
            }
        }
    }
}
