using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.apapiez.StatelyPlugs
{
    /// <summary>
    /// Abstract base class for an action which can be attached to states
    /// When implementing concrete classes remeber to include the CreateAssetMenu directive
    /// </summary>
    public abstract class ScriptableAction : ScriptableObject
    {
        public abstract void Execute(GameObject actor);

    }
}