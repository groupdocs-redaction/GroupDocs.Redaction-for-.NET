﻿// Copyright (c) Aspose 2002-2016. All Rights Reserved.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using GroupDocsRedactionVisualStudioPlugin.GUI;

namespace GroupDocsRedactionVisualStudioPlugin.Core
{
    public class GroupDocsComponentsManager
    {
        ComponentWizardPage _pageOne = null;
        public GroupDocsComponentsManager(ComponentWizardPage page)
        {
            _pageOne = page;
        }

        /**
         * 
         * @return
         */
        public bool downloadComponents()
        {
            if (!isIneternetConnected())
            {
                _pageOne.showMessage(Constants.INTERNET_CONNECTION_REQUIRED_MESSAGE_TITLE, Constants.INTERNET_CONNECTION_REQUIRED_MESSAGE, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return false;
            }

            foreach (GroupDocsComponent component in GroupDocsComponents.list.Values)
            {
                if (component.is_selected())
                {
                    GlobalData.SelectedComponent = component.get_name();

                    if (libraryAlreadyExists(component.get_downloadFileName()))
                    {
                        component.set_currentVersion(readVersion(component));
                        if (readVersion(component).CompareTo(component.get_latestVersion()) == 0)
                        {
                            component.set_downloaded(true);
                        }
                        else
                        {
                            addToDownloadList(component, component.get_downloadUrl(), component.get_downloadFileName());
                        }
                    }
                    else
                    {
                        addToDownloadList(component, component.get_downloadUrl(), component.get_downloadFileName());
                    }
                }
            }
            return true;
        }

        public static string readVersion(GroupDocsComponent component)
        {
            string localPath = getLibaryDownloadPath() + component.get_name() + ".ver";
            string line = string.Empty;

            try
            {
                return System.IO.File.ReadAllText(localPath);
            }
            catch (Exception) { }
            return line;
        }

        public void storeReleaseNotes(GroupDocsComponent component)
        {
            string localPath = getLibaryDownloadPath() + component.get_name() + ".htm";
            try
            {
                System.IO.File.WriteAllText(localPath, component.get_changeLog());
            }
            catch (FileNotFoundException e)
            {

            }
            catch (Exception e)
            {

            }

        }

        public static void storeVersion(GroupDocsComponent component)
        {
            string localPath = getLibaryDownloadPath() + component.get_name() + ".ver";
            try
            {
                System.IO.File.WriteAllText(localPath, component.get_latestVersion());
            }
            catch (FileNotFoundException e)
            {

            }
            catch (Exception e)
            {

            }
        }

        public static bool libraryAlreadyExists(string libFileName)
        {
            return System.IO.File.Exists(getLibaryDownloadPath() 
                + libFileName.Replace(".zip", "") + "\\lib\\" + libFileName.Replace(".zip", ".dll"));
        }

        public static void addToDownloadList(GroupDocsComponent component, string urlStr, string outputFile)
        {
            AsyncDownload asyncDownload = new AsyncDownload();
            asyncDownload.Url = urlStr;
            asyncDownload.LocalPath = getLibaryDownloadPath() + outputFile;
            asyncDownload.Component = component;
            AsyncDownloadList.list.Add(asyncDownload);
        }

        public static string removeExtention(string filePath)
        {
            return Path.GetFileNameWithoutExtension(filePath);
        }

        public static bool isIneternetConnected()
        {
            try
            {
                System.Net.IPHostEntry ipHostEntry = System.Net.Dns.GetHostEntry("www.google.com");
            }
            catch (SocketException)
            {
                return false;
            }
            return true;
        }

        public static string getLibaryDownloadPath()
        {

            string path = "";
            path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            path = path + "/groupdocs/dotnet/libraries/";

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            return path;

        }

        public static string getGroupDocsHomePath()
        {
            string path = "";
            path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            path = path + "/groupdocs/dotnet/";
            return path;
        }

        public static void unZipFile(string zipFile, string outputFolder)
        {
            try
            {
                if (Directory.Exists(outputFolder))
                {
                    Directory.Delete(outputFolder, true);
                }
            }
            catch { }
            ZipUtilities zipUtilities = new ZipUtilities();
            zipUtilities.ExtractZipFile(zipFile, outputFolder);
        }
    }
}
