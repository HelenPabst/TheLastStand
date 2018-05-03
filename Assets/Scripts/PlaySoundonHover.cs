using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundonHover : MonoBehaviour
{ 
    private void OnMouseOver()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }
}
