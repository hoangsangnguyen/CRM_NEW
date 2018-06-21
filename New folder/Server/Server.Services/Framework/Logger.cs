using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using Falcon.Web.Core.Log;
using Vino.Server.Data.Framework;
using Vino.Server.Services.Database;

namespace Vino.Server.Services.Framework
{
    public class Logger : ILogger
    {
        private void InsertLog(LogLevel level, string shortMessage, string fullMessage, string context)
        {
            //fire and forget
            Task.Run(() =>
            {
                using (var db = new DataContext())
                {
                    db.Logs.Add(new Log()
                    {
                        LogLevel = level,
                        Context = context,
                        CreatedAt = DateTime.Now,
                        FullMessage = fullMessage,
                        ShortMessage = shortMessage
                    });
                    db.SaveChanges();
                }
            });
        }
        public void Debug(string shortMessage, string fullMessage = "", string context = "")
        {
            InsertLog(LogLevel.Debug, shortMessage, fullMessage, context);
        }

        public void Info(string shortMessage, string fullMessage = "", string context = "")
        {
            InsertLog(LogLevel.Information, shortMessage, fullMessage, context);
        }

        public void Warning(string shortMessage, string fullMessage = "", string context = "")
        {
            InsertLog(LogLevel.Information, shortMessage, fullMessage, context);
        }

        public void Error(string shortMessage, string fullMessage = "", string context = "")
        {
            InsertLog(LogLevel.Error, shortMessage, fullMessage, context);
        }

        public void Fatal(string shortMessage, string fullMessage = "", string context = "")
        {
            InsertLog(LogLevel.Fatal, shortMessage, fullMessage, context);
        }
    }
}