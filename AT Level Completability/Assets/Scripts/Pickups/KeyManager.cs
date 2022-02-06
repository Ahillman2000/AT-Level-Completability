using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    [SerializeField] List<GameObject> keys;

    public void CollectKey(GameObject _key)
    {
        keys.Add(_key);
    }
    public void RemoveKey(GameObject _key)
    {
        keys.Remove(_key);
    }
    public bool HasKey(GameObject _key)
    {
        return keys.Contains(_key);
    }
}
