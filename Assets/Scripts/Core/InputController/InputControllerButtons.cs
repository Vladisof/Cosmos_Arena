namespace Core.InputController
{
    public class InputControllerButtons : InputControllerMain, IInputController
    {
        private bool _isMoveForward;
        private bool _isMoveBack;
        private bool _isRotationRight;
        private bool _isRotationLeft;
        private bool _isRotationUp;
        private bool _isRotationDown;

        private void Update()
        {
            if (_isMoveForward)
            {
                MoveForward();
            }
            else if (_isMoveBack)
            {
                MoveBack();
            }
            else if (_isRotationRight)
            {
                RotationRight();
            }
            else if (_isRotationLeft)
            {
                RotationLeft();
            }
            else if (_isRotationUp)
            {
                RotationUp();
            }
            else if (_isRotationDown)
            {
                RotationDown();
            }
        }

        public void SetMoveForward()
        {
            _isMoveForward = true;
        }

        public void SetMoveBack()
        {
            _isMoveBack = true;
        }

        public void SetRotationLeft()
        {
            _isRotationLeft = true;
        }

        public void SetRotationRight()
        {
            _isRotationRight = true;
        }

        public void SetRotationUp()
        {
            _isRotationUp = true;
        }

        public void SetRotationDown()
        {
            _isRotationDown = true;
        }
        
        public void Stop()
        {
            _isMoveForward = false;
            _isMoveBack = false;
            _isRotationRight =false;
            _isRotationLeft = false;
            _isRotationUp = false;
            _isRotationDown = false;
        }
        
        public void Enable()
        {
            gameObject.SetActive(true);
        }

        public void Disable()
        {
            gameObject.SetActive(false);
        }
    }
}