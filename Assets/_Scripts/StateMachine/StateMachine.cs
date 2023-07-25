using System;
using System.Collections.Generic;

public class StateMachine
{
    public IState currentState { get; private set; }

    private Stack<IState> stateStack = new();

    public void SetState(IState newState)
    {
        if (currentState != null)
            currentState.Exit();

        stateStack.Push(newState);
        currentState = newState;
        currentState.Enter();
    }

    public void ReturnPreviousState()
    {
        if (stateStack.Count <= 1 || currentState == null)
            throw new Exception("There is nothing in the state stack!");

        currentState.Exit();
        stateStack.Pop();
        currentState = stateStack.Peek();
        currentState.Enter();
    }
}
