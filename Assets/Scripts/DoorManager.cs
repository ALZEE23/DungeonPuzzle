using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DoorManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator doorAnimator;
    public Animator doorAnimator2;
    public Animator doorAnimator3;

    public NavMeshObstacle doorObstacle;
    public NavMeshObstacle doorObstacle2;
    public NavMeshObstacle doorObstacle3;

    public bool key1;
    public bool key2;
    public bool key3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenDoor()
    {
        switch (gameObject.name)
        {
            case "Door1":
                if (key1)
                {
                    doorAnimator.SetTrigger("Open");
                    doorObstacle.enabled = false;
                }
                break;
            case "Door2":
                if (key2)
                {
                    doorAnimator2.SetTrigger("Open");
                    doorObstacle2.enabled = false;
                }
                break;
            case "Door3":
                if (key3)
                {
                    doorAnimator3.SetTrigger("Open");
                    doorObstacle3.enabled = false;
                }
                break;
        }
    }
}
