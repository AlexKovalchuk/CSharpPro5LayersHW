using Animals.Application.Domain.Owners.Commands.CreateOwner;
using Animals.Application.Domain.Owners.Commands.DeleteOwner;
using Animals.Application.Domain.Owners.Queries.GetOwners;
using Animals.Application.Domain.Owners.Queries.GetOwnersDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Animals.Api.Constants;
using Animals.Api.Domain.Owners.Requests;
using Animals.Application.Domain.Owners.Commands.UpdateOwner;

namespace Animals.Api.Domain.Owners;

[Route(Routes.Owners)]
public class OwnersController(
    IMediator mediator) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<IEnumerable<OwnerDto>>> GetOwners(
        [FromQuery][Required] int page = 1,
        [FromQuery][Required] int pageSize = 10)
    {
        var owners = await mediator.Send(new GetOwnersQuery(page, pageSize));
        return Ok(owners);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OwnerDetailsDto>> GetOwner(Guid id)
    {
        var owner = await mediator.Send(new GetOwnersDetailsQuery(id));
        return Ok(owner);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateOwner(CreateOwnerRequest request)
    {
        var command = new CreateOwnerCommand(
            request.FirstName,
            request.FirstName, 
            request.MiddleName,
            request.Email, 
            request.PhoneNumber);

        var ownerId = await mediator.Send(command);
        return Ok(ownerId);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Guid>> UpdateOwner(
        Guid id,
        UpdateOwnerRequest request)
    {
        var command = new UpdateOwnerCommand(
            id,
            request.FirstName,
            request.LastName,
            request.MiddleName,
            request.Email,
            request.PhoneNumber);
        await mediator.Send(command);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteOwner(Guid id)
    {
        await mediator.Send(new DeleteOwnerCommand(id));
        return Ok();
    }
}