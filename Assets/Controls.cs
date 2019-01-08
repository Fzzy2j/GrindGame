﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{

    public Rigidbody2D rigidBody;
    public StringRenderer grappleStringPrefab;

    private StringRenderer grappleString;
    private DistanceJoint2D joint;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, getDirection());
            if (hit.collider != null)
            {
                grappleString = Instantiate(grappleStringPrefab.gameObject).GetComponent<StringRenderer>();
                grappleString.point3.position = hit.point;
                grappleString.point1.position = gameObject.transform.position;
                grappleString.centerString();
                joint = gameObject.AddComponent(typeof(DistanceJoint2D)) as DistanceJoint2D;
                joint.connectedBody = grappleString.point3.GetComponent<Rigidbody2D>();
            }
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            if (grappleString != null)
                Destroy(grappleString.gameObject);
            if (joint != null)
                Destroy(joint);
        }
        if (Input.GetKey(KeyCode.LeftArrow) && rigidBody.velocity.x > -1)
        {
            rigidBody.AddForce(new Vector2(-1, 0));
        }
        if (Input.GetKey(KeyCode.RightArrow) && rigidBody.velocity.x < 1)
        {
            rigidBody.AddForce(new Vector2(1, 0));
        }

        if (grappleString != null)
            grappleString.point1.position = gameObject.transform.position;

    }

    private Vector2Int getDirection()
    {
        Vector2Int dir = new Vector2Int(0, 0);

        if (Input.GetKey(KeyCode.LeftArrow))
            dir.x = -1;
        else if (Input.GetKey(KeyCode.RightArrow))
            dir.x = 1;

        if (Input.GetKey(KeyCode.UpArrow))
            dir.y = 1;
        else if (Input.GetKey(KeyCode.DownArrow))
            dir.y = -1;

        return dir;
    }
}
