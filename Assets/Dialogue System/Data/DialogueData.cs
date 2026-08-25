using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    [CreateAssetMenu(fileName="New Dialogue", menuName="Dialogue/New Dialogue")]
    public class DialogueData : ScriptableObject
    {
        [SerializeField, TextArea(2, 5)] private List<string> lines = new();
        
        public IReadOnlyList<string> Lines => lines;
    }
}