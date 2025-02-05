using System;
using System.Collections.Generic;
using System.Text;
using GorillaNetworking;
using Photon.Pun;
using StupidTemplate.Classes;
using StupidTemplate.Notifications;
using UnityEngine;
using UnityEngine.InputSystem;
using static StupidTemplate.Menu.Main;
using static StupidTemplate.Mods.Movement;

namespace StupidTemplate.Mods
{
    public class Room
    {

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
