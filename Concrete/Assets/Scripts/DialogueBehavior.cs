using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBehavior : MonoBehaviour
{
    [SerializeField] private Collider player;
    [SerializeField] private TextMesh text;

    private void OnTriggerEnter(Collider other)
    {
        if (other == player)
        {
            Debug.Log("enter");
            //text opacity behavior
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other == player)
        {
            Debug.Log("stay");
            //text opacity behavior
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //text opacity go back to 0
    }
}
