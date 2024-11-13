using MediatR;
using Rackbook.Domain.Entities;
using Rackbook.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Application.ManageCountry
{
    public class DeleteCountryCommand : IRequest<GenericResult<Country>>
    {
        public int Id { get; set; }

        private class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand, GenericResult<Country>>
        {
            private readonly ICountryRepository _country;
            public DeleteCountryCommandHandler(ICountryRepository country)
            {
                this._country = country;
            }
            public async Task<GenericResult<Country>> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
            {
                GenericResult<Country> Result = new GenericResult<Country>();
                try
                {
                    if (request.Id <= 0)
                    {
                        Result.Status = false;
                        Result.Message = "Bad request.";
                    }
                    else
                    {
                        var _Result = await this._country.DeleteAsync(request.Id);
                        if (_Result is not null)
                        {
                            Result.Data = _Result;
                            Result.Status = true;
                            Result.Message = $"{_Result.CountryName} has deleted successfully.";
                        }
                        else
                        {
                            Result.Status = false;
                            Result.Message = $"An error occurred while delete record.";
                        }
                    }

                    return Result;
                }
                catch (Exception ex)
                {
                    Result.Status = false;
                    Result.Message = ex.Message;
                    return Result;
                }
            }
        }
    }
}
