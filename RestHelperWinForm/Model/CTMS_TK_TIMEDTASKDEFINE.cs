//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace KMHC.CTMS.DAL.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class CTMS_TK_TIMEDTASKDEFINE
    {
        public string TIMEDTASKDEFINEID { get; set; }
        public string TRIGGERTYPE { get; set; }
        public Nullable<decimal> TIMEDTYPE { get; set; }
        public Nullable<decimal> HOWLONGDAY { get; set; }
        public Nullable<decimal> DAYORWORKDAY { get; set; }
        public Nullable<decimal> HOWLONGWEEKS { get; set; }
        public Nullable<decimal> DAYOFWEEK { get; set; }
        public Nullable<decimal> HOWLONGMONTH { get; set; }
        public Nullable<decimal> HOWLONGMONTHDAY { get; set; }
        public Nullable<decimal> HOWLONGMONTHWEEK { get; set; }
        public Nullable<decimal> HOWLONGMONTHWEEKDAY { get; set; }
        public Nullable<decimal> HOWLONGYEARMONTH { get; set; }
        public Nullable<decimal> HOWLONGYEARDAY { get; set; }
        public Nullable<decimal> HOWLONGYEARWEEK { get; set; }
        public Nullable<decimal> HOWLONGYEARWEEKDAY { get; set; }
        public System.DateTime STARTDATE { get; set; }
        public string STARTTIME { get; set; }
        public Nullable<decimal> NEVEREXPIRE { get; set; }
        public System.DateTime ENDDATE { get; set; }
        public string ENDTIME { get; set; }
        public string RECEIVEUSER { get; set; }
        public string RECEIVEROLE { get; set; }
        public string MESSAGEBODY { get; set; }
        public string MODELCODE { get; set; }
        public string MSGLINKURL { get; set; }
        public string PROCESSWCFURL { get; set; }
        public string PROCESSFUNCNAME { get; set; }
        public string PROCESSFUNCPAMETER { get; set; }
        public string DATASTATUS { get; set; }
        public Nullable<System.DateTime> CREATEDATE { get; set; }
        public string CREATETIME { get; set; }
        public Nullable<System.DateTime> UPDATEDATE { get; set; }
        public string UPDATETIME { get; set; }
        public string FUNCTIONMARK { get; set; }
        public string APPLYID { get; set; }
        public bool ISDELETED { get; set; }
    }
}
