using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Node", menuName = "Node")]
[System.Serializable]
public class Node : ScriptableObject
{
    public GameObject Prefab;
    public Connection Up;
    public Connection Down;
    public Connection Left;
    public Connection Right;
}

[System.Serializable]
public class Connection
{
    public List<Node> CompatibleNodes = new();
}