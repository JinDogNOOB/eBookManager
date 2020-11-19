using System;
using System.Collections.Generic;
// List<> 사용하기 때문에 Generic 네임스페이스 추가해야한다

namespace eBookManager.Engine
{
    [Serializable]
    public class StorageSpace{
        public int id {get; set;}
        public string name {get; set;}
        public string description{get;set;}
        public List<Document> bookList {get;set;}

    }

}