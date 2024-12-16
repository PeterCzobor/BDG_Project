using SimpleFileBrowser;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileBrowserInit : MonoBehaviour
{
    public Sprite desktopSprite;
    public Sprite downloadSprite;
    public Sprite documentSprite;
    public Sprite pictureSprite;
    public Sprite driveSprite;

    void Start()
    {
        FileBrowser.ClearQuickLinks();

        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string picturesPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
        string downloadsPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";

        FileBrowser.AddQuickLink("C:\\", "C:\\", driveSprite);
        FileBrowser.AddQuickLink("Desktop", desktopPath, desktopSprite);
        FileBrowser.AddQuickLink("Downloads", downloadsPath, downloadSprite);
        FileBrowser.AddQuickLink("Documents", documentsPath, documentSprite);
        FileBrowser.AddQuickLink("Pictures", picturesPath, pictureSprite);
        FileBrowser.AddQuickLink("Users", "C:\\Users", null);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
