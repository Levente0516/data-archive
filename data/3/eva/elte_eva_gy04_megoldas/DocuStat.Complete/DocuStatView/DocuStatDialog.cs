using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ELTE.DocuStat.Model;
using ELTE.DocuStat.Persistence;

namespace ELTE.DocuStat.View
{
    public partial class DocuStatDialog : Form
    {
      

        public DocuStatDialog()
        {
            InitializeComponent();

            openFileDialogMenuItem.Click += OpenDialog;

            countWordsMenuItem.Click += CountWords;
        }

        private void CountWords(object? sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == null)
            {
                MessageBox.Show("No selected tab!");
                return;
            }

            (tabControl1.SelectedTab.Controls[0] as DocuStatControl)!.CountWords(sender, e);
        }

        private void OpenDialog(object? sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Filter = "Text files (*.txt)|*.txt|PDF files (*.pdf)|*.pdf";
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    tabControl1.TabPages.Clear();
                    foreach (var fileName in openFileDialog.FileName)
                    {

                        AddTabPage(fileName);
                    }

                    IFileManager? fileManager = FileManagerFactory.CreateForPath(openFileDialog.FileName);

                    if (fileManager == null)
                    {
                        MessageBox.Show("File reading is unsuccessful!\nUnsupported file format.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    
                    try
                    {
                        
                    }
                    catch (FileManagerException ex)
                    {
                        MessageBox.Show("File reading is unsuccessful!\n" + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private async Task AddTabPage(string fileName)
        {
            IFileManager? fileManager = FileManagerFactory.CreateForPath(fileName);

            if (fileManager == null)
            {
                MessageBox.Show("File reading is unsuccessful!\nUnsupported file format.",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                DocuStatControl control = new DocuStatControl();
                control.LoadFile(fileManager);
                TabPage tabPage = new TabPage(System.IO.Path.GetFileName(fileName));
                tabPage.Controls.Add(control);
                tabControl1.TabPages.Add(tabPage);
            }

            catch (FileManagerException ex)
            {
                return;
            }
        }
    }
}