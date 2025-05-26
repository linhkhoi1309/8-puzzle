using System.Numerics;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GraphController : MonoBehaviour
{
    public Tilemap tilemap;
    public Vector2Int gridLowerBound;
    public Vector2Int gridUpperBound;
    public Sprite blankSprite;
    public Sprite oneSprite;
    public Sprite twoSprite;
    public Sprite threeSprite;
    public Sprite fourSprite;
    public Sprite fiveSprite;
    public Sprite sixSprite;
    public Sprite sevenSprite;
    public Sprite eightSprite;
    [HideInInspector] public int width;
    [HideInInspector] public int height;
    public int[,] currentState;
    public int[,] initalState;

    void Start()
    {
        InitializeGraph();
    }

    public void InitializeGraph()
    {
        width = gridUpperBound.x - gridLowerBound.x + 1;
        height = gridUpperBound.y - gridLowerBound.y + 1;
        currentState = new int[width, height];

        // Set initial state of the graph
        int cnt = 1;
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                currentState[x, y] = cnt;
                cnt++;
                if (cnt > 8) cnt = 0;
            }
        }
        initalState = (int[,])currentState.Clone();
        RotateGraphClockWise(currentState, width);
        SetGraphState(currentState);
    }

    public void SetCellSprite(Vector2Int graphPosition, int value)
    {
        Vector3Int cellPosition = new Vector3Int(graphPosition.x + gridLowerBound.x, graphPosition.y + gridLowerBound.y, 0);
        Sprite spriteToSet = blankSprite;

        switch (value)
        {
            case 1:
                spriteToSet = oneSprite;
                break;
            case 2:
                spriteToSet = twoSprite;
                break;
            case 3:
                spriteToSet = threeSprite;
                break;
            case 4:
                spriteToSet = fourSprite;
                break;
            case 5:
                spriteToSet = fiveSprite;
                break;
            case 6:
                spriteToSet = sixSprite;
                break;
            case 7:
                spriteToSet = sevenSprite;
                break;
            case 8:
                spriteToSet = eightSprite;
                break;
        }

        Tile tile = ScriptableObject.CreateInstance<Tile>();
        tile.sprite = spriteToSet;
        tilemap.SetTile(cellPosition, tile);
    }

    public bool IsCellWithinBounds(Vector2Int cellPosition)
    {
        return cellPosition.x >= gridLowerBound.x && cellPosition.x <= gridUpperBound.x &&
               cellPosition.y >= gridLowerBound.y && cellPosition.y <= gridUpperBound.y;
    }

    public void ColorCell(Vector2Int graphPosition, Sprite sprite)
    {
        Vector3Int cellPosition = new Vector3Int(graphPosition.x + gridLowerBound.x, graphPosition.y + gridLowerBound.y, 0);
        Tile tile = ScriptableObject.CreateInstance<Tile>();
        tile.sprite = sprite;
        tilemap.SetTile(cellPosition, tile);
    }

    public void RotateGraphClockWise(int[,] graph, int n)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n - 1 - i; j++)
            {
                Ultility.Swap(ref graph[i, j], ref graph[n - 1 - j, n - 1 - i]);
            }
        }
        for (int i = 0; i < n / 2; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Ultility.Swap(ref graph[i, j], ref graph[n - 1 - i, j]);
            }
        }
    }

    public void ShuffleGraph(int[,] graph, int n)
    {
        int[] temp = new int[n * n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                temp[i * n + j] = graph[i, j];
            }
        }
        Ultility.Shuffle(temp);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                graph[i, j] = temp[i * n + j];
            }
        }
    }

    public void SetGraphState(int[,] graph)
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector2Int graphPosition = new Vector2Int(x, y);
                SetCellSprite(graphPosition, graph[x, y]);
            }
        }
    }
}
