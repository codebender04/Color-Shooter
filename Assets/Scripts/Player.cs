using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private float rotateSpeed;
    private Quaternion target = Quaternion.Euler(0, 0, 0);
    private bool isSlerping = false;
    private void Update()
    {   
        if (Input.GetKeyDown(KeyCode.W))
        {
            target = Quaternion.Euler(0, 0, 90);
        } 
        else if (Input.GetKeyDown(KeyCode.A))
        {
            target = Quaternion.Euler(0, 0, 180);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            target = Quaternion.Euler(0, 0, -90);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            target = Quaternion.Euler(0, 0, 0);
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * rotateSpeed);

        if (Quaternion.Angle(transform.rotation, target) < 4f)
        {
            isSlerping = false;
        }
        else
        {
            isSlerping = true;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isSlerping)
            {
                Instantiate(bulletPrefab, shootPoint.position, transform.rotation);
            }
        }
    }
}
