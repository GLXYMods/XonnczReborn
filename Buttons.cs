using Photon.Pun;
using StupidTemplate.Classes;
using StupidTemplate.Mods;
using static StupidTemplate.Settings;

namespace StupidTemplate.Menu
{
    internal class Buttons
    {
        public static ButtonInfo[][] buttons = new ButtonInfo[][]
        {
            new ButtonInfo[] { // Main Mods
                new ButtonInfo { buttonText = "Settings", method =() => SettingsMods.MenuSettings(), isTogglable = false, toolTip = "Opens the main page for the menu."},
                new ButtonInfo { buttonText = "Movement", method =() => SettingsMods.Movement(), isTogglable = false, toolTip = "Opens the movement page for the menu."},
                new ButtonInfo { buttonText = "Visual", method =() => SettingsMods.visual(), isTogglable = false, toolTip = "Opens the visuals page for the menu."},
                new ButtonInfo { buttonText = "Rig", method =() => SettingsMods.rig(), isTogglable = false, toolTip = "Opens the rig page for the menu."},
                new ButtonInfo { buttonText = "Infection", method =() => SettingsMods.tag(), isTogglable = false, toolTip = "Opens the infection page for the menu."},
                new ButtonInfo { buttonText = "Room", method =() => SettingsMods.room(), isTogglable = false, toolTip = "Opens the room page for the menu."},
            },

            new ButtonInfo[] { // nth
            },

            new ButtonInfo[] { // Settings
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page for the menu."},
                new ButtonInfo { buttonText = "Right Hand", enableMethod =() => SettingsMods.RightHand(), disableMethod =() => SettingsMods.LeftHand(), toolTip = "Puts the menu on your right hand."},
                new ButtonInfo { buttonText = "Notifications", enableMethod =() => SettingsMods.EnableNotifications(), disableMethod =() => SettingsMods.DisableNotifications(), enabled = !disableNotifications, toolTip = "Toggles the notifications."},
                new ButtonInfo { buttonText = "FPS Counter", enableMethod =() => SettingsMods.EnableFPSCounter(), disableMethod =() => SettingsMods.DisableFPSCounter(), enabled = fpsCounter, toolTip = "Toggles the FPS counter."},
                new ButtonInfo { buttonText = "Disconnect Button", enableMethod =() => SettingsMods.EnableDisconnectButton(), disableMethod =() => SettingsMods.DisableDisconnectButton(), enabled = disconnectButton, toolTip = "Toggles the disconnect button."},
                new ButtonInfo { buttonText = "Boards", method =() => Visual.boards(), enabled = true, toolTip = "Toggles the disconnect button."},
                new ButtonInfo { buttonText = "Change Theme", overlapText = "Change Theme", method =() => Visual.ChangeMenuTheme(), isTogglable = false, toolTip = "Change the menu color."},
            },

            new ButtonInfo[] { // Movement
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page for the menu."},
                new ButtonInfo { buttonText = "Platforms", method =() => Movement.platforms(), toolTip = "Walk on air with cubes!"},
                new ButtonInfo { buttonText = "Inviz Platforms", method =() => Movement.Invizplatforms(), toolTip = "Walk on air with invisable cubes!"},
                new ButtonInfo { buttonText = "Fly", method =() => Movement.Fly(), toolTip = "Fly like superman!"},
                new ButtonInfo { buttonText = "Fast Fly", method =() => Movement.FastFly(), toolTip = "Fly like faster superman!"},
                new ButtonInfo { buttonText = "Slow Fly", method =() => Movement.SlowFly(), toolTip = "Fly like a damn snail!"},
                new ButtonInfo { buttonText = "Iron Monke", method =() => Movement.iron(), toolTip = "Become Iron Man!"},
                new ButtonInfo { buttonText = "Wasd", method =() => Movement.sadda(), toolTip = "Use Wasd Movement!"},
                new ButtonInfo { buttonText = "Tp Gun", method =() => Movement.tpgun(), toolTip = "Use Wasd Movement!"},
            },

            new ButtonInfo[] { // Visual
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Opens the settings for the menu."},
                new ButtonInfo { buttonText = "Chams", method =() => Visual.Chams(), disableMethod =() => Visual.ChamsOff(), toolTip = "Puts a cham on everyone in the lobby, Green if uninfected and Red if infected!"},
                new ButtonInfo { buttonText = "Chams V2", method =() => Visual.Chams2(), disableMethod =() => Visual.ChamsOff(), toolTip = "Puts a cham on everyone in the lobby, Js diff colors than V1!"},
                new ButtonInfo { buttonText = "Tracers", method =() => Visual.tracers(), toolTip = "Puts a cham on everyone in the lobby, Js diff colors than V1!"},
            },
            new ButtonInfo[] { // Rig
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Opens the settings for the menu."},
                new ButtonInfo { buttonText = "Ghost Monke", method =() => Rig.Ghost(), toolTip = "Freeze your vrrig!"},
                new ButtonInfo { buttonText = "Inviz Monke", method =() => Rig.Inviz(), toolTip = "Become invisable!"},
                new ButtonInfo { buttonText = "Freeze Rig", method =() => Rig.freeze(), toolTip = "Freeze your rig!"},
                new ButtonInfo { buttonText = "Rig Gun", method =() => Rig.riggun(), toolTip = "Shoot your rig with a gun!"},
            },
            new ButtonInfo[] { // Tag
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Opens the settings for the menu."},
                new ButtonInfo { buttonText = "Tag All", method =() => Infection.TagAll(), toolTip = "Tags Everyone!"},
                new ButtonInfo { buttonText = "Tag Self", method =() => Infection.TagSelf(), toolTip = "Tags Yourself!"},
                new ButtonInfo { buttonText = "Tag Aura", method =() => Infection.TagAura(), toolTip = "Tag People around you!"},
                new ButtonInfo { buttonText = "Tag Gun", method =() => Infection.TagGun(), toolTip = "Tag People With A Gun!"},
                new ButtonInfo { buttonText = "Flick Tag Gun", method =() => Infection.TagGun(), toolTip = "FlickTag People With A Gun!"},
            },
            new ButtonInfo[] { // Room
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Opens the settings for the menu."},
                new ButtonInfo { buttonText = "Disconnect", method =() => PhotonNetwork.Disconnect(), isTogglable = false, toolTip = "Leaves the lobby!"},
                new ButtonInfo { buttonText = "Disconnect[B]", method =() => Room.DisconnectB(), toolTip = "Leaves the lobby with [B]!"},
                new ButtonInfo { buttonText = "Disconnect[RT]", method =() => Room.DisconnectRT(), toolTip = "Leaves the lobby with [RT]!"},
                new ButtonInfo { buttonText = "Disconnect[LT]", method =() => Room.DisconnectLT(), toolTip = "Leaves the lobby with [LT]!"},
                new ButtonInfo { buttonText = "Get Room Info", method =() => Room.roominfo(), isTogglable = false, toolTip = "Leaves the lobby with [LT]!"},
            },
        };
    }
}
