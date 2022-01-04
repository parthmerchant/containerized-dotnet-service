using dotnet_webapi.Models;
using dotnet_webapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class ContractController : ControllerBase
{
    public ContractController()
    {
    }

    [HttpGet]
    public ActionResult<List<Contract>> GetAllContracts() =>
        ContractService.GetAllContracts();

    [HttpGet("{id}")]
    public ActionResult<Contract> GetContractById(int id)
    {
        var contract = ContractService.GetContractById(id);

        if (contract == null) return NotFound();

        return contract;
    }

    [HttpPost]
    public IActionResult CreateContract(Contract contract)
    {
        ContractService.AddContract(contract);

        return CreatedAtAction(nameof(CreateContract), new { id = contract.ContractId }, contract);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateContract(int id, Contract contract)
    {
        if (id != contract.ContractId) return BadRequest();

        var existingContract = ContractService.GetContractById(id);

        if (existingContract is null) return NotFound();

        ContractService.UpdateContract(contract);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteContract(int id)
    {
        var contract = ContractService.GetContractById(id);

        if (contract is null) return NotFound();

        ContractService.DeleteContract(id);

        return NoContent();
    }
}
