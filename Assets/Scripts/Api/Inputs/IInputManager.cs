using System;
using Api.Initializable;

namespace Api.Inputs
{
    public interface IInputManager
    {
        public bool MoveInput { get; }
        public bool InteractInput { get; }
        public bool AttackInput { get; }
        public bool DashInput { get; }
        public bool MenuOpenCloseInput { get; }
    }
}