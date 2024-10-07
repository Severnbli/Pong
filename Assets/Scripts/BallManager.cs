using UnityEngine;

public class BallManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _balls;
    
    private static Vector3 _handledBallPosition;
    private static Vector3 _handledBallvelocity;
    private static float _handledBallAngularVelocity;
    private static GameObject[] _staticBalls;
    
    private static string _handledBallname;

    void Awake() {
        _staticBalls = _balls;
    }

    public static GameObject[] GetActiveBalls() {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Ball");
        return gameObjects;
    }

    public static void SpawnBall(GameObject ball, float rbAVelocity = 0, Vector3 rbVelocity = new Vector3()) {
        Vector2 position = FindNewCentralPosition();
        SpawnBall(ball, position, rbAVelocity, rbVelocity);
    }

    public static void SpawnRandBall(float rbAVelocity = 0, Vector3 rbVelocity = new Vector3()) {
        GameObject ball = GetRandBall();

        if (ball) {
            SpawnBall(ball, rbAVelocity, rbVelocity);
        }
    }

    public static void ReSpawnRandBallInTheSamePosition(float rbAVelocity, Vector3 rbVelocity, Vector3 position) {
        GameObject ball = GetRandBall();

        if (ball) {
            SpawnBall(ball, position, rbAVelocity, rbVelocity);
        }
    }

    public static void HandleBall() {
        GameObject[] balls = GetActiveBalls();
        
        foreach (GameObject ball in balls) {
            _handledBallname = ball.name;
            _handledBallPosition = ball.transform.position;
            
            Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
            if (rb) {
                _handledBallvelocity = rb.velocity;
                _handledBallAngularVelocity = rb.angularVelocity; 
            }
        }
        DelBalls();
    }

    public static void SpawnHandledBall() {
        DelBalls();

        GameObject ball = Instantiate(_staticBalls[FindIdBall(_handledBallname)], _handledBallPosition, Quaternion.identity);

        ball.gameObject.tag = "Ball";

        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
        if (rb) {
            rb.velocity = _handledBallvelocity;
            rb.angularVelocity = _handledBallAngularVelocity;
        }
    }

    public static void SpawnBall(GameObject ball, Vector3 position, float rbAVelocity = 0, Vector3 rbVelocity = new Vector3()) {
        DelBalls();

        GameObject newBall = Instantiate(ball, position, Quaternion.identity);

        newBall.tag = "Ball";

        if (rbVelocity != new Vector3()) {
            Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();

            if (rb) {
                rb.velocity = rbVelocity;
                rb.angularVelocity = rbAVelocity;
            }
        }
    }

    public static int FindIdBall(string name)
    {
        for (int i = 0; i < _staticBalls.Length; i++)
        {
            if (_staticBalls[i].name == name)
            {
                return i;
            }
        }
        return 0;
    }

    public static void DelBalls() {
        GameObject[] balls = GetActiveBalls();
        
        foreach (GameObject ball in balls) {
            Destroy(ball);
        }
    }

    public static Vector3 FindNewCentralPosition() {
        GameObject[] centralElements = GameObject.FindGameObjectsWithTag("CentralElement");

        if (centralElements.Length > 0)
        {
            int randomIndex = Random.Range(0, centralElements.Length);
            
            GameObject centralElement = centralElements[randomIndex];

            if (centralElement) {
                return centralElement.transform.position;
            } else {
                return new Vector3();
            }
        } else {
            return new Vector3();
        }
    }

    public static GameObject GetRandBall() {
        if (_staticBalls.Length > 0) {
            int randomIndex = Random.Range(0, _staticBalls.Length);
            
            GameObject ball = _staticBalls[randomIndex];

            return ball;
        } else {
            return null;
        }
    }
}
