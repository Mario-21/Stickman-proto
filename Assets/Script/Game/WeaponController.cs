﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class WeaponController : MonoBehaviour
{
    [Header("Disparo Player")]
    public Transform RaySpawn;
    public float rango;
    public GameObject bullet;
    public GameObject balaClon;
    public float fuerzaLanzamiento;
    [SerializeField]
    private int numeroDisparos = 0;
    [SerializeField]
    private int totalDisparos = 10;

    [Header("Objetivo de disparo en la escena")]
    public Transform mira;
    public Transform container;

    void Update()
    { 
        
        mira.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        if (numeroDisparos <= totalDisparos)
        {
            if (Input.GetButtonDown("Fire1")) 
            {
                AtaqueBotton();
            }
        }
    }

    private void LateUpdate()
    {
        container.up = container.position - mira.position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(RaySpawn.position, (mira.position - container.position));
    }

    public void AtaqueBotton()
    {
        balaClon = Instantiate(bullet, RaySpawn.position, RaySpawn.rotation);
        balaClon.GetComponent<Rigidbody2D>().velocity =transform.right * fuerzaLanzamiento;
        Turn.seguirBala = true;
        numeroDisparos++;
        Turn.moverCamera = false;
        //RaycastHit2D hit = Physics2D.Raycast(RaySpawn.position, (mira.position - container.position).normalized, 1000f, ~(1 << 10));
    }
}
