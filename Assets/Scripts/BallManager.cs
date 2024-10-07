using UnityEngine;

public class BallManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _balls;

    public GameObject[] GetActiveBalls() {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Ball");
        return gameObjects;
    }

    public void SpawnBall(GameObject ball) {
        Vector2 position = FindNewCentralPosition();
        SpawnBall(ball, position);
    }

    public void SpawnRandBall() {
        GameObject ball = GetRandBall();

        if (ball) {
            SpawnBall(ball);
        }
    }

    public void ReSpawnRandBallInTheSamePosition(Vector2 position) {
        GameObject ball = GetRandBall();

        if (ball) {
            SpawnBall(ball, position);
        }
    }

    public void SpawnBall(GameObject ball, Vector2 position) {
        DelBalls();

        GameObject newBall = Instantiate(ball, position, Quaternion.identity);
        newBall.tag = "Ball";
    }

    public void DelBalls() {
        GameObject[] balls = GetActiveBalls();
        
        foreach (GameObject ball in balls) {
            if (ball != null) {
                 Destroy(ball);
            }
        }
    }

    public static Vector3 FindNewCentralPosition() {
        GameObject[] centralElements = GameObject.FindGameObjectsWithTag("CentralElement");

        if (centralElements.Length > 0)
        {
            int randomIndex = Random.Range(0, centralElements.Length);
            return centralElements[randomIndex].transform.position;
        }

        return Vector3.zero;
    }

    public GameObject GetRandBall() {
        if (_balls.Length > 0) {
            int randomIndex = Random.Range(0, _balls.Length);
            
            GameObject ball = _balls[randomIndex];

            return ball;
        } else {
            return null;
        }
    }
}
