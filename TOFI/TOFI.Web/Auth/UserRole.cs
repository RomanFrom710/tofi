﻿using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using TOFI.TransferObjects.Employee.DataObjects;

namespace TOFI.Web.Auth
{
    public class UserRole : IRole
    {
        public string Id => Name;

        public string Name { get; set; }
    }


    public static class UserRoles
    {
        public const string Client = "client";
        public const string Employee = "employee";
        public const string Admin = "admin";


        public static readonly string[] All = {Client, Employee, Admin};

        public static readonly Dictionary<EmployeeRights, string> RightsToRoles =
            new Dictionary<EmployeeRights, string> {{EmployeeRights.Admin, Admin}};

        public static readonly Dictionary<string, EmployeeRights> RolesToRights =
            new Dictionary<string, EmployeeRights> {{Admin, EmployeeRights.Admin}};


        public static IList<string> GetRoles(AuthUser user)
        {
            var res = new List<string>();
            if (user?.Dto?.Client != null)
            {
                res.Add(Client);
            }
            if (user?.Dto?.Employee != null)
            {
                res.Add(Employee);
                foreach (var key in RightsToRoles.Keys)
                {
                    if (user.Dto.Employee.Rights.HasFlag(key))
                    {
                        res.Add(RightsToRoles[key]);
                    }
                }
            }
            return res;
        }

        public static bool IsInRole(AuthUser user, string role)
        {
            switch (role)
            {
                case Client:
                    return user?.Dto?.Client != null;
                case Employee:
                    return user?.Dto?.Employee != null;
                default:
                    return user?.Dto?.Employee != null && RolesToRights.ContainsKey(role) &&
                           user.Dto.Employee.Rights.HasFlag(RolesToRights[role]);
            }
        }

        public static void AddToRole(AuthUser user, string role)
        {
            switch (role)
            {
                case Client:
                    throw new NotSupportedException();
                case Employee:
                    if (user?.Dto != null && user.Dto.Employee == null)
                    {
                        user.Dto.Employee = new EmployeeDto {Rights = EmployeeRights.None};
                    }
                    break;
                default:
                    if (user?.Dto != null && RolesToRights.ContainsKey(role))
                    {
                        if (user.Dto.Employee == null)
                        {
                            user.Dto.Employee = new EmployeeDto {Rights = EmployeeRights.None};
                        }
                        user.Dto.Employee.Rights = user.Dto.Employee.Rights | RolesToRights[role];
                    }
                    break;
            }
        }

        public static void RemoveFromRole(AuthUser user, string role)
        {
            switch (role)
            {
                case Client:
                    throw new NotSupportedException();
                case Employee:
                    if (user?.Dto?.Employee != null)
                    {
                        user.Dto.Employee = null;
                    }
                    break;
                default:
                    if (user?.Dto?.Employee != null && RolesToRights.ContainsKey(role) &&
                        user.Dto.Employee.Rights.HasFlag(RolesToRights[role]))
                    {
                        user.Dto.Employee.Rights = user.Dto.Employee.Rights ^ RolesToRights[role];
                    }
                    break;
            }
        }
    }
}