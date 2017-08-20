﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Win32;
using System.IO;

namespace imageDeCap
{
    public partial class SettingsWindow : Form
    {
        Form1 parentForm;
        public SettingsWindow(Form1 parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
            initSettings();
        }

        void initSettings()
        {
            checkBox1.Checked = Preferences.saveImageAtAll;
            button2.Enabled = Preferences.saveImageAtAll;
            alsoSaveTextFilesBox.Enabled = Preferences.saveImageAtAll;
            alsoSaveTextFilesBox.Checked = Preferences.AlsoSaveTextFiles;

            textBox1.Text = Preferences.SaveImagesHere;
            textBox1.Enabled = checkBox1.Checked;

            checkBox7.Checked = Preferences.EditScreenshotAfterCapture;
            checkBox3.Checked = Preferences.CopyLinksToClipboard;
            checkBox4.Checked = Preferences.DisableSoundEffects;

            checkBox2.Checked = Preferences.OpenInBrowser;
            checkBox2.Enabled = !Preferences.NeverUpload;
            checkBox3.Enabled = !Preferences.NeverUpload;
            checkBox5.Enabled = !Preferences.NeverUpload;
            textBox2.Enabled = !Preferences.NeverUpload;

            neverUpload.Checked = Preferences.NeverUpload;

            checkBox5.Checked = Preferences.DisableNotifications;

            textBox2.Text = Preferences.PastebinSubjectLine;

            checkBox6.Checked = Preferences.FreezeScreenOnRegionShot;

            AlsoFTPTextFilesBox.Checked = Preferences.uploadToFTP;
            AlsoFTPTextFilesBox.Enabled = Preferences.uploadToFTP;
            AlsoFTPTextFilesBox.Checked = Preferences.AlsoFTPTextFiles;
            FTPURL.Enabled = Preferences.uploadToFTP;
            FTPUsername.Enabled = Preferences.uploadToFTP;
            FTPpassword.Enabled = Preferences.uploadToFTP;
            
            HotkeyTextBox1.Text = Preferences.Hotkey1;
            HotkeyTextBox2.Text = Preferences.Hotkey2;
            HotkeyTextBox3.Text = Preferences.Hotkey3;
            HotkeyTextBox4.Text = Preferences.Hotkey4;

            FTPpassword.Text = Preferences.FTPpassword;
            FTPURL.Text = Preferences.FTPurl;
            FTPUsername.Text = Preferences.FTPusername;

            gifFPS.Value = Preferences.GIFRecordingFramerate;

            //Uninstallbutton.Enabled = !Preferences.Portable;
            //AddToAutoStart.Enabled = !Preferences.Portable;
            //button4.Enabled = !Preferences.Portable;

            CopyImageToClipboard.Checked = Preferences.CopyImageToClipboard;
        }

        //static void CreateShortcut(string targetProgram, string shortcutPath)
        //{
        //    object shDesktop = (object)"Desktop";
        //    IWshRuntimeLibrary.WshShell shell = new IWshRuntimeLibrary.WshShell();
        //    string shortcutAddress = shortcutPath;
        //    IWshRuntimeLibrary.IWshShortcut shortcut = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(shortcutAddress);
        //    shortcut.Description = "imageDeCap auto-start";
        //
        //    shortcut.TargetPath = targetProgram;
        //    shortcut.Save();
        //}


        //string exeName = Path.GetFileName(System.Reflection.Assembly.GetEntryAssembly().Location);

        //public static string PortablePath;
        //public static string InstallPath;
        //public static string PortableSettingsPath;
        //public static string InstallSettingsPath;
        //public static string PortableExePath;
        //public static string InstallExePath;
        //public static string PortableLinksPath;
        //public static string InstallLinksPath; 
        //public static void LoadInstall()
        //{
        //    Preferences.Load(InstallSettingsPath);
        //    Preferences.SettingsFilePath = InstallPath;
        //}
        //public static void LoadPortable()
        //{
        //    Preferences.Load(PortableSettingsPath);
        //    Preferences.SettingsFilePath = PortablePath;
        //}
        //public static void PortableToInstall()
        //{
        //    if (System.IO.File.Exists(InstallExePath))
        //        System.IO.File.Delete(InstallExePath);
        //    if (!Directory.Exists(InstallPath))
        //        Directory.CreateDirectory(InstallPath);
        //
        //    SettingsWindow.TryMoveFile(PortableSettingsPath, InstallSettingsPath);
        //    SettingsWindow.TryMoveFile(PortableLinksPath, InstallLinksPath);
        //    System.IO.File.Copy(PortableExePath, InstallExePath);
        //}
        //public static void InstallToPortable()
        //{
        //    SettingsWindow.TryMoveFile(InstallSettingsPath, PortableSettingsPath);
        //    SettingsWindow.TryMoveFile(InstallLinksPath, PortableLinksPath);
        //}

        //public static void TryMoveFile(string from, string to)
        //{
        //    if (System.IO.File.Exists(to))
        //    {
        //        try { System.IO.File.Delete(to); } catch { }
        //    }
        //    if (System.IO.File.Exists(from))
        //    {
        //        System.IO.File.Copy(from, to);
        //        try { System.IO.File.Delete(from); } catch { }
        //    }
        //}
        //public static void TryCopyFile(string from, string to)
        //{
        //    if (System.IO.File.Exists(from))
        //    {
        //        System.IO.File.Copy(from, to);
        //        try { System.IO.File.Delete(from); } catch { }
        //    }
        //}
        //public static void TryDelete(string file)
        //{
        //    if(File.Exists(file))
        //    {
        //        File.Delete(file);
        //    }
        //}
        //
        //public static void AddToStartup()
        //{
        //    string startMenuShortcutPath = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu) + @"\imageDeCap.lnk";
        //    string shortcutPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup) + @"\imageDeCap.lnk";
        //
        //    if (System.IO.File.Exists(shortcutPath))
        //        System.IO.File.Delete(shortcutPath);
        //    if (System.IO.File.Exists(startMenuShortcutPath))
        //        System.IO.File.Delete(startMenuShortcutPath);
        //
        //    CreateShortcut(InstallExePath, shortcutPath);
        //    CreateShortcut(InstallExePath, startMenuShortcutPath);
        //}
        //public void RemoveFromStartup()
        //{
        //    string startMenuShortcutPath = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu) + @"\imageDeCap.lnk";
        //    string shortcutPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup) + @"\imageDeCap.lnk";
        //
        //    System.IO.File.Delete(startMenuShortcutPath);
        //    System.IO.File.Delete(shortcutPath);
        //}


        private void button5_Click(object sender, EventArgs e)//Apply
        {
            Preferences.saveImageAtAll = checkBox1.Checked;
            Preferences.SaveImagesHere = textBox1.Text;

            Preferences.Save();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }


        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
        }
        private void writeHotkey(KeyEventArgs e, TextBox box)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SettingsWindow_Load(object sender, EventArgs e)
        {
        }

        private void SettingsWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = checkBox1.Checked;
            button2.Enabled = checkBox1.Checked;
            alsoSaveTextFilesBox.Enabled = checkBox1.Checked;
            Preferences.saveImageAtAll = checkBox1.Checked;
            Preferences.Save();
        }


        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Preferences.SaveImagesHere = textBox1.Text;
            Preferences.Save();
        }
        
        private void RegisterInStartup(bool isChecked)
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey
                    ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (isChecked)
            {
                registryKey.SetValue("imageDeCap", Application.ExecutablePath);
            }
            else
            {
                registryKey.DeleteValue("imageDeCap");
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            Preferences.EditScreenshotAfterCapture = checkBox7.Checked;
            Preferences.Save();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            Preferences.CopyLinksToClipboard = checkBox3.Checked;
            Preferences.Save();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            Preferences.DisableSoundEffects = checkBox4.Checked;
            Preferences.Save();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Preferences.OpenInBrowser = checkBox2.Checked;
            Preferences.Save();
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            Preferences.PastebinSubjectLine = textBox2.Text;
            Preferences.Save();
        }

        private void neverUpload_CheckedChanged(object sender, EventArgs e)
        {
            Preferences.NeverUpload = neverUpload.Checked;
            Preferences.Save();
            checkBox2.Enabled = !Preferences.NeverUpload;
            checkBox3.Enabled = !Preferences.NeverUpload;
            checkBox5.Enabled = !Preferences.NeverUpload;
            textBox2.Enabled = !Preferences.NeverUpload;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Preferences.Reset();
            //Preferences.Save();
            initSettings();
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            Preferences.DisableNotifications = checkBox5.Checked;
            Preferences.Save();
            
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {

            Preferences.FreezeScreenOnRegionShot = checkBox6.Checked;
            Preferences.Save();
        }

        private void checkBoxUploadToFTP_CheckedChanged(object sender, EventArgs e)
        {
            //checkBoxUploadToFTP.Enabled = checkBoxUploadToFTP.Checked;
            Preferences.uploadToFTP = checkBoxUploadToFTP.Checked;
            Preferences.Save();

            AlsoFTPTextFilesBox.Enabled = Preferences.uploadToFTP;
            FTPURL.Enabled = Preferences.uploadToFTP;
            FTPUsername.Enabled = Preferences.uploadToFTP;
            FTPpassword.Enabled = Preferences.uploadToFTP;
        }

        private void FTPURL_TextChanged(object sender, EventArgs e)
        {
            Preferences.FTPurl = FTPURL.Text;
            Preferences.Save();
        }

        private void FTPUsername_TextChanged(object sender, EventArgs e)
        {
            Preferences.FTPusername = FTPUsername.Text;
            Preferences.Save();
        }

        private void FTPpassword_TextChanged(object sender, EventArgs e)
        {
            Preferences.FTPpassword = FTPpassword.Text;
            Preferences.Save();
        }

        private void alsoSaveTextFilesBox_CheckedChanged(object sender, EventArgs e)
        {
            Preferences.AlsoSaveTextFiles = alsoSaveTextFilesBox.Checked;
            Preferences.Save();
        }

        private void AlsoFTPTectFilesBox_CheckedChanged(object sender, EventArgs e)
        {
            Preferences.AlsoFTPTextFiles = AlsoFTPTextFilesBox.Checked;
            Preferences.Save();
        }

        public static string getCurrentHotkey()
        {

            string textToPutInBox = "";
            int length = Enum.GetValues(typeof(System.Windows.Input.Key)).Length;

            for (int i = length; i-- > 0;)
            {
                if(Enum.IsDefined(typeof(System.Windows.Input.Key), i) && i != 0)
                {
                    bool isDown = System.Windows.Input.Keyboard.IsKeyDown((System.Windows.Input.Key)i);
                    if (isDown)
                    {
                        textToPutInBox += ((System.Windows.Input.Key)i).ToString() + "+";
                        //textToPutInBox += i.ToString() + "+";
                    }
                }
            }
            if(textToPutInBox == "")
            {
                return "";
            }
            else
            {
                return textToPutInBox.Remove(textToPutInBox.Length - 1);
            }
        }

        private void HotkeyTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            HotkeyTextBox1.Text = getCurrentHotkey();
            Preferences.Hotkey1 = HotkeyTextBox1.Text;
            Preferences.Save();
        }
        private void HotkeyTextBox1_GotFocus(object sender, EventArgs e)
        {
            Program.hotkeysEnabled = false;
        }
        private void HotkeyTextBox1_LostFocus(object sender, EventArgs e)
        {
            Program.hotkeysEnabled = true;
        }

        private void HotkeyTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            HotkeyTextBox2.Text = getCurrentHotkey();
            Preferences.Hotkey2 = HotkeyTextBox2.Text;
            Preferences.Save();
        }
        private void HotkeyTextBox2_GotFocus(object sender, EventArgs e)
        {
            Program.hotkeysEnabled = false;
        }
        private void HotkeyTextBox2_LostFocus(object sender, EventArgs e)
        {
            Program.hotkeysEnabled = true;
        }
        private void HotkeyTextBox3_KeyDown(object sender, KeyEventArgs e)
        {
            HotkeyTextBox3.Text = getCurrentHotkey();
            Preferences.Hotkey3 = HotkeyTextBox3.Text;
            Preferences.Save();
        }
        private void HotkeyTextBox3_GotFocus(object sender, EventArgs e)
        {
            Program.hotkeysEnabled = false;
        }
        private void HotkeyTextBox3_LostFocus(object sender, EventArgs e)
        {
            Program.hotkeysEnabled = true;
        }

        private void HotkeyTextBox4_KeyDown(object sender, KeyEventArgs e)
        {
            HotkeyTextBox4.Text = getCurrentHotkey();
            Preferences.Hotkey4 = HotkeyTextBox4.Text;
            Preferences.Save();
        }
        private void HotkeyTextBox4_GotFocus(object sender, EventArgs e)
        {
            Program.hotkeysEnabled = false;
        }
        private void HotkeyTextBox4_LostFocus(object sender, EventArgs e)
        {
            Program.hotkeysEnabled = true;
        }

        private void HotkeyTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void HotkeyTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void HotkeyTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void HotkeyTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void installedLabel_Click(object sender, EventArgs e)
        {

        }

        private void CopyImageToClipboard_CheckedChanged(object sender, EventArgs e)
        {
            Preferences.CopyImageToClipboard = CopyImageToClipboard.Checked;
            Preferences.Save();
        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }





        


        //private void AddToStartMenu_Click(object sender, EventArgs e)
        //{
        //    //Install();
        //}
        //
        //private void AddToAutoStart_Click(object sender, EventArgs e)
        //{
        //    AddToStartup();
        //}
        //
        //private void button4_Click(object sender, EventArgs e)
        //{
        //    //UnInstall();
        //}

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.mattwestphal.com/");
        }

        private void imageContainer_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.mattwestphal.com/");
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void gifFPS_ValueChanged(object sender, EventArgs e)
        {
            Preferences.GIFRecordingFramerate = (int)gifFPS.Value;
        }

        //private void Uninstallbutton_Click(object sender, EventArgs e)
        //{
        //    var d = MessageBox.Show("Uninstall and Exit?", "Uninstall", MessageBoxButtons.OKCancel);
        //    if(d == DialogResult.OK)
        //    {
        //        TryDelete(InstallExePath);
        //        TryDelete(InstallLinksPath);
        //        TryDelete(InstallSettingsPath);
        //        RemoveFromStartup();
        //        Program.ImageDeCap.actuallyCloseTheProgram();
        //    }
        //}

        //private void button4_Click_1(object sender, EventArgs e)
        //{
        //    RemoveFromStartup();
        //}
    }
}
