using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    public GameObject dialogBox;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
       if (other.CompareTag("Player"))
        {
            dialogBox.SetActive(true);
        }
    }
}
