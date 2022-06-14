using UnityEngine;

namespace com.apapiez.StatelyPlugs
{
    /// <summary>
    /// State class which executes actions and holds references to transitions and actions
    /// </summary>
    [CreateAssetMenu(menuName = "StatelyPlugs/State")]
    public class State : ScriptableObject
    {

        #region private-fields

        // The list of actions which will be performed each tick
        [SerializeField] private ScriptableAction[] actions;

        // The list of actions to perform when entering the state
        [SerializeField] private ScriptableAction[] entryActions;

        // The list of actions to perform when exiting the state
        [SerializeField] private ScriptableAction[] exitActions;

        // The list of potential transitions to other states
        [SerializeField] private Transition[] transitions;


        #endregion

        #region accessors

        public ScriptableAction[] Actions
        {
            get { return actions; }
            set { actions = value; }

        }

        public ScriptableAction[] EntryActions
        {
            get { return entryActions; }
            set { entryActions = value; }
        }

        public ScriptableAction[] ExitActions
        {
            get { return exitActions; }
            set { exitActions = value; }
        }

        public Transition[] Transitions
        {
            get { return transitions; }
            set { transitions = value; }
        }

        #endregion

        /// <summary>
        /// The method called each tick to update the state machine
        /// Executes any actions associated with the state then checks for possible transitions
        /// </summary>
        /// <param name="stateManager"> The state manager running the machine </param>
        public void UpdateState(StateManager stateManager)
        {
            ExecuteActions(stateManager);
            CheckForTransitions(stateManager);
        }

        /// <summary>
        /// Runs the actions associated with the state to be run each tick
        /// </summary>
        /// <param name="stateManager"></param>
        private void ExecuteActions(StateManager stateManager)
        {
            foreach (ScriptableAction action in actions)
            {
                action.Execute(stateManager.gameObject);
            }
        }

        /// <summary>
        /// Runs the entry actions when the state is first entered
        /// </summary>
        /// <param name="stateManager"></param>
        public void ExecuteEntryActions(StateManager stateManager)
        {
            foreach (ScriptableAction action in entryActions)
            {
                action.Execute(stateManager.gameObject);
            }
        }

        /// <summary>
        /// Runs the exit actions when the state is exited
        /// </summary>
        /// <param name="stateManager"></param>
        public void ExecuteExitActions(StateManager stateManager)
        {
            foreach (ScriptableAction action in exitActions)
            {
                action.Execute(stateManager.gameObject);
            }
        }

        /// <summary>
        /// Calls the decision method on each transition to see if the transition can go ahead
        /// If it can, changes the state on the state manager which then handles calling this states exit actions and the new states exit actions
        /// </summary>
        /// <param name="stateManager"></param>
        private void CheckForTransitions(StateManager stateManager)
        {
            foreach (Transition transition in transitions)
            {
                bool decisionSucceeded = transition.decision.Decide(stateManager);
                if (decisionSucceeded)
                {
                    stateManager.TransitionToState(transition.trueState);
                }
                else
                {
                    stateManager.TransitionToState(transition.falseState);
                }
            }
        }


    }
}