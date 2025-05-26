using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Button randomizeButton;
    public Button resetButton;

    GraphController graphController;

    private void Awake()
    {
        graphController = FindFirstObjectByType<GraphController>();
    }
    void Start()
    {
        randomizeButton.onClick.AddListener(OnRandomizeButtonClicked);
        resetButton.onClick.AddListener(OnResetButtonClicked);
    }

    private void OnRandomizeButtonClicked()
    {
        graphController.ShuffleGraph(graphController.currentState, graphController.width);
        graphController.SetGraphState(graphController.currentState);
    }

    public void OnResetButtonClicked()
    {
        graphController.ResetGraph();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
