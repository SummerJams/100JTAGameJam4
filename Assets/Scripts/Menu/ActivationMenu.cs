using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationMenu : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> children;
    [SerializeField]
    private bool _active = false;
    public bool active{get{return _active;}}
    private void Update()
    {
        ActiveMenu(_active);
    }
    private void OnDisable()
    {
        _active = false;
    }
    private void Start()
    {
        Transform[] childrenTransforms = GetComponentsInChildren<Transform>(true);
        for (int i = 1; i < childrenTransforms.Length; i++)
        {
            children.Add(childrenTransforms[i].gameObject);
            children[i-1].SetActive(false);
        }
    }
    public void ActiveMenu(bool active)
    {
        _active = active;
        for (int i = 0; i < children.Count; i++)
        {
            children[i].SetActive(_active);
        }
    }
}
