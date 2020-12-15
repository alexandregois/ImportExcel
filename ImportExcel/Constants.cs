using System;
using System.Collections.Generic;
using System.Text;

namespace ImportExcel.Service
{
    internal class Constants
    {
        internal const string HostAddress = "208.115.211.92";
        internal const string DataBase = "importexcel";

        internal const string UserDataBase = "alexandre";
        internal const string UserPassDataBase = "win@@002";

        internal const string Conexao = @"data source=" + HostAddress + ";initial catalog="
                + DataBase + ";user id=" + UserDataBase
                + ";password=" + UserPassDataBase + ";Connect Timeout=60";

    }
}
