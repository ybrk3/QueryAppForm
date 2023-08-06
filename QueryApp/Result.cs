using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryApp
{
    public class Result
    {

        public Result()
        {

        }
        public ProcessState ProcessState { get; set; }
        public string Message { get; set; }
        public int Progress { get; set; }
    }
    public enum ProcessState
    {
        None = 0,
        Active = 1,
        Success = 2,
        Failed = 3
    }
    public static class ProcessMessages
    {
        internal static string QueryInactive = "Şuan da işlem bulunmamaktadır.";
        internal static string QueryActive = "İşlem devam ediyor.";
        internal static string QuerySucceeded = "İşlem başarıyla tamamlandı.";
        internal static string QueryFailed = "İşlem başarız oldu";
    }
}
