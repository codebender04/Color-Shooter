using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float speed;   

    public Color BulletColor => currentBulletColor;

    private Color red = new(1f, 0.25f, 0.25f, 1f);
    private Color green = new(0.4f, 1, 0.4f, 1f);
    private Color blue = new(0.3f, 0.5f, 1f, 1f);
    private Color[] colorArray;
    private Color currentBulletColor;
    private int currentColorIndex = 0;
    private Vector3 upPos;
    private Vector3 downPos;

    private void Awake()
    {
        upPos = transform.position + new Vector3(0f, 3f, 0f);
        downPos = transform.position + new Vector3(0f, -3f, 0f);
        colorArray = new Color[] { red, green, blue };
        currentBulletColor = colorArray[currentColorIndex];
    }
    private void Update()
    {
        HandleMovement();

        HandleColorSwitch();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot(currentBulletColor);
        }
    }
    private void HandleColorSwitch()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            currentColorIndex++;
            if (currentColorIndex > colorArray.Length - 1) { currentColorIndex = 0; }
            currentBulletColor = colorArray[currentColorIndex];
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            currentColorIndex--;
            if (currentColorIndex < 0) { currentColorIndex = colorArray.Length - 1; }
            currentBulletColor = colorArray[currentColorIndex];
        }
    }
    private void HandleMovement()
    {
        if (Vector2.Distance(transform.position, upPos) < 0.1f && Input.GetKeyDown(KeyCode.W))
        {
            return;
        }
        if (Vector2.Distance(transform.position, downPos) < 0.1f && Input.GetKeyDown(KeyCode.S))
        {
            return;
        }
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position += new Vector3(0f, 3f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position += new Vector3(0f, -3f, 0f);
        }
    }
    private void Shoot(Color bulletColor)
    {    
        currentBulletColor = bulletColor;
        Instantiate(bulletPrefab, shootPoint.position, transform.rotation);   
    }
    //private bool IsSlerping()
    //{
    //    return !(Quaternion.Angle(transform.rotation, target) < 4f);
    //}
    //private void HandleRotation()
    //{
    //    if (Input.GetKeyDown(KeyCode.W))
    //    {
    //        target = Quaternion.Euler(0, 0, 90);
    //    }
    //    else if (Input.GetKeyDown(KeyCode.A))
    //    {
    //        target = Quaternion.Euler(0, 0, 180);
    //    }
    //    else if (Input.GetKeyDown(KeyCode.S))
    //    {
    //        target = Quaternion.Euler(0, 0, -90);
    //    }
    //    else if (Input.GetKeyDown(KeyCode.D))
    //    {
    //        target = Quaternion.Euler(0, 0, 0);
    //    }

    //    transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * rotateSpeed);
    //}
}
