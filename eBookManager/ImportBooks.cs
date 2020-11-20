using System;
using eBookManager.Engine;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static eBookManager.Helper.ExtensionMethods;
using static System.Math;


using System.ComponentModel;


namespace eBookManager
{
    public class ImportBooks : Form
    {
        private string _jsonPath;
        private List<StorageSpace> spaces;
        private enum StorageSpaceSelection {New = -9999, NoSelection = -1}

        // cs7 expression bodied property
        private HashSet<string> AllowedExtensions => new HashSet<string>(StringComparer.InvariantCultureIgnoreCase) {".doc", ".docx", ".pdf", ".epub"};
        private enum Extension {doc=0, docx=1, pdf=2, epub=3};

        public ImportBooks()
        {
            
            InitializeComponent(); // ㅎㅎ..
            
            _jsonPath = Path.Combine(Application.StartupPath, "bookData.txt");
            spaces = spaces.ReadFromDataStore(_jsonPath);
        }

        // TreeView 컨트롤에 선택한 위치의 파일과 폴더로 채운다
        public void PopulateBookList(string paramDir, TreeNode paramNode){
            DirectoryInfo dir = new DirectoryInfo(paramDir);

            foreach(DirectoryInfo dirInfo in dir.GetDirectories()){
                TreeNode node = new TreeNode(dirInfo.Name);
                node.ImageIndex = 4;
                node.SelectedImageIndex = 5;

                if(paramNode != null)
                    paramNode.Nodes.Add(node);
                else
                    tvFoundBooks.Nodes.Add(node);
                // 파고판다 판다!!
                PopulateBookList(dirInfo.FullName, node);
            }

            foreach(FileInfo fileInfo in dir.GetFiles().Where(x => AllowedExtensions.Contains(x.Extension)).ToList()){
                TreeNode node = new TreeNode(fileInfo.Name);
                node.Tag = fileInfo.FullName;
                int iconIndex = Enum.Parse(typeof(Extension), fileInfo.Extension.TrimStart('.'), true).GetHashCode();
                node.ImageIndex = iconIndex;
                node.SelectedImageIndex = iconIndex;

                if(paramNode != null)
                    paramNode.Nodes.Add(node);
                else
                    tvFoundBooks.Nodes.Add(node);
            }
        }











    }
}
