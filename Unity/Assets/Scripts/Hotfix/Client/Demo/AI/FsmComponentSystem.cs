
using UnityHFSM;

namespace ET.Client
{
    [FriendOf(typeof(FsmComponent))]
    public class FsmComponentAwakeSystem : AwakeSystem<FsmComponent>
    {
        protected override void Awake(FsmComponent self)
        {
            self.Fsm = new StateMachine();

            self.Fsm.AddState(StateTypes.Idle.ToString(), new CharacterState(self));
            self.Fsm.AddState(StateTypes.Run.ToString(), new CharacterState(self));
            self.Fsm.Init();
        }
    }
    [FriendOf(typeof(FsmComponent))]
    public class FsmComponentDestroySystem : DestroySystem<FsmComponent>
    {
        protected override void Destroy(FsmComponent self)
        {

        }
    }
    [FriendOf(typeof(FsmComponent))]
    public class FsmComponentUpdateSystem : UpdateSystem<FsmComponent>
    {
        protected override void Update(FsmComponent self)
        {
            self.Fsm.OnLogic();
        }
    }
    [FriendOf(typeof(FsmComponent))]
    public static class FsmComponentSystem
    {
        public static void ChangeState(this FsmComponent self, string name)
        {
            if (self.Fsm != null)
                self.Fsm.RequestStateChange(name);
        }
    }
}
