using Photon.Pun;
using StupidTemplate.Classes;
using StupidTemplate.Mods;
using StupidTemplate.Notifications;
using UnityEngine;
using Xonncz_Reborn.Mods;
using static StupidTemplate.Settings;
using static StupidTemplate.Menu.Main;
using static Ui;
using template.overview;
using Player = GorillaLocomotion.GTPlayer;
using template.Mods;

namespace StupidTemplate.Menu
{
    internal class Buttons
    {

        public static ButtonInfo[][] buttons = new ButtonInfo[][]
        {
             new ButtonInfo[] {                                                             
                new ButtonInfo { buttonText = "PC Mods", method =() => SettingsMods.pc(), isTogglable = false, toolTip = "Opens the pc mods page for the menu."},
                new ButtonInfo { buttonText = "Settings", method =() => SettingsMods.MenuSettings(), isTogglable = false, toolTip = "Opens the main page for the menu."},
                new ButtonInfo { buttonText = "Projectile", method =() => SettingsMods.ProjSettings(), isTogglable = false, toolTip = "Opens the projectile page for the menu."},
                new ButtonInfo { buttonText = "Movement", method =() => SettingsMods.Movement(), isTogglable = false, toolTip = "Opens the movement page for the menu."},
                new ButtonInfo { buttonText = "Visual", method =() => SettingsMods.visual(), isTogglable = false, toolTip = "Opens the visuals page for the menu."},
                new ButtonInfo { buttonText = "Rig", method =() => SettingsMods.rig(), isTogglable = false, toolTip = "Opens the rig page for the menu."},
                new ButtonInfo { buttonText = "Infection", method =() => SettingsMods.tag(), isTogglable = false, toolTip = "Opens the infection page for the menu."},
                new ButtonInfo { buttonText = "Room", method =() => SettingsMods.room(), isTogglable = false, toolTip = "Opens the room page for the menu."},
                new ButtonInfo { buttonText = "Troll", method =() => SettingsMods.overpowered(), isTogglable = false, toolTip = "Opens the troll page for the menu."},
                new ButtonInfo { buttonText = "Fun", method =() => SettingsMods.fun(), isTogglable = false, toolTip = "Opens the Fun page for the menu."},
            },

            new ButtonInfo[] { // Pc Mods
               new ButtonInfo { buttonText = "Wasd", method =() => Movement.sadda(), toolTip = "Use Wasd Movement. HOLD [N] To Noclip!"},
               new ButtonInfo { buttonText = "Tp Gun[PC]", method =() => Movement.TpGun(), toolTip = "Telport with a gun!"},
               new ButtonInfo { buttonText = "Tag Gun[PC]", method =() => Infection.PcTagGun(), toolTip = "Tag People With A Gun!"},
               new ButtonInfo { buttonText = "Copy Gun[PC]", method =() => Troll.PcCopyGun(), toolTip = "Copy Whoever you shoot!"},
               new ButtonInfo { buttonText = "Follow Gun[PC]", method =() => Troll.PcFollowGun(), toolTip = "Follow Whoever you shoot!"},
               new ButtonInfo { buttonText = "Rig Gun[PC]", method =() => Rig.riggun2(), toolTip = "Shoot Your Rig Anywhere With A Gun!"},
               new ButtonInfo { buttonText = "Auto Guardian[PC]", method =() => Troll.AutoGuardian(), toolTip = "Tps you to the guardian ball thing and gets you guardian!"},
               new ButtonInfo { buttonText = "Grab Gun[<color=purple>GUARDIAN</color>][PC]", method =() => Troll.grabgun2(), toolTip = "Grabs The Person You Shoot If You Are Guardian!"},
               new ButtonInfo { buttonText = "Grab All & Drop All[<color=purple>GUARDIAN</color>][RMB][LMB]", method =() => Troll.GrabAllAndDropAll(), toolTip = "Grabs Everyone If You Are Guardian!"},
               new ButtonInfo { buttonText = "Crash All[<color=purple>GUARDIAN</color>][RMB]", method =() => Troll.crash(), toolTip = "Crashes Everyone If You Are Guardian, Hold It For 3 Seconds Then Let Go!!"},
               new ButtonInfo { buttonText = "Crash Gun[<color=purple>GUARDIAN</color>][PC]", method =() => Troll.crashgun2(), toolTip = "Crashes Everyone If You Are Guardian, Hold It For 3 Seconds Then Let Go!!"},
               new ButtonInfo { buttonText = "Grab Id Gun[PC]", method =() => Troll.GrabIdGun2(), toolTip = "Grabs the persons id that you shoot!"},
               new ButtonInfo { buttonText = "Tag All[RMB]", method =() => Infection.TagAll(), toolTip = "Tags Everyone!"},
               new ButtonInfo { buttonText = "Tag Self[RMB]", method =() => Infection.TagSelf(), toolTip = "Tags Yourself!"},
               new ButtonInfo { buttonText = "Tp to stump[RMB]", method =() => Movement.TpToStump(), toolTip = "Telport to stump!"},
               new ButtonInfo { buttonText = "Tp to city[RMB]", method =() => Movement.TpToCity(), toolTip = "Telport to city!"},
               new ButtonInfo { buttonText = "Tp to tut[RMB]", method =() => Movement.TpToTut(), toolTip = "Telport to tutorial!"},
            },

            new ButtonInfo[] { // Settings
                new ButtonInfo { buttonText = "Save Prefs", method =() => Main.Save(), isTogglable = false, toolTip = "Saves mods"},
                new ButtonInfo { buttonText = "Load Mods", method =() => Main.Load(), isTogglable = false, toolTip = "Loads mods saved"},
                new ButtonInfo { buttonText = "Save Settings", method =() => Main.SaveSettings(), isTogglable = false, toolTip = "Save Settings"},
                new ButtonInfo { buttonText = "Right Hand", enableMethod =() => SettingsMods.RightHand(), disableMethod =() => SettingsMods.LeftHand(), toolTip = "Puts the menu on your right hand."},
                new ButtonInfo { buttonText = "Notifications", enableMethod =() => SettingsMods.EnableNotifications(), disableMethod =() => SettingsMods.DisableNotifications(), enabled = !disableNotifications, toolTip = "Toggles the notifications."},
                new ButtonInfo { buttonText = "Clear Notifications", method =() => NotifiLib.ClearAllNotifications(), isTogglable = false, toolTip = "Clears the notifications."},
                new ButtonInfo { buttonText = "FPS Counter", enableMethod =() => SettingsMods.EnableFPSCounter(), disableMethod =() => SettingsMods.DisableFPSCounter(), enabled = fpsCounter, toolTip = "Toggles the FPS counter."},
                new ButtonInfo { buttonText = "Disconnect Button", enableMethod =() => SettingsMods.EnableDisconnectButton(), disableMethod =() => SettingsMods.DisableDisconnectButton(), enabled = disconnectButton, toolTip = "Toggles the disconnect button."},
                new ButtonInfo { buttonText = "Thin Outline", enableMethod =() => Main.thickk = true, enabled = true, toolTip = "Toggles the disconnect button."},
                new ButtonInfo { buttonText = "Fading Colors", enableMethod =() => Main.fading = true, disableMethod =() => Main.fading = false, toolTip = "Toggles the disconnect button."},
                new ButtonInfo { buttonText = "Boards", method =() => Visual.boards(), enabled = true, isTogglable = false, toolTip = "Toggles the disconnect button."},
                new ButtonInfo { buttonText = "Change Theme", overlapText = "Change Theme", method =() => Visual.ChangeMenuTheme(), isTogglable = false, toolTip = "Change the menu color."},
                new ButtonInfo { buttonText = "Faded Menu Color 1", overlapText = "Faded Menu Color 1", method =() => Main.ChangeFadingColor1(), isTogglable = false, toolTip = "Change the menu color."},
                new ButtonInfo { buttonText = "Faded Menu Color 2", overlapText = "Faded Menu Color 2", method =() => Main.ChangeFadingColor2(), isTogglable = false, toolTip = "Change the menu color."},
                new ButtonInfo { buttonText = "Outline Color", overlapText = "Outline Color", method =() => Main.OutlineColor1(), isTogglable = false, toolTip = "Change the menu color."},
                new ButtonInfo { buttonText = "Change Button Sound", method =() => Main.changebuttonsound(), isTogglable = false, toolTip = "Change the sound of buttons when clicked!"},
                new ButtonInfo { buttonText = "Change Menu Font", method =() => Main.changemenufont(), isTogglable = false, toolTip = "Change the font of the menu!"},
                new ButtonInfo { buttonText = "LongArm Size", overlapText = "LongArm Size", method =() => Rig.ChangeLongArmsShit(), isTogglable = false, toolTip = "Change the size of long arms!"},
                new ButtonInfo { buttonText = "Flush RPC'S", method =() => Room.flush(), isTogglable = false, toolTip = "Flushes Report Calls."},
                new ButtonInfo { buttonText = "No Finger Movement", method =() => Room.CantMoveFingers(), toolTip = "You cant move any of your fingers."},
                new ButtonInfo { buttonText = "Fps Booster", method =() => Room.fpsboost(), disableMethod =() => Room.disablefpsboost(), toolTip = "Really Good Fps Booster."},
                new ButtonInfo { buttonText = "Menu Trail", method =() => Main.TrailOn(), disableMethod =() => Main.TrailOff(), enabled = true, toolTip = "Toggle the menu trail."},
                new ButtonInfo { buttonText = "Trail Orbit", method =() => Main.OrbitOn(), disableMethod =() => Main.OrbitOff(), enabled = true, toolTip = "Toggle the trail orbit."},
            },

            new ButtonInfo[] { // Proj
                new ButtonInfo { overlapText = "Change Projectile Color", buttonText = "Change Projectile Color", method =() => Projectiles.change(), isTogglable = false, toolTip = "CS Projectile Spamer Change"},
                new ButtonInfo { overlapText = "Change Trail", buttonText = "Change Trail", method =() => Projectiles.trail(), isTogglable = false, toolTip = "CS Projectile Spamer Change"},
                new ButtonInfo { buttonText = "Water Ballon Spam[CS]", method =() => Projectiles.sig(), toolTip = "Projectile Spam[CS]!"},
                new ButtonInfo { buttonText = "Snowball Spam[CS]", method =() => Projectiles.sig2(), toolTip = "Projectile Spam[CS]!"},
                new ButtonInfo { buttonText = "Ice Spam[CS]", method =() => Projectiles.sig3(), toolTip = "Projectile Spam[CS]!"},
                new ButtonInfo { buttonText = "Heart Spam[CS]", method =() => Projectiles.sig4(), toolTip = "Projectile Spam[CS]!"},
                new ButtonInfo { buttonText = "Paintball Spam[CS]", method =() => Projectiles.sig5(), toolTip = "Projectile Spam[CS]!"},
                new ButtonInfo { buttonText = "Leaf Spam[CS]", method =() => Projectiles.sig6(), toolTip = "Projectile Spam[CS]!"},
                new ButtonInfo { buttonText = "Waterballon Gun[CS]", method =() => Projectiles.waterballongun(), toolTip = "Shoot Waterballoons[CS]!"},
                new ButtonInfo { buttonText = "Snowball Gun[CS]", method =() => Projectiles.snowballgun(), toolTip = "Shoot Snowballs[CS]!"},
                new ButtonInfo { buttonText = "Heart Gun[CS]", method =() => Projectiles.heartgun(), toolTip = "Shoot hearts[CS]!"},
                new ButtonInfo { buttonText = "Ice Gun[CS]", method =() => Projectiles.rainbowgun(), toolTip = "Shoot Ice[CS]!"},
                new ButtonInfo { buttonText = "Paintball Gun[CS]", method =() => Projectiles.paintballgun(), toolTip = "Shoot paintballs[CS]!"},
                new ButtonInfo { buttonText = "Leaf Gun[CS]", method =() => Projectiles.leafgun(), toolTip = "Shoot leafs[CS]!"},
                new ButtonInfo { buttonText = "Deadshot Gun[CS]", method =() => Projectiles.deadshotgun(), toolTip = "Shoot paintballs[CS]!"},
                new ButtonInfo { buttonText = "Piss[CS]", method =() => Projectiles.Piss(), toolTip = "Shoot Piss[CS]!"},
                new ButtonInfo { buttonText = "Cum[CS]", method =() => Projectiles.Cum(), toolTip = "Shoot Cum[CS]!"},
                new ButtonInfo { buttonText = "Throw Up[CS]", method =() => Projectiles.Throw(), toolTip = "Throw up[CS]!"},
            },

            new ButtonInfo[] { // Movement
                new ButtonInfo { buttonText = "Platforms", method =() => Movement.platforms(), toolTip = "Walk on air with cubes!"},
                new ButtonInfo { buttonText = "Platforms[<color=green>Sticky</color>]", method =() => Movement.StickyPlatforms(), toolTip = "Walk on air with sticky cubes!"},
                new ButtonInfo { buttonText = "Platforms No Clip", method =() => Movement.platformsno(), toolTip = "Walk on air with cubes!"},
                new ButtonInfo { buttonText = "Inviz Platforms", method =() => Movement.Invizplatforms(), toolTip = "Walk on air with invisable cubes!"},
                new ButtonInfo { buttonText = "Fly", method =() => Movement.Fly(), toolTip = "Fly like superman!"},
                new ButtonInfo { buttonText = "Trigger Fly", method =() => Movement.TriggerFly(), toolTip = "Fly like superman!"},
                new ButtonInfo { buttonText = "Fast Fly", method =() => Movement.FastFly(), toolTip = "Fly like faster superman!"},
                new ButtonInfo { buttonText = "Trigger Fast Fly", method =() => Movement.TriggerFastFly(), toolTip = "Fly like faster superman!"},
                new ButtonInfo { buttonText = "Slow Fly", method =() => Movement.SlowFly(), toolTip = "Fly like a damn snail!"},
                new ButtonInfo { buttonText = "Trigger Slow Fly", method =() => Movement.TriggerSlowFly(), toolTip = "Fly like a damn snail!"},
                new ButtonInfo { buttonText = "Iron Monke", method =() => Movement.iron(), toolTip = "Become Iron Man!"},
                new ButtonInfo { buttonText = "Tp Gun", method =() => Movement.TpGun(), toolTip = "Telport with a gun!"},
                new ButtonInfo { buttonText = "Tp to stump", method =() => Movement.TpToStump(), toolTip = "Telport to stump!"},
                new ButtonInfo { buttonText = "Tp to city", method =() => Movement.TpToCity(), toolTip = "Telport to city!"},
                new ButtonInfo { buttonText = "Tp to tut", method =() => Movement.TpToTut(), toolTip = "Telport to tutorial!"},
                new ButtonInfo { buttonText = "NoClip", method =() => Movement.Noclip(), toolTip = "makes you go through things!"},
                new ButtonInfo { buttonText = "Fly + NoClip", method =() => Movement.flywithnoclip(), toolTip = "Makes you go through things while flying!"},
                new ButtonInfo { buttonText = "Up And Down", method =() => Movement.upandDown(), toolTip = "Makes you go up and down!"},
                new ButtonInfo { buttonText = "Dash", method =() => Movement.dash(), toolTip = "Dash!"},
                new ButtonInfo { buttonText = "Speed Boost", method =() => Movement.Speed(), toolTip = "Gives you a speed boost!"},
                new ButtonInfo { buttonText = "Mega Speed Boost", method =() => Movement.mega(), toolTip = "Gives you a mega speed boost!"},
                new ButtonInfo { buttonText = "Mosa Settings", method =() => Movement.mosa(), toolTip = "Gives you a slight speed boost!"},
                new ButtonInfo { buttonText = "Slide Control", method =() => Movement.SlideControl(), toolTip = "Gives you a mega slide control boost!"},
                new ButtonInfo { buttonText = "Car Monke", method =() => Movement.carmonke(), toolTip = "Move like a car!"},
                new ButtonInfo { buttonText = "Checkpoint", method =() => Movement.check(), disableMethod =() => Movement.disablecheck(), toolTip = "Its in the name lil bro!"},
                new ButtonInfo { buttonText = "Joystick Fly", method =() => Movement.JoystickFly(), toolTip = "Fly With Your Joystick. It Uses Velocity!"},
            },

            new ButtonInfo[] { // Visual
                new ButtonInfo { buttonText = "Chams", method =() => Visual.Chams(), disableMethod =() => Visual.ChamsOff(), toolTip = "Puts a cham on everyone in the lobby, Green if uninfected and Red if infected!"},
                new ButtonInfo { buttonText = "Chams V2", method =() => Visual.Chams2(), disableMethod =() => Visual.ChamsOff(), toolTip = "Puts a cham on everyone in the lobby, Js diff colors than V1!"},
                new ButtonInfo { buttonText = "Tracers", method =() => Visual.tracers(), toolTip = "Puts a cham on everyone in the lobby"},
                new ButtonInfo { buttonText = "Sphere Esp", method =() => Visual.sphereEsp(), toolTip = "Puts a sphere on everyone in the lobby"},
                new ButtonInfo { buttonText = "Head Esp", method =() => Visual.head(), toolTip = "Puts a sphere on everyone head in the lobby"},
                new ButtonInfo { buttonText = "RGB ALL[CS]", method =() => Visual.makeeveryonergb(), toolTip = "makes everyone rgb[CS]!"},
                new ButtonInfo { buttonText = "NameTags", method =() => Visual.NameTags(), toolTip = "Puts Everyones Names Onto There Head!"},
                new ButtonInfo { buttonText = "Display", method =() => Display_Shitta.Display(), toolTip = "Display Shit As Text In Game!"},
                new ButtonInfo { buttonText = "Stump Text", method =() => Visual.StumpText(), enabled = true, toolTip = "Opens the pc page for the menu."},
            },

            new ButtonInfo[] { // Rig
                new ButtonInfo { buttonText = "Ghost Monke", method =() => Rig.Ghost(), toolTip = "Freeze your vrrig!"},
                new ButtonInfo { buttonText = "Inviz Monke", method =() => Rig.Inviz(), toolTip = "Become invisable!"},
                new ButtonInfo { buttonText = "Freeze Rig", method =() => Rig.freeze(), toolTip = "Freeze your rig!"},
                new ButtonInfo { buttonText = "Rig Gun", method =() => Rig.riggun(), disableMethod =() => GorillaTagger.Instance.offlineVRRig.enabled = true, toolTip = "Shoot Your Rig Anywhere With A Gun!"},
                new ButtonInfo { buttonText = "Grab Rig", method =() => Rig.GrabRig(), toolTip = "Grab your rig!"},
                new ButtonInfo { buttonText = "Fake Oculus Menu", method =() => Rig.FakeOculusMenu(), toolTip = "Fake that you are in your oculus menu!"},
                new ButtonInfo { buttonText = "Long Arms", method =() => Rig.LongArms(), disableMethod =() => GorillaLocomotion.GTPlayer.Instance.transform.localScale = new Vector3(1f, 1f, 1f), toolTip = "Long arms!"},
            },

            new ButtonInfo[] { // Tag
                new ButtonInfo { buttonText = "Tag Self[RT]", method =() => Infection.TagSelf(), toolTip = "Tags Yourself!"},
                new ButtonInfo { buttonText = "Tag All[RT]", method =() => Infection.TagAll(), toolTip = "Tags Everyone!"},
                new ButtonInfo { buttonText = "Tag Aura", method =() => Infection.TagAura(), toolTip = "Tags Everyone Close To You!"},
                new ButtonInfo { buttonText = "Anti Tag", method =() => Infection.antitag(), toolTip = "Makes you inviz when a tagged person comes near you!"},
                new ButtonInfo { buttonText = "Tag Gun", method =() => Infection.TagGun(), disableMethod =() => GorillaTagger.Instance.offlineVRRig.enabled = true, toolTip = "Tag People With A Gun!"},
                new ButtonInfo { buttonText = "Flick Tag Gun", method =() => Infection.FlickTagGun(), toolTip = "Flick Tag People With A Gun!"},
            },

            new ButtonInfo[] { // Room
                new ButtonInfo { buttonText = "Antireport[DISCONNECT]", method =() => Room.AntiReport(), enabled = true, toolTip = "When Someone Gets Close To The Report Button You Disconnect!"},
                new ButtonInfo { buttonText = "Disconnect", method =() => PhotonNetwork.Disconnect(), isTogglable = false, toolTip = "Leaves the lobby!"},
                new ButtonInfo { buttonText = "Disconnect[B]", method =() => Room.DisconnectB(), toolTip = "Leaves the lobby with [B]!"},
                new ButtonInfo { buttonText = "Disconnect[RT]", method =() => Room.DisconnectRT(), toolTip = "Leaves the lobby with [RT]!"},
                new ButtonInfo { buttonText = "Disconnect[LT]", method =() => Room.DisconnectLT(), toolTip = "Leaves the lobby with [LT]!"},
                new ButtonInfo { buttonText = "Get Room Info", method =() => Room.roominfo(), isTogglable = false, toolTip = "Get the room details!"},
                new ButtonInfo { buttonText = "Leave Troop", method =() => Room.LeaveTroop(), isTogglable = false, toolTip = "Leaves your troop!"},
            },

            new ButtonInfo[] { // Troll
                new ButtonInfo { buttonText = "Auto Guardian", method =() => Troll.AutoGuardian(), toolTip = "Tps you to the guardian ball thing and gets you guardian!"},
                new ButtonInfo { buttonText = "Grab All & Drop All[<color=purple>GUARDIAN</color>][RG][RT]", method =() => Troll.GrabAllAndDropAll(), disableMethod =() => Room.flush(), toolTip = "Grabs Everyone If You Are Guardian!"},
                new ButtonInfo { buttonText = "Grab Gun[<color=purple>GUARDIAN</color>]", method =() => Troll.grabgun1(),  disableMethod =() => Room.flush(), toolTip = "Grabs The Person You Shoot If You Are Guardian!"},
                new ButtonInfo { buttonText = "Crash All[<color=purple>GUARDIAN</color>][RG]", method =() => Troll.crash(), disableMethod =() => Room.flush(), toolTip = "Crashes Everyone If You Are Guardian, Hold It For 3 Seconds Then Let Go!!!"},
                new ButtonInfo { buttonText = "Crash Gun[<color=purple>GUARDIAN</color>]", method =() => Troll.crashgun1(), disableMethod =() => Room.flush(), toolTip = "Crashes Anyone That You Shoot If You Are Guardian, Hold It For 3 Seconds Then Let Go!!!"},
                new ButtonInfo { buttonText = "RGB[D?][<color=purple>Stump</color>]", method =() => Troll.RGB(), toolTip = "Makes Your Monke Rainbow!"},
                new ButtonInfo { buttonText = "Inviz On Touch", method =() => Troll.InvizOnTouch(), toolTip = "Makes You Go Invisable When Someone Touches Your Head!"},
                new ButtonInfo { buttonText = "Ghost On Touch", method =() => Troll.GhostOnTouch(), toolTip = "Makes You A Ghost When Someone Touches Your Head!"},                
                new ButtonInfo { buttonText = "Copy Gun", method =() => Troll.CopyPlayerGun(), toolTip = "Copy Whoever you shoot!"},
                new ButtonInfo { buttonText = "Follow Gun", method =() => Troll.followgun(), toolTip = "Follow Whoever you shoot!"},
                new ButtonInfo { buttonText = "Follow Closest", method =() => Troll.followclosest(), disableMethod =() => Troll.enablerig(), toolTip = "Follow The Closest Player!"},
                new ButtonInfo { buttonText = "Copy Closest", method =() => Troll.copyclosest(), disableMethod =() => Troll.enablerig(), toolTip = "Copy The Closest Player!"},
                new ButtonInfo { buttonText = "Disable Slide Colliders", method =() => Troll.disableslide(), disableMethod =() => Troll.enableslide(), toolTip = "Disables All Of The Colliders On The Slide!"},
                new ButtonInfo { buttonText = "Rope Spaz", method =() => Troll.RopeSpaz(), toolTip = "Spazes all of the ropes!"},
                new ButtonInfo { buttonText = "Ropes Up", method =() => Troll.RopeUp(), toolTip = "Launches all of the ropes up!"},
                new ButtonInfo { buttonText = "Ropes Down", method =() => Troll.RopeDown(), toolTip = "Launches all of the ropes down!"},
                new ButtonInfo { buttonText = "Ropes Left", method =() => Troll.RopeLeft(), toolTip = "Launches all of the ropes left!"},
                new ButtonInfo { buttonText = "Ropes Right", method =() => Troll.RopeRight(), toolTip = "Launches all of the ropes right!"},
                new ButtonInfo { buttonText = "Ropes Forward", method =() => Troll.RopeForward(), toolTip = "Launches all of the ropes forward!"},
            },

            new ButtonInfo[] { // Fun
                new ButtonInfo { buttonText = "Hands in head", method =() => Fun.HandsINhead(), toolTip = "Put hands in hed!"},
                new ButtonInfo { buttonText = "BrokenControllerRight", method =() => Fun.BrokenControllerRIGHT(), toolTip = "Make your right controller go to your left hand!"},
                new ButtonInfo { buttonText = "BrokenControllerLeft", method =() => Fun.BrokenControllerLEFT(), toolTip = "Make your left controller go to your right hand!"},
                new ButtonInfo { buttonText = "Low Grav", method =() => Fun.LowGravity(), toolTip = "Makes your gravity become low!"},
                new ButtonInfo { buttonText = "High Grav", method =() => Fun.HighGravity(), toolTip = "Makes your gravity become high!"},
                new ButtonInfo { buttonText = "No Grav", method =() => Fun.ZeroGravity(), toolTip = "Gives you no gravity!"},
                new ButtonInfo { buttonText = "Rotate Self[CURSED][RG]", method =() => Troll.RotateSelf(), toolTip = "Rotates yourself in a very fucking cursed way!"},
                new ButtonInfo { buttonText = "Draw[RGB]", method =() => Fun.DrawRGB(), toolTip = "Lets you draw with rgb spheres!"},
                new ButtonInfo { buttonText = "Rainbow Snow", method =() => Fun.Snow(), toolTip = "Falling  Rainbow Snow Particals!"},
                new ButtonInfo { buttonText = "Big Shark", method =() => Fun.BigShark(), toolTip = "Make The Shark Big!"},
                new ButtonInfo { buttonText = "Small Shark", method =() => Fun.SmallShark(), toolTip = "Make The Shark Small!"},
                new ButtonInfo { buttonText = "Grab All Id's", method =() => Fun.GrabAllIds(), isTogglable = false, toolTip = "Grabs everyones id's!"},
                new ButtonInfo { buttonText = "Grab Id Gun", method =() => Troll.GrabIdGun1(), toolTip = "Grabs the persons id that you shoot!"},
                new ButtonInfo { buttonText = "Monke Plush Display", method =() => Visual.MonkePlush(), disableMethod =() => Visual.MonkePlushOff(), toolTip = "Put The Monke Plush Display In Stump."},
                new ButtonInfo { buttonText = "Grab Monke Plush Display", method =() => Visual.GrabMonkePlush(), toolTip = "Grab The Monke Plush Display."},
                new ButtonInfo { buttonText = "Emit Fire <color=yellow>[CS]</color>", method =() => Particles.FireBall(), toolTip = "You Can Emit Fire."},
                new ButtonInfo { buttonText = "Grenade <color=yellow>[CS]</color>", method =() => Particles.Grenade(), toolTip = "Throwable Grenade."},
            },

        };
    }
}
