using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeRingerScript : MonoBehaviour
{

    Collider2D Collider;

    private void Awake()
    {
        Collider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        
    }

    private void EnabledCollider(bool EnabledCollider)
    {
        if (!EnabledCollider)
        {
            Collider.enabled = false;
        }
        else
        {
            Collider.enabled = true;
        }
    }

}
