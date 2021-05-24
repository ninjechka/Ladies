using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float timeOffset;
    [SerializeField] private Vector2 posOffset;
    [SerializeField] private float leftLimit;
    [SerializeField] private float rightLimit;
    [SerializeField] private float bottomLimit;
    [SerializeField] private float topLimit;

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
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
            Mathf.Clamp(transform.position.y, bottomLimit, topLimit),
            transform.position.z);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(leftLimit, topLimit), 
            new Vector2(rightLimit, topLimit));
        Gizmos.DrawLine(new Vector2(rightLimit, topLimit), 
            new Vector2(rightLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(rightLimit, bottomLimit),
            new Vector2(leftLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, bottomLimit),
            new Vector2(leftLimit, topLimit));

    }
}
