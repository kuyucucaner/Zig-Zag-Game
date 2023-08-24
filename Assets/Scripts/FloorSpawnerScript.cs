using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawnerScript : MonoBehaviour
{
    public GameObject lastFloor;

    private void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            CreateFloor();

        }
    }
        void Update()
    {
    
        
    }

    public void CreateFloor()
    {
       Vector3 direction;
       if(Random.Range(0,2) == 0)
        {
            direction = Vector3.left;
        }
       else
        {
            direction = Vector3.forward;
        }
        lastFloor =  Instantiate(lastFloor,lastFloor.transform.position + direction,lastFloor.transform.rotation);
    }
}
