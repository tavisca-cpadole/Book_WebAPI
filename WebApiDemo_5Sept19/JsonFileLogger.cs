using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace WebApiDemo_5Sept19
{
    public class JsonFileLogger : ILog
    {
        public void WriteLog(Log log)
        {
            string path = "./Log/Log.json";
            string json = File.ReadAllText(path);
            List<Log> logs = JsonConvert.DeserializeObject<List<Log>>(json);
            logs.Add(log);
            string newJson = JsonConvert.SerializeObject(logs);
            File.WriteAllText(path, newJson);
        }
    }


}
