using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{
    public GameObject[] levels;
    private Camera mainCamera;
    private Vector2 screenBounds;
    public float choke;
    public float scrollSpeed = 0;

    void Start()
    {
        mainCamera = gameObject.GetComponent<Camera>();
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        foreach (var obj in levels)
        {
            loadChildObjects(obj);
        }
    }
    void loadChildObjects(GameObject obj)
    {
        var objectWidth = obj.GetComponent<SpriteRenderer>().bounds.size.x - choke;
        var childsNeeded = (int)Mathf.Ceil(screenBounds.x * 2 / objectWidth);
        var clone = Instantiate(obj);
        for (int i = 0; i <= childsNeeded; i++)
        {
            GameObject c = Instantiate(clone);
            c.transform.SetParent(obj.transform);
            c.transform.position = new Vector3(objectWidth * i, obj.transform.position.y, obj.transform.position.z);
            c.name = obj.name + i;
        }
        Destroy(clone);
        Destroy(obj.GetComponent<SpriteRenderer>());
    }
    void repositionChildObjects(GameObject obj)
    {
        var children = obj.GetComponentsInChildren<Transform>();
        if (children.Length > 1)
        {
            var firstChild = children[1].gameObject;
            var lastChild = children[children.Length - 1].gameObject;
            var halfObjectWidth = lastChild.GetComponent<SpriteRenderer>().bounds.extents.x - choke;
            if (transform.position.x + screenBounds.x > lastChild.transform.position.x + halfObjectWidth)
            {
                firstChild.transform.SetAsLastSibling();
                firstChild.transform.position = new Vector3(lastChild.transform.position.x + halfObjectWidth * 2,
                    lastChild.transform.position.y, 
                    lastChild.transform.position.z);
            }
            else if (transform.position.x - screenBounds.x < firstChild.transform.position.x - halfObjectWidth)
            {
                lastChild.transform.SetAsFirstSibling();
                lastChild.transform.position = new Vector3(firstChild.transform.position.x - halfObjectWidth * 2,
                    firstChild.transform.position.y,
                    firstChild.transform.position.z);
            }
        }
    }
    void Update()
    {

        var velocity = Vector3.zero;
        var desiredPosition = transform.position + new Vector3(scrollSpeed, 0, 0);
        var smoothPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, 0.3f);
        transform.position = smoothPosition;

    }
    void LateUpdate()
    {
        foreach (var obj in levels)
        {
            repositionChildObjects(obj);
        }
    }
}