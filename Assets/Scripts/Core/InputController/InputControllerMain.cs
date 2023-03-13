using Units;
using UnityEngine;

namespace Core.InputController
{
    public class InputControllerMain : MonoBehaviour
    {
        private Player _player;
        
        public void Init(Player player)
        {
            _player = player;
        }

        public void MoveForward()
        {
            _player.Move(1);
        }

        public void MoveBack()
        {
            _player.Move(-1);
        }

        public void RotationLeft()
        {
            _player.RotationHorizontal(-1);
        }

        public void RotationRight()
        {
            _player.RotationHorizontal(1);
        }
        
        public void RotationUp()
        {
            _player.RotationVertical(-1);
        }

        public void RotationDown()
        {
            _player.RotationVertical(1);
        }

        public void Shoot()
        {
            _player.Shoot();
        }
        
        public void Ultimate()
        {
            _player.UseUltimate();
        }
    }
}