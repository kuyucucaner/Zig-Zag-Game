using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovementScript : MonoBehaviour
{
    Vector3 direction;
    public float speed;
    public FloorSpawnerScript floorSpawner;
    public static bool didItFall;
    public float extraSpeed;

     void Start()
    {
        direction = Vector3.forward;
        didItFall = false;
    }
     void Update()
    {   if(transform.position.y <= 0.5f)
            {
            didItFall = true;
        }
        if (didItFall == true)
        {
            return;
        }
        if(Input.GetMouseButtonDown(0))
        {
            if(direction.x == 0)
            {
                direction = Vector3.left;
            }
            else
            {
                direction = Vector3.forward;
            }

            speed =speed + extraSpeed * Time.deltaTime;
        }
    }
    private void FixedUpdate()
    {
        Vector3 movement = (direction*Time.deltaTime) * speed;
        transform.position += movement;
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            ScoreScript.score++;
            collision.gameObject.AddComponent<Rigidbody>();
            floorSpawner.CreateFloor();
            StartCoroutine(DeleteFloor(collision.gameObject));
        }
    }

    IEnumerator DeleteFloor(GameObject floor)
    {
        yield return new WaitForSeconds(3f);
        Destroy(floor);
    }
}
