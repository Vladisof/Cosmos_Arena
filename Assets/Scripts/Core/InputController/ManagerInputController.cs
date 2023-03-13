using System;
using Units;
using UnityEngine;

namespace Core.InputController
{
    public class ManagerInputController : MonoBehaviour
    {
        [SerializeField] private InputControllerButtons _inputControllerButtons;

        public void Init(TypeInputController typeInputController)
        {
            switch (typeInputController)
            {
                case TypeInputController.None:
                    break;
                case TypeInputController.Button:
                {
                    SetActiveInputControllerButton(ActiveUnitsSingleton.Instance.Player);
                    break;
                }
                case TypeInputController.ButtonKeyboard:
                {
                    SetActiveInputControllerButton(ActiveUnitsSingleton.Instance.Player);
                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException(nameof(typeInputController), typeInputController, null);
            }
        }
        
        
        private void SetActiveInputControllerButton(Player player)
        {
            _inputControllerButtons.Init(player);
            _inputControllerButtons.Enable();
        }
    }
}