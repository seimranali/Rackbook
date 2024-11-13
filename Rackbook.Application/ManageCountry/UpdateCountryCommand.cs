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
    public class UpdateCountryCommand : IRequest<GenericResult<Country>>
    {
        public Country model { get; set; }

        private class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand, GenericResult<Country>>
        {
            private readonly ICountryRepository _country;
            public UpdateCountryCommandHandler(ICountryRepository country)
            {
                this._country = country;
            }
            public async Task<GenericResult<Country>> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
            {
                GenericResult<Country> Result = new GenericResult<Country>();
                try
                {
                    if (request.model is null)
                    {
                        Result.Status = false;
                        Result.Message = "Bad request.";
                    }
                    else
                    {
                        var _Result = await this._country.UpdateAsync(request.model);
                        if (_Result is not null)
                        {
                            Result.Data = _Result;
                            Result.Status = true;
                            Result.Message = $"{_Result.CountryName} has updated successfully.";
                        }
                        else
                        {
                            Result.Status = false;
                            Result.Message = $"An error occurred while update record.";
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
