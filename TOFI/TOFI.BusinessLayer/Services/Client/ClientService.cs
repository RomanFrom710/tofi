﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Result;
using BLL.Services.Client.ViewModels;
using BLL.Services.Credits.CreditAccount.ViewModels;
using BLL.Services.Model;
using DAL.Repositories.Client;
using TOFI.TransferObjects.Client.DataObjects;
using TOFI.TransferObjects.Client.Queries;
using TOFI.TransferObjects.Credits.CreditAccount.DataObjects;

namespace BLL.Services.Client
{
    public class ClientService : ModelService<ClientDto, ClientViewModel>, IClientService
    {
        private readonly IClientQueryRepository _queryRepository;
        private readonly IClientCommandRepository _commandRepository;


        public ClientService(IClientQueryRepository queryRepository, IClientCommandRepository commandRepository)
            : base(queryRepository, commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }


        public QueryResult<ClientDto> GetClientDto(ClientQuery query)
        {
            return RunQuery<ClientQuery, ClientDto>(_queryRepository, query);
        }

        public async Task<QueryResult<ClientDto>> GetClientDtoAsync(ClientQuery query)
        {
            return await RunQueryAsync<ClientQuery, ClientDto>(_queryRepository, query);
        }

        public QueryResult<ClientViewModel> GetClient(ClientQuery query)
        {
            return RunQuery<ClientQuery, ClientDto>(_queryRepository, query).MapTo<ClientViewModel>();
        }

        public async Task<QueryResult<ClientViewModel>> GetClientAsync(ClientQuery query)
        {
            return (await RunQueryAsync<ClientQuery, ClientDto>(_queryRepository, query)).MapTo<ClientViewModel>();
        }


        public CommandResult AddOrUpdateClient(ClientViewModel client)
        {
            var clientRes = GetClientDto(ClientQuery.WithUserId(client.User.Id));
            if (clientRes.IsFailed)
            {
                return new CommandResult(null, false).From(clientRes);
            }
            return clientRes.Value == null ? CreateModel(client) : UpdateModel(client);
        }

        public async Task<CommandResult> AddOrUpdateClientAsync(ClientViewModel client)
        {
            var clientRes = await GetClientDtoAsync(ClientQuery.WithUserId(client.User.Id));
            if (clientRes.IsFailed)
            {
                return new CommandResult(null, false).From(clientRes);
            }
            return await (clientRes.Value == null ? CreateModelAsync(client) : UpdateModelAsync(client));
        }


        public ValueResult<bool> CanAddCreditRequest(int userId)
        {
            var clientRes = GetClient(ClientQuery.WithUserId(userId));
            if (clientRes.IsFailed)
            {
                return new ValueResult<bool>(false, false).From(clientRes);
            }
            var validationRes = ValidateClientInfo(clientRes.Value);
            if (validationRes.IsFailed)
            {
                return new ValueResult<bool>(false, false).From(validationRes);
            }
            return new ValueResult<bool>(ValidateClientInfo(clientRes.Value).Value.Count == 0, true);
        }

        public ValueResult<List<KeyValuePair<string, string>>> ValidateClientInfo(ClientViewModel client)
        {
            try
            {
                return new ValueResult<List<KeyValuePair<string, string>>>(ValidateClientInner(client), true);
            }
            catch (Exception ex)
            {
                return new ValueResult<List<KeyValuePair<string, string>>>(new List<KeyValuePair<string, string>>(),
                    false).Fatal($"Unhandled exception: {ex.Message}", ex);
            }
        }


        private List<KeyValuePair<string, string>> ValidateClientInner(ClientViewModel client)
        {
            var res = new List<KeyValuePair<string, string>>();
            if (client == null)
            {
                res.Add(new KeyValuePair<string, string>("", "Информация о клиенте не заполнена"));
                return res;
            }
            if (client.Birthday.HasValue)
            {
                var age = (int) Math.Floor((DateTime.Now.Date - client.Birthday.Value.Date).TotalDays/365);
                if (age < 18)
                    res.Add(new KeyValuePair<string, string>(nameof(client.Birthday), "Вы слишком молоды для получения кредитов"));
                if (age > 122)
                    res.Add(new KeyValuePair<string, string>(nameof(client.Birthday),
                        "Рекорд долгожительства составляет 122 года, что ставит под сомнение корректность введенных данных"));
            }
            if (DateTime.Now.Date < client.IssueDate)
                res.Add(new KeyValuePair<string, string>(nameof(client.IssueDate),
                    "Ваш паспорт из будущего. Извините, но мы не можем принять его"));
            if (DateTime.Now.Date > client.ExpirationDate)
                res.Add(new KeyValuePair<string, string>(nameof(client.ExpirationDate),
                    "Ваш паспорт недействителен. Сначала получите новый"));
            return res;
        }

        public ListQueryResult<CreditAccountDto> GetClientAccountsDto(ClientAccountsQuery query)
        {
            return RunListQuery<ClientAccountsQuery, CreditAccountDto>(_queryRepository, query);
        }

        public async Task<ListQueryResult<CreditAccountDto>> GetClientAccountsDtoAsync(ClientAccountsQuery query)
        {
            return await RunListQueryAsync<ClientAccountsQuery, CreditAccountDto>(_queryRepository, query);
        }

        public ListQueryResult<CreditAccountViewModel> GetClientAccounts(ClientAccountsQuery query)
        {
            return RunListQuery<ClientAccountsQuery, CreditAccountDto>(_queryRepository, query).MapTo<CreditAccountViewModel>();
        }

        public async Task<ListQueryResult<CreditAccountViewModel>> GetClientAccountsAsync(ClientAccountsQuery query)
        {
            return (await RunListQueryAsync<ClientAccountsQuery, CreditAccountDto>(_queryRepository, query)).MapTo<CreditAccountViewModel>();
        }
    }
}