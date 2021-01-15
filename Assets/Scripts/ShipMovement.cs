using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] float planetSpeed = 5f;
    [SerializeField] float turnSpeed = 5f;
    [SerializeField] float sensingDist = 50f;
    WorldGen world;

    private void Start() {
        world = GetComponent<WorldGen>();
    }

    private void Update() {
        SetVel();
        AvoidPlanets();
    }
    Vector3 reflection;
    private void AvoidPlanets() {
        bool hitOnce = false;
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, sensingDist)) {
            if (hit.collider.tag == "Planet") {
                Rigidbody rb = hit.collider.attachedRigidbody;
                if (!hitOnce) {
                    reflection = Vector3.Reflect(transform.forward, hit.normal);
                    hitOnce = true;
                }
                rb.AddRelativeForce(reflection * turnSpeed);
                Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);
                Debug.Log("Collision");
                if (hit.distance <= sensingDist / 2)
                    turnSpeed = 10000;
                else
                    turnSpeed = 7000;

            }
        }
        else {
            Debug.DrawRay(transform.position, transform.forward * sensingDist, Color.blue);
            hitOnce = false;
        }
    }

    private void SetVel() {
        foreach (GameObject planet in world.planetsInWorld) {
            Rigidbody rb = planet.GetComponent<Rigidbody>();
            rb.velocity = transform.forward * -planetSpeed;
        }
    }
}
