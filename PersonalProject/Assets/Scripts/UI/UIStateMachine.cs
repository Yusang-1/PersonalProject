public class UIStateMachine
{
    UIState currentState;

    public UIStateMachine(UIState defaultState)
    {
        currentState = defaultState;
    }

    public void SetState(UIState state)
    {
        UIManager.Instance.UIDictionary[currentState].SetActive(false);

        currentState = state;

        UIManager.Instance.UIDictionary[currentState].SetActive(true);
    }
}
