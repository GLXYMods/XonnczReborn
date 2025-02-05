using BepInEx;
using GorillaTagScripts;
using HarmonyLib;
using Photon.Pun;
using StupidTemplate.Classes;
using StupidTemplate.Mods;
using StupidTemplate.Notifications;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Networking;
using UnityEngine.UI;
using static StupidTemplate.Menu.Buttons;
using static StupidTemplate.Menu.Main;
using static StupidTemplate.Settings;
using static Ui;
using Button = StupidTemplate.Classes.Button;

namespace StupidTemplate.Menu
{
    [HarmonyPatch(typeof(GorillaLocomotion.Player))]
    [HarmonyPatch("LateUpdate", MethodType.Normal)]
    public class Main : MonoBehaviour
    {
        public static int fontC = 0;
        public static Font Arial = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        public static Font Sans = Font.CreateDynamicFontFromOSFont("Comic Sans MS", 24);
        public static Font AgencyFB = Font.CreateDynamicFontFromOSFont("Agency FB", 24);
        public static Font consolas = Font.CreateDynamicFontFromOSFont("Consolas", 24);
        public static Font Verdana = Font.CreateDynamicFontFromOSFont("Verdana", 24);
        public static Font ubuntu = Font.CreateDynamicFontFromOSFont("Candara", 24);
        public static Font MSGOTHIC = Font.CreateDynamicFontFromOSFont("MS Gothic", 24);
        public static Font impact = Font.CreateDynamicFontFromOSFont("Impact", 24);
        public static bool thickk = true;
        public static void changemenufont()
        {
            fontC++;
            if (fontC > 6)
            {
                fontC = 0;
            }
            if (fontC < 0)
            {
                fontC = 6;
            }

            if (fontC == 0)
            {
                currentFont = Arial;
            }

            if (fontC == 1)
            {
                currentFont = Sans;
            }
            if (fontC == 2)
            {
                currentFont = Verdana;
            }
            if (fontC == 3)
            {
                currentFont = consolas;
            }
            if (fontC == 4)
            {
                currentFont = ubuntu;
            }
            if (fontC == 5)
            {
                currentFont = MSGOTHIC;
            }
            if (fontC == 6)
            {
                currentFont = impact;
            }
        }

        public static int btn = 0;
        public static void changebuttonsound()
        {
            btn++;
            if (btn > 15)
            {
                btn = 0;
            }
            if (btn < 0)
            {
                btn = 15;
            }

            if (btn == 0)
            {
                Button.buttonSound = 114;
            }

            if (btn == 1)
            {
                Button.buttonSound = 123;
            }

            if (btn == 2)
            {
                Button.buttonSound = 138;
            }

            if (btn == 3)
            {
                Button.buttonSound = 146;
            }

            if (btn == 4)
            {
                Button.buttonSound = 147;
            }

            if (btn == 5)
            {
                Button.buttonSound = 140;
            }

            if (btn == 6)
            {
                Button.buttonSound = 85;
            }

            if (btn == 7)
            {
                Button.buttonSound = 84;
            }

            if (btn == 8)
            {
                Button.buttonSound = 92;
            }

            if (btn == 9)
            {
                Button.buttonSound = 91;
            }
            if (btn == 10)
            {
                Button.buttonSound = 55;
            }
            if (btn == 11)
            {
                Button.buttonSound = 73;
            }
            if (btn == 12)
            {
                Button.buttonSound = 51;
            }
            if (btn == 13)
            {
                Button.buttonSound = 15;
            }
            if (btn == 14)
            {
                Button.buttonSound = 32;
            }
            if (btn == 15)
            {
                Button.buttonSound = 64;
            }
        }

        public static bool sound1 = false;
        public static bool sound2 = false;
        public static bool sound3 = false;
        public static bool sound4 = false;
        public static bool sound5 = false;
        public static bool sound6 = false;
        public static bool sound7 = false;
        public static bool sound8 = false;
        public static bool sound9 = false;
        public static bool sound10 = false;
        public static bool sound11 = false;
        public static bool sound12 = false;
        public static bool sound13 = false;
        public static bool realsoundOn = true;

        public static bool pagebuttons = true;

        public static void Save()
        {
            List<String> list = new List<String>();
            foreach (ButtonInfo[] button in Menu.Buttons.buttons)
            {
                foreach (ButtonInfo button2 in button)
                {
                    if (button2.enabled == true)
                    {
                        list.Add(button2.buttonText + button2.overlapText);
                    }
                }
            }
            System.IO.Directory.CreateDirectory("XonnczReborn");
            System.IO.File.WriteAllLines("XonnczReborn\\Prefabs.txt", list);
            NotifiLib.SendNotification("<color=grey>[</color><color=green>SUCCESSFULLY</color><color=grey>]</color> Saved Mods!");
        }
        public static void SaveSettings()
        {
            List<String> list = new List<String>();
            foreach (ButtonInfo[] button in Menu.Buttons.buttons)
            {
                foreach (ButtonInfo button2 in button)
                {
                    if (button2.enabled == true)
                    {
                        list.Add(button2.buttonText + button2.overlapText);
                    }
                }
            }
            Directory.CreateDirectory("XonnczReborn");
            File.WriteAllLines("XonnczReborn\\Settings.txt", list);
            string text4 = string.Concat(new string[]
            {
               btn.ToString(),
               "\n",
               fontC.ToString(),
               "\n",
               Visual.t.ToString(),
               "\n",
            });
            File.WriteAllText("XonnczReborn\\Settings.txt", text4.ToString());
            NotifiLib.SendNotification("<color=grey>[</color><color=green>SUCCESSFULLY</color><color=grey>]</color> Saved Settings!");
        }

        public static void LoadSettings()
        {
            string[] array = File.ReadAllLines("XonnczReborn\\Settings.txt");
            foreach (string b in array)
            {
                foreach (ButtonInfo[] button in Buttons.buttons)
                {
                    foreach (ButtonInfo button2 in button)
                    {
                        if (button2.buttonText == b)
                        {
                            button2.enabled = button2.isTogglable;
                        }
                    }                   
                }
            }
            try
            {
                string text3 = File.ReadAllText("XonnczReborn\\Settings.txt");
                string[] array4 = text3.Split(new string[] { "\n" }, StringSplitOptions.None);
                btn = int.Parse(array4[0]) - 1;
                changebuttonsound();
                fontC = int.Parse(array4[1]) - 1;
                changemenufont();
                Visual.t = int.Parse(array4[2]) - 1;
                Visual.ChangeMenuTheme();
            }
            catch { /* skibidi sigma rizz :) */ }
            NotifiLib.SendNotification("<color=grey>[</color><color=green>SUCCESSFULLY</color><color=grey>]</color> Loaded Settings!");
        }

        public static void Load()
        {
            String[] thing = System.IO.File.ReadAllLines("XonnczReborn\\Prefabs.txt");
            foreach (String thing2 in thing)
            {
                foreach (ButtonInfo[] button in Menu.Buttons.buttons)
                {
                    foreach (ButtonInfo button2 in button)
                    {
                        if (button2.buttonText + button2.overlapText == thing2)
                        {
                            button2.enabled = true;
                        }
                    }
                }               
            }
            NotifiLib.SendNotification("<color=grey>[</color><color=green>SUCCESSFULLY</color><color=grey>]</color> Loaded Mods!");
        }



        // Constant
        public static void Prefix()
        {
            // Initialize Menu
                try
                {                   
                    bool toOpen = (!rightHanded && ControllerInputPoller.instance.leftControllerSecondaryButton) || (rightHanded && ControllerInputPoller.instance.rightControllerSecondaryButton);
                    bool keyboardOpen = UnityInput.Current.GetKey(keyboardButton);

                    if (menu == null)
                    {
                        if (toOpen || keyboardOpen)
                        {
                            CreateMenu();
                            RecenterMenu(rightHanded, keyboardOpen);
                            if (reference == null)
                            {
                                CreateReference(rightHanded);
                            }
                        }
                    }
                    else
                    {
                        if ((toOpen || keyboardOpen))
                        {
                            RecenterMenu(rightHanded, keyboardOpen);
                        }
                        else
                        {
                            Rigidbody comp = menu.AddComponent(typeof(Rigidbody)) as Rigidbody;
                            if (rightHanded)
                            {
                                comp.velocity = GorillaLocomotion.Player.Instance.rightHandCenterVelocityTracker.GetAverageVelocity(true, 0);
                            }
                            else
                            {
                                comp.velocity = GorillaLocomotion.Player.Instance.leftHandCenterVelocityTracker.GetAverageVelocity(true, 0);
                            }
                            UnityEngine.Object.Destroy(menu, 2);
                            menu = null;

                            UnityEngine.Object.Destroy(reference);
                            reference = null;
                        }
                    }
                }
                catch (Exception exc)
                {
                    UnityEngine.Debug.LogError(string.Format("{0} // Error initializing at {1}: {2}", PluginInfo.Name, exc.StackTrace, exc.Message));
                }

            // Constant
                try
                {
                    // Pre-Execution
                        if (fpsObject != null)
                        {
                            fpsObject.text = "FPS: " + Mathf.Ceil(1f / Time.unscaledDeltaTime).ToString();
                        }

                    // Execute Enabled mods
                        foreach (ButtonInfo[] buttonlist in buttons)
                        {
                            foreach (ButtonInfo v in buttonlist)
                            {
                                if (v.enabled)
                                {
                                    if (v.method != null)
                                    {
                                        try
                                        {
                                            v.method.Invoke();
                                        }
                                        catch (Exception exc)
                                        {
                                            UnityEngine.Debug.LogError(string.Format("{0} // Error with mod {1} at {2}: {3}", PluginInfo.Name, v.buttonText, exc.StackTrace, exc.Message));
                                        }
                                    }
                                }
                            }
                        }
                } catch (Exception exc)
                {
                    UnityEngine.Debug.LogError(string.Format("{0} // Error with executing mods at {1}: {2}", PluginInfo.Name, exc.StackTrace, exc.Message));
                }           
        }

        // Functions

        public static int Fade = 0;

        public static bool ClearMenu = false;

        public static void ChangeFadingColor1()
        {
            Fade++;
            if (Fade < 0)
            {
                Fade = 8;
            }
            if (Fade > 8)
            {
                Fade = 0;
            }

            if (Fade == 0)
            {
                fadingcolor1 = Color.red;
                GetIndex("Faded Menu Color 1").overlapText = "Faded Menu Color[<color=red>Red</color>]";
            }
            if (Fade == 1)
            {
                fadingcolor1 = Color.blue;
                GetIndex("Faded Menu Color 1").overlapText = "Faded Menu Color[<color=blue>Blue</color>]";
            }
            if (Fade == 2)
            {
                fadingcolor1 = Color.green;
                GetIndex("Faded Menu Color 1").overlapText = "Faded Menu Color[<color=green>Green</color>]";
            }
            if (Fade == 3)
            {
                fadingcolor1 = Color.cyan;
                GetIndex("Faded Menu Color 1").overlapText = "Faded Menu Color[<color=cyan>Cyan</color>]";
            }
            if (Fade == 4)
            {
                fadingcolor1 = Color.magenta;
                GetIndex("Faded Menu Color 1").overlapText = "Faded Menu Color[<color=magenta>Magenta</color>]";
            }
            if (Fade == 5)
            {
                fadingcolor1 = Color.black;
                GetIndex("Faded Menu Color 1").overlapText = "Faded Menu Color[<color=black>Black</color>]";
            }
            if (Fade == 6)
            {
                fadingcolor1 = Color.grey;
                GetIndex("Faded Menu Color 1").overlapText = "Faded Menu Color[<color=grey>Grey</color>]";
            }
            if (Fade == 7)
            {
                fadingcolor1 = Color.yellow;
                GetIndex("Faded Menu Color 1").overlapText = "Faded Menu Color[<color=yellow>Yellow</color>]";
            }
            if (Fade == 8)
            {
                fadingcolor1 = Color.white;
                GetIndex("Faded Menu Color 1").overlapText = "Faded Menu Color[<color=white>White</color>]";
            }
        }
        public static void ChangeFadingColor2()
        {
            Fade++;
            if (Fade < 0)
            {
                Fade = 8;
            }
            if (Fade > 8)
            {
                Fade = 0;
            }

            if (Fade == 0)
            {
                fadingcolor2 = Color.red;
                GetIndex("Faded Menu Color 2").overlapText = "Faded Menu Color[<color=red>Red</color>]";
            }
            if (Fade == 1)
            {
                fadingcolor2 = Color.blue;
                GetIndex("Faded Menu Color 2").overlapText = "Faded Menu Color[<color=blue>Blue</color>]";
            }
            if (Fade == 2)
            {
                fadingcolor2 = Color.green;
                GetIndex("Faded Menu Color 2").overlapText = "Faded Menu Color[<color=green>Green</color>]";
            }
            if (Fade == 3)
            {
                fadingcolor2 = Color.cyan;
                GetIndex("Faded Menu Color 2").overlapText = "Faded Menu Color[<color=cyan>Cyan</color>]";
            }
            if (Fade == 4)
            {
                fadingcolor2 = Color.magenta;
                GetIndex("Faded Menu Color 2").overlapText = "Faded Menu Color[<color=magenta>Magenta</color>]";
            }
            if (Fade == 5)
            {
                fadingcolor2 = Color.black;
                GetIndex("Faded Menu Color 2").overlapText = "Faded Menu Color[<color=black>Black</color>]";
            }
            if (Fade == 6)
            {
                fadingcolor2 = Color.grey;
                GetIndex("Faded Menu Color 2").overlapText = "Faded Menu Color[<color=grey>Grey</color>]";
            }
            if (Fade == 7)
            {
                fadingcolor2 = Color.yellow;
                GetIndex("Faded Menu Color 2").overlapText = "Faded Menu Color[<color=yellow>Yellow</color>]";
            }
            if (Fade == 8)
            {
                fadingcolor2 = Color.white;
                GetIndex("Faded Menu Color 2").overlapText = "Faded Menu Color[<color=white>White</color>]";
            }
        }

        public static Color MenuColor = new Color32(255, 0, 0, 255);
        public static Color fadingcolor1 = Color.red;
        public static Color fadingcolor2 = Color.black;
        public static Color OutlineColor = new Color32(0, 0, 0, 255);
        public static Color enabledColor = MenuColor;
        public static bool fading = false;

        public static void CreateMenu()
        {
            // Menu Holder
                menu = GameObject.CreatePrimitive(PrimitiveType.Cube);
                UnityEngine.Object.Destroy(menu.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(menu.GetComponent<BoxCollider>());
                UnityEngine.Object.Destroy(menu.GetComponent<Renderer>());
                menu.transform.localScale = new Vector3(0.1f, 0.3f, 0.3825f);

            // Menu Background
                menuBackground = GameObject.CreatePrimitive(PrimitiveType.Cube);
                UnityEngine.Object.Destroy(menuBackground.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(menuBackground.GetComponent<BoxCollider>());
                menuBackground.transform.parent = menu.transform;
                menuBackground.transform.rotation = Quaternion.identity;
                menuBackground.transform.localScale = menuSize;
                menuBackground.GetComponent<Renderer>().material.color = MenuColor;
                if (fading) 
                { 
                    GradientColorKey[] array = new GradientColorKey[3];
                    array[0].color = fadingcolor1;
                    array[0].time = 0f;
                    array[1].color = fadingcolor2;
                    array[1].time = 0.5f;
                    array[2].color = fadingcolor1;
                    array[2].time = 1f;
                    ColorChanger faded = menuBackground.AddComponent<ColorChanger>();
                    faded.colorInfo = new ExtGradient
                    {
                        colors = array
                    };
                    faded.Start();
                }
                else
                {
                    GradientColorKey[] array = new GradientColorKey[3];
                    array[0].color = MenuColor;
                    array[0].time = 0f;
                    array[1].color = MenuColor;
                    array[1].time = 0.5f;
                    array[2].color = MenuColor;
                    array[2].time = 1f;
                    ColorChanger faded = menuBackground.AddComponent<ColorChanger>();
                    faded.colorInfo = new ExtGradient
                    {
                        colors = array
                    };
                    faded.Start();
                } 
                if (ClearMenu) 
                {
                    menuBackground.GetComponent<Renderer>().enabled = false;
                }
                else
                {
                    menuBackground.GetComponent<Renderer>().enabled = true;
                }    
                
                menuBackground.transform.position = new Vector3(0.05f, 0f, 0f);

                GameObject outline = GameObject.CreatePrimitive(PrimitiveType.Cube);
                UnityEngine.Object.Destroy(outline.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(outline.GetComponent<BoxCollider>());
                outline.transform.parent = menu.transform;
                outline.transform.rotation = Quaternion.identity;
                outline.transform.localScale = menuSize;
                outline.GetComponent<Renderer>().material.color = OutlineColor;
                ColorChanger colorChanger2 = outline.AddComponent<ColorChanger>();
                colorChanger2.Start();
                outline.transform.position = new Vector3(0.05f, 0f, 0f);
                if (thickk) 
                {
                    outline.transform.localScale = new Vector3(0.08f, 1.2f, 1.1f);
                }
                else
                {
                    outline.transform.localScale = new Vector3(0.08f, 1.16f, 1.07f);
                }



            // Canvas
                canvasObject = new GameObject();
                canvasObject.transform.parent = menu.transform;
                Canvas canvas = canvasObject.AddComponent<Canvas>();
                CanvasScaler canvasScaler = canvasObject.AddComponent<CanvasScaler>();
                canvasObject.AddComponent<GraphicRaycaster>();
                canvas.renderMode = RenderMode.WorldSpace;
                canvasScaler.dynamicPixelsPerUnit = 1000f;

            // Title and FPS
                Text text = new GameObject
                {
                    transform =
                    {
                        parent = canvasObject.transform
                    }
                }.AddComponent<Text>();
                text.font = currentFont;
                text.text = PluginInfo.Name;
                text.fontSize = 1;
                text.color = textColors[0];
                text.supportRichText = true;
                text.fontStyle = FontStyle.Italic;
                text.alignment = TextAnchor.MiddleCenter;
                text.resizeTextForBestFit = true;
                text.resizeTextMinSize = 0;
                RectTransform component = text.GetComponent<RectTransform>();
                component.localPosition = Vector3.zero;
                component.sizeDelta = new Vector2(0.28f, 0.05f);
                component.position = new Vector3(0.06f, 0f, 0.165f);
                component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));

                if (fpsCounter)
                {
                    fpsObject = new GameObject
                    {
                        transform =
                    {
                        parent = canvasObject.transform
                    }
                    }.AddComponent<Text>();
                    fpsObject.font = currentFont;
                    fpsObject.text = "FPS: " + Mathf.Ceil(1f / Time.unscaledDeltaTime).ToString();
                    fpsObject.color = textColors[0];
                    fpsObject.fontSize = 1;
                    fpsObject.supportRichText = true;
                    fpsObject.fontStyle = FontStyle.Italic;
                    fpsObject.alignment = TextAnchor.MiddleCenter;
                    fpsObject.horizontalOverflow = UnityEngine.HorizontalWrapMode.Overflow;
                    fpsObject.resizeTextForBestFit = true;
                    fpsObject.resizeTextMinSize = 0;
                    RectTransform component2 = fpsObject.GetComponent<RectTransform>();
                    component2.localPosition = Vector3.zero;
                    component2.sizeDelta = new Vector2(0.28f, 0.02f);
                    component2.position = new Vector3(0.06f, 0f, 0.135f);
                    component2.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
                }

            // Buttons
                // Home                   
                    // disconnect Button
                    if (disconnectButton)
                    {
                        GameObject disconnectbutton = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        if (!UnityInput.Current.GetKey(KeyCode.Q))
                        {
                            disconnectbutton.layer = 2;
                        }
                        UnityEngine.Object.Destroy(disconnectbutton.GetComponent<Rigidbody>());
                        disconnectbutton.GetComponent<BoxCollider>().isTrigger = true;
                        disconnectbutton.transform.parent = menu.transform;
                        disconnectbutton.transform.rotation = Quaternion.identity;
                        disconnectbutton.transform.localScale = new Vector3(0.06f, 0.5f, 0.12f);
                        disconnectbutton.transform.localPosition = new Vector3(0.63f, 0.26f, -0.4f);
                        disconnectbutton.GetComponent<Renderer>().material.color = buttonColors[0].colors[0].color;
                        disconnectbutton.AddComponent<Classes.Button>().relatedText = "Disconnect";
                        ColorChanger colorChangers = menuBackground.AddComponent<ColorChanger>();
                        colorChangers = disconnectbutton.AddComponent<ColorChanger>();
                        colorChangers.colorInfo = buttonColors[0];
                        colorChangers.Start();              
                        Text discontext = new GameObject
                        {
                            transform =
                            {
                                parent = canvasObject.transform
                            }
                        }.AddComponent<Text>();
                        discontext.text = "Leave";
                        discontext.font = currentFont;
                        discontext.fontSize = 1;
                        discontext.color = textColors[0];
                        discontext.alignment = TextAnchor.MiddleCenter;
                        discontext.resizeTextForBestFit = true;
                        discontext.resizeTextMinSize = 0;
                        RectTransform rectt = discontext.GetComponent<RectTransform>();
                        rectt.localPosition = Vector3.zero;
                        rectt.sizeDelta = new Vector2(0.2f, 0.03f);
                        rectt.localPosition = new Vector3(0.067f, disconnectbutton.transform.position.y, -0.15f);
                        rectt.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
                        if (ClearMenu)
                        {
                            disconnectbutton.GetComponent<Renderer>().enabled = false;
                        }
                        else
                        {
                            disconnectbutton.GetComponent<Renderer>().enabled = true;
                        }
                    }

             // Page Buttons
                GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                if (!UnityInput.Current.GetKey(KeyCode.Q))
                {
                    gameObject.layer = 2;
                }
                UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
                gameObject.GetComponent<BoxCollider>().isTrigger = true;
                gameObject.transform.parent = menu.transform;
                gameObject.transform.rotation = Quaternion.identity;
                gameObject.transform.localScale = new Vector3(0.09f, 0.2f, 0.16f);
                gameObject.transform.localPosition = new Vector3(0.56f, -0.15f, -0.40f);
                gameObject.GetComponent<Renderer>().material.color = buttonColors[0].colors[0].color;
                gameObject.AddComponent<Classes.Button>().relatedText = "PreviousPage";
                ColorChanger colorChanger = menuBackground.AddComponent<ColorChanger>();
                colorChanger.Start();
                colorChanger = gameObject.AddComponent<ColorChanger>();
                colorChanger.colorInfo = buttonColors[0];
                colorChanger.Start();

                text = new GameObject
                {
                    transform =
                        {
                            parent = canvasObject.transform
                        }
                }.AddComponent<Text>();
                text.font = currentFont;
                text.text = "<";
                text.fontSize = 1;
                text.color = textColors[0];
                text.alignment = TextAnchor.MiddleCenter;
                text.resizeTextForBestFit = true;
                text.resizeTextMinSize = 0;
                component = text.GetComponent<RectTransform>();
                component.localPosition = Vector3.zero;
                component.sizeDelta = new Vector2(0.2f, 0.03f);
                component.localPosition = new Vector3(0.064f, gameObject.transform.position.y, gameObject.transform.position.z);
                if (ClearMenu)
                {
                    gameObject.GetComponent<Renderer>().enabled = false;
                }
                else
                {
                    gameObject.GetComponent<Renderer>().enabled = true;
                }
                component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));

                gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                if (!UnityInput.Current.GetKey(KeyCode.Q))
                {
                    gameObject.layer = 2;
                }
                UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
                gameObject.GetComponent<BoxCollider>().isTrigger = true;
                gameObject.transform.parent = menu.transform;
                gameObject.transform.rotation = Quaternion.identity;
                gameObject.transform.localScale = new Vector3(0.09f, 0.2f, 0.16f);
                gameObject.transform.localPosition = new Vector3(0.56f, -0.41f, -0.40f);
                gameObject.GetComponent<Renderer>().material.color = buttonColors[0].colors[0].color;
                gameObject.AddComponent<Classes.Button>().relatedText = "NextPage";

                colorChanger = gameObject.AddComponent<ColorChanger>();
                colorChanger.colorInfo = buttonColors[0];
                colorChanger.Start();

                text = new GameObject
                {
                    transform =
                        {
                            parent = canvasObject.transform
                        }
                }.AddComponent<Text>();
                text.font = currentFont;
                text.text = ">";
                text.fontSize = 1;
                text.color = textColors[0];
                text.alignment = TextAnchor.MiddleCenter;
                text.resizeTextForBestFit = true;
                text.resizeTextMinSize = 0;
                component = text.GetComponent<RectTransform>();
                component.localPosition = Vector3.zero;
                component.sizeDelta = new Vector2(0.2f, 0.03f);
                component.localPosition = new Vector3(0.064f, -0.123f, gameObject.transform.position.z);
                component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
                if (ClearMenu) 
                {
                    gameObject.GetComponent<Renderer>().enabled = false;
                }
                else
                {
                    gameObject.GetComponent<Renderer>().enabled = true;
                }

            // Mod Buttons
            ButtonInfo[] activeButtons = buttons[buttonsType].Skip(pageNumber * buttonsPerPage).Take(buttonsPerPage).ToArray();
            for (int i = 0; i < activeButtons.Length; i++)
            {
                CreateButton(i * 0.1f, activeButtons[i]);
            }
        }

        public static void CreateButton(float offset, ButtonInfo method)
        {
            GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            if (!UnityInput.Current.GetKey(KeyCode.Q))
            {
                gameObject.layer = 2;
            }
            UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
            gameObject.transform.parent = menu.transform;
            gameObject.transform.rotation = Quaternion.identity;
            gameObject.transform.localScale = new Vector3(0.09f, 0.9f, 0.08f);
            gameObject.transform.localPosition = new Vector3(0.56f, 0f, 0.28f - offset);
            gameObject.AddComponent<Classes.Button>().relatedText = method.buttonText;

            ColorChanger colorChanger = gameObject.AddComponent<ColorChanger>();
            if (method.enabled)
            {
                gameObject.GetComponent<Renderer>().material.color = MenuColor;
            }
            else
            {
                colorChanger.colorInfo = buttonColors[0];
            }
            colorChanger.Start();

            Text text = new GameObject
            {
                transform =
                {
                    parent = canvasObject.transform
                }
            }.AddComponent<Text>();
            text.font = currentFont;
            text.text = method.buttonText;
            if (method.overlapText != null)
            {
                text.text = method.overlapText;
            }
            text.supportRichText = true;
            text.fontSize = 1;
            if (method.enabled)
            {
                text.color = textColors[1];
            }
            else
            {
                text.color = textColors[0];
            }
            text.alignment = TextAnchor.MiddleCenter;
            text.fontStyle = FontStyle.Italic;
            text.resizeTextForBestFit = true;
            text.resizeTextMinSize = 0;
            RectTransform component = text.GetComponent<RectTransform>();
            component.localPosition = Vector3.zero;
            component.sizeDelta = new Vector2(.2f, .03f);
            component.localPosition = new Vector3(.064f, 0, .111f - offset / 2.6f);
            component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
            if (ClearMenu)
            {
                gameObject.GetComponent<Renderer>().enabled = false;
            }
            else
            {
                gameObject.GetComponent<Renderer>().enabled = true;
            }
        }

        public static void RecreateMenu()
        {
            if (menu != null)
            {
                UnityEngine.Object.Destroy(menu);
                menu = null;

                CreateMenu();
                RecenterMenu(rightHanded, UnityInput.Current.GetKey(keyboardButton));
            }
        }

        public static void RecenterMenu(bool isRightHanded, bool isKeyboardCondition)
        {
            if (!isKeyboardCondition)
            {
                if (!isRightHanded)
                {
                    menu.transform.position = GorillaTagger.Instance.leftHandTransform.position;
                    menu.transform.rotation = GorillaTagger.Instance.leftHandTransform.rotation;
                }
                else
                {
                    menu.transform.position = GorillaTagger.Instance.rightHandTransform.position;
                    Vector3 rotation = GorillaTagger.Instance.rightHandTransform.rotation.eulerAngles;
                    rotation += new Vector3(0f, 0f, 180f);
                    menu.transform.rotation = Quaternion.Euler(rotation);
                }
            }
            else
            {
                try
                {
                    TPC = GameObject.Find("Player Objects/Third Person Camera/Shoulder Camera").GetComponent<Camera>();
                }
                catch { }
                if (TPC != null)
                {
                    TPC.transform.position = new Vector3(-64f, 3.4f, -65f);
                    TPC.transform.rotation = Quaternion.identity;                    
                    menu.transform.parent = TPC.transform;
                    menu.transform.position = TPC.transform.position + (TPC.transform.forward * 0.5f) + (TPC.transform.up * 0f);
                    Vector3 rot = TPC.transform.rotation.eulerAngles;
                    rot += new Vector3(-90f, 90f, 0f);
                    menu.transform.rotation = Quaternion.Euler(rot);

                    if (reference != null)
                    {
                        if (Mouse.current.leftButton.isPressed)
                        {
                            Ray ray = TPC.ScreenPointToRay(Mouse.current.position.ReadValue());
                            RaycastHit hit;
                            bool worked = Physics.Raycast(ray, out hit, 100);
                            if (worked)
                            {
                                Classes.Button collide = hit.transform.gameObject.GetComponent<Classes.Button>();
                                if (collide != null)
                                {
                                    collide.OnTriggerEnter(buttonCollider);
                                }
                            }
                        }
                        else
                        {
                            reference.transform.position = new Vector3(999f, -999f, -999f);
                        }
                    }
                }
            }
        }

        public static void CreateReference(bool isRightHanded)
        {
            reference = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            if (isRightHanded)
            {
                reference.transform.parent = GorillaTagger.Instance.leftHandTransform;
            }
            else
            {
                reference.transform.parent = GorillaTagger.Instance.rightHandTransform;
            }
            reference.GetComponent<Renderer>().material.color = backgroundColor.colors[0].color;
            reference.transform.localPosition = new Vector3(0f, -0.1f, 0f);
            reference.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            buttonCollider = reference.GetComponent<SphereCollider>();

            ColorChanger colorChanger = reference.AddComponent<ColorChanger>();
            colorChanger.colorInfo = backgroundColor;
            colorChanger.Start();
        }

        public static void Toggle(string buttonText)
        {
            int lastPage = ((buttons[buttonsType].Length + buttonsPerPage - 1) / buttonsPerPage) - 1;
            if (buttonText == "PreviousPage")
            {
                pageNumber--;
                if (pageNumber < 0)
                {
                    pageNumber = lastPage;
                }
            } 
            else
            {
                if (buttonText == "NextPage")
                {
                    pageNumber++;
                    if (pageNumber > lastPage)
                    {
                        pageNumber = 0;
                    }
                }
                else 
                if (buttonText == "Disconnect")
                {
                    PhotonNetwork.Disconnect();
                }
                else
                if (buttonText == "Home")
                {
                    Global.ReturnHome();
                }
                else
                {
                    ButtonInfo target = GetIndex(buttonText);
                    if (target != null)
                    {
                        if (target.isTogglable)
                        {
                            target.enabled = !target.enabled;
                            if (target.enabled)
                            {
                                NotifiLib.SendNotification("<color=red>[</color><color=red>ENABLE</color><color=red>]</color> " + target.toolTip);
                                if (target.enableMethod != null)
                                {
                                    try { target.enableMethod.Invoke(); } catch { }
                                }
                            }
                            else
                            {
                                NotifiLib.SendNotification("<color=red>[</color><color=red>DISABLE</color><color=red>]</color> " + target.toolTip);
                                if (target.disableMethod != null)
                                {
                                    try { target.disableMethod.Invoke(); } catch { }
                                }
                            }
                        }
                        else
                        {
                            NotifiLib.SendNotification("<color=red>[</color><color=red>ENABLE</color><color=red>]</color> " + target.toolTip);
                            if (target.method != null)
                            {
                                try { target.method.Invoke(); } catch { }
                            }
                        }
                    }
                    else
                    {
                        UnityEngine.Debug.LogError(buttonText + " does not exist");
                    }
                }
            }
            RecreateMenu();
        }

        public static GradientColorKey[] GetSolidGradient(Color color)
        {
            return new GradientColorKey[] { new GradientColorKey(color, 0f), new GradientColorKey(color, 1f) };
        }

        public static ButtonInfo GetIndex(string buttonText)
        {
            foreach (ButtonInfo[] buttons in Menu.Buttons.buttons)
            {
                foreach (ButtonInfo button in buttons)
                {
                    if (button.buttonText == buttonText)
                    {
                        return button;
                    }
                }
            }

            return null;
        }

        // Variables
            // Important
                // Objects
                    public static GameObject menu;
                    public static GameObject menuBackground;   
                    public static GameObject reference;
                    public static GameObject canvasObject;

                    public static SphereCollider buttonCollider;
                    public static Camera TPC;
                    public static Text fpsObject;

        // Data
            public static int pageNumber = 0;
            public static int buttonsType = 0;
    }
}
