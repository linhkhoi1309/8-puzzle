using System;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Button randomizeButton;

    GraphController graphController;

    private void Awake()
    {
        graphController = FindFirstObjectByType<GraphController>();
    }
    void Start()
    {
        randomizeButton.onClick.AddListener(OnRandomizeButtonClicked);
    }

    private void OnRandomizeButtonClicked()
    {
        graphController.ShuffleGraph(graphController.currentState, graphController.width);
        graphController.SetGraphState(graphController.currentState);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
