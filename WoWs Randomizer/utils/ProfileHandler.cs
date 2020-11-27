using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace WoWs_Randomizer.utils
{
    class ProfileHandler
    {
        Dictionary<string, ToolStripMenuItem> menuItems = new Dictionary<string, ToolStripMenuItem>();

        public ProfileHandler() { }
        public void addMenuitem(ToolStripMenuItem item)
        {
            menuItems.Add(item.Text, item);
        }

        public void uncheckAll()
        {
            foreach(KeyValuePair<string,ToolStripMenuItem> kvPair in menuItems)
            {
                ToolStripMenuItem item = kvPair.Value;
                item.Checked = false;
            }
        }

        public bool checkItem(string profileName)
        {
            if (menuItems.ContainsKey(profileName))
            {
                ToolStripMenuItem item = menuItems[profileName];
                item.Checked = true;
                return true;
            }
            return false;
        }

        public void clearCurrentProfile()
        {
            string[] files = Directory.GetFiles(Commons.GetCurrentDirectory());
            foreach (var filename in files)
            {
                string delfile = Path.GetFileName(filename);
                if (delfile.EndsWith(".obj") || delfile.EndsWith(".cfg"))
                {
                    File.Delete(filename);
                }
            }
        }

        public bool activateItem(string profileName)
        {
            if ( menuItems.ContainsKey(profileName))
            {
                ToolStripMenuItem item = menuItems[profileName];

                ensureDirExists(getCheckedProfileName());
                ensureDirExists(profileName);

                safeCopyCurrentProfile();

                if ( makeProfileCurrent(profileName))
                {
                    uncheckAll();
                    item.Checked = true;
                    return true;
                } else
                {
                    throw new FileNotFoundException("Profile does not exists");
                }
            }
            return false;
        }

        private bool makeProfileCurrent(string profileName)
        {
            string destDir = Commons.GetCurrentDirectory() + @"\profile" + profileName;
            string[] files = Directory.GetFiles(destDir);
            if ( files.Length == 0 )
            {
                return false;
            }
            string currDir = Commons.GetCurrentDirectory();
            foreach (var filename in files)
            {
                string copyFile = Path.GetFileName(filename);
                File.Copy(filename.ToString(), currDir + @"\" + copyFile, true);
            }
            return true;
        }

        private void safeCopyCurrentProfile()
        {
            string sourceDir = Commons.GetCurrentDirectory() + @"\profile" + getCheckedProfileName();
            string[] files = Directory.GetFiles(Commons.GetCurrentDirectory());
            foreach (var filename in files)
            {
                string copyFile = Path.GetFileName(filename);
                if (copyFile.EndsWith(".obj") || copyFile.EndsWith(".cfg"))
                {
                    File.Copy(filename.ToString(), sourceDir + @"\" + copyFile, true);
                }
            }
        }

        private void ensureDirExists(string profile)
        {
            if (!Directory.Exists(Commons.GetCurrentDirectory() + @"\profile" + profile))
            {
                Directory.CreateDirectory(Commons.GetCurrentDirectory() + @"\profile" + profile);
            }
        }

        private string getCheckedProfileName()
        {
            foreach(KeyValuePair<string,ToolStripMenuItem> kvPair in menuItems)
            {
                ToolStripMenuItem item = kvPair.Value;
                if ( item.Checked )
                {
                    return item.Text;
                }
            }
            return "";
        }
    }
}
