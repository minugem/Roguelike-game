using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{
    [SerializeField] private int Width;
    [SerializeField] private int Height;

    private Node[,] Grid;

    public List<Node> Nodes = new();

    private List<Vector2Int> ToCollapse = new();

    private Vector2Int[] Offsets = new Vector2Int[]
    {
        new Vector2Int(0,1),
        new Vector2Int(0,-1),
        new Vector2Int(1,0),
        new Vector2Int(-1,0)
    };

    private void Start()
    {
        Grid = new Node[Width, Height];
        Collapse();
    }

    private void Collapse()
    {
        ToCollapse.Clear();
        ToCollapse.Add(new Vector2Int(Width / 2, Height / 2));

        while (ToCollapse.Count > 0)
        {
            int x = ToCollapse[0].x;
            int y = ToCollapse[0].y;

            List<Node> nodes = new(Nodes);

            for (int i = 0; i < Offsets.Length; i++)
            {
                Vector2Int neighbour = new Vector2Int(x + Offsets[i].x, y + Offsets[i].y);

                if (InGride(neighbour))
                {
                    Node neighbourNode = Grid[neighbour.x, neighbour.y];
                    if (neighbourNode == null)
                    {
                        if (!ToCollapse.Contains(neighbour)) ToCollapse.Add(neighbour);
                    }
                    else
                    {
                        switch (i)
                        {
                            case 0:
                                WhittleNodes(nodes, neighbourNode.Down.CompatibleNodes);
                                break;
                            case 1:
                                WhittleNodes(nodes, neighbourNode.Up.CompatibleNodes);
                                break;
                            case 2:
                                WhittleNodes(nodes, neighbourNode.Left.CompatibleNodes);
                                break;
                            case 3:
                                WhittleNodes(nodes, neighbourNode.Right.CompatibleNodes);
                                break;
                        }
                    }
                }
            }

            if (nodes.Count < 1)
            {
                Grid[x, y] = Nodes[0];
                Debug.LogWarning("Fail on " + x + ", " + y);
            }
            else
            {
                Grid[x, y] = Nodes[Random.Range(0, nodes.Count)];
            }

            Instantiate(Grid[x, y].Prefab, new Vector3(x, y, 0), Quaternion.identity);
            ToCollapse.RemoveAt(0);
        }
    }

    private void WhittleNodes(List<Node> nodes, List<Node> validNodes)
    {
        for (int i = nodes.Count - 1; i >= 0; i--)
        {
            if (!validNodes.Contains(nodes[i]))
            {
                nodes.RemoveAt(i);
            }
        }
    }

    private bool InGride(Vector2Int pos)
    {
        return pos.x > -1 && pos.x < Width && pos.y > -1 && pos.y < Height;
    }
}
