using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float timeOffset;
    [SerializeField] private Vector2 posOffset;

    void Start()
    {
        
    }

    void Update()
    {
        var start = transform.position;
        var end = player.transform.position;
        end.x += posOffset.x;
        end.y += posOffset.y;
        end.z = -10;
        transform.position = Vector3.Lerp(start, end, timeOffset * Time.deltaTime);
    }
}
