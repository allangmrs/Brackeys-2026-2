using UnityEngine;

namespace Fairy
{
    public class FairyDialoguePoint : MonoBehaviour
    {
        [field: SerializeField]
        public bool FaceRight { get; private set; } = true;
    }
}