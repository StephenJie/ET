using System;
using System.Collections.Generic;
using System.IO;

namespace ET.Client
{
    [Event(SceneType.Current)]
    public class EventHandle_PlayAnimation : AEvent<Scene, Event_PlayAnimation>
    {
        protected override async ETTask Run(Scene root, Event_PlayAnimation argss)
        {
            argss.Unit?.GetComponent<AnimatorComponent>()?.Play(EnumHelper.FromString<MotionType>(argss.StateName));

            await ETTask.CompletedTask;
            //GlobalComponent globalComponent = root.AddComponent<GlobalComponent>();
            //root.AddComponent<UIGlobalComponent>();
            //root.AddComponent<UIComponent>();
            //root.AddComponent<ResourcesLoaderComponent>();
            //root.AddComponent<PlayerComponent>();
            //root.AddComponent<CurrentScenesComponent>();

            //// 根据配置修改掉Main Fiber的SceneType
            //SceneType sceneType = EnumHelper.FromString<SceneType>(globalComponent.GlobalConfig.AppType.ToString());
            //root.SceneType = sceneType;

            //await root.AddComponent<YIUIMgrComponent>().Initialize();
            //root.AddComponent<GMCommandComponent>();

            //await EventSystem.Instance.PublishAsync(root, new AppStartInitFinish());
        }
    }
}