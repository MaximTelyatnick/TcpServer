using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packet
{
    public class Utils
    {

        public enum TypeCommand
        {
            Control,
            Inform

        };

        public enum ControlCommand
        {
            Start,
            Reload,
            Stop,
            Connected,
            Disconnected,
            Read,
            Write,
            Control
        }

        public enum Operation
        {
            Add,
            Update
        };

        public enum DeviceIndication
        {
            Connected,
            Loaded,
            Disabled,
            Offline
        };

        public enum GridName
        {
            Units,
            Measures,
            Contractors,
            Currency,
            Users,
            ZoneNames,
            StorageGroups,
            Persons,
            Profession,
            Alarms
        }

        public enum DeviceTypes
        {
            PLC,
            BarcodeScanner,
            Stacker,
            DropoffWindow,
            DB
        }

        public static Dictionary<string, string> dictUnits = new Dictionary<string, string>(2)
        {
            {"UnitLocalName","Обозначение"},
            {"UnitFullName","Наименование"}
        };

        public static Dictionary<string, string> dictUsers = new Dictionary<string, string>(3)
        {
            {"Fio","Пользователь"},
            {"Login","Логин"},
            {"RoleName", "Полномочия"}
        };

        public static Dictionary<string, string> dictMeasures = new Dictionary<string, string>(5)
        {
           {"PackingName","Наименование"},
           {"Height","Высота"},
           {"Width" ,"Ширина"},
           {"Length","Длина"},
           {"UnitWeight", "Значение(вес,шт...)"},
           {"UnitName","Ед.изм."}

        };

        public static Dictionary<string, string> dictContractors = new Dictionary<string, string>(4)
        {
           {"Name","Наименование"},
           {"ShortName","Краткое наименование"},
           {"Srn","Код по ЗКПО"},
           {"Tin" ,"Код ИНН"}
        };

        public static Dictionary<string, string> dictCurrency = new Dictionary<string, string>(2)
        {
            {"CurrencyCode","Код"},
            {"CurrencyName","Наименование"}

        };

        public static Dictionary<string, string> dictZoneNames = new Dictionary<string, string>(3)
        {
           {"ZoneName","Наименование"},
           {"ZoneColor","Цвет"},
           {"ZoneTypeName","Тип зоны"}
        };

        public static Dictionary<string, string> dictStorageGroups = new Dictionary<string, string>(2)
        {
            {"StorageGroupName","Наименование"},
            {"Description","Описание"}
        };

        public static Dictionary<string, string> dictPersons = new Dictionary<string, string>(2)
        {
            {"PersonName","ФИО"},
            {"ProfessionName","Профессия"}
        };

        public static Dictionary<string, string> dictProfession = new Dictionary<string, string>(1)
        {
            {"ProfessionName","Профессия"}
        };

        public static Dictionary<string, string> dictAlarms = new Dictionary<string, string>(2)
        {
            {"AlarmNumber","Код ошибки"},
            {"AlarmText","Текст сообщения"}
        };

        public class BarcodeCommandSourse
        {
            public int ComandNumber { get; set; }
            public string BarcodeText { get; set; }
            public string CommandText { get; set; }
        };

        public static Dictionary<int, string> dictBarcodeCommand = new Dictionary<int, string>(8)
        {
            {1,"CONFIRMQUANTITY"},
            {2,"CHANGECELL"},
            {3,"CLOSECELLFULL"},
            {4,"CLOSECELLWITHLOADUP"},
            {5,"CANCELOPERATION"},
            {6,"BREAKOPERATION"},
            {7,"CELLCLOSEAGAIN"},
            {8,"CELLOPENAGAIN"},
        };

        public enum ProcessComand
        {
            ConfirmQuantity,
            ChangeCell,
            CloseCellFull,
            CloseCellWithLoadUp,
            CancelOperation,
            BreakOperation,
            CellCloseAgain,
            CellOpenAgain,
            OpenCell,
            Error,
            None
        }

        public class ProcessInfo
        {
            public int CellNumber { get; set; }
            public string OperationName { get; set; }
            public int WindowNumber { get; set; }
            public string StackerName { get; set; }
        }

        public enum StatusWindow
        {
            WindowBusy,
            WindowNotBusy,
            WindowMissing
        }

        public enum StatusClient
        {
            Connect,
            Disconnect
        }
    }
}
