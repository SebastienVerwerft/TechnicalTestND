using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movements")]
    [SerializeField] private float _movingSpeed;
    [SerializeField] private float _sideStepSpeed;

    private Vector3 _moveDirection;

    void Start()
    {
        // Init
        _moveDirection = Vector3.forward;
    }

    void Update()
    {
        // Detect if we touch the screen
        if(Input.touchCount > 0)
        {
            // Get the first input only
            Touch touch = Input.GetTouch(0);

            // if we touch on left side or right side, modify the direction
            if(touch.position.x < Screen.width/2)
            {
                _moveDirection = new Vector3(-_sideStepSpeed, 0, 1);
            }
            else
            {
                _moveDirection = new Vector3(_sideStepSpeed, 0, 1);
            }
        }

        // if we don't touch, just run forward
        else
        {
            _moveDirection = Vector3.forward;
        }
    }

    private void FixedUpdate()
    {
        // Moving the character
        transform.Translate(_moveDirection * Time.deltaTime * _movingSpeed);
    }
}
