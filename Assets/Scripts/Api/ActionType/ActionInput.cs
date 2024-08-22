using System;
using System.Collections.Generic;

namespace Api.ActionType
{
    public class ActionInput
    {
        private readonly ActionType _action;
        private InputType[] _inputs;

        public ActionInput(ActionType action, InputType input1, InputType input2 = InputType.None)
        {
            _action = action;
            _inputs = new[] { input1, input2 };
        }

        public void ChangeInput(int index, InputType input)
        {
            // if()
            // _inputs[0]
        }
    }
}