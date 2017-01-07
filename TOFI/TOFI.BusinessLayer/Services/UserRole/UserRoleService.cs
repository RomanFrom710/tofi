using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Services.Client;
using BLL.Services.Employee;
using BLL.Services.User;
using TOFI.TransferObjects.Client.Queries;
using TOFI.TransferObjects.Employee.DataObjects;
using TOFI.TransferObjects.Employee.Queries;
using TOFI.TransferObjects.User.Queries;

namespace BLL.Services.UserRole
{
    public class UserRoleService : Service, IUserRoleService
    {
        public const string Client = "client";
        public const string Employee = "employee";
        public const string Cashier = "cashier";
        public const string Operator = "operator";
        public const string SecurityOfficer = "security";
        public const string CreditCommitteeMember = "committee member";
        public const string CreditDepartmentChief = "department chief";
        public const string Admin = "admin";
        public const string Superuser = "superuser";


        public static readonly string[] All = {Client, Employee, Admin};

        public static readonly Dictionary<EmployeeRights, string> RightsToRoles =
            new Dictionary<EmployeeRights, string>
            {
                {EmployeeRights.Cashier, Cashier},
                {EmployeeRights.Operator, Operator},
                {EmployeeRights.SecurityOfficer, SecurityOfficer},
                {EmployeeRights.CreditCommitteeMember, CreditCommitteeMember},
                {EmployeeRights.CreditDepartmentChief, CreditDepartmentChief},
                {EmployeeRights.Admin, Admin},
                {EmployeeRights.Superuser, Superuser}
            };

        public static readonly Dictionary<string, EmployeeRights> RolesToRights =
            new Dictionary<string, EmployeeRights>
            {
                {Cashier, EmployeeRights.Cashier},
                {Operator, EmployeeRights.Operator},
                {SecurityOfficer, EmployeeRights.SecurityOfficer},
                {CreditCommitteeMember, EmployeeRights.CreditCommitteeMember},
                {CreditDepartmentChief, EmployeeRights.CreditDepartmentChief},
                {Admin, EmployeeRights.Admin},
                {Superuser, EmployeeRights.Superuser}
            };


        private readonly IUserService _userService;
        private readonly IClientService _clientService;
        private readonly IEmployeeService _employeeService;


        public UserRoleService(IUserService userService, IClientService clientService,
            IEmployeeService employeeService)
        {
            _userService = userService;
            _clientService = clientService;
            _employeeService = employeeService;
        }


        public async Task<IList<string>> GetRoles(int userId)
        {
            var client = (await _clientService.GetClientDtoAsync(ClientQuery.WithUserId(userId))).Value;
            var employee = (await _employeeService.GetEmployeeDtoAsync(EmployeeQuery.WithUserId(userId))).Value;
            var res = new List<string>();
            if (client != null)
            {
                res.Add(Client);
            }
            if (employee != null)
            {
                res.Add(Employee);
                foreach (var key in RightsToRoles.Keys)
                {
                    if (employee.Rights.HasFlag(key))
                    {
                        res.Add(RightsToRoles[key]);
                    }
                }
            }
            return res;
        }

        public async Task<bool> IsInRole(int userId, string role)
        {
            var client = (await _clientService.GetClientDtoAsync(ClientQuery.WithUserId(userId))).Value;
            var employee = (await _employeeService.GetEmployeeDtoAsync(EmployeeQuery.WithUserId(userId))).Value;
            switch (role)
            {
                case Client:
                    return client != null;
                case Employee:
                    return employee != null;
                default:
                    return employee != null && RolesToRights.ContainsKey(role) &&
                           employee.Rights.HasFlag(RolesToRights[role]);
            }
        }

        public async Task AddToRole(int userId, string role)
        {
            var user = (await _userService.GetUserDtoAsync(UserQuery.WithId(userId))).Value;
            if (user == null)
                return;
            var employee = (await _employeeService.GetEmployeeDtoAsync(EmployeeQuery.WithUserId(userId))).Value;
            switch (role)
            {
                case Client:
                    throw new NotSupportedException();
                case Employee:
                    if (employee == null)
                    {
                        employee = new EmployeeDto {Rights = EmployeeRights.None, User = user};
                        await _employeeService.CreateModelAsync(employee);
                    }
                    break;
                default:
                    if (RolesToRights.ContainsKey(role))
                    {
                        if (employee == null)
                        {
                            employee = new EmployeeDto {Rights = EmployeeRights.None, User = user};
                            employee.Rights = employee.Rights | RolesToRights[role];
                            await _employeeService.CreateModelAsync(employee);
                        }
                        else
                        {
                            employee.Rights = employee.Rights | RolesToRights[role];
                            await _employeeService.UpdateModelAsync(employee);
                        }
                    }
                    break;
            }
        }

        public async Task RemoveFromRole(int userId, string role)
        {
            var employee = (await _employeeService.GetEmployeeDtoAsync(EmployeeQuery.WithUserId(userId))).Value;
            switch (role)
            {
                case Client:
                    throw new NotSupportedException();
                case Employee:
                    if (employee != null)
                    {
                        await _employeeService.DeleteModelAsync(employee.Id);
                    }
                    break;
                default:
                    if (employee != null && RolesToRights.ContainsKey(role) &&
                        employee.Rights.HasFlag(RolesToRights[role]))
                    {
                        employee.Rights = employee.Rights ^ RolesToRights[role];
                        await _employeeService.UpdateModelAsync(employee);
                    }
                    break;
            }
        }
    }
}