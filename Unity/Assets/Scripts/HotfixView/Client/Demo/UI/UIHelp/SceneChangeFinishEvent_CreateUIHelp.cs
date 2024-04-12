namespace ET.Client
{
    [Event(SceneType.Current)]
    public class SceneChangeFinishEvent_CreateUIHelp : AEvent<Scene, SceneChangeFinish>
    {
        protected override async ETTask Run(Scene scene, SceneChangeFinish args)
        {
            //await YIUIMgrComponent.Inst.OpenPanelAsync<MainPanelComponent>();
            await YIUIMgrComponent.Inst.OpenPanelAsync<SkillPanelComponent>();
            //await UIHelper.Create(scene, UIType.UIHelp, UILayer.Mid);
        }
    }
}
