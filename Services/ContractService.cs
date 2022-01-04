using dotnet_webapi.Models;

namespace dotnet_webapi.Services;

public static class ContractService
{
    static List<Contract> Contracts { get; }
    static int nextId = 4;
    static ContractService()
    {
        Contracts = new List<Contract>
        {
            new Contract {
                ContractId = 1,
                SenderName = "Parth",
                RecipientName = "Chris",
                Amount = 100.0,
                IsActive = true
            },
            new Contract {
                ContractId = 2,
                SenderName = "Parth",
                RecipientName = "Shakeeb",
                Amount = 10.0,
                IsActive = true
            },
            new Contract {
                ContractId = 3,
                SenderName = "Parth",
                RecipientName = "Dan",
                Amount = 82.0,
                IsActive = false
            }
        };
    }

    public static List<Contract> GetAllContracts() => Contracts;

    public static Contract? GetContractById(int id) => Contracts.FirstOrDefault(p => p.ContractId == id);

    public static void AddContract(Contract contract)
    {
        contract.ContractId = nextId++;
        Contracts.Add(contract);
    }

    public static void DeleteContract(int id)
    {
        var contract = GetContractById(id);
        if (contract is null) return;
        Contracts.Remove(contract);
    }

    public static void UpdateContract(Contract contract)
    {
        var index = Contracts.FindIndex(p => p.ContractId == contract.ContractId);
        if (index == -1) return;
        Contracts[index] = contract;
    }
}
