using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DoorManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int nilai;
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

        if (DialogSystem.nilai == 3)
        {

            key1 = true;
        }
        else if (DialogSystem.nilai == 6)
        {
            key2 = true;
        }
        else if (DialogSystem.nilai == 7)
        {
            key3 = true;
        }
        OpenDoor();
    }

    public void OpenDoor()
    {
        // Check Door 1
        if (key1 && doorAnimator != null)
        {
            doorAnimator.SetTrigger("open");
            if (doorObstacle != null)
                doorObstacle.enabled = false;
        }

        // Check Door 2
        if (key2 && doorAnimator2 != null)
        {
            doorAnimator2.SetTrigger("open");
            if (doorObstacle2 != null)
                doorObstacle2.enabled = false;
        }

        // Check Door 3
        if (key3 && doorAnimator3 != null)
        {
            doorAnimator3.SetTrigger("open");
            if (doorObstacle3 != null)
                doorObstacle3.enabled = false;
        }
    }
}
