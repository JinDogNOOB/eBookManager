using System;

namespace eBookManager.Engine
{
    // 책클래스
    public class Document{
        public string title{get;set;}
        public string fileName {get; set;}
        public string extension {get;set;}
        public DateTime lastAccessed{get;set;}
        public DateTime created{get;set;}
        public string filePath{get;set;}
        public string fileSize{get;set;}
        public string ISBN{get;set;}
        public string price{get;set;}
        public string publisher{get;set;}
        public string author{get;set;}
        public DateTime publishDate{get;set;}
        public DeweyDecimal classification {get;set;}
        public string category {get;set;}

    }
}
