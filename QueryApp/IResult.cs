using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryApp
{

    public interface IResult
    {
        ProcessState ProcessState { get; }
        string Message { get; }
        float Progress { get; }
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
