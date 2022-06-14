namespace com.apapiez.StatelyPlugs
{
    /// <summary>
    /// Transition binds together a decision and the potential states to transition to
    /// If the decision returns true, the FSM is moved to the true state
    /// If the decision returns False, the FSM is moved to the false state.
    /// </summary>
    [System.Serializable]
    public class Transition
    {
        public Decision decision;
        public State trueState;
        public State falseState;

    }
}