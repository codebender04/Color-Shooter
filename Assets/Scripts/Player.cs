using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private float rotateSpeed;
    private Vector3 rotationVector = Vector3.zero;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            rotationVector = new Vector3(0, 90, 0);
        } 
        else if (Input.GetKeyDown(KeyCode.A))
        {
            rotationVector = new Vector3(0, 180, 0);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            rotationVector = new Vector3(0, -90, 0);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            rotationVector = new Vector3(0, 0, 0);
        }
        //transform.right = Vector3.Slerp(transform.right, rotationVector, rotateSpeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(bulletPrefab, shootPoint.position, transform.rotation);
        }
    }
}
