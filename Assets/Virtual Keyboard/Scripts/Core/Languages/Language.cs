namespace VirtualKeyboard
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "New Language", menuName = "Virtual Keyboard/Keyboard Language", order = 0)]
    public class Language : ScriptableObject
    {
        [SerializeField] ButtonRowNames[] rowNames;
        [SerializeField] ButtonRowNames[] alternateRowNames;

        public ButtonRowNames GetRow(int row, bool alternate)
        {
            if (alternate && alternateRowNames.Length == rowNames.Length) return alternateRowNames[row];
            return rowNames[row];
        }

        public ButtonRowNames[] GetAllRows(bool alternate)
        {
            if (alternate && alternateRowNames.Length == rowNames.Length) return alternateRowNames;
            return rowNames;
        }
    }
}
