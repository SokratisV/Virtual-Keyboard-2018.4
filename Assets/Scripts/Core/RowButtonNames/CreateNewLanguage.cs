namespace VirtualKeyboard
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "New Language", menuName = "Virtual Keyboard/Keyboard Language", order = 0)]
    public class CreateNewLanguage : ScriptableObject
    {
        [SerializeField] ButtonRowNames[] rowNames;
        [SerializeField] ButtonRowNames[] alternateRowNames;

        public ButtonRowNames GetRow(int row, bool alternate = false)
        {
            Debug.Assert(rowNames.Length != alternateRowNames.Length, $"{name} is not setup correctly (alternate rows)");
            if (alternate) return alternateRowNames[row];
            return rowNames[row];
        }

        public ButtonRowNames[] GetAllRows(bool alternate = false)
        {
            Debug.Assert(rowNames.Length != alternateRowNames.Length, $"{name} is not setup correctly (alternate rows)");
            if (alternate) return alternateRowNames;
            return rowNames;
        }
    }
}
