using Units;

namespace Core.InputController
{
    public interface IInputController
    {
        void Init(Player player);
        void Enable();
        void Disable();
    }
}