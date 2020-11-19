using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;


namespace eBookManager.Helper
{
    public static class ExtensionMethods
    {
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
            JsonSerializer json = new JsonSerializer();
            


        }








    }
}
