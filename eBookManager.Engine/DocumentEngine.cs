using System;
using System.IO;

namespace eBookManager.Engine
{
    public class DocumentEngine{
        // 문서를 지원하는 간단한 기능을 제공하는 게 목적인 클래스
        

        // 하나이상의 반환값을 반환하는 방법에는
        // out 또는 cs7에서는 다음과 같은 tuple
        public (DateTime dateCreated, DateTime dateLastAccessed, string fileName, string fileExtension, long fileLength, bool error) GetFileProperties(string filePath){
            var returnTuple = (
                created: DateTime.MinValue, 
                lastDateAccessed: DateTime.MinValue,
                name: "",
                ext: "",
                fileSize : 0L,
                error : false
            );

            try{
                FileInfo fi = new FileInfo(filePath);
                fi.Refresh();
                returnTuple = (fi.CreationTime, fi.LastAccessTime, fi.Name, fi.Extension, fi.Length, false);
            }catch{
                returnTuple.error = true;
            }
            return returnTuple;
        }

    }

}