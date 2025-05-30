using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using ExitGames.Client.Photon;
using GorillaNetworking;
using Photon.Pun;
using Photon.Realtime;
using StupidTemplate.Classes;
using StupidTemplate.Notifications;
using UnityEngine;
using Player = GorillaLocomotion.GTPlayer;
using UnityEngine.InputSystem;
using static StupidTemplate.Menu.Main;
using static StupidTemplate.Mods.Movement;

namespace StupidTemplate.Mods
{
    public class Room
    {

        public static void fpsboost()
        {
            Application.targetFrameRate = int.MaxValue;
            QualitySettings.globalTextureMipmapLimit = int.MaxValue;
            QualitySettings.masterTextureLimit = int.MaxValue;
            QualitySettings.maxQueuedFrames = int.MaxValue;
        }

        public static void disablefpsboost()
        {
            Application.targetFrameRate = default;
            QualitySettings.globalTextureMipmapLimit = default;
            QualitySettings.masterTextureLimit = default;
            QualitySettings.maxQueuedFrames = default;
        }

        public static void flush()
        {
            try
            {
                if (hasRemovedThisFrame)
                {
                    return;
                }
                hasRemovedThisFrame = true;
                RaiseEventOptions options = new RaiseEventOptions
                {
                    CachingOption = EventCaching.RemoveFromRoomCache,
                    TargetActors = new int[] { PhotonNetwork.LocalPlayer.ActorNumber }
                };
                PhotonNetwork.NetworkingClient.OpRaiseEvent(200, null, options, SendOptions.SendReliable);
                GorillaNot.instance.rpcErrorMax = int.MaxValue;
                GorillaNot.instance.rpcCallLimit = int.MaxValue;
                GorillaNot.instance.logErrorMax = int.MaxValue;
                PhotonNetwork.MaxResendsBeforeDisconnect = int.MaxValue;
                PhotonNetwork.QuickResends = int.MaxValue;
                PhotonNetwork.RemoveRPCs(PhotonNetwork.LocalPlayer);
                PhotonNetwork.RemoveBufferedRPCs(GorillaTagger.Instance.myVRRig.ViewID, null, null);
                PhotonNetwork.RemoveRPCsInGroup(int.MaxValue);
                PhotonView playerPhotonView = GorillaTagger.Instance.myVRRig.GetComponent<PhotonView>();
                if (playerPhotonView != null)
                {
                    if (playerPhotonView.Owner == null)
                    {
                        playerPhotonView.TransferOwnership(PhotonNetwork.LocalPlayer);
                    }
                    PhotonNetwork.OpCleanRpcBuffer(playerPhotonView);
                }
                PhotonNetwork.SendAllOutgoingCommands();
                GorillaNot.instance.OnPlayerLeftRoom(PhotonNetwork.LocalPlayer);
                GorillaGameManager.instance.OnPlayerLeftRoom(PhotonNetwork.LocalPlayer);
                GorillaGameManager.instance.OnPlayerLeftRoom(PhotonNetwork.LocalPlayer);
                GorillaGameManager.instance.OnPlayerLeftRoom(PhotonNetwork.LocalPlayer);
                GorillaNot.instance.OnPlayerLeftRoom(PhotonNetwork.LocalPlayer);
                try
                {
                    PhotonNetwork.NetworkingClient.EventReceived -= PhotonNetwork.NetworkingClient.OnEvent;
                    PhotonNetwork.NetworkingClient.EventReceived += (eventData) =>
                    {
                        if (eventData.Sender != PhotonNetwork.LocalPlayer.ActorNumber)
                        {
                            return;
                        }
                    };
                    PhotonNetwork.NetworkingClient.LoadBalancingPeer.LimitOfUnreliableCommands = 0;
                }
                catch (Exception ex)
                { }
                if (GorillaNot.instance != null)
                {
                    FieldInfo report = typeof(GorillaNot).GetField("sendReport", BindingFlags.NonPublic);
                    if (report != null)
                    {
                        report.SetValue(GorillaNot.instance, false);
                    }
                    report = typeof(GorillaNot).GetField("_sendReport", BindingFlags.NonPublic);
                    if (report != null)
                    {
                        report.SetValue(GorillaNot.instance, false);
                    }
                }
            }
            catch (Exception ex)
            { Debug.Log("{ERROR} : " + ex.Message); }
        }
        private static bool hasRemovedThisFrame = false;



        public static bool dis = false;
        public static void AntiReport()
        {
            var scoreboardLine = GorillaScoreboardTotalUpdater.allScoreboardLines.Find((GorillaPlayerScoreboardLine L) => L.playerVRRig.isLocal);
            foreach (VRRig vrrigs in GorillaParent.instance.vrrigs)
            {
                var Limit = 0.51f;
                var ReportPosition = scoreboardLine.reportButton.gameObject.transform.position;
                var RightDis = Vector3.Distance(vrrigs.rightHandTransform.position, ReportPosition);
                var LeftDis = Vector3.Distance(vrrigs.leftHandTransform.position, ReportPosition);
                if (RightDis <= Limit || LeftDis <= Limit)
                {
                    if (!vrrigs.isLocal && !vrrigs.isMyPlayer)
                    {                        
                        PhotonNetwork.Disconnect();
                        flush();
                    }
                }
            }
        }



        public static void CantMoveFingers()
        {
            ControllerInputPoller.instance.rightControllerGripFloat = 0f;
            ControllerInputPoller.instance.leftControllerGripFloat = 0f;
            ControllerInputPoller.instance.rightControllerIndexFloat = 0f;
            ControllerInputPoller.instance.leftControllerIndexFloat = 0f;
            ControllerInputPoller.instance.rightControllerPrimaryButton = false;
            ControllerInputPoller.instance.leftControllerPrimaryButton = false;
            ControllerInputPoller.instance.rightControllerPrimaryButtonTouch = false;
            ControllerInputPoller.instance.leftControllerPrimaryButtonTouch = false;
            ControllerInputPoller.instance.rightControllerSecondaryButtonTouch = false;
            ControllerInputPoller.instance.leftControllerSecondaryButtonTouch = false;
            ControllerInputPoller.instance.leftControllerSecondaryButton = false;
            ControllerInputPoller.instance.rightControllerSecondaryButton = false;
        }

        

        public static void LeaveTroop()
        {
            GorillaComputer.instance.LeaveTroop();
        }






        public static void roominfo()
        {
            if (PhotonNetwork.InRoom == true)
            {
                string name = PhotonNetwork.CurrentRoom.Name;
                string masterId = PhotonNetwork.CurrentRoom.MasterClientId.ToString();
                Notifications.NotifiLib.SendNotification($"Room Code : {name}");
            }
            else
            {
                NotifiLib.SendNotification("<color=red>{ERROR}</color>, Not Connected To A Room");
            }
        }


        public static void DisconnectB()
        {
            if (PhotonNetwork.InRoom == true)
            {
                if (ControllerInputPoller.instance.rightControllerPrimaryButton)
                {
                    PhotonNetwork.Disconnect();
                }
            }
            else
            {
                NotifiLib.SendNotification("<color=red>{ERROR}</color>, Not Connected To A Room");
            }
        }


        public static void DisconnectRT()
        {
            if (PhotonNetwork.InRoom == true)
            {
                if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f)
                {
                    PhotonNetwork.Disconnect();
                }
            }
            else
            {
                Notifications.NotifiLib.SendNotification("<color=red>{ERROR}</color>, Not Connected To A Room");
            }
        }


        public static void DisconnectLT()
        {
            if (PhotonNetwork.InRoom == true)
            {
                if (ControllerInputPoller.instance.leftControllerIndexFloat > 0.1f)
                {
                    PhotonNetwork.Disconnect();
                }
            }
            else
            {
                Notifications.NotifiLib.SendNotification("<color=red>{ERROR}</color>, Not Connected To A Room");
            }
        }






    }
}
