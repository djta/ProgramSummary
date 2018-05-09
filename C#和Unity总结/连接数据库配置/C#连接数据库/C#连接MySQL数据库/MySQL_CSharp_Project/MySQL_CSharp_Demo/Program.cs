﻿using MySQL_CSharp_Formwork;
using System;
using MySql.Data.MySqlClient;

namespace MySQL_CSharp_Demo
{
    class Program
    {
        static void Main(string[] args)
        {

            MySQLHelper.OpenDataBase("localhost",3306,"testbase","root","83117973bb");
            string tablename = "rr";
            string tablename2 = "pp";
            string column1Name = "type";
            string column1Type = FieldType.VarChar.ToString();
            string column2Name = "price";
            string column2Type = FieldType.Int.ToString();
            string column3Name = "color";
            string column3Type = FieldType.VarChar.ToString();
            string[] types = new string[] { column1Type, column2Type, column3Type };
            string[] name = new string[] { column1Name, column2Name, column3Name };
            string[] colLength = new[] {"255", "255", "2000"};
            string[] colState = new[] { FieldState.Null.ToString(), FieldState.Null.ToString(), FieldState.Null.ToString() };
            MySQLHelper.CreateTable(tablename, name, types, colLength,colState);
            MySQLHelper.CreateTable(tablename2, name, types, colLength, colState);
            // 增
            string[] str = new string[] { "二手奥拓", "1600", "red" };
            for (int i = 0; i < 5; i++)
            {
                str[1] = (Convert.ToInt32(str[1]) + i*500).ToString();
                MySQLHelper.InsertData(tablename, name, str);
            }

            // 改
            string[] ss = new string[] { column3Name };
            string[] gg = new string[] { "bule" };
            string[] key = new string[] { column2Name };
            string[] value = new string[] { "1600" };
            string[] operation = new string[] { "=" };
            MySQLHelper.UpdateDataOR(tablename, ss, gg, key, value, operation);

            // 查
            MySqlDataReader reader = MySQLHelper.SelectDataOR(tablename, key, ss, gg, operation);
            MySQLHelper.ShowData(reader);

            // 删
            MySQLHelper.DeleteDataOR(tablename, ss, gg, operation);
            // 查看整张表
            MySqlDataReader reader2 = MySQLHelper.ReadFullTable(tablename);
            MySQLHelper.ShowData(reader2);
            Console.ReadLine();
            // 关闭数据库
            MySQLHelper.CloseDataBase();
            Console.ReadLine();
        }
    }
}
