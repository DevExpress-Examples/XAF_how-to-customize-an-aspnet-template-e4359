using System;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using System.Collections.Generic;
using System.ComponentModel;

namespace CustomizeTemplate.Module.BusinessObjects {
    [DefaultClassOptions]
    public class Contact {
        [Browsable(false)]
        public Int32 ID { get; protected set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }
}

