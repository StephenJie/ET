using UnityEngine;
using Cinemachine;

namespace ET
{
    [FriendOf(typeof(GlobalComponent))]
    public static partial class GlobalComponentSystem
    {
        [EntitySystem]
        public static void Awake(this GlobalComponent self)
        {
            self.Global = GameObject.Find("/Global").transform;
            self.Unit = GameObject.Find("/Global/Unit").transform;
            self.UI = GameObject.Find("/Global/UI").transform;
            self.GlobalConfig = Resources.Load<GlobalConfig>("GlobalConfig");
            self.PlayerFollowCamera = GameObject.Find("/Global/PlayerFollowCamera").transform;

        }
    }

    [ComponentOf(typeof(Scene))]
    public class GlobalComponent : Entity, IAwake
    {
        public Transform Global;
        public Transform Unit { get; set; }
        public Transform UI;

        public GlobalConfig GlobalConfig { get; set; }
        public Transform PlayerFollowCamera;
        CinemachineVirtualCamera virtualCamera;
        public CinemachineVirtualCamera VirtualCamera
        {
            get
            {
                if (virtualCamera == null) virtualCamera = PlayerFollowCamera.GetComponent<CinemachineVirtualCamera>();
                return virtualCamera;
            }
            set { }
        }

    }
}