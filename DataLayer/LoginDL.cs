﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    public class LoginDL:DataProvider
    {
        public bool Login(Account account)
        {
            string sql = "SELECT COUNT(UserName) FROM Users WHERE Username = '" + account.Username + "' AND Password = '" + account.Password + "'";
            try
            {
            return ((int)MyExecuteScalar(sql, CommandType.Text) > 0);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
