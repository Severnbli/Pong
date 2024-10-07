using UnityEngine;

public class BallActivity : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 20.0f;
    [SerializeField] private float _gravityForce = 10.0f;
    private Rigidbody2D _rb;
    private Vector3 _centralPosition;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        
        GameObject[] centralElements = GameObject.FindGameObjectsWithTag("CentralElement");

        if (centralElements.Length > 0)
        {
            int randomIndex = Random.Range(0, centralElements.Length);
            
            GameObject centralElement = centralElements[randomIndex];

            if (centralElement) {
                _centralPosition = centralElement.transform.position;
            } else {
                _centralPosition = new Vector3();
            }
        } 
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Flipper") {
            Debug.Log("Hit a ball! " + Time.realtimeSinceStartup);
        }
        if (collision.gameObject.name == "LeftBorder") {
            gameObject.transform.position = _centralPosition;
           // GameManager.incrementLeftCounter();
        } else if (collision.gameObject.name == "RightBorder") {
            gameObject.transform.position = _centralPosition;
          //  GameManager.incrementRightCounter();
        }

        Vector2 collisionNormal = collision.GetContact(0).normal;
        Vector2 ballVelocity = _rb.velocity;
        float angle = Vector2.SignedAngle(ballVelocity, collisionNormal);

        if (angle > 0)
        {
            _rb.angularVelocity = -_rotationSpeed;
        }
        else
        {
            _rb.angularVelocity = _rotationSpeed;
        }
    }

    void FixedUpdate() {
        float force;
        if (_centralPosition.x > gameObject.transform.position.x) {
            force = -_gravityForce;
        } else if (_centralPosition.x < gameObject.transform.position.x) {
            force = _gravityForce;
        } else {
            bool isRight = Random.Range(0, 2) == 1 ? true : false;
            if (isRight) {
                force = _gravityForce;
            } else {
                force = -_gravityForce;
            }
        }
        _rb.AddForce(new Vector2(force, 0), ForceMode2D.Impulse);
    }
}
