using System;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float redius = 3f;
    public Transform interactionTransform;

    bool isFocused=false;
    Transform player;

    bool hasIntracted = false;

    private void Update()
    {
        if(isFocused && !hasIntracted)
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if (distance < redius)
            {
                interact();
                hasIntracted = true;
            }
        }
    }

    public virtual void interact()
    {
        Debug.Log("Intraction with "+ transform.name);
    }

    public void onFocused(Transform playerTransform)
    {
        isFocused = true;
        player = playerTransform;
        hasIntracted = false;
    }

    public void onDefocused()
    {
        isFocused = false;
        player = null;
        hasIntracted = false;
    }
    private void OnDrawGizmosSelected()
    {

        if (interactionTransform == null)
            interactionTransform = transform;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, redius);
    }
}
