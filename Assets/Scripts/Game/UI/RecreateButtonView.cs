using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class RecreateButtonView : MonoBehaviour
    {
        private Button _recenterButton;

        private void Start()
        {
            _recenterButton = GetComponent<Button>();
            
            _recenterButton.onClick.AddListener(() =>
                Debug.Log("Clicked")
            );
        }
    }
}
