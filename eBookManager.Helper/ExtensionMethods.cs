using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.IO;


namespace eBookManager.Helper
{
    public static class ExtensionMethods
    {
        // Extension 메쏘드들을 모아놓은 곳!
        public static int ToInt(this string value, int defaultInteger = 0){
            try{
                if(int.TryParse(value, out int validInteger)) // out 변수
                    return validInteger;
                else
                    return defaultInteger;
            }catch{
                return defaultInteger;
            }
        }

        public static double ToMegabytes(this long bytes){
            return (bytes > 0) ? (bytes/1024f) / 1024f : bytes;
        }

        public static bool StorageSpaceExists(this List<Engine.StorageSpace> space, string nameValueToCheck, out int storageSpaceId){
            bool exists = false;
            storageSpaceId = 0;
            
            if(space.Count != 0){
                int count = (from s in space where s.name.Equals(nameValueToCheck) select s).Count();

                if(count > 0)
                    exists = true;

                storageSpaceId = (from s in space select s.id).Max() + 1;
            }
            return exists;
        }

        public static void WriteToDataStore(this List<Engine.StorageSpace> value, string storagePath, bool appendToExistingFile = false){
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            using (StreamWriter sw = new StreamWriter(storagePath, appendToExistingFile)){
                using(JsonWriter writer = new JsonTextWriter(sw)){
                    // JsonWriter는 패치되서 추상클래스로 바뀌었나보다
                    // 하위에 bsonWriter랑 JsonTextWriter 있길래 후자 사용
                    serializer.Serialize(writer, value);
                }
            }
            return;
        }

        public static List<Engine.StorageSpace> ReadFromDataStore(this List<Engine.StorageSpace> value, string storagePath){
            JsonSerializer serializer = new JsonSerializer();
            if(!File.Exists(storagePath)){
                // 파일 없으면 새로 생성
                FileStream newFile = File.Create(storagePath);
                newFile.Close();
            }
            
            using (StreamReader sr = new StreamReader(storagePath)){
                using(JsonReader reader = new JsonTextReader(sr)){
                    List<Engine.StorageSpace> retVal = serializer.Deserialize<List<Engine.StorageSpace>>(reader);
                    if(retVal is null)
                        retVal = new List<Engine.StorageSpace>();
                    return retVal;
                }
            }
        }






    }
}
