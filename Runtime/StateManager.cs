using UnityEngine;

namespace com.apapiez.StatelyPlugs
{
    /// <summary>
    /// The behaviour to attach to a game object, responsible for running the FSM.
    /// </summary>
    public class StateManager : MonoBehaviour
    {

        #region private-fields
        // The current state the FSM is in
        [SerializeField] State currentState;
        
        // The state the FSM is about to transition to next tick
        [SerializeField] State nextState;

        // The state the FSM was in the previous tick
        //TODO: is this needed?
        [SerializeField] State previousState;

        // A dummy state, used to tell the state machine to remain in the same state
        [SerializeField] State remainState;

        //A flag to determine whether the FSM should be running or not
        [SerializeField] private bool isActive;

        #endregion

        #region accessors

        public State CurrentState
        {
            get { return currentState; }
            set { currentState = value; }
        }        

        public State NextState
        {
            get { return nextState; }
            set { nextState = value; }
        }        

        public State PreviousState
        {
            get { return previousState; }
            set { previousState = value; }
        }        

        public State RemainState
        {
            get { return remainState; }
            set { remainState = value; }
        }        

        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

        #endregion

        /// <summary>
        /// Moves the FSM to the next state
        /// Self transitions will call this method with remainState as an argument, keeping the FSM in the current state
        /// Calls the exit actions on the current state and the entry actions on the new state
        /// </summary>
        /// <param name="nextState">The state to switch to.</param>
        public void TransitionToState(State nextState)
        {
            if (nextState != remainState)
            {
                currentState.ExecuteExitActions(this);
                nextState.ExecuteEntryActions(this);
                previousState = currentState;
                currentState = nextState;
                isActive = true;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (!isActive)
            {
                return;
            }
            currentState.UpdateState(this);
        }
    }

}