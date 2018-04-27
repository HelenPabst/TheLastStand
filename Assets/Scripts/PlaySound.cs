using UnityEngine;
using UnityEngine.EventSystems;

public class PlaySound : MonoBehaviour
{

    private AudioSource buttonSound;

    private void Start()
    {
        buttonSound = GetComponent<AudioSource>();
        if (buttonSound == null)
        {
            Debug.Log("EMpty");
        }
        Debug.Log("Sound played");
    }

    private void OnMouseEnter()
    {
        buttonSound.Play();
        Debug.Log("Sound played inside");
    }
}
