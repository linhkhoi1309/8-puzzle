using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class InputController : MonoBehaviour
{
    GraphController graphController;
    void Start()
    {
        graphController = FindFirstObjectByType<GraphController>();
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int cellPosition = graphController.tilemap.WorldToCell(mouseWorldPosition);
            Vector2Int graphPosition = new Vector2Int(cellPosition.x - graphController.gridLowerBound.x, cellPosition.y - graphController.gridLowerBound.y);
        }
    }
}
