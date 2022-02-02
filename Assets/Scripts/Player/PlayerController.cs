using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movements")]
    [SerializeField] private float _movingSpeed;
    [SerializeField] private float _sideStepSpeed;

    private float _timeElapsed;
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

            if(touch.phase == TouchPhase.Began)
            {
                _timeElapsed = 0f;
            }

            if(touch.phase == TouchPhase.Stationary)
            {
                // Adding a little smooth start on side moves
                float t = _timeElapsed / _sideStepSpeed;
                float value = Mathf.Lerp(0, 1, t * t * t);

                // if we touch on left side or right side, modify the direction
                if (touch.position.x < Screen.width/2)
                {
                    _moveDirection = new Vector3(-value, 0, 1);
                }
                else
                {
                    _moveDirection = new Vector3(value, 0, 1);
                }

                // Add the time to respect the curve
                _timeElapsed += Time.deltaTime;
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
