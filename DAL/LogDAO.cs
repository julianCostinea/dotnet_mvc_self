using System;
using System.Web;
using DTO;

namespace DAL
{
    public class LogDAO
    {
        public static void AddLog(int processType, string tableName, int processId, SessionDTO session)
        {
            using (POSTDATASELFEntities db = new POSTDATASELFEntities())
            {
                Log_Table log = new Log_Table();
                log.UserID = session.UserID;
                log.ProcessType = processType;
                log.ProcessID = processId;
                log.ProcessCategoryType = tableName;
                log.ProcessDate = DateTime.Now;
                log.IPAddress = HttpContext.Current.Request.UserHostAddress;
                db.Log_Table.Add(log);
                db.SaveChanges();
            }
        }
    }
}