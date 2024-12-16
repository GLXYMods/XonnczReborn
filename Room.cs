using System;
using System.Collections.Generic;
using System.Text;
using Photon.Pun;

namespace StupidTemplate.Mods
{
    public class Room
    {


        public static void roominfo()
        {
            if (PhotonNetwork.InRoom == true)
            {
                string name = PhotonNetwork.CurrentRoom.Name;
                string idk = PhotonNetwork.CountOfPlayersInRooms.ToString();
                string masterId = PhotonNetwork.CurrentRoom.MasterClientId.ToString();
                Notifications.NotifiLib.SendNotification($"{name}, {masterId}, {idk}");
            }
            else
            {
                Notifications.NotifiLib.SendNotification("<color=red>{ERROR}</color>, Not Connected To A Room");
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
                Notifications.NotifiLib.SendNotification("<color=red>{ERROR}</color>, Not Connected To A Room");
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
