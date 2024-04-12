

using UnityHFSM;

namespace ET.Client
{
    [ComponentOf(typeof(Unit))]
    public class FsmComponent : Entity,IAwake,IDestroy,IUpdate
    {
        public StateMachine Fsm;
    }
}
