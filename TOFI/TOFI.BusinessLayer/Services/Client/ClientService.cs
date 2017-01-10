using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Result;
using BLL.Services.Client.ViewModels;
using BLL.Services.Credits.BankCredits.CreditTypes;
using BLL.Services.Credits.BankCredits.CreditTypes.ViewModels;
using BLL.Services.Credits.CreditAccount.ViewModels;
using BLL.Services.Model;
using DAL.Repositories.Client;
using TOFI.TransferObjects.Client.DataObjects;
using TOFI.TransferObjects.Client.Queries;
using TOFI.TransferObjects.Credits.BankCredits.CreditTypes.DataObjects;
using TOFI.TransferObjects.Credits.CreditAccount.DataObjects;
using TOFI.TransferObjects.Model.Queries;

namespace BLL.Services.Client
{
    public class ClientService : ModelService<ClientDto, ClientViewModel>, IClientService
    {
        private readonly IClientQueryRepository _queryRepository;
        private readonly IClientCommandRepository _commandRepository;
        private readonly ICreditTypeService _creditTypeService;


        public ClientService(IClientQueryRepository queryRepository, IClientCommandRepository commandRepository,
            ICreditTypeService creditTypeService) : base(queryRepository, commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
            _creditTypeService = creditTypeService;
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

        public ListQueryResult<CreditTypeDto> GetCreditTypesDto(SelectCreditTypesQuery query)
        {
            var creditsRes = _creditTypeService.GetAllModelDtos(new AllModelsQuery());
            if (creditsRes.IsFailed)
            {
                return new ListQueryResult<CreditTypeDto>(query, Enumerable.Empty<CreditTypeDto>(), false).From(creditsRes);
            }
            var credits = creditsRes.Value.Where(c =>
            {
                foreach (var condition in c.CreditConditions)
                {
                    if (condition.MonthDurationFrom > query.MonthDuration ||
                        query.MonthDuration > condition.MonthDurationTo)
                        continue;
                    if (condition.MinCreditSum.Currency.Id != query.CreditSumCurrencyId)
                        continue;
                    if (condition.MinCreditSum.Value > query.CreditSumValue ||
                        query.CreditSumValue > condition.MaxCreditSum.Value)
                        continue;
                    return true;
                }
                return false;
            });
            return new ListQueryResult<CreditTypeDto>(query, credits, true);
        }

        public async Task<ListQueryResult<CreditTypeDto>> GetCreditTypesDtoAsync(SelectCreditTypesQuery query)
        {
            var creditsRes = await _creditTypeService.GetAllModelDtosAsync(new AllModelsQuery());
            if (creditsRes.IsFailed)
            {
                return new ListQueryResult<CreditTypeDto>(query, Enumerable.Empty<CreditTypeDto>(), false).From(creditsRes);
            }
            var credits = creditsRes.Value.Where(c =>
            {
                foreach (var condition in c.CreditConditions)
                {
                    if (condition.MonthDurationFrom > query.MonthDuration ||
                        query.MonthDuration > condition.MonthDurationTo)
                        continue;
                    if (condition.MinCreditSum.Currency.Id != query.CreditSumCurrencyId)
                        continue;
                    if (condition.MinCreditSum.Value > query.CreditSumValue ||
                        query.CreditSumValue > condition.MaxCreditSum.Value)
                        continue;
                    return true;
                }
                return false;
            });
            return new ListQueryResult<CreditTypeDto>(query, credits, true);
        }

        public ListQueryResult<CreditTypeViewModel> GetCreditTypes(SelectCreditTypesQuery query)
        {
            var creditsRes = _creditTypeService.GetAllModels(new AllModelsQuery());
            if (creditsRes.IsFailed)
            {
                return new ListQueryResult<CreditTypeViewModel>(query, Enumerable.Empty<CreditTypeViewModel>(), false).From(creditsRes);
            }
            var credits = creditsRes.Value.Where(c =>
            {
                foreach (var condition in c.CreditConditions)
                {
                    if (condition.MonthDurationFrom > query.MonthDuration ||
                        query.MonthDuration > condition.MonthDurationTo)
                        continue;
                    if (condition.MinCreditSum.Currency.Id != query.CreditSumCurrencyId)
                        continue;
                    if (condition.MinCreditSum.Value > query.CreditSumValue ||
                        query.CreditSumValue > condition.MaxCreditSum.Value)
                        continue;
                    var minMonthPayment = _creditTypeService.MinMonthPayment(query, c);
                    if (query.SumReadyToPay < minMonthPayment)
                        continue;
                    return true;
                }
                return false;
            });
            return new ListQueryResult<CreditTypeViewModel>(query, credits, true);
        }

        public async Task<ListQueryResult<CreditTypeViewModel>> GetCreditTypesAsync(SelectCreditTypesQuery query)
        {
            var creditsRes = await _creditTypeService.GetAllModelsAsync(new AllModelsQuery());
            if (creditsRes.IsFailed)
            {
                return new ListQueryResult<CreditTypeViewModel>(query, Enumerable.Empty<CreditTypeViewModel>(), false).From(creditsRes);
            }
            var credits = creditsRes.Value.Where(c =>
            {
                foreach (var condition in c.CreditConditions)
                {
                    if (condition.MonthDurationFrom > query.MonthDuration ||
                        query.MonthDuration > condition.MonthDurationTo)
                        continue;
                    if (condition.MinCreditSum.Currency.Id != query.CreditSumCurrencyId)
                        continue;
                    if (condition.MinCreditSum.Value > query.CreditSumValue ||
                        query.CreditSumValue > condition.MaxCreditSum.Value)
                        continue;
                    var minMonthPayment = _creditTypeService.MinMonthPayment(query, c);
                    if (query.SumReadyToPay < minMonthPayment)
                        continue;
                    return true;
                }
                return false;
            });
            return new ListQueryResult<CreditTypeViewModel>(query, credits, true);
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
            return new ValueResult<bool>(ValidateClientInfo(clientRes.Value).Value.Count == 0 &&
                                         clientRes.Value.User.EmailConfirmed, true);
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
    }
}