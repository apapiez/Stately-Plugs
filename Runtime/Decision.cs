using UnityEngine;

namespace com.apapiez.StatelyPlugs
{
    /// <summary>
    /// Abstract base class which a FSM transition uses to decide which state to switch into
    /// when creating concrete implementations, remeber to add a CreateAssetMenu directive to enable editor functionality
    /// </summary>
    public abstract class Decision : ScriptableObject
    {
        public abstract bool Decide(StateManager stateManager);
    }
}

