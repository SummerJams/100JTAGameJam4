using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    private Vector3 target;
    [SerializeField]
    private Texture2D aim;
    [SerializeField]
    int t;//
    private void Awake()
    {
        //aim = GetComponent<Texture2D>();
        //Cursor.SetCursor(aim, )
    }
    public void ActiveAim(bool isActive)
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (isActive)
            Cursor.SetCursor(aim, Vector2.zero, CursorMode.Auto);
        else
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        //new Texture2D(3, 3)
        t++;
    }
    private void Update()
    {
        //transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
