using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetManager : MonoBehaviour
{
    static AssetManager instance;
    public static AssetManager Instance { get { return instance; } }

    public List<GameObject> Trees { get => trees; set => trees = value; }
    public List<GameObject> Rocks { get => rocks; set => rocks = value; }
    public List<GameObject> Plants { get => plants; set => plants = value; }
    public List<GameObject> RawItems { get => rawItems; set => rawItems = value; }

    [SerializeField] List<GameObject> trees = new List<GameObject>();
    [SerializeField] List<GameObject> rocks = new List<GameObject>();
    [SerializeField] List<GameObject> plants = new List<GameObject>();
    [SerializeField] List<GameObject> rawItems = new List<GameObject>();
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
}
