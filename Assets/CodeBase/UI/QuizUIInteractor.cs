using TMPro;
using UnityEngine;

namespace CodeBase.UI
{
    public class QuizUIInteractor : MonoBehaviour
    {
        [SerializeField] private string _exerciseText;
        [SerializeField] private TextMeshProUGUI _exerciseTextComponent;
        
        public void UpdateText(Cell cell)
        {
            _exerciseTextComponent.text = _exerciseText + cell.Name;
        }
    }
}