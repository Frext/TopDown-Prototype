using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] private float speed = 25.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self);
    }
}
