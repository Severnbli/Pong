using UnityEngine;

public class BallActivity : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 20f;
    [SerializeField] private float _gravityForce = 1f;
    private Rigidbody2D _rb;
    private Vector3 _centralPosition;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag.Contains("Flipper")) {
            Rigidbody2D rigidbody = gameObject.GetComponent<Rigidbody2D>();

            if (rigidbody) {
                BallManager.ReSpawnRandBallInTheSamePosition(rigidbody.angularVelocity, rigidbody.velocity, gameObject.transform.position);
            }
        }
        if (collision.gameObject.name == "LeftPlayerHittingZone") {
            BallManager.SpawnRandBall();
            LevelManager.incrementLeftCounter();
           
        } else if (collision.gameObject.name == "RightPlayerHittingZone") {
            BallManager.SpawnRandBall();
            LevelManager.incrementRightCounter();
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
