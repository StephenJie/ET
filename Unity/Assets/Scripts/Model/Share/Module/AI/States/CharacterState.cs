
using ET;
using ET.Client;
using UnityHFSM;

namespace ET
{
    [EnableClass]
    public class CharacterState : State
    {
        public Unit owner;
        /// <summary>
        /// 互斥的状态，如果当前身上有这些状态，将无法切换至此状态
        /// </summary>
        public StateTypes ConflictState =
                StateTypes.RePluse | StateTypes.Dizziness | StateTypes.Striketofly | StateTypes.Sneer | StateTypes.Fear;

        public CharacterState(FsmComponent self)
        {
            owner = self.GetParent<Unit>();
        }

        public override void OnEnter()
        {
            //this.nam
            Log.Info(this.name + ":OnEnter");
            EventSystem.Instance.Publish(owner.Scene(), new Event_PlayAnimation() { Unit = owner ,StateName=this.name});
        }
        public override void OnLogic()
        {
            //Log.Info("IdleState" + "OnLogic");

        }
        public override void Init()
        {
            Log.Info(this.name + ":Init");

        }
        public override void OnExit()
        {
            Log.Info(this.name + ":OnExit");
        }
    }
}