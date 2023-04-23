using System;
using MongoDB.Bson;

namespace ET.Client
{
    [FriendOf(typeof (BattleSceneClientUpdater))]
    public static class BattleSceneClientUpdaterSystem
    {
        [FriendOf(typeof (Room))]
        public class UpdateSystem: UpdateSystem<BattleSceneClientUpdater>
        {
            protected override void Update(BattleSceneClientUpdater self)
            {
                self.Update();
            }
        }

        private static void Update(this BattleSceneClientUpdater self)
        {
            Room room = self.GetParent<Room>();

            FrameBuffer frameBuffer = room.FrameBuffer;

            long timeNow = TimeHelper.ServerFrameTime();
            if (timeNow < room.StartTime + frameBuffer.NowFrame * LSConstValue.UpdateInterval)
            {
                return;
            }

            if (frameBuffer.NowFrame > frameBuffer.RealFrame + frameBuffer.PredictionCount)
            {
                return;
            }
            
            OneFrameMessages oneFrameMessages = GetOneFrameMessages(self, frameBuffer.NowFrame);
            room.Update(oneFrameMessages);
            ++frameBuffer.NowFrame;
        }

        private static OneFrameMessages GetOneFrameMessages(this BattleSceneClientUpdater self, int frame)
        {
            Room room = self.GetParent<Room>();
            FrameBuffer frameBuffer = room.FrameBuffer;
            
            if (frame <= frameBuffer.RealFrame)
            {
                return frameBuffer.GetFrame(frame);
            }
            
            // predict
            return GetPredictionOneFrameMessage(self, frame);
        }

        // 获取预测一帧的消息
        private static OneFrameMessages GetPredictionOneFrameMessage(this BattleSceneClientUpdater self, int frame)
        {
            Room room = self.GetParent<Room>();
            Scene clientScene = room.GetParent<Scene>();
            OneFrameMessages preFrame = room.FrameBuffer.GetFrame(frame - 1);
            OneFrameMessages predictionFrame  = preFrame != null? MongoHelper.Clone(preFrame) : new OneFrameMessages();
            predictionFrame.Frame = frame;

            PlayerComponent playerComponent = clientScene.GetComponent<PlayerComponent>();
            long myId = playerComponent.MyId;

            FrameMessage frameMessage = new() { InputInfo = new LSInputInfo(), Frame = frame };
            frameMessage.InputInfo.V = self.InputInfo.V;
            frameMessage.InputInfo.Button = self.InputInfo.Button;

            predictionFrame.InputInfos[myId] = frameMessage.InputInfo;
            
            room.FrameBuffer.AddFrame(predictionFrame);
            
            clientScene.GetComponent<SessionComponent>().Session.Send(frameMessage);

            return predictionFrame;
        }
    }
}