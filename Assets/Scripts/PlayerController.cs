using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;

    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float xRange;
    [SerializeField] private float zRange;

    private float horizontalInput;
    private float verticalInput;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -xRange) {
            
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        } else if (transform.position.x > xRange) {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.z > zRange) {

            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);

        } else if (transform.position.z < -zRange) {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
        transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space)) {

            Instantiate(projectilePrefab, transform.position + new Vector3(0, 0.3f, 0), Quaternion.identity);
        }
    }
}