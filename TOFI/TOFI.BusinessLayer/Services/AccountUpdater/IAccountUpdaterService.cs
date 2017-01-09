using System;
using BLL.Result;

namespace BLL.Services.AccountUpdater
{
    public interface IAccountUpdaterService : IService
    {
        ServiceResult UpdateAccounts(DateTime specifiedDate);
    }
}