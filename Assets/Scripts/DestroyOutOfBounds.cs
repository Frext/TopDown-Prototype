using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    [SerializeField] private float topBound = 30f;
    [SerializeField] private float lowerBound = -10f;

    private static int lives = 3;

    private void Start()
    {
        if (transform.position.z > topBound) {

            Destroy(gameObject);
        }
        else if (transform.position.z < lowerBound) {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (transform.position.z > topBound) {

            Destroy(gameObject);
        } else if (transform.position.z < lowerBound) {

            DecreaseLives();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer.Equals(LayerMask.NameToLayer("Player"))) {

            DecreaseLives();
        }
    }

    private void DecreaseLives()
    {
        lives = Mathf.Clamp(lives - 1, 0, 3);

        if (lives > 0) {

            print("Lives : " + lives);
        } else { 
            print("Game Over!");
        }
    }
}
