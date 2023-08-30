using ImGuiNET;
using ClickableTransparentOverlay;
using System.Numerics;
using System.Runtime.InteropServices;
using Memory;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Reflection;
using Veldrid;

namespace Imgui_Net
{
    public class RenderClass : Overlay
    {
        /// <summary>
        /// https://keyauth.cc/
        /// </summary>
        public static api KeyAuthApp = new api(
         name: "",                              
         ownerid: "",
         secret: "",
         version: ""
     );
        Vector4 selected_color = new Vector4(1.0f,1.0f,1.0f,1.0f);
        bool checkbox1;
        bool checkbox2= false;
       
        bool checkbox;
        string tyeLog = "Aimbot";
      
        bool checkboxexample2 = false;
        bool checkboxexample;
        bool Login_form = true;
        bool Menu_form = false;
        Vector2 Login_imgui = new Vector2(750, 500);
        Vector2 Imgui_Size = new Vector2(350, 350);
        Vector2 Menu_Size = new Vector2(510, 370);
        Vector2 menu_login = new Vector2(20, 30);
        Vector2 Node = new Vector2(3, 3);
        Vector2 Node2 = new Vector2(5, 5);
        string username = "";
        string pass = "";
        float rouding = 1.0f;
        float opacity = 0.7f;
        
        protected override async void Render()
        {
            
            if (Login_form)
            {
               
                ImGuiStylePtr stylea = ImGui.GetStyle();
                stylea.Alpha = 0.9f;
                stylea.WindowBorderSize = 0.2f;
                stylea.WindowRounding = 8f;
                stylea.ChildRounding = 8f;
             
                stylea.Colors[(int)ImGuiCol.Border] = selected_color;
                stylea.Colors[(int)ImGuiCol.Text] = selected_color;
                stylea.Colors[(int)ImGuiCol.TitleBgActive] = new Vector4(0.50f,0.9f,0.40f,1.0f);
                
                ImGui.GetIO().Fonts.AddFontFromFileTTF(@"C:\Windows\Fonts\comicbd.ttf", 13);
                

                ImGui.SetNextWindowSize(Imgui_Size);
                ImGui.SetNextWindowPos(Login_imgui, ImGuiCond.Appearing);
                ImGui.Begin("bimsocool .Net Imgui", ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoSavedSettings);
                {
                    ImGui.SetCursorPos(menu_login);
                    ImGui.BeginChild("#bimsocool");
                    {
                        ImGui.Text("User Name");
                        ImGui.InputText("##User", ref username, Char.MaxValue);
                        ImGui.Text("Password");
                        ImGui.InputText("##Pass", ref pass, Char.MaxValue, ImGuiInputTextFlags.Password);
                        ImGui.Spacing();
                        
                        if (ImGui.Button("Login"))
                        {
                            
                            Thread t2 = new Thread(() =>
                            {
                                Program.ProgressBarCiz(0, 8, 100, 0, ConsoleColor.DarkGreen);
                                
                              

                            }); t2.Start();
                            Thread t = new Thread(() =>
                            {
                                
                                
                                KeyAuthApp.login(username, pass);
                                if (KeyAuthApp.response.success)
                                {
                                   
                                   
                                    Login_form = false;
                                    Menu_form = true;

                                }
                                else
                                {
                                   
                                }
                                
                            }); t.Start();

                            
                        }
                        if (ImGui.IsItemHovered(ImGuiHoveredFlags.AllowWhenOverlapped))
                        {
                            ImGui.SetTooltip("Click Login");
                        }
                        ImGui.End();
                        

                    }
                    ImGui.EndChild();


                }
                ImGui.End();
            }
            if(Menu_form)
            {

                ImGuiStylePtr style =  ImGui.GetStyle();
                ImGuiStylePtr stylea = ImGui.GetStyle();
                
                stylea.WindowBorderSize = 0.2f;
                stylea.WindowRounding = rouding;
                stylea.ChildRounding = rouding;

                stylea.Colors[(int)ImGuiCol.Border] = selected_color;
                stylea.Colors[(int)ImGuiCol.Text] = selected_color;
                style.Alpha = opacity;
                style.WindowBorderSize = 0.2f;
                ImGui.SetNextWindowSize(Menu_Size);
                ImGui.SetNextWindowPos(Login_imgui, ImGuiCond.Appearing);
                ImGui.Begin("bimsocool .Net Imgui", ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoSavedSettings);
                {
                    
                    ImGui.SetCursorPos(menu_login);
                    ImGui.BeginChild("#test");
                    {
                        ImGui.ColorEdit4("Change Color", ref selected_color,ImGuiColorEditFlags.PickerMask| ImGuiColorEditFlags.NoInputs);
                        ImGui.SliderFloat("Change Rouding", ref rouding,1,20);
                        ImGui.SliderFloat("Change Opacity", ref opacity, 0.1f, 1.0f);
                        ImGui.Spacing();
                        ImGui.PushStyleVar(ImGuiStyleVar.FramePadding,Node);
                        ImGui.PushStyleVar(ImGuiStyleVar.ItemInnerSpacing,Node2);
                        checkboxexample = ImGui.Checkbox("Check Box", ref checkboxexample2);
                        ImGui.PopStyleVar();
                        ImGui.Spacing();
                        ImGui.Spacing();

                       


                    } 
                    ImGui.EndChild();

                    
                }
                ImGui.End();
            }
            

        }

       






        
        
       

    }
}
