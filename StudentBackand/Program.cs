using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;
using System.Linq;
using System.Reflection;
using System.Collections;

namespace StudentBackand
{
     class Program
    {
        
        public static void CheakIf(string qery)
        {
            //to cheak it .
            Data data = new Data();
            data.Users = new List<User> { new User() { fullName = "a", email = "jobs@ravend.net", age = 60 } };
          
            string list = qery.Split()[1];
            string condition = qery.Split("where")[1].Split("select")[0].Replace("'", "\"");
            string select = "new(" + qery.Split("select")[1] + ")";

            FieldInfo fieldInfo = data.GetType().GetField("Users");

            if (typeof(IList).IsAssignableFrom(fieldInfo.FieldType))
            {
                Type type = fieldInfo.FieldType;
                Type itemType = type.GetGenericArguments()[0];
                var listType = typeof(List<>);
                var constructedListType = listType.MakeGenericType(itemType);

                var instance = Activator.CreateInstance(constructedListType);
                instance = fieldInfo.GetValue(data);
                var sel = (instance as IList).AsQueryable().Where(condition).Select(select).ToDynamicArray();

                foreach (var i in sel)
                {    
                    Console.WriteLine(i);
                }

                if (sel.Count() != 1)
                    Console.WriteLine("no macth");

                Console.ReadLine();

            }


        }


        static void Main(string[] args)
        {  
            
           
             string str = "	from Users where(FullName = 'foo' or FullName = 'bar') and Age < 99 select FullName, Email";
             CheakIf(str);
         
        }
    }

    public class Data
    {
        public List<User> Users;
        public List<Order> Orders;
        // etc וכו'
    }

}

